using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovow.Tools.SpriteSheetInspector.UserControls
{
    internal sealed class BorderedPictureBox : PictureBox
    {
        public BorderedPictureBox()
        {
            this.BorderColor = Color.Black;
            this.BorderDrawingStyle = ButtonBorderStyle.Solid;
            this.BorderStyle = BorderStyle.None;
            this.DoubleBuffered = true;
        }

        public Color BorderColor { get; set; }

        public ButtonBorderStyle BorderDrawingStyle { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            ControlPaint.DrawBorder(pe.Graphics, pe.ClipRectangle, this.BorderColor, this.BorderDrawingStyle);
        }
    }
}
