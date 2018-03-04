using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public struct ColorArgb
    {
        public static readonly ColorArgb Empty = new ColorArgb(0, 0, 0, 0);

        public ColorArgb(int a, int r, int g, int b)
            :this()
        {
            this.A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public int A { get; set; }

        public int R { get; set; }

        public int G { get; set; }

        public int B { get; set; }

        public static ColorArgb FromColor(Color color)
        {
            return new ColorArgb(color.A, color.R, color.G, color.B);
        }

        public Color ToColor()
        {
            return Color.FromArgb(A, R, G, B);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            try
            {
                var other = (ColorArgb)obj;
                return A.Equals(other.A) &&
                    R.Equals(other.R) &&
                    G.Equals(other.G) &&
                    B.Equals(other.B);
            }
            catch
            {
                return false;
            }
        }
    }
}
