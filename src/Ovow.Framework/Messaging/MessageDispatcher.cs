using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Messaging
{
    internal sealed class MessageDispatcher : IMessageDispatcher
    {
        private readonly ConcurrentDictionary<Type, List<Action<IMessage>>> messageHandlers = new ConcurrentDictionary<Type, List<Action<IMessage>>>();

        public MessageDispatcher() { }

        public void DispatchMessage<TMessage>(TMessage message) where TMessage : IMessage
        {
            if (messageHandlers.TryGetValue(typeof(TMessage), out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler(message);
                }
            }
        }

        public void RegisterHandler<TMessage>(Action<IMessage> handler)
            where TMessage : IMessage
        {
            if (messageHandlers.TryGetValue(typeof(TMessage), out var handlers))
            {
                handlers.Add(handler);
            }
            else
            {
                messageHandlers.TryAdd(typeof(TMessage), new List<Action<IMessage>> { handler });
            }
        }
    }
}
