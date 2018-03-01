using Ovow.Tools.Common.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public class SsiWorkspace : Workspace<SsiProject>
    {
        protected override string WorkspaceFileDescription => "Ovow Sprite Sheet Inspector Project";

        protected override string WorkspaceFileExtension => "ssi";

        protected override SsiProject Create()
        {
            throw new NotImplementedException();
        }

        protected override SsiProject OpenFromFile(string fileName)
        {
            throw new NotImplementedException();
        }

        protected override void SaveToFile(SsiProject model, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
