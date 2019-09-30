using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Sprites
{
    public struct TextRenderingOptions
    {
        public static readonly TextRenderingOptions DefaultOptions = new TextRenderingOptions(false, Color.Black);

        public TextRenderingOptions(bool centerScreen, Color color) : this()
        {
            CenterScreen = centerScreen;
            Color = color;
        }

        public bool CenterScreen { get; }

        public Color Color { get; }
    }
}
