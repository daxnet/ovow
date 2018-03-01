using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.Common.Workspaces
{
    public sealed class WorkspaceEventArgs : EventArgs
    {
        public WorkspaceEventArgs(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; }
    }
}
