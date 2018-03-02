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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovow.Tools.SpriteSheetInspector
{
    public partial class FrmMain : Form
    {
        private readonly SsiWorkspace workspace = new SsiWorkspace();
        private List<BorderedPictureBox> spritePictureBoxes = new List<BorderedPictureBox>();
        private TreeNode rootNode;
        private TreeNode spritesNode;
        private TreeNode actionsNode;
        private List<Image> animationImages = new List<Image>();

        private delegate void SetAnimationPictureDelegate(Image picture);
        private delegate int GetFPSValueDelegate();
        private delegate void SetControlButtonStatusDelegate(bool playing);

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

            mnuSaveProject.Enabled = false;
            tbtnSaveProject.Enabled = false;
            this.mnuCloseProject.Enabled = false;
        }

        private void Workspace_WorkspaceClosed(object sender, EventArgs e)
        {
            this.pictureBox.Image = null;
            this.propertyGrid.SelectedObject = null;
            this.ClearSpriteBoundingBoxes();
            this.tv.Nodes.Clear();

            this.backgroundWorker1.CancelAsync();

            this.pbAnimation.Image = null;

            foreach (var image in this.animationImages)
            {
                image?.Dispose();
            }

            this.animationImages.Clear();

            this.btnAnimate.Enabled = false;
            this.tbFPS.Enabled = false;
            this.mnuCloseProject.Enabled = false;
            this.mnuSaveProject.Enabled = false;
            this.tbtnSaveProject.Enabled = false;
        }

        private void Workspace_WorkspaceCreated(object sender, WorkspaceCreatedEventArgs<SsiProject> e)
        {
            this.pictureBox.Image = workspace.SpriteSheet.Bitmap;
            this.RecreateSpriteBoundingBoxes();
            this.propertyGrid.SelectedObject = workspace.SpriteSheet;
            this.mnuCloseProject.Enabled = true;
        }

        private void Workspace_WorkspaceSaved(object sender, WorkspaceSavedEventArgs e)
        {
            mnuSaveProject.Enabled = false;
            tbtnSaveProject.Enabled = false;
        }

        private void Workspace_WorkspaceOpened(object sender, WorkspaceOpenedEventArgs e)
        {
            this.pictureBox.Image = workspace.SpriteSheet.Bitmap;
            this.RecreateSpriteBoundingBoxes();
            this.propertyGrid.SelectedObject = workspace.SpriteSheet;
            this.mnuCloseProject.Enabled = true;
        }

        private void Workspace_WorkspaceChanged(object sender, EventArgs e)
        {
            mnuSaveProject.Enabled = true;
            tbtnSaveProject.Enabled = true;
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
                this.spritesNode = this.rootNode.Nodes.Add("Sprites");
                this.spritesNode.ImageKey = this.spritesNode.SelectedImageKey = this.spritesNode.StateImageKey = "sprites";
                this.actionsNode = this.rootNode.Nodes.Add("Actions");
                this.actionsNode.ImageKey = this.actionsNode.SelectedImageKey = this.actionsNode.StateImageKey = "actions";

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

                    var boundingBox = CreateBoundingBox(bb.Key, width, height);
                    boundingBox.Location = new Point(x, y);
                    this.pictureBox.Controls.Add(boundingBox);

                    var spriteNode = spritesNode.Nodes.Add($"{bb.Key} ([{x},{y}] - [{x + width},{y + height}])");
                    spriteNode.ImageKey = spriteNode.SelectedImageKey = spriteNode.StateImageKey = $"Sprite_{bb.Key}";
                    spriteNode.Tag = bb;
                }

                tv.ExpandAll();
            }
        }

        private PictureBox CreateBoundingBox(int index, int width, int height)
        {
            var borderColor = Color.Black;
            if (this.workspace.SpriteSheet.BackgroundColor == Color.Transparent || this.workspace.SpriteSheet.BackgroundColor == default(Color))
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
                  foreach (TreeNode node in tv.Nodes[0].Nodes[0].Nodes)
                  {
                      var kvp = (KeyValuePair<int, Rectangle>)node.Tag;
                      if (kvp.Key == idx)
                      {
                          tv.SelectedNode = node;
                          tv.ExpandAll();
                      }
                  }

                  if (mcEventArgs.Button == MouseButtons.Right)
                  {

                  }
              };

            this.spritePictureBoxes.Add(pb);

            return pb;
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

        private void InvalidatePanel()
        {
            pictureBox.Invalidate();
            foreach (Control control in pictureBox.Controls)
            {
                control.Invalidate();
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

        private void StartAnimation()
        {
            animationImages.Clear();
            foreach (TreeNode actionSpriteNode in tv.SelectedNode.Nodes)
            {
                var boundingBox = (KeyValuePair<int, Rectangle>)actionSpriteNode.Tag;
                var spritePicture = new Bitmap(boundingBox.Value.Width, boundingBox.Value.Height);
                using (var graphics = Graphics.FromImage(spritePicture))
                {
                    graphics.DrawImage(this.workspace.SpriteSheet.Bitmap,
                        new Rectangle(0, 0, boundingBox.Value.Width, boundingBox.Value.Height),
                        boundingBox.Value,
                        GraphicsUnit.Pixel);
                }

                animationImages.Add(spritePicture);
            }

            this.SetControlButtonStatus(true);
            backgroundWorker1.RunWorkerAsync();
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
                    btnAnimate.Image = Resources.pause;
                }
                else
                {
                    btnAnimate.Image = Resources.play;
                }
            }
        }

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

        #region Action Methods

        private void Action_NewProject(object sender, EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                if (this.workspace.Close())
                {
                    this.workspace.New();
                }
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

        private void Action_CloseProject(object sender, EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                this.workspace.Close();
            }
        }
        #endregion

        private void Action_NewAction(object sender, EventArgs e)
        {

            using (var dlg = new FrmTextInput("Action Name:", AllActionNames))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    actionsNode.Nodes.Add(dlg.InputText.Trim(), dlg.InputText.Trim(), "action", "action");

                    actionsNode.Expand();
                }
            }
        }

        private void Action_MoveActionSpriteUp(object sender, EventArgs e)
        {
            tv.SelectedNode.MoveUp();
        }

        private void Action_MoveActionSpriteTop(object sender, EventArgs e)
        {
            tv.SelectedNode.MoveTop();
        }

        private void Action_MoveActionSpriteDown(object sender, EventArgs e)
        {
            tv.SelectedNode.MoveDown();
        }

        private void Action_MoveActionSpriteBottom(object sender, EventArgs e)
        {
            tv.SelectedNode.MoveBottom();
        }

        private void Action_DeleteActionSpriteNode(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the selected sprite?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                tv.SelectedNode.RemoveEx();
            }
        }

        private void Action_Animate(object sender, EventArgs e)
        {
            this.StartAnimation();
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node != null)
            {
                if (node.Tag is KeyValuePair<int, Rectangle> boundingBox)
                {
                    this.SelectSpriteOnSheet(boundingBox.Key);
                }
                else
                {
                    this.SelectSpriteOnSheet(-1);
                }

                if (node.Parent == actionsNode)
                {
                    btnAnimate.Enabled = true;
                    tbFPS.Enabled = true;
                }
                else
                {
                    btnAnimate.Enabled = false;
                    tbFPS.Enabled = false;
                }
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

        private void tv_MouseClick(object sender, MouseEventArgs e)
        {
            var node = tv.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                tv.SelectedNode = node;
                if (e.Button == MouseButtons.Right)
                {
                    if (node == actionsNode)
                    {
                        cmsActions.Show(tv, e.X, e.Y);
                    }
                    else if (node.Parent == actionsNode)
                    {
                        cmsAction.Show(tv, e.X, e.Y);
                    }
                    else if (node.Parent?.Parent == actionsNode)
                    {
                        cmsActionSprite.Show(tv, e.X, e.Y);
                    }
                }
            }
        }

        private void pnlMain_Scroll(object sender, ScrollEventArgs e)
        {
            this.InvalidatePanel();
        }

        private void tv_DragEnter(object sender, DragEventArgs e)
        {

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
                var toolStripItem = cmnuAddToAction.DropDownItems.Add(actionName, Resources.action, (cmnuSender, cmnuEventArgs) =>
                {
                    var action = ((ToolStripItem)cmnuSender).Tag as string;
                    var actionNode = actionsNode.Nodes.Find(action, true).First();
                    var actionFrameNode = actionNode.Nodes.Add(boundingBoxIndex.ToString());
                    actionFrameNode.Tag = workspace.SpriteSheet.SpriteBoundingBoxes.First(x => x.Key == boundingBoxIndex);
                    actionFrameNode.ImageKey = actionFrameNode.SelectedImageKey = $"Sprite_{boundingBoxIndex}";
                });

                toolStripItem.Tag = actionName;
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var index = 0;
            var total = animationImages.Count;
            while (true)
            {
                if (backgroundWorker1.CancellationPending)
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

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                StartAnimation();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.workspace.Close();
        }
    }
}
