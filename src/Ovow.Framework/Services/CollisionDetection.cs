using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using Ovow.Framework.Messaging.GeneralMessages;

namespace Ovow.Framework.Services
{
    public sealed class CollisionDetection : GameService
    {
        private static readonly CollisionDetector detector = new CollisionDetector();

        public CollisionDetection(IOvowGame game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            var list = this.Game.OvowGameComponents.ToList();
            var aArray = new IVisibleComponent[list.Count];
            var bArray = new IVisibleComponent[list.Count];
            foreach( var elementA in aArray)
            {
                foreach(var elementB in bArray)
                {
                    if (elementA.Equals(elementB))
                    {
                        continue;
                    }

                    if (detector.Collides(elementA, elementB, true))
                    {
                        this.Game.MessageDispatcher.DispatchMessage(new CollisionDetectedMessage(elementA, elementB));
                    }
                }
            }
        }

        internal sealed class CollisionDetector
        {
            public CollisionDetector()
            { }

            public bool Collides(IVisibleComponent a, IVisibleComponent b, bool byPixel = false)
            {
                var widthMe = a.Texture.Width;
                var heightMe = a.Texture.Height;
                var widthOther = b.Texture.Width;
                var heightOther = b.Texture.Height;

                if (byPixel &&                                // if we need per pixel
                    ((Math.Min(widthOther, heightOther) > 100) ||  // at least avoid doing it
                    (Math.Min(widthMe, heightMe) > 100)))          // for small sizes (nobody will notice :P)
                {
                    return a.BoundingBox.Intersects(b.BoundingBox) // If simple intersection fails, don't even bother with per-pixel
                        && PerPixelCollision(a, b);
                }

                return a.BoundingBox.Intersects(b.BoundingBox);
            }

            private static bool PerPixelCollision(IVisibleComponent a, IVisibleComponent b)
            {
                // Get Color data of each Texture
                Color[] bitsA = new Color[a.Texture.Width * a.Texture.Height];
                a.Texture.GetData(bitsA);
                Color[] bitsB = new Color[b.Texture.Width * b.Texture.Height];
                b.Texture.GetData(bitsB);

                // Calculate the intersecting rectangle
                int x1 = Math.Max(a.Texture.Bounds.X, b.Texture.Bounds.X);
                int x2 = Math.Min(a.Texture.Bounds.X + a.Texture.Bounds.Width, b.Texture.Bounds.X + b.Texture.Bounds.Width);

                int y1 = Math.Max(a.Texture.Bounds.Y, b.Texture.Bounds.Y);
                int y2 = Math.Min(a.Texture.Bounds.Y + a.Texture.Bounds.Height, b.Texture.Bounds.Y + b.Texture.Bounds.Height);

                // For each single pixel in the intersecting rectangle
                for (int y = y1; y < y2; ++y)
                {
                    for (int x = x1; x < x2; ++x)
                    {
                        // Get the color from each texture
                        Color ca = bitsA[(x - a.Texture.Bounds.X) + (y - a.Texture.Bounds.Y) * a.Texture.Width];
                        Color cb = bitsB[(x - b.Texture.Bounds.X) + (y - b.Texture.Bounds.Y) * b.Texture.Width];

                        if (ca.A != 0 && cb.A != 0) // If both colors are not transparent (the alpha channel is not 0), then there is a collision
                        {
                            return true;
                        }
                    }
                }
                // If no collision occurred by now, we're clear.
                return false;
            }
        }
    }
}
