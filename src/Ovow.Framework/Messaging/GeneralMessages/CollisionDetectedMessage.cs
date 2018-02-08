using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Messaging.GeneralMessages
{
    public sealed class CollisionDetectedMessage : Message
    {
        public CollisionDetectedMessage(IVisibleComponent a, IVisibleComponent b)
        {
            this.A = a;
            this.B = b;
        }

        public IVisibleComponent A { get; }
        public IVisibleComponent B { get; }
    }
}
