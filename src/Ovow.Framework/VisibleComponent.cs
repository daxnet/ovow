using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;

namespace Ovow.Framework
{
    public abstract class VisibleComponent : IVisible, IComponent
    {
        protected readonly IOvowGame game;

        protected VisibleComponent(IOvowGame game)
        {
            this.game = game;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            this.game.MessageDispatcher.DispatchMessage(message);
        }

        public void Subscribe<TMessage>(Action<TMessage> handler) 
            where TMessage : IMessage
        {
            this.game.MessageDispatcher.RegisterHandler(handler);
        }

        public abstract void Update(GameTime gameTime);
    }
}
