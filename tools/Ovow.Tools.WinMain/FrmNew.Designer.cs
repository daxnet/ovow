namespace Ovow.Tools.WinMain
{
    partial class FrmNew
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
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            kryptonListView1 = new Krypton.Toolkit.KryptonListView();
            lblName = new Krypton.Toolkit.KryptonLabel();
            txtName = new Krypton.Toolkit.KryptonTextBox();
            lblDirectory = new Krypton.Toolkit.KryptonLabel();
            txtDirectory = new Krypton.Toolkit.KryptonTextBox();
            btnBrowseDirectory = new Krypton.Toolkit.KryptonButton();
            btnOK = new Krypton.Toolkit.KryptonButton();
            btnCancel = new Krypton.Toolkit.KryptonButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(149, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Values.Text = "Select a project template:";
            // 
            // kryptonListView1
            // 
            kryptonListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            kryptonListView1.ItemStyle = Krypton.Toolkit.ButtonStyle.ListItem;
            kryptonListView1.Location = new Point(12, 38);
            kryptonListView1.Name = "kryptonListView1";
            kryptonListView1.OwnerDraw = true;
            kryptonListView1.Size = new Size(583, 267);
            kryptonListView1.StateCommon.Item.Content.ShortText.MultiLine = Krypton.Toolkit.InheritBool.True;
            kryptonListView1.StateCommon.Item.Content.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            kryptonListView1.StateCommon.Item.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            kryptonListView1.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblName.Location = new Point(29, 314);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 20);
            lblName.TabIndex = 2;
            lblName.Values.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(78, 311);
            txtName.Name = "txtName";
            txtName.Size = new Size(517, 23);
            txtName.TabIndex = 3;
            // 
            // lblDirectory
            // 
            lblDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDirectory.Location = new Point(12, 340);
            lblDirectory.Name = "lblDirectory";
            lblDirectory.Size = new Size(63, 20);
            lblDirectory.TabIndex = 4;
            lblDirectory.Values.Text = "Directory:";
            // 
            // txtDirectory
            // 
            txtDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDirectory.Location = new Point(78, 340);
            txtDirectory.Name = "txtDirectory";
            txtDirectory.Size = new Size(421, 23);
            txtDirectory.TabIndex = 5;
            // 
            // btnBrowseDirectory
            // 
            btnBrowseDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBrowseDirectory.Location = new Point(505, 338);
            btnBrowseDirectory.Name = "btnBrowseDirectory";
            btnBrowseDirectory.Size = new Size(90, 25);
            btnBrowseDirectory.TabIndex = 6;
            btnBrowseDirectory.Values.Text = "Browse...";
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(409, 378);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(90, 25);
            btnOK.TabIndex = 7;
            btnOK.Values.Text = "&OK";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(505, 378);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 25);
            btnCancel.TabIndex = 8;
            btnCancel.Values.Text = "&Cancel";
            // 
            // FrmNew
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(607, 415);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnBrowseDirectory);
            Controls.Add(txtDirectory);
            Controls.Add(lblDirectory);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(kryptonListView1);
            Controls.Add(lblTitle);
            Name = "FrmNew";
            Text = "Create a new project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel lblTitle;
        private Krypton.Toolkit.KryptonListView kryptonListView1;
        private Krypton.Toolkit.KryptonLabel lblName;
        private Krypton.Toolkit.KryptonTextBox txtName;
        private Krypton.Toolkit.KryptonLabel lblDirectory;
        private Krypton.Toolkit.KryptonTextBox txtDirectory;
        private Krypton.Toolkit.KryptonButton btnBrowseDirectory;
        private Krypton.Toolkit.KryptonButton btnOK;
        private Krypton.Toolkit.KryptonButton btnCancel;
    }
}