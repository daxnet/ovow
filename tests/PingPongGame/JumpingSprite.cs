using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework;
using Ovow.Framework.Messaging.GeneralMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGame
{
    public class JumpingSprite : Sprite
    {

        public JumpingSprite(IOvowGame game, Texture2D texture, Vector2 position, int dx, int dy) : base(game, texture, position)
        {
            this.DX = dx;
            this.DY = dy;

            Subscribe<ReachBoundaryMessage>((publisher, message) =>
            {
                if (publisher == this)
                {
                    if ((message.ReachedBoundary & Boundary.Left) == Boundary.Left ||
                    (message.ReachedBoundary & Boundary.Right) == Boundary.Right)
                    {
                        DX *= -1;
                    }

                    if ((message.ReachedBoundary & Boundary.Top) == Boundary.Top ||
                    (message.ReachedBoundary & Boundary.Bottom) == Boundary.Bottom)
                    {
                        DY *= -1;
                    }
                }
            });

            Subscribe<CollisionDetectedMessage>((publisher, message) =>
            {
                if (message.A.Equals(this))
                {
                    var selfOrientation = Orientation;
                    var collisionOrientation = message.CollisionInformationA.Orientation;
                    if ((selfOrientation & collisionOrientation & Orientation.East) == Orientation.East ||
                        (selfOrientation & collisionOrientation & Orientation.West) == Orientation.West)
                    {
                        DX *= -1;
                    }

                    if ((selfOrientation & collisionOrientation & Orientation.North) == Orientation.North ||
                        (selfOrientation & collisionOrientation & Orientation.South) == Orientation.South)
                    {
                        DY *= -1;
                    }
                }
            });
        }

        public int DX { get; set; }

        public int DY { get; set; }

        public Orientation Orientation
        {
            get
            {
                if (DX ==0 && DY == 0)
                {
                    return Orientation.NotDefined;
                }
                if (DX == 0)
                {
                    return DY > 0 ? Orientation.South : Orientation.North;
                }
                if (DY == 0)
                {
                    return DX > 0 ? Orientation.East : Orientation.West;
                }

                var orientation = Orientation.NotDefined;
                if (DX < 0)
                {
                    orientation |= Orientation.West;
                }
                else
                {
                    orientation |= Orientation.East;
                }

                if (DY < 0)
                {
                    orientation |= Orientation.North;
                }
                else
                {
                    orientation |= Orientation.South;
                }

                return orientation;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (this.X + this.DX <= 0 || this.X + this.DX >= game.GraphicsDevice.Viewport.Width - this.Width)
            {
                this.DX *= -1;
            }

            if (this.Y + this.DY <= 0 || this.Y + this.DY >= game.GraphicsDevice.Viewport.Height - this.Height)
            {
                this.DY *= -1;
            }

            this.X += this.DX;
            this.Y += this.DY;

            base.Update(gameTime);
        }
    }
}
