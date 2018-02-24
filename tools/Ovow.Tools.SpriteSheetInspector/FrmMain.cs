using Ovow.Framework.Sprites;
using Ovow.Tools.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovow.Tools.SpriteSheetInspector
{
    public partial class FrmMain : Form
    {
        private SpriteSheet spriteSheet;
        private List<PictureBox> spriteBoundingBoxes = new List<PictureBox>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void LoadSpriteSheet(string fileName)
        {
            UnloadSpriteSheet();
            this.spriteSheet = SpriteSheet.CreateFromFile(fileName);
            this.spriteSheet.PropertyChanged += SpriteSheet_PropertyChanged;
            this.pictureBox.Image = this.spriteSheet.Bitmap;

            this.RecreateSpriteBoundingBoxes();

            this.propertyGrid.SelectedObject = this.spriteSheet;
        }

        private void ClearSpriteBoundingBoxes()
        {
            if (this.spriteBoundingBoxes.Count > 0)
            {
                foreach(var bb in this.spriteBoundingBoxes)
                {
                    bb.Controls.Find("lbl", true).ToList().ForEach(c => c.Dispose());
                    bb.Controls.Clear();
                    bb.Dispose();
                }

                this.pictureBox.Controls.Clear();
                this.spriteBoundingBoxes.Clear();
            }
        }

        private void RecreateSpriteBoundingBoxes()
        {
            using (new LengthyOperation(this))
            {
                this.ClearSpriteBoundingBoxes();
                foreach (var bb in this.spriteSheet.SpriteBoundingBoxes)
                {
                    var boundingBox = CreateBoundingBox(bb.Key, bb.Value.Item2.X - bb.Value.Item1.X, bb.Value.Item2.Y - bb.Value.Item1.Y);
                    boundingBox.Location = new Point(bb.Value.Item1.X, bb.Value.Item1.Y);
                    this.pictureBox.Controls.Add(boundingBox);
                }
            }
        }

        private void UnloadSpriteSheet()
        {
            using (new LengthyOperation(this))
            {
                this.pictureBox.Image = null;
                if (this.spriteSheet != null)
                {
                    this.spriteSheet.PropertyChanged -= SpriteSheet_PropertyChanged;
                    this.spriteSheet.Dispose();
                    this.spriteSheet = null;
                }

                this.propertyGrid.SelectedObject = null;
                this.ClearSpriteBoundingBoxes();
            }
        }

        private void SpriteSheet_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("BackgroundColor"))
            {
                this.RecreateSpriteBoundingBoxes();
            }
        }

        private PictureBox CreateBoundingBox(int index, int width, int height)
        {
            var pb = new PictureBox();
            pb.BackColor = Color.Transparent;
            pb.Width = width;
            pb.Height = height;
            pb.BorderStyle = BorderStyle.FixedSingle;

            var label = new Label();
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = index.ToString();
            label.Font = new Font(FontFamily.GenericSerif, 8.0F);
            label.BackColor = Color.Gray;
            label.ForeColor = Color.White;
            label.AutoSize = true;
            label.Location = new Point(0, 0);
            label.Name = "lbl";

            pb.Controls.Add(label);
            pb.Tag = index;

            this.spriteBoundingBoxes.Add(pb);

            return pb;
        }

        private void Action_OpenSpriteSheetImage(object sender, EventArgs e)
        {
            if (openSpriteSheetImageDialog.ShowDialog() == DialogResult.OK)
            {
                LoadSpriteSheet(openSpriteSheetImageDialog.FileName);
            }
        }

        private void Action_Close(object sender, EventArgs e)
        {
            this.UnloadSpriteSheet();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnloadSpriteSheet();
        }
    }
}
