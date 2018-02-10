using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class JumpingSprite : Sprite
    {

        public JumpingSprite(IOvowGame game, Texture2D texture, Vector2 position, int dx, int dy) : base(game, texture, position)
        {
            this.DX = dx;
            this.DY = dy;
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
    }
}
