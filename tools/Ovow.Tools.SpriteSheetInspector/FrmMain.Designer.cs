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
            this.mnuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnNewProject = new System.Windows.Forms.ToolStripButton();
            this.tbtnOpenProject = new System.Windows.Forms.ToolStripButton();
            this.tbtnSaveProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tv = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblTreeViewTitle = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.lblPropertyTitle = new System.Windows.Forms.Label();
            this.cbAnimationActions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAnimationPanelTitle = new System.Windows.Forms.Label();
            this.pbAnimation = new System.Windows.Forms.PictureBox();
            this.tbFPS = new System.Windows.Forms.TrackBar();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.openSpriteSheetImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNewAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuExportAction = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBoundingBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuAddToAction = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsActionSprite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMoveBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDeleteActionFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuActionAnimate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDeleteAction = new System.Windows.Forms.ToolStripMenuItem();
            this.animationExecutor = new System.ComponentModel.BackgroundWorker();
            this.exportDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFPS)).BeginInit();
            this.cmsActions.SuspendLayout();
            this.cmsBoundingBox.SuspendLayout();
            this.cmsActionSprite.SuspendLayout();
            this.cmsAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProject,
            this.mnuOpenProject,
            this.mnuSaveProject,
            this.toolStripMenuItem3,
            this.mnuCloseProject,
            this.toolStripMenuItem4,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuNewProject
            // 
            this.mnuNewProject.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.new_proj;
            this.mnuNewProject.Name = "mnuNewProject";
            this.mnuNewProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewProject.Size = new System.Drawing.Size(164, 22);
            this.mnuNewProject.Text = "&New...";
            this.mnuNewProject.Click += new System.EventHandler(this.Action_NewProject);
            // 
            // mnuOpenProject
            // 
            this.mnuOpenProject.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.open_proj;
            this.mnuOpenProject.Name = "mnuOpenProject";
            this.mnuOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenProject.Size = new System.Drawing.Size(164, 22);
            this.mnuOpenProject.Text = "&Open...";
            this.mnuOpenProject.Click += new System.EventHandler(this.Action_OpenProject);
            // 
            // mnuSaveProject
            // 
            this.mnuSaveProject.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.save_proj;
            this.mnuSaveProject.Name = "mnuSaveProject";
            this.mnuSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveProject.Size = new System.Drawing.Size(164, 22);
            this.mnuSaveProject.Text = "&Save";
            this.mnuSaveProject.Click += new System.EventHandler(this.Action_SaveProject);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuCloseProject
            // 
            this.mnuCloseProject.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.close_project;
            this.mnuCloseProject.Name = "mnuCloseProject";
            this.mnuCloseProject.Size = new System.Drawing.Size(164, 22);
            this.mnuCloseProject.Text = "&Close";
            this.mnuCloseProject.Click += new System.EventHandler(this.Action_CloseProject);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(164, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.Action_Exit);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(47, 21);
            this.mnuHelp.Text = "&Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnNewProject,
            this.tbtnOpenProject,
            this.tbtnSaveProject,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnNewProject
            // 
            this.tbtnNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnNewProject.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.new_proj;
            this.tbtnNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnNewProject.Name = "tbtnNewProject";
            this.tbtnNewProject.Size = new System.Drawing.Size(23, 22);
            this.tbtnNewProject.Text = "toolStripButton2";
            this.tbtnNewProject.Click += new System.EventHandler(this.Action_NewProject);
            // 
            // tbtnOpenProject
            // 
            this.tbtnOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnOpenProject.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.open_proj;
            this.tbtnOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnOpenProject.Name = "tbtnOpenProject";
            this.tbtnOpenProject.Size = new System.Drawing.Size(23, 22);
            this.tbtnOpenProject.Text = "Open Project";
            this.tbtnOpenProject.Click += new System.EventHandler(this.Action_OpenProject);
            // 
            // tbtnSaveProject
            // 
            this.tbtnSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSaveProject.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.save_proj;
            this.tbtnSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSaveProject.Name = "tbtnSaveProject";
            this.tbtnSaveProject.Size = new System.Drawing.Size(23, 22);
            this.tbtnSaveProject.Text = "Save Project";
            this.tbtnSaveProject.Click += new System.EventHandler(this.Action_SaveProject);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 511);
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
            this.splitContainer3.Panel1.Controls.Add(this.lblTreeViewTitle);
            this.splitContainer3.Panel2Collapsed = true;
            this.splitContainer3.Size = new System.Drawing.Size(216, 511);
            this.splitContainer3.SplitterDistance = 269;
            this.splitContainer3.TabIndex = 0;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.HideSelection = false;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.imageList1;
            this.tv.Location = new System.Drawing.Point(0, 23);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(216, 488);
            this.tv.TabIndex = 6;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tv_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblTreeViewTitle
            // 
            this.lblTreeViewTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTreeViewTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTreeViewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTreeViewTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreeViewTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTreeViewTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTreeViewTitle.Name = "lblTreeViewTitle";
            this.lblTreeViewTitle.Size = new System.Drawing.Size(216, 23);
            this.lblTreeViewTitle.TabIndex = 0;
            this.lblTreeViewTitle.Text = "Project Explorer";
            this.lblTreeViewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(564, 511);
            this.splitContainer2.SplitterDistance = 366;
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
            this.pnlMain.Size = new System.Drawing.Size(366, 511);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlMain_Scroll);
            this.pnlMain.Click += new System.EventHandler(this.pnlMain_Click);
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
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.propertyGrid);
            this.splitContainer4.Panel1.Controls.Add(this.lblPropertyTitle);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.cbAnimationActions);
            this.splitContainer4.Panel2.Controls.Add(this.label1);
            this.splitContainer4.Panel2.Controls.Add(this.lblAnimationPanelTitle);
            this.splitContainer4.Panel2.Controls.Add(this.pbAnimation);
            this.splitContainer4.Panel2.Controls.Add(this.tbFPS);
            this.splitContainer4.Panel2.Controls.Add(this.btnAnimate);
            this.splitContainer4.Size = new System.Drawing.Size(194, 511);
            this.splitContainer4.SplitterDistance = 215;
            this.splitContainer4.TabIndex = 0;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 23);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(194, 192);
            this.propertyGrid.TabIndex = 8;
            // 
            // lblPropertyTitle
            // 
            this.lblPropertyTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPropertyTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPropertyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPropertyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblPropertyTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPropertyTitle.Name = "lblPropertyTitle";
            this.lblPropertyTitle.Size = new System.Drawing.Size(194, 23);
            this.lblPropertyTitle.TabIndex = 2;
            this.lblPropertyTitle.Text = "Properties";
            this.lblPropertyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAnimationActions
            // 
            this.cbAnimationActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAnimationActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimationActions.FormattingEnabled = true;
            this.cbAnimationActions.Location = new System.Drawing.Point(55, 32);
            this.cbAnimationActions.Name = "cbAnimationActions";
            this.cbAnimationActions.Size = new System.Drawing.Size(127, 21);
            this.cbAnimationActions.TabIndex = 11;
            this.cbAnimationActions.SelectedIndexChanged += new System.EventHandler(this.cbAnimationActions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Action:";
            // 
            // lblAnimationPanelTitle
            // 
            this.lblAnimationPanelTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAnimationPanelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnimationPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAnimationPanelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimationPanelTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblAnimationPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAnimationPanelTitle.Name = "lblAnimationPanelTitle";
            this.lblAnimationPanelTitle.Size = new System.Drawing.Size(194, 23);
            this.lblAnimationPanelTitle.TabIndex = 9;
            this.lblAnimationPanelTitle.Text = "Animation Panel";
            this.lblAnimationPanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbAnimation
            // 
            this.pbAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAnimation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAnimation.Location = new System.Drawing.Point(12, 110);
            this.pbAnimation.Name = "pbAnimation";
            this.pbAnimation.Size = new System.Drawing.Size(170, 169);
            this.pbAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnimation.TabIndex = 8;
            this.pbAnimation.TabStop = false;
            // 
            // tbFPS
            // 
            this.tbFPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFPS.Location = new System.Drawing.Point(50, 59);
            this.tbFPS.Maximum = 60;
            this.tbFPS.Minimum = 1;
            this.tbFPS.Name = "tbFPS";
            this.tbFPS.Size = new System.Drawing.Size(132, 45);
            this.tbFPS.TabIndex = 7;
            this.tbFPS.Value = 8;
            // 
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(12, 59);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(32, 32);
            this.btnAnimate.TabIndex = 6;
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
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
            this.cmnuExportAction});
            this.cmsActions.Name = "cmsActions";
            this.cmsActions.Size = new System.Drawing.Size(152, 54);
            // 
            // cmnuNewAction
            // 
            this.cmnuNewAction.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.add;
            this.cmnuNewAction.Name = "cmnuNewAction";
            this.cmnuNewAction.Size = new System.Drawing.Size(151, 22);
            this.cmnuNewAction.Text = "New Action...";
            this.cmnuNewAction.Click += new System.EventHandler(this.Action_NewAction);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            // 
            // cmnuExportAction
            // 
            this.cmnuExportAction.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.export;
            this.cmnuExportAction.Name = "cmnuExportAction";
            this.cmnuExportAction.Size = new System.Drawing.Size(151, 22);
            this.cmnuExportAction.Text = "Export...";
            this.cmnuExportAction.Click += new System.EventHandler(this.Action_Export);
            // 
            // cmsBoundingBox
            // 
            this.cmsBoundingBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuAddToAction});
            this.cmsBoundingBox.Name = "cmsBoundingBox";
            this.cmsBoundingBox.Size = new System.Drawing.Size(157, 26);
            this.cmsBoundingBox.Opening += new System.ComponentModel.CancelEventHandler(this.cmsBoundingBox_Opening);
            // 
            // cmnuAddToAction
            // 
            this.cmnuAddToAction.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.add;
            this.cmnuAddToAction.Name = "cmnuAddToAction";
            this.cmnuAddToAction.Size = new System.Drawing.Size(156, 22);
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
            this.cmnuDeleteActionFrame});
            this.cmsActionSprite.Name = "cmsAction";
            this.cmsActionSprite.Size = new System.Drawing.Size(173, 120);
            this.cmsActionSprite.Opening += new System.ComponentModel.CancelEventHandler(this.cmsAction_Opening);
            // 
            // cmnuMoveTop
            // 
            this.cmnuMoveTop.Name = "cmnuMoveTop";
            this.cmnuMoveTop.Size = new System.Drawing.Size(172, 22);
            this.cmnuMoveTop.Text = "Move to Top";
            this.cmnuMoveTop.Click += new System.EventHandler(this.Action_MoveActionFrameTop);
            // 
            // cmnuMoveUp
            // 
            this.cmnuMoveUp.Name = "cmnuMoveUp";
            this.cmnuMoveUp.Size = new System.Drawing.Size(172, 22);
            this.cmnuMoveUp.Text = "Move Up";
            this.cmnuMoveUp.Click += new System.EventHandler(this.Action_MoveActionFrameUp);
            // 
            // cmnuMoveDown
            // 
            this.cmnuMoveDown.Name = "cmnuMoveDown";
            this.cmnuMoveDown.Size = new System.Drawing.Size(172, 22);
            this.cmnuMoveDown.Text = "Move Down";
            this.cmnuMoveDown.Click += new System.EventHandler(this.Action_MoveActionFrameDown);
            // 
            // cmnuMoveBottom
            // 
            this.cmnuMoveBottom.Name = "cmnuMoveBottom";
            this.cmnuMoveBottom.Size = new System.Drawing.Size(172, 22);
            this.cmnuMoveBottom.Text = "Move to Bottom";
            this.cmnuMoveBottom.Click += new System.EventHandler(this.Action_MoveActionFrameBottom);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 6);
            // 
            // cmnuDeleteActionFrame
            // 
            this.cmnuDeleteActionFrame.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.delete;
            this.cmnuDeleteActionFrame.Name = "cmnuDeleteActionFrame";
            this.cmnuDeleteActionFrame.Size = new System.Drawing.Size(172, 22);
            this.cmnuDeleteActionFrame.Text = "Delete...";
            this.cmnuDeleteActionFrame.Click += new System.EventHandler(this.Action_DeleteActionFrameNode);
            // 
            // cmsAction
            // 
            this.cmsAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuActionAnimate,
            this.toolStripMenuItem5,
            this.cmnuDeleteAction});
            this.cmsAction.Name = "cmsAction";
            this.cmsAction.Size = new System.Drawing.Size(124, 54);
            // 
            // cmnuActionAnimate
            // 
            this.cmnuActionAnimate.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.play;
            this.cmnuActionAnimate.Name = "cmnuActionAnimate";
            this.cmnuActionAnimate.Size = new System.Drawing.Size(123, 22);
            this.cmnuActionAnimate.Text = "Animate";
            this.cmnuActionAnimate.Click += new System.EventHandler(this.Action_Animate);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(120, 6);
            // 
            // cmnuDeleteAction
            // 
            this.cmnuDeleteAction.Image = global::Ovow.Tools.SpriteSheetInspector.Properties.Resources.delete;
            this.cmnuDeleteAction.Name = "cmnuDeleteAction";
            this.cmnuDeleteAction.Size = new System.Drawing.Size(123, 22);
            this.cmnuDeleteAction.Text = "Delete...";
            // 
            // animationExecutor
            // 
            this.animationExecutor.WorkerSupportsCancellation = true;
            this.animationExecutor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.animationExecutor_DoWork);
            // 
            // exportDialog
            // 
            this.exportDialog.DefaultExt = "xml";
            this.exportDialog.Filter = "Animated Sprite Action Definition (*.xml)|*.xml";
            this.exportDialog.Title = "Export Actions";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ovow Sprite Sheet Inspector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFPS)).EndInit();
            this.cmsActions.ResumeLayout(false);
            this.cmsBoundingBox.ResumeLayout(false);
            this.cmsActionSprite.ResumeLayout(false);
            this.cmsAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenProject;
        private System.Windows.Forms.ToolStripButton tbtnOpenProject;
        private System.Windows.Forms.OpenFileDialog openSpriteSheetImageDialog;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseProject;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnNewProject;
        private System.Windows.Forms.ToolStripButton tbtnSaveProject;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmsActions;
        private System.Windows.Forms.ToolStripMenuItem cmnuNewAction;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmnuExportAction;
        private System.Windows.Forms.ContextMenuStrip cmsBoundingBox;
        private System.Windows.Forms.ToolStripMenuItem cmnuAddToAction;
        private System.Windows.Forms.ContextMenuStrip cmsActionSprite;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveTop;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem cmnuMoveBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmnuDeleteActionFrame;
        private System.Windows.Forms.ContextMenuStrip cmsAction;
        private System.Windows.Forms.ToolStripMenuItem cmnuActionAnimate;
        private System.ComponentModel.BackgroundWorker animationExecutor;
        private System.Windows.Forms.ToolStripMenuItem mnuNewProject;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Label lblTreeViewTitle;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label lblAnimationPanelTitle;
        private System.Windows.Forms.PictureBox pbAnimation;
        private System.Windows.Forms.TrackBar tbFPS;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Label lblPropertyTitle;
        private System.Windows.Forms.ComboBox cbAnimationActions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem cmnuDeleteAction;
        private System.Windows.Forms.SaveFileDialog exportDialog;
    }
}

