using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.Common.Workspaces
{
    public sealed class WorkspaceSavedEventArgs : WorkspaceEventArgs
    {
        public WorkspaceSavedEventArgs(string fileName) : base(fileName)
        {
        }
    }
}
