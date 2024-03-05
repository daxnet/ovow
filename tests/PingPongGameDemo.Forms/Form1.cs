using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPongGameDemo.Forms
{
    public partial class Form1 : Form
    {
        private readonly PingPongGameControl _control;
        public Form1()
        {
            InitializeComponent();
            _control = new PingPongGameControl();
            _control.AddScene<GameScene>("pingpong", true);
            _control.Dock = DockStyle.Fill;
            panel1.Controls.Add(_control);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            _control.ActiveFormScene.SetParameter("balls", trackBar1.Value.ToString());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _control.ActiveFormScene.SetParameter("balls", trackBar1.Value.ToString());
        }
    }
}
