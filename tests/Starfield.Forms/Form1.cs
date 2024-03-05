using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starfield.Forms
{
    public partial class Form1 : Form
    {
        private readonly StarfieldControl _ctl;
        public Form1()
        {
            InitializeComponent();
            _ctl = new StarfieldControl();
            _ctl.AddScene<StarfieldScene>("starfield", true);
            _ctl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_ctl);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            _ctl.ActiveFormScene.SetParameter("numOfStars", trackBar1.Value.ToString());
        }
    }
}
