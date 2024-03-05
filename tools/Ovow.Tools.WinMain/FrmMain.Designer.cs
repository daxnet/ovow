namespace Ovow.Tools.WinMain
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            statusStrip = new Krypton.Toolkit.KryptonStatusStrip();
            menuStrip = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuNew = new ToolStripMenuItem();
            mnuOpen = new ToolStripMenuItem();
            kryptonManager = new Krypton.Toolkit.KryptonManager(components);
            dockingManager = new Krypton.Docking.KryptonDockingManager();
            toolStripContainer1 = new ToolStripContainer();
            pnlMain = new Krypton.Toolkit.KryptonPanel();
            mainDockableWorkspace = new Krypton.Docking.KryptonDockableWorkspace();
            toolStrip = new Krypton.Toolkit.KryptonToolStrip();
            tbtnNew = new ToolStripButton();
            tbtnOpen = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            tbtnSolutionExplorer = new ToolStripButton();
            mnuView = new ToolStripMenuItem();
            mnuSolutionExplorer = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainDockableWorkspace).BeginInit();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Font = new Font("Segoe UI", 9F);
            statusStrip.Location = new Point(0, 564);
            statusStrip.Name = "statusStrip";
            statusStrip.ProgressBars = null;
            statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            statusStrip.Size = new Size(809, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "kryptonStatusStrip1";
            // 
            // menuStrip
            // 
            menuStrip.Font = new Font("Segoe UI", 9F);
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(809, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuNew, mnuOpen });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(37, 20);
            mnuFile.Text = "&File";
            // 
            // mnuNew
            // 
            mnuNew.Image = Properties.Resources.page_white;
            mnuNew.Name = "mnuNew";
            mnuNew.ShortcutKeys = Keys.Control | Keys.N;
            mnuNew.Size = new Size(150, 22);
            mnuNew.Text = "&New...";
            // 
            // mnuOpen
            // 
            mnuOpen.Name = "mnuOpen";
            mnuOpen.Size = new Size(150, 22);
            mnuOpen.Text = "Open...";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(pnlMain);
            toolStripContainer1.ContentPanel.Size = new Size(809, 515);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 24);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(809, 540);
            toolStripContainer1.TabIndex = 2;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip);
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(mainDockableWorkspace);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(809, 515);
            pnlMain.TabIndex = 0;
            // 
            // mainDockableWorkspace
            // 
            mainDockableWorkspace.ActivePage = null;
            mainDockableWorkspace.AutoHiddenHost = false;
            mainDockableWorkspace.CompactFlags = Krypton.Workspace.CompactFlags.RemoveEmptyCells | Krypton.Workspace.CompactFlags.RemoveEmptySequences | Krypton.Workspace.CompactFlags.PromoteLeafs;
            mainDockableWorkspace.ContainerBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelClient;
            mainDockableWorkspace.Dock = DockStyle.Fill;
            mainDockableWorkspace.Location = new Point(0, 0);
            mainDockableWorkspace.Name = "mainDockableWorkspace";
            // 
            // 
            // 
            mainDockableWorkspace.Root.UniqueName = "f919c3e274d7423886fdbe92e9a4ad6b";
            mainDockableWorkspace.Root.WorkspaceControl = mainDockableWorkspace;
            mainDockableWorkspace.SeparatorStyle = Krypton.Toolkit.SeparatorStyle.LowProfile;
            mainDockableWorkspace.ShowMaximizeButton = false;
            mainDockableWorkspace.Size = new Size(809, 515);
            mainDockableWorkspace.SplitterWidth = 5;
            mainDockableWorkspace.TabIndex = 0;
            mainDockableWorkspace.TabStop = true;
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.None;
            toolStrip.Font = new Font("Segoe UI", 9F);
            toolStrip.Items.AddRange(new ToolStripItem[] { tbtnNew, tbtnOpen, toolStripButton1, toolStripSeparator1, tbtnSolutionExplorer });
            toolStrip.Location = new Point(3, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(110, 25);
            toolStrip.TabIndex = 0;
            // 
            // tbtnNew
            // 
            tbtnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tbtnNew.Image = Properties.Resources.page_white;
            tbtnNew.ImageTransparentColor = Color.Magenta;
            tbtnNew.Name = "tbtnNew";
            tbtnNew.Size = new Size(23, 22);
            tbtnNew.Text = "New";
            // 
            // tbtnOpen
            // 
            tbtnOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tbtnOpen.Image = (Image)resources.GetObject("tbtnOpen.Image");
            tbtnOpen.ImageTransparentColor = Color.Magenta;
            tbtnOpen.Name = "tbtnOpen";
            tbtnOpen.Size = new Size(23, 22);
            tbtnOpen.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // tbtnSolutionExplorer
            // 
            tbtnSolutionExplorer.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tbtnSolutionExplorer.Image = (Image)resources.GetObject("tbtnSolutionExplorer.Image");
            tbtnSolutionExplorer.ImageTransparentColor = Color.Magenta;
            tbtnSolutionExplorer.Name = "tbtnSolutionExplorer";
            tbtnSolutionExplorer.Size = new Size(23, 22);
            tbtnSolutionExplorer.Text = "Solution Explorer";
            // 
            // mnuView
            // 
            mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuSolutionExplorer });
            mnuView.Name = "mnuView";
            mnuView.Size = new Size(44, 20);
            mnuView.Text = "&View";
            // 
            // mnuSolutionExplorer
            // 
            mnuSolutionExplorer.Name = "mnuSolutionExplorer";
            mnuSolutionExplorer.Size = new Size(180, 22);
            mnuSolutionExplorer.Text = "&Solution Explorer";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 586);
            Controls.Add(toolStripContainer1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stellar Workshop";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainDockableWorkspace).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonStatusStrip statusStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuFile;
        private Krypton.Toolkit.KryptonManager kryptonManager;
        private Krypton.Docking.KryptonDockingManager dockingManager;
        private ToolStripContainer toolStripContainer1;
        private Krypton.Toolkit.KryptonPanel pnlMain;
        private Krypton.Toolkit.KryptonToolStrip toolStrip;
        private ToolStripButton tbtnNew;
        private Krypton.Docking.KryptonDockableWorkspace mainDockableWorkspace;
        private ToolStripMenuItem mnuNew;
        private ToolStripMenuItem mnuOpen;
        private ToolStripButton tbtnOpen;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tbtnSolutionExplorer;
        private ToolStripMenuItem mnuView;
        private ToolStripMenuItem mnuSolutionExplorer;
    }
}
