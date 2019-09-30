// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Copyright (C) 2019 by daxnet.
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

using Ovow.Framework;
using Ovow.Framework.Sprites;
using Ovow.Tools.Common;
using Ovow.Tools.Common.Workspaces;
using Ovow.Tools.SpriteSheetInspector.Models;
using Ovow.Tools.SpriteSheetInspector.Properties;
using Ovow.Tools.SpriteSheetInspector.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Ovow.Tools.SpriteSheetInspector
{
    public partial class FrmMain : Form
    {
        private readonly List<Image> animationImages = new List<Image>();
        private readonly List<BorderedPictureBox> spritePictureBoxes = new List<BorderedPictureBox>();
        private readonly SsiWorkspace workspace = new SsiWorkspace();
        private TreeNode actionsNode;
        private TreeNode rootNode;
        private TreeNode spritesNode;
        public FrmMain()
        {
            InitializeComponent();

            workspace.WorkspaceCreated += Workspace_WorkspaceCreated;
            workspace.WorkspaceChanged += Workspace_WorkspaceChanged;
            workspace.WorkspaceOpened += Workspace_WorkspaceOpened;
            workspace.WorkspaceSaved += Workspace_WorkspaceSaved;
            workspace.WorkspaceClosed += Workspace_WorkspaceClosed;

            workspace.SpriteSheetBackgroundColorChanged += (ssbccSender, ssbccEventArgs) =>
              {
                  RecreateSpriteBoundingBoxes();
              };

            this.pnlMain.MouseWheel += (s, e) => InvalidatePanel();
            typeof(Control)
                .GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(this.pictureBox, true);

            this.SetControlButtonStatus(false);
            this.btnAnimate.Enabled = false;
            this.tbFPS.Enabled = false;
            this.cbAnimationActions.Enabled = false;

            mnuSaveProject.Enabled = false;
            tbtnSaveProject.Enabled = false;
            this.mnuCloseProject.Enabled = false;
        }

        private delegate int GetFPSValueDelegate();

        private delegate void SetAnimationPictureDelegate(Image picture);
        private delegate void SetControlButtonStatusDelegate(bool playing);
        private IEnumerable<string> AllActionNames
        {
            get
            {
                foreach (TreeNode node in actionsNode.Nodes)
                {
                    yield return node.Text;
                }
            }
        }

        private void Action_Animate(object sender, EventArgs e)
        {
            this.StartAnimation();
        }

        private void Action_CloseProject(object sender, EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                this.workspace.Close();
            }
        }

        private void Action_DeleteActionFrameNode(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the selected sprite?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var actionFrameNode = tv.SelectedNode;
                var actionNode = actionFrameNode.Parent;
                var actionFrameIndex = ((KeyValuePair<int, Rectangle>)(((TreeNodePayload)actionFrameNode.Tag).Data)).Key;
                var actionName = actionNode.Text;
                var action = this.workspace
                    .Model
                    .GetAction(actionName);

                action.RemoveFrame(actionFrameIndex);
                if (cbAnimationActions.Items.Count > 0 && ((SsiAction)cbAnimationActions.SelectedItem).Name.Equals(actionName))
                {
                    this.BindAnimationForAction(action);
                }

                tv.SelectedNode.RemoveEx();
            }
        }

        private void Action_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Action_Export(object sender, EventArgs e)
        {
            var definition = new AnimatedSpriteDefinition();
            foreach (TreeNode actionNode in actionsNode.Nodes)
            {
                var actionName = actionNode.Text;
                var actionDefinition = new AnimatedSpriteActionDefinition { Name = actionName };
                foreach (TreeNode actionFrameNode in actionNode.Nodes)
                {
                    var actionFrameIndex = ((KeyValuePair<int, Rectangle>)(((TreeNodePayload)actionFrameNode.Tag).Data)).Key;
                    var actionFrameBoundingBox = ((KeyValuePair<int, Rectangle>)(((TreeNodePayload)actionFrameNode.Tag).Data)).Value;
                    var actionFrameDefinition = new AnimatedSpriteActionFrameDefinition
                    {
                        X = actionFrameBoundingBox.X,
                        Y = actionFrameBoundingBox.Y,
                        Width = actionFrameBoundingBox.Width,
                        Height = actionFrameBoundingBox.Height
                    };
                    actionDefinition.Frames.Add(actionFrameDefinition);
                }
                definition.Actions.Add(actionDefinition);
            }

            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream  = new FileStream(exportDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    AnimatedSpriteDefinition.Save(fileStream, definition);
                }
            }
        }

        private void Action_MoveActionFrameBottom(object sender, EventArgs e)
        {
            var actionFrameNode = tv.SelectedNode;
            var actionName = actionFrameNode.Parent.Text;
            var actionFrameBoundingBoxIndex = ((KeyValuePair<int, Rectangle>)((TreeNodePayload)actionFrameNode.Tag).Data).Key;
            var action = this.workspace.Model.GetAction(actionName);
            action.MoveFrameBottom(actionFrameBoundingBoxIndex);
            actionFrameNode.MoveBottom();
            this.BindAnimationForAction(action);
        }

        private void Action_MoveActionFrameDown(object sender, EventArgs e)
        {
            var actionFrameNode = tv.SelectedNode;
            var actionName = actionFrameNode.Parent.Text;
            var actionFrameBoundingBoxIndex = ((KeyValuePair<int, Rectangle>)((TreeNodePayload)actionFrameNode.Tag).Data).Key;
            var action = this.workspace.Model.GetAction(actionName);
            action.MoveFrameDown(actionFrameBoundingBoxIndex);
            actionFrameNode.MoveDown();
            this.BindAnimationForAction(action);
        }

        private void Action_MoveActionFrameTop(object sender, EventArgs e)
        {
            var actionFrameNode = tv.SelectedNode;
            var actionName = actionFrameNode.Parent.Text;
            var actionFrameBoundingBoxIndex = ((KeyValuePair<int, Rectangle>)((TreeNodePayload)actionFrameNode.Tag).Data).Key;
            var action = this.workspace.Model.GetAction(actionName);
            action.MoveFrameTop(actionFrameBoundingBoxIndex);
            actionFrameNode.MoveTop();
            this.BindAnimationForAction(action);
        }

        private void Action_MoveActionFrameUp(object sender, EventArgs e)
        {
            var actionFrameNode = tv.SelectedNode;
            var actionName = actionFrameNode.Parent.Text;
            var actionFrameBoundingBoxIndex = ((KeyValuePair<int, Rectangle>)((TreeNodePayload)actionFrameNode.Tag).Data).Key;
            var action = this.workspace.Model.GetAction(actionName);
            action.MoveFrameUp(actionFrameBoundingBoxIndex);
            actionFrameNode.MoveUp();
            this.BindAnimationForAction(action);
        }

        private void Action_NewAction(object sender, EventArgs e)
        {
            using (var dlg = new FrmTextInput("Action Name:", AllActionNames))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var actionName = dlg.InputText.Trim();
                    var action = new SsiAction(actionName);
                    this.workspace.Model.AddAction(action);

                    this.BindAnimationActions();

                    var actionNode = actionsNode.Nodes.Add(actionName, actionName, "action", "action");
                    actionNode.Tag = new TreeNodePayload(TreeNodeType.Action, actionName);
                    actionsNode.Expand();
                }
            }
        }

        private void Action_NewProject(object sender, EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                //    if (this.workspace.Close())
                //    {
                //        this.workspace.New();
                //    }
                //}
                this.workspace.New();
            }
        }

        private void Action_OpenProject(object sender, EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                this.workspace.Open();
            }
        }

        private void Action_SaveProject(object sender, EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                this.workspace.Save();
            }
        }

        private void animationExecutor_DoWork(object sender, DoWorkEventArgs e)
        {
            var index = 0;
            var total = animationImages.Count;
            while (true)
            {
                if (animationExecutor.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                if (total > 0)
                {
                    SetAnimationPicture(animationImages[index]);
                }

                index++;
                if (index >= total)
                {
                    index = 0;
                }

                var sleep = 1000.0F / GetFPSValue();
                Thread.Sleep(Convert.ToInt32(sleep));
            }

            SetControlButtonStatus(false);
        }

        private void BindAnimationActions()
        {
            cbAnimationActions.Items.Clear();
            if (this.workspace?.Model?.ActionCount > 0)
            {
                foreach (var action in this.workspace?.Model?.Actions)
                {
                    cbAnimationActions.Items.Add(action);
                }

                cbAnimationActions.SelectedItem = this.workspace?.Model?.Actions.FirstOrDefault();
                BindAnimationForAction((SsiAction)cbAnimationActions.SelectedItem);
                btnAnimate.Enabled = true;
                tbFPS.Enabled = true;
                cbAnimationActions.Enabled = true;
            }
            else
            {
                btnAnimate.Enabled = false;
                tbFPS.Enabled = false;
                cbAnimationActions.Enabled = false;
            }
        }

        private void BindAnimationForAction(SsiAction action)
        {
            animationImages.Clear();
            foreach (var actionFrame in action.Frames)
            {
                var spriteFrameImage = new Bitmap(actionFrame.Width, actionFrame.Height);
                using (var graphics = Graphics.FromImage(spriteFrameImage))
                {
                    graphics.DrawImage(this.workspace.SpriteSheet.Bitmap,
                        new Rectangle(0, 0, actionFrame.Width, actionFrame.Height),
                        new Rectangle(actionFrame.X, actionFrame.Y, actionFrame.Width, actionFrame.Height), GraphicsUnit.Pixel);
                }

                animationImages.Add(spriteFrameImage);
            }

            if (animationImages.Count > 0)
            {
                SetAnimationPicture(animationImages[0]);
            }
            else
            {
                SetAnimationPicture(null);
            }
        }

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            if (animationExecutor.IsBusy)
            {
                animationExecutor.CancelAsync();
            }
            else
            {
                StartAnimation();
            }
        }

        private void cbAnimationActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var action = (SsiAction)cbAnimationActions.SelectedItem;
            this.BindAnimationForAction(action);
        }

        private void ClearSpriteBoundingBoxes()
        {
            if (this.spritePictureBoxes.Count > 0)
            {
                foreach (var bb in this.spritePictureBoxes)
                {
                    bb.Controls.Find("lbl", true).ToList().ForEach(c => c.Dispose());
                    bb.Controls.Clear();
                    bb.Dispose();
                }

                this.pictureBox.Controls.Clear();
                this.spritePictureBoxes.Clear();
            }
        }

        private void cmsAction_Opening(object sender, CancelEventArgs e)
        {
            cmnuMoveUp.Enabled =
                        cmnuMoveTop.Enabled =
                        cmnuMoveDown.Enabled =
                        cmnuMoveBottom.Enabled = true;

            var node = tv.GetNodeAt(tv.PointToClient(cmsActionSprite.Bounds.Location));
            if (node != null)
            {
                if (node == node.Parent.Nodes[0])
                {
                    cmnuMoveUp.Enabled = cmnuMoveTop.Enabled = false;
                }
                else if (node == node.Parent.Nodes[node.Parent.Nodes.Count - 1])
                {
                    cmnuMoveDown.Enabled = cmnuMoveBottom.Enabled = false;
                }
            }
        }

        private void cmsBoundingBox_Opening(object sender, CancelEventArgs e)
        {
            if (AllActionNames.Count() == 0)
            {
                cmnuAddToAction.Enabled = false;
                return;
            }

            cmnuAddToAction.Enabled = true;
            cmnuAddToAction.DropDownItems.Clear();

            var ctrl = pictureBox.GetChildAtPoint(pictureBox.PointToClient(cmsBoundingBox.Bounds.Location));
            var boundingBoxIndex = Convert.ToInt32(ctrl.Tag);

            foreach (var actionName in AllActionNames)
            {
                var toolStripItem = cmnuAddToAction.DropDownItems.Add(actionName, Resources.action,
                    (cmnuSender, cmnuEventArgs) =>
                        {
                            var actionNameLocal = ((ToolStripItem)cmnuSender).Tag as string;
                            var actionNode = actionsNode.Nodes.Find(actionNameLocal, true).First();

                            var selectedBoundingBox = workspace.SpriteSheet.SpriteBoundingBoxes.First(x => x.Key == boundingBoxIndex);
                            var action = workspace.Model.GetAction(actionNameLocal);

                            action.AddFrame(new SsiActionFrame
                            {
                                BoundingBoxIndex = boundingBoxIndex,
                                X = selectedBoundingBox.Value.X,
                                Y = selectedBoundingBox.Value.Y,
                                Width = selectedBoundingBox.Value.Width,
                                Height = selectedBoundingBox.Value.Height
                            });

                            if (cbAnimationActions.Items.Count > 0 &&
                            ((SsiAction)cbAnimationActions.SelectedItem).Name.Equals(actionNameLocal))
                            {
                                this.BindAnimationForAction(action);
                            }

                            var actionFrameNode = actionNode.Nodes.Add(boundingBoxIndex.ToString());
                            actionFrameNode.Tag = new TreeNodePayload(TreeNodeType.ActionFrame, selectedBoundingBox);
                            actionFrameNode.ImageKey = actionFrameNode.SelectedImageKey = $"Sprite_{boundingBoxIndex}";
                        });

                toolStripItem.Tag = actionName;
            }
        }

        private PictureBox CreateSpriteBoundingBox(int index, int width, int height)
        {
            var borderColor = Color.Black;
            if (this.workspace.SpriteSheet.BackgroundColor.RgbEquals(Color.Transparent) ||
                this.workspace.SpriteSheet.BackgroundColor.RgbEquals(default(Color)))
            {
                borderColor = SystemColors.Control.Inverse();
            }
            else
            {
                borderColor = this.workspace.SpriteSheet.BackgroundColor.Inverse();
            }

            var pb = new BorderedPictureBox { BorderColor = borderColor };
            pb.BackColor = Color.Transparent;
            pb.Width = width;
            pb.Height = height;
            pb.ContextMenuStrip = cmsBoundingBox;

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
            pb.MouseClick += (mcSender, mcEventArgs) =>
              {
                  var idx = Convert.ToInt32(pb.Tag);
                  this.SelectSpriteOnSheet(idx);
                  foreach (TreeNode node in spritesNode.Nodes)
                  {
                      var kvp = (KeyValuePair<int, Rectangle>)((TreeNodePayload)node.Tag).Data;
                      if (kvp.Key == idx)
                      {
                          tv.SelectedNode = node;
                          tv.ExpandAll();
                      }
                  }
              };

            this.spritePictureBoxes.Add(pb);

            return pb;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.workspace.Close();
        }

        private int GetFPSValue()
        {
            if (tbFPS.InvokeRequired)
            {
                GetFPSValueDelegate d = new GetFPSValueDelegate(GetFPSValue);
                return Convert.ToInt32(this.Invoke(d));
            }
            else
            {
                return tbFPS.Value;
            }
        }

        private void InvalidatePanel()
        {
            pictureBox.Invalidate();
            foreach (Control control in pictureBox.Controls)
            {
                control.Invalidate();
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.SelectSpriteOnSheet(-1);
            tv.SelectedNode = tv.Nodes[0].Nodes[0];
        }

        private void pnlMain_Click(object sender, EventArgs e)
        {
            this.SelectSpriteOnSheet(-1);

            if (tv.Nodes.Count > 0 &&
                tv.Nodes[0].Nodes.Count > 0)
            {
                tv.SelectedNode = tv.Nodes[0].Nodes[0];
            }
        }

        private void pnlMain_Scroll(object sender, ScrollEventArgs e)
        {
            this.InvalidatePanel();
        }

        private void RecreateSpriteBoundingBoxes()
        {
            using (new LengthyOperation(this))
            {
                this.ClearSpriteBoundingBoxes();

                this.imageList1.Images.Clear();
                this.imageList1.Images.Add("root", Resources.root);
                this.imageList1.Images.Add("sprites", Resources.sprites);
                this.imageList1.Images.Add("actions", Resources.actions);
                this.imageList1.Images.Add("action", Resources.action);

                this.tv.Nodes.Clear();
                this.rootNode = this.tv.Nodes.Add(Path.GetFileName(this.workspace.SpriteSheet.FileName));
                this.rootNode.ImageKey = this.rootNode.SelectedImageKey = this.rootNode.StateImageKey = "root";
                this.rootNode.Tag = new TreeNodePayload(TreeNodeType.Root);

                this.spritesNode = this.rootNode.Nodes.Add("Sprites");
                this.spritesNode.ImageKey = this.spritesNode.SelectedImageKey = this.spritesNode.StateImageKey = "sprites";
                this.spritesNode.Tag = new TreeNodePayload(TreeNodeType.SpritesRoot);

                this.actionsNode = this.rootNode.Nodes.Add("Actions");
                this.actionsNode.ImageKey = this.actionsNode.SelectedImageKey = this.actionsNode.StateImageKey = "actions";
                this.actionsNode.Tag = new TreeNodePayload(TreeNodeType.ActionsRoot);

                foreach (var bb in this.workspace.SpriteSheet.SpriteBoundingBoxes)
                {
                    var x = bb.Value.X;
                    var y = bb.Value.Y;
                    var width = bb.Value.Width;
                    var height = bb.Value.Height;

                    var img = new Bitmap(width, height);
                    using (var graphics = Graphics.FromImage(img))
                    {
                        graphics.DrawImage(this.workspace.SpriteSheet.Bitmap, new Rectangle(0, 0, width, height), bb.Value, GraphicsUnit.Pixel);
                    }

                    imageList1.Images.Add($"Sprite_{bb.Key}", img);

                    var boundingBox = CreateSpriteBoundingBox(bb.Key, width, height);
                    boundingBox.Location = new Point(x, y);
                    this.pictureBox.Controls.Add(boundingBox);

                    var spriteNode = spritesNode.Nodes.Add($"{bb.Key} ([{x},{y}] - [{x + width},{y + height}])");
                    spriteNode.ImageKey = spriteNode.SelectedImageKey = spriteNode.StateImageKey = $"Sprite_{bb.Key}";
                    spriteNode.Tag = new TreeNodePayload(TreeNodeType.Sprite, bb);
                }

                foreach (var action in this.workspace?.Model?.Actions)
                {
                    var actionNode = actionsNode.Nodes.Add(action.Name, action.Name, "action", "action");
                    actionNode.Tag = new TreeNodePayload(TreeNodeType.Action, action.Name);

                    foreach (var frame in action.Frames)
                    {
                        var actionFrameNode = actionNode.Nodes.Add(frame.BoundingBoxIndex.ToString());
                        actionFrameNode.Tag = new TreeNodePayload(TreeNodeType.ActionFrame, new KeyValuePair<int, Rectangle>(frame.BoundingBoxIndex, new Rectangle(frame.X, frame.Y, frame.Width, frame.Height)));
                        actionFrameNode.ImageKey = actionFrameNode.SelectedImageKey = $"Sprite_{frame.BoundingBoxIndex}";
                    }
                }

                rootNode.Expand();
                spritesNode.Expand();
                actionsNode.Expand();

                tv.SelectedNode = rootNode;
            }
        }

        private void SelectSpriteOnSheet(int index)
        {
            foreach (var pb in this.spritePictureBoxes)
            {
                if (Convert.ToInt32(pb.Tag) == index)
                {
                    pb.BackColor = Color.FromArgb(128, Color.Black);
                }
                else
                {
                    pb.BackColor = Color.Transparent;
                }
                pb.Refresh();
            }
        }

        private void SetAnimationPicture(Image picture)
        {
            if (pbAnimation.InvokeRequired)
            {
                SetAnimationPictureDelegate d = new SetAnimationPictureDelegate(SetAnimationPicture);
                this.Invoke(d, picture);
            }
            else
            {
                try
                {
                    pbAnimation.Image = picture;
                }
                catch
                {
                    pbAnimation.Image = null;
                }
            }
        }

        private void SetControlButtonStatus(bool playing)
        {
            if (btnAnimate.InvokeRequired)
            {
                SetControlButtonStatusDelegate d = new SetControlButtonStatusDelegate(SetControlButtonStatus);
                this.Invoke(d, playing);
            }
            else
            {
                if (playing)
                {
                    cmnuActionAnimate.Enabled = false;
                    cbAnimationActions.Enabled = false;
                    btnAnimate.Image = Resources.pause;
                }
                else
                {
                    if (animationImages.Count > 0)
                    {
                        SetAnimationPicture(animationImages[0]);
                    }

                    cmnuActionAnimate.Enabled = true;
                    cbAnimationActions.Enabled = true;
                    btnAnimate.Image = Resources.play;
                }
            }
        }

        private void StartAnimation()
        {
            this.SetControlButtonStatus(true);
            animationExecutor.RunWorkerAsync();
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node != null)
            {
                TreeNodePayload payload = (TreeNodePayload)node.Tag;
                switch (payload.Type)
                {
                    case TreeNodeType.Sprite:
                    case TreeNodeType.ActionFrame:
                        var boundingBox = (KeyValuePair<int, Rectangle>)payload.Data;
                        this.SelectSpriteOnSheet(boundingBox.Key);
                        break;

                    default:
                        this.SelectSpriteOnSheet(-1);
                        break;
                }
            }
        }

        private void tv_MouseClick(object sender, MouseEventArgs e)
        {
            var node = tv.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                tv.SelectedNode = node;
                var payload = (TreeNodePayload)node.Tag;
                if (e.Button == MouseButtons.Right)
                {
                    switch (payload.Type)
                    {
                        case TreeNodeType.ActionsRoot:
                            cmsActions.Show(tv, e.X, e.Y);
                            break;

                        case TreeNodeType.Action:
                            cmsAction.Show(tv, e.X, e.Y);
                            break;

                        case TreeNodeType.ActionFrame:
                            cmsActionSprite.Show(tv, e.X, e.Y);
                            break;
                    }
                }
            }
        }

        private void Workspace_WorkspaceChanged(object sender, EventArgs e)
        {
            mnuSaveProject.Enabled = true;
            tbtnSaveProject.Enabled = true;
        }

        private void Workspace_WorkspaceClosed(object sender, EventArgs e)
        {
            this.pictureBox.Image = null;
            this.propertyGrid.SelectedObject = null;
            this.ClearSpriteBoundingBoxes();
            this.tv.Nodes.Clear();

            this.animationExecutor.CancelAsync();

            this.pbAnimation.Image = null;

            foreach (var image in this.animationImages)
            {
                image?.Dispose();
            }

            this.animationImages.Clear();
            this.cbAnimationActions.Items.Clear();

            this.btnAnimate.Enabled = false;
            this.tbFPS.Enabled = false;
            this.mnuCloseProject.Enabled = false;
            this.mnuSaveProject.Enabled = false;
            this.tbtnSaveProject.Enabled = false;
            this.cbAnimationActions.Enabled = false;
        }

        private void Workspace_WorkspaceCreated(object sender, WorkspaceCreatedEventArgs<SsiProject> e)
        {
            this.pictureBox.Image = workspace.SpriteSheet.Bitmap;
            this.RecreateSpriteBoundingBoxes();
            this.propertyGrid.SelectedObject = workspace.SpriteSheet;
            this.mnuCloseProject.Enabled = true;
        }

        private void Workspace_WorkspaceOpened(object sender, WorkspaceOpenedEventArgs<SsiProject> e)
        {
            this.pictureBox.Image = workspace.SpriteSheet.Bitmap;
            this.RecreateSpriteBoundingBoxes();
            this.BindAnimationActions();

            this.propertyGrid.SelectedObject = workspace.SpriteSheet;
            this.mnuCloseProject.Enabled = true;
        }

        private void Workspace_WorkspaceSaved(object sender, WorkspaceSavedEventArgs<SsiProject> e)
        {
            mnuSaveProject.Enabled = false;
            tbtnSaveProject.Enabled = false;
        }
    }
}