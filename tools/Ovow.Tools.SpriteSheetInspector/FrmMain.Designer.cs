namespace Ovow.Tools.SpriteSheetInspector
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tv = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbFPS = new System.Windows.Forms.TrackBar();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.openSpriteSheetImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNewAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.normalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBoundingBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuAddToAction = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsActionSprite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMoveBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDeleteAction = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuActionAnimate = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbAnimation = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.mnuOpenSpriteSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.cmsActions.SuspendLayout();
            this.cmsBoundingBox.SuspendLayout();
            this.cmsActionSprite.SuspendLayout();
            this.cmsAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenSpriteSheet,
            this.mnuClose});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(191, 22);
            this.mnuClose.Text = "Close";
            this.mnuClose.Click += new System.EventHandler(this.Action_Close);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(763, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(763, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(763, 512);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tv);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pbAnimation);
            this.splitContainer3.Panel2.Controls.Add(this.tbFPS);
            this.splitContainer3.Panel2.Controls.Add(this.btnAnimate);
            this.splitContainer3.Size = new System.Drawing.Size(216, 512);
            this.splitContainer3.SplitterDistance = 269;
            this.splitContainer3.TabIndex = 0;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.HideSelection = false;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.imageList1;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(216, 269);
            this.tv.TabIndex = 0;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv_DragEnter);
            this.tv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tv_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbFPS
            // 
            this.tbFPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFPS.Location = new System.Drawing.Point(42, 13);
            this.tbFPS.Maximum = 60;
            this.tbFPS.Minimum = 1;
            this.tbFPS.Name = "tbFPS";
            this.tbFPS.Size = new System.Drawing.Size(162, 45);
            this.tbFPS.TabIndex = 1;
            this.tbFPS.Value = 10;
            // 
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(12, 13);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(24, 24);
            this.btnAnimate.TabIndex = 0;
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer2.Size = new System.Drawing.Size(543, 512);
            this.splitContainer2.SplitterDistance = 348;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.pictureBox);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(348, 512);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlMain_Scroll);
            this.pnlMain.Click += new System.EventHandler(this.pnlMain_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(191, 512);
            this.propertyGrid.TabIndex = 0;
            // 
            // openSpriteSheetImageDialog
            // 
            this.openSpriteSheetImageDialog.DefaultExt = "*.png";
            this.openSpriteSheetImageDialog.Filter = "PNG (*.png)|*.png";
            this.openSpriteSheetImageDialog.Title = "Open Sprite Sheet Image";
            // 
            // cmsActions
            // 
            this.cmsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuNewAction,
            this.toolStripMenuItem1,
            this.normalizeToolStripMenuItem});
            this.cmsActions.Name = "cmsActions";
            this.cmsActions.Size = new System.Drawing.Size(146, 54);
            // 
            // cmnuNewAction
            // 
            this.cmnuNewAction.Name = "cmnuNewAction";
            this.cmnuNewAction.Size = new System.Drawing.Size(145, 22);
            this.cmnuNewAction.Text = "New Action...";
            this.cmnuNewAction.Click += new System.EventHandler(this.Action_NewAction);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // normalizeToolStripMenuItem
            // 
            this.normalizeToolStripMenuItem.Name = "normalizeToolStripMenuItem";
            this.normalizeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.normalizeToolStripMenuItem.Text = "Normalize...";
            // 
            // cmsBoundingBox
            // 
            this.cmsBoundingBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuAddToAction});
            this.cmsBoundingBox.Name = "cmsBoundingBox";
            this.cmsBoundingBox.Size = new System.Drawing.Size(149, 26);
            this.cmsBoundingBox.Opening += new System.ComponentModel.CancelEventHandler(this.cmsBoundingBox_Opening);
            // 
            // cmnuAddToAction
            // 
            this.cmnuAddToAction.Name = "cmnuAddToAction";
            this.cmnuAddToAction.Size = new System.Drawing.Size(148, 22);
            this.cmnuAddToAction.Text = "Add to Action";
            // 
            // cmsActionSprite
            // 
            this.cmsActionSprite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuMoveTop,
            this.cmnuMoveUp,
            this.cmnuMoveDown,
            this.cmnuMoveBottom,
            this.toolStripMenuItem2,
            this.cmnuDeleteAction});
            this.cmsActionSprite.Name = "cmsAction";
            this.cmsActionSprite.Size = new System.Drawing.Size(162, 120);
            this.cmsActionSprite.Opening += new System.ComponentModel.CancelEventHandler(this.cmsAction_Opening);
            // 
            // cmnuMoveTop
            // 
            this.cmnuMoveTop.Name = "cmnuMoveTop";
            this.cmnuMoveTop.Size = new System.Drawing.Size(161, 22);
            this.cmnuMoveTop.Text = "Move to Top";
            this.cmnuMoveTop.Click += new System.EventHandler(this.Action_MoveActionSpriteTop);
            // 
            // cmnuMoveUp
            // 
            this.cmnuMoveUp.Name = "cmnuMoveUp";
            this.cmnuMoveUp.Size = new System.Drawing.Size(161, 22);
            this.cmnuMoveUp.Text = "Move Up";
            this.cmnuMoveUp.Click += new System.EventHandler(this.Action_MoveActionSpriteUp);
            // 
            // cmnuMoveDown
            // 
            this.cmnuMoveDown.Name = "cmnuMoveDown";
            this.cmnuMoveDown.Size = new System.Drawing.Size(161, 22);
            this.cmnuMoveDown.Text = "Move Down";
            this.cmnuMoveDown.Click += new System.EventHandler(this.Action_MoveActionSpriteDown);
            // 
            // cmnuMoveBottom
            // 
            this.cmnuMoveBottom.Name = "cmnuMoveBottom";
            this.cmnuMoveBottom.Size = new System.Drawing.Size(161, 22);
            this.cmnuMoveBottom.Text = "Move to Bottom";
            this.cmnuMoveBottom.Click += new System.EventHandler(this.Action_MoveActionSpriteBottom);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
            // 
            // cmnuDeleteAction
            // 
            this.cmnuDeleteAction.Name = "cmnuDeleteAction";
            this.cmnuDeleteAction.Size = new System.Drawing.Size(161, 22);
            this.cmnuDeleteAction.Text = "Delete...";
            this.cmnuDeleteAction.Click += new System.EventHandler(this.Action_DeleteActionSpriteNode);
            // 
            // cmsAction
            // 
            this.cmsAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuActionAnimate});
            this.cmsAction.Name = "cmsAction";
            this.cmsAction.Size = new System.Drawing.Size(120, 26);
            // 
            // cmnuActionAnimate
            // 
            this.cmnuActionAnimate.Name = "cmnuActionAnimate";
            this.cmnuActionAnimate.Size = new System.Drawing.Size(119, 22);
            this.cmnuActionAnimate.Text = "Animate";
            this.cmnuActionAnimate.Click += new System.EventHandler(this.Action_Animate);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // pbAnimation
            // 
            this.pbAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAnimation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAnimation.Location = new System.Drawing.Point(12, 64);
            this.pbAnimation.Name = "pbAnimation";
            this.pbAnimation.Size = new System.Drawing.Size(192, 157);
            this.pbAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAnimation.TabIndex = 2;
            this.pbAnimation.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 50);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.folder_image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.Action_OpenSpriteSheetImage);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // mnuOpenSpriteSheet
            // 
            this.mnuOpenSpriteSheet.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.folder_image;
            this.mnuOpenSpriteSheet.Name = "mnuOpenSpriteSheet";
            this.mnuOpenSpriteSheet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenSpriteSheet.Size = new System.Drawing.Size(191, 22);
            this.mnuOpenSpriteSheet.Text = "Open Image...";
            this.mnuOpenSpriteSheet.Click += new System.EventHandler(this.Action_OpenSpriteSheetImage);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ovow Sprite Sheet Inspector";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbFPS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.cmsActions.ResumeLayout(false);
            this.cmsBoundingBox.ResumeLayout(false);
            this.cmsActionSprite.ResumeLayout(false);
            this.cmsAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenSpriteSheet;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.OpenFileDialog openSpriteSheetImageDialog;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmsActions;
        private System.Windows.Forms.ToolStripMenuItem cmnuNewAction;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem normalizeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsBoundingBox;
        private System.Windows.Forms.ToolStripMenuItem cmnuAddToAction;
        private System.Windows.Forms.ContextMenuStrip cmsActionSprite;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveTop;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmnuDeleteAction;
        private System.Windows.Forms.ContextMenuStrip cmsAction;
        private System.Windows.Forms.ToolStripMenuItem cmnuActionAnimate;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.TrackBar tbFPS;
        private System.Windows.Forms.PictureBox pbAnimation;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

