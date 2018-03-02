using Newtonsoft.Json;
using Ovow.Framework.Sprites;
using Ovow.Tools.Common.Workspaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public class SsiWorkspace : Workspace<SsiProject>
    {
        private SpriteSheet spriteSheet;

        protected override string WorkspaceFileDescription => "Ovow Sprite Sheet Inspector Project";

        protected override string WorkspaceFileExtension => "ssi";

        protected override SsiProject Create()
        {
            using (var openFileDialog = new OpenFileDialog {
                    Filter = "Sprite Sheet Image Files (*.png)|*.png",
                    DefaultExt = "png",
                    AddExtension = true,
                    Title = "Open Sprite Sheet Image"
                })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.LoadSpriteSheetFromFile(openFileDialog.FileName);
                    return new SsiProject(openFileDialog.FileName);
                }
                else
                {
                    return null;
                }
            }
        }

        public event EventHandler SpriteSheetBackgroundColorChanged;

        public SpriteSheet SpriteSheet
            => spriteSheet;

        protected override SsiProject OpenFromFile(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var project = JsonConvert.DeserializeObject<SsiProject>(json);
            this.LoadSpriteSheetFromFile(project.SpriteSheetFileName);
            return project;
        }

        protected override void SaveToFile(SsiProject model, string fileName)
        {
            var json = JsonConvert.SerializeObject(model);
            File.WriteAllText(fileName, json);
        }

        protected override void OnWorkspaceClosed(EventArgs e)
        {
            base.OnWorkspaceClosed(e);
            if (this.spriteSheet != null)
            {
                this.spriteSheet.PropertyChanged -= SpriteSheet_PropertyChanged;
                this.spriteSheet.Dispose();
                this.spriteSheet = null;
            }
        }

        private void LoadSpriteSheetFromFile(string fileName)
        {
            this.spriteSheet = SpriteSheet.CreateFromFile(fileName);
            this.spriteSheet.PropertyChanged += SpriteSheet_PropertyChanged;
        }

        private void OnSpriteSheetBackgroundColorChanged(EventArgs e)
        {
            this.SpriteSheetBackgroundColorChanged?.Invoke(this, e);
        }

        private void SpriteSheet_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("BackgroundColor"))
            {
                this.OnSpriteSheetBackgroundColorChanged(EventArgs.Empty);
            }
        }
    }
}
