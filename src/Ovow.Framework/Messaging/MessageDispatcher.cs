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
        private readonly ConcurrentDictionary<Type, List<Action<object, IMessage>>> messageHandlers = new ConcurrentDictionary<Type, List<Action<object, IMessage>>>();

        public MessageDispatcher() { }

        public Task DispatchMessageAsync<TMessage>(object publisher, TMessage message) 
            where TMessage : IMessage
        {
            return Task.Factory.StartNew(() =>
            {
                DispatchMessageSync(publisher, message);
            });
        }

        public void DispatchMessageSync<TMessage>(object publisher, TMessage message)
            where TMessage : IMessage
        {
            if (messageHandlers.TryGetValue(typeof(TMessage), out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler(publisher, message);
                }
            }
        }

        public void RegisterHandler<TMessage>(Action<object, TMessage> handler)
            where TMessage : IMessage
        {
            Action<object, IMessage> convertedHandler = (publisher, message) => handler(publisher, (TMessage)message);

            if (messageHandlers.TryGetValue(typeof(TMessage), out var handlers))
            {
                handlers.Add(convertedHandler);
            }
            else
            {
                messageHandlers.TryAdd(typeof(TMessage), new List<Action<object, IMessage>> { convertedHandler });
            }
        }
    }
}
