using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;

namespace Ovow.Framework.Services
{
    public sealed class CollisionDetection : IGameService
    {
        private readonly IOvowGame game;
        private static readonly CollisionDetector detector = new CollisionDetector();

        public CollisionDetection(IOvowGame game)
        {
            this.game = game;
        }

        public IOvowGame Game => this.game;

        public void Update(GameTime gameTime)
        {
            var list = this.game.OvowGameComponents.ToList();
            var aArray = new IVisibleComponent[list.Count];
            var bArray = new IVisibleComponent[list.Count];
            foreach( var elementA in aArray)
            {
                foreach(var elementB in bArray)
                {
                    // TODO: 
                    if (elementB == elementA)
                    if (detector.Collides(elementA, elementB, true))
                    {

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

                var aBounds = new Rectangle((int)a.Position.X, (int)a.Position.Y, a.Texture.Width, a.Texture.Height);
                var bBounds = new Rectangle((int)b.Position.X, (int)b.Position.Y, b.Texture.Width, b.Texture.Height);

                if (byPixel &&                                // if we need per pixel
                    ((Math.Min(widthOther, heightOther) > 100) ||  // at least avoid doing it
                    (Math.Min(widthMe, heightMe) > 100)))          // for small sizes (nobody will notice :P)
                {
                    return aBounds.Intersects(bBounds) // If simple intersection fails, don't even bother with per-pixel
                        && PerPixelCollision(a, b);
                }

                return aBounds.Intersects(bBounds);
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
