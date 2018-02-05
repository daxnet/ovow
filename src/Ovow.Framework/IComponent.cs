using Microsoft.Xna.Framework;
using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    /// <summary>
    /// Represents that the implemented classes are game components.
    /// </summary>
    public interface IComponent
    {
        void Update(GameTime gameTime);

        void Subscribe<TMessage>(Action<TMessage> handler)
            where TMessage : IMessage;

        void Publish<TMessage>(TMessage message)
            where TMessage : IMessage;
    }
}
