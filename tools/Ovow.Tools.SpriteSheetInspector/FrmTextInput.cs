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
    public partial class FrmTextInput : Form
    {
        private readonly IEnumerable<string> compare;

        private FrmTextInput()
        {
            InitializeComponent();
        }

        public FrmTextInput(string title)
            : this(title, null)
        {
            
        }

        public FrmTextInput(string title, IEnumerable<string> compare)
            : this()
        {
            this.lblTitle.Text = title;
            this.compare = compare;
        }

        public string InputText
        {
            get { return this.txtInput.Text; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(this.txtInput.Text))
            {
                errorProvider1.SetError(txtInput, "Input cannot be empty.");
                DialogResult = DialogResult.None;
            }
            else
            {
                if (this.compare != null && this.compare.Contains(this.txtInput.Text))
                {
                    errorProvider1.SetError(txtInput, "The input text already exists.");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
