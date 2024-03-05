using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Navigator;
using Ovow.Tools.WinMain.Properties;

namespace Ovow.Tools.WinMain.Pages
{
    public partial class SolutionExplorer : UserControl
    {
        #region Public Constructors

        public SolutionExplorer()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Classes

        public sealed class Page : KryptonPage
        {
            public const string Identifier = "71E80254-138B-4C3E-BCE5-33F9D55CE316";

            #region Public Constructors

            public Page()
                : base("Solution Explorer", Resources.application_side_list, Identifier)
            {
                TextTitle = "Solution Explorer";
                var ctrl = new SolutionExplorer();
                ctrl.Dock = DockStyle.Fill;
                Controls.Add(ctrl);
            }

            #endregion Public Constructors
        }

        #endregion Public Classes
    }
}
