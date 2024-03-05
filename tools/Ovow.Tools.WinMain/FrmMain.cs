using System.ComponentModel;
using Krypton.Docking;
using Krypton.Navigator;
using Krypton.Toolkit;
using Ovow.Tools.Core.Components;
using Ovow.Tools.WinMain.Pages;
using Ovow.Tools.WinMain.Properties;

namespace Ovow.Tools.WinMain
{
    public partial class FrmMain : KryptonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            components ??= new Container();
            foreach (var action in CreateFormActions())
            {
                components.Add(action);
            }
        }

        private IEnumerable<FormAction> CreateFormActions()
        {
            yield return new FormAction(new ToolStripItem[] { mnuNew, tbtnNew }, OnNewClicked)
            {
                Image = Resources.page_white,
                ShortcutKeys = Keys.Control | Keys.N,
                ToolTipText = @"Creates a new project."
            };

            yield return new FormAction(new ToolStripItem[] { mnuSolutionExplorer, tbtnSolutionExplorer }, OnSolutionExplorerClicked)
            {
                Image = Resources.application_side_list,
                ToolTipText = @"Open Solution Explorer."
            };
        }

        private void OnNewClicked(object? sender, EventArgs e)
        {

        }

        private void OnSolutionExplorerClicked(object? sender, EventArgs e)
        {
            dockingManager.ShowPage(SolutionExplorer.Page.Identifier);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var dockingWorkspace = dockingManager.ManageWorkspace("mainDockingWorkspace", mainDockableWorkspace);
            dockingManager.ManageControl("mainDockingControl", pnlMain, dockingWorkspace);
            dockingManager.ManageFloating("mainFloating", this);

            dockingManager.AddDockspace("mainDockingControl", DockingEdge.Left, new KryptonPage[] 
            { 
                new SolutionExplorer.Page() 
            });
        }
    }
}
