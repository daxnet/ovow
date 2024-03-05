namespace Ovow.Tools.WinMain.Pages
{
    partial class SolutionExplorer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            projectTree = new Krypton.Toolkit.KryptonTreeView();
            SuspendLayout();
            // 
            // projectTree
            // 
            projectTree.Dock = DockStyle.Fill;
            projectTree.Location = new Point(0, 0);
            projectTree.Name = "projectTree";
            projectTree.Size = new Size(299, 391);
            projectTree.TabIndex = 0;
            // 
            // ProjectExplorer
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(projectTree);
            Name = "ProjectExplorer";
            Size = new Size(299, 391);
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonTreeView projectTree;
    }
}
