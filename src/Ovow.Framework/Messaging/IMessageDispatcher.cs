using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Messaging
{
    public interface IMessageDispatcher
    {
        void RegisterHandler<TMessage>(Action<TMessage> handler)
            where TMessage : IMessage;

        void DispatchMessage<TMessage>(TMessage message)
            where TMessage : IMessage;
    }
}
