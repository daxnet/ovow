using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Messaging
{
    public interface IMessageSubscriber
    {
        void Subscribe<TMessage>(Action<object, TMessage> handler)
            where TMessage : IMessage;
    }
}
