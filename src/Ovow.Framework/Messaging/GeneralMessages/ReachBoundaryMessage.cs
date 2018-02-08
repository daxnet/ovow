using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Messaging.GeneralMessages
{
    public sealed class ReachBoundaryMessage : Message
    {
        public ReachBoundaryMessage(Boundary boundary)
        {
            this.ReachedBoundary = boundary;
        }

        public Boundary ReachedBoundary { get; }

        [Flags]
        public enum Boundary
        {
            None = 0,
            Top = 1,
            Left = 2,
            Bottom = 4,
            Right = 8
        }
    }
}
