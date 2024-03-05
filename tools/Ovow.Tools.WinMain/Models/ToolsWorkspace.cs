using Ovow.Tools.Core.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.WinMain.Models
{
    internal sealed class ToolsWorkspace : Workspace<ToolsSolution>
    {
        protected override string WorkspaceFileDescription => "Ovow Tools Solution";

        protected override string WorkspaceFileExtension => "ots";

        protected override ToolsSolution? Create()
        {
            throw new NotImplementedException();
        }

        protected override ToolsSolution OpenFromFile(string fileName)
        {
            throw new NotImplementedException();
        }

        protected override void SaveToFile(ToolsSolution? model, string? fileName)
        {
            throw new NotImplementedException();
        }
    }
}
