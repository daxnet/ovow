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
    public abstract class VisibleComponent : IVisibleComponent
    {
        protected readonly IOvowGame game;

        protected VisibleComponent(IOvowGame game, Texture2D texture)
            : this (game, texture, Vector2.Zero)
        {

        }

        protected VisibleComponent(IOvowGame game, Texture2D texture, Vector2 position)
        {
            this.game = game;
            this.Texture = texture;
            this.Position = position;
        }

        public Texture2D Texture { get; }

        public Vector2 Position { get; set; }

        public float X
        {
            get
            {
                return this.Position.X;
            }
            set
            {
                this.Position = new Vector2(value, this.Position.Y);
            }
        }

        public float Y
        {
            get
            {
                return this.Position.Y;
            }
            set
            {
                this.Position = new Vector2(this.Position.X, value);
            }
        }


        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            this.game.MessageDispatcher.DispatchMessage(message);
        }

        public void Subscribe<TMessage>(Action<TMessage> handler) 
            where TMessage : IMessage
        {
            Action<IMessage> convertedHandler = (message) => handler((TMessage)message);
            this.game.MessageDispatcher.RegisterHandler<TMessage>(convertedHandler);
        }

        public abstract void Update(GameTime gameTime);
    }
}
