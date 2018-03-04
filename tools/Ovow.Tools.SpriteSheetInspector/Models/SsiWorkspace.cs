// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Copyright (C) 2018 by daxnet.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------

using Newtonsoft.Json;
using Ovow.Framework.Sprites;
using Ovow.Tools.Common.Workspaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
            using (var openFileDialog = new OpenFileDialog
            {
                Filter = "Sprite Sheet Image Files (*.png)|*.png",
                DefaultExt = "png",
                AddExtension = true,
                Title = "Open Sprite Sheet Image"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var project = new SsiProject(openFileDialog.FileName);
                    return project;
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
            // this.LoadSpriteSheetFromFile(project.SpriteSheetFileName, project.BackgroundColor.ToColor());
            return project;
        }

        protected override void SaveToFile(SsiProject model, string fileName)
        {
            if (model.BackgroundColor.Equals(ColorArgb.FromColor(Color.Transparent)))
            {
                model.BackgroundColor = ColorArgb.Empty;
            }

            var json = JsonConvert.SerializeObject(model);
            File.WriteAllText(fileName, json);
        }

        protected override void OnWorkspaceOpened(WorkspaceOpenedEventArgs<SsiProject> e)
        {
            this.LoadSpriteSheetFromFile(e.Model.SpriteSheetFileName, e.Model.BackgroundColor.ToColor());

            base.OnWorkspaceOpened(e);
        }

        protected override void OnWorkspaceCreated(WorkspaceCreatedEventArgs<SsiProject> e)
        {
            this.LoadSpriteSheetFromFile(e.Model.SpriteSheetFileName);
            base.OnWorkspaceCreated(e);
        }

        protected override void OnWorkspaceClosed(EventArgs e)
        {
            if (this.spriteSheet != null)
            {
                this.spriteSheet.PropertyChanged -= SpriteSheet_PropertyChanged;
                this.spriteSheet.Dispose();
                this.spriteSheet = null;
            }

            base.OnWorkspaceClosed(e);
        }

        private void LoadSpriteSheetFromFile(string fileName, Color backgroundColor = default(Color))
        {
            this.spriteSheet = SpriteSheet.CreateFromFile(fileName, backgroundColor);

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
                this.Model.BackgroundColor = ColorArgb.FromColor(this.spriteSheet.BackgroundColor);
            }
        }
    }
}