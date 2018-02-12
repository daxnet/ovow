using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;

namespace Ovow.Framework.Scenes
{
    public abstract class Transition : ITransition
    {
        private readonly Guid id = Guid.NewGuid();
        
        protected Transition(IScene scene)
        {
            this.Scene = scene;
        }

        public Rectangle BoundingBox => Scene.BoundingBox;

        public Vector2 Position => Vector2.Zero;

        public Texture2D Texture => Scene.Texture;

        public Guid Id => id;

        public IScene Scene { get; }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IComponent other)
        {
            throw new NotImplementedException();
        }

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TMessage>(Action<object, TMessage> handler) where TMessage : IMessage
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
