using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovow.Tools.Common
{
    public sealed class LengthyOperation : IDisposable
    {
        public LengthyOperation(Form parent)
        {
            this.parent = parent;
            this.parent.Cursor = Cursors.WaitCursor;
        }

        Form parent;

        public void Dispose()
        {
            parent.Cursor = Cursors.Default;
        }
    }
}
