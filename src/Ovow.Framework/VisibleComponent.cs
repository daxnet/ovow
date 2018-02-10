using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using Ovow.Framework.Messaging.GeneralMessages;

namespace Ovow.Framework
{
    public abstract class VisibleComponent : Component, IVisibleComponent
    {
        protected readonly IOvowGame game;

        protected VisibleComponent(IOvowGame game, Texture2D texture)
            : this(game, texture, Vector2.Zero)
        {

        }

        protected VisibleComponent(IOvowGame game, Texture2D texture, Vector2 position)
        {
            this.game = game;
            this.Texture = texture;
            this.X = position.X;
            this.Y = position.Y;
        }

        public Texture2D Texture { get; }

        public Vector2 Position => new Vector2(X, Y);

        public float X { get; set; }

        public float Y { get; set; }

        public int Width => this.Texture.Width;

        public int Height => this.Texture.Height;

        public bool OutOfViewport
        {
            get
            {
                var viewport = this.game.GraphicsDeviceManager.GraphicsDevice.Viewport;
                return (X + Width <= 0) || (Y + Height <= 0) || (X >= viewport.Width) || (Y >= viewport.Height);
            }
        }

        public bool HitViewportBoundary
        {
            get
            {
                var viewport = this.game.GraphicsDeviceManager.GraphicsDevice.Viewport;
                return (X <= 0) || (Y <= 0) || (X >= viewport.Width - Width) || (Y >= viewport.Height - Height);
            }
        }

        public Rectangle BoundingBox => new Rectangle((int)X, (int)Y, Width, Height);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public override void Update(GameTime gameTime)
        {
            var viewport = this.game.GraphicsDeviceManager.GraphicsDevice.Viewport;
            ReachBoundaryMessage.Boundary b = ReachBoundaryMessage.Boundary.None;
            if (X <= 0)
            {
                b |= ReachBoundaryMessage.Boundary.Left;
            }
            if (Y <= 0)
            {
                b |= ReachBoundaryMessage.Boundary.Top;
            }
            if (X >= viewport.Width - Width)
            {
                b |= ReachBoundaryMessage.Boundary.Right;
            }
            if (Y >= viewport.Height - Height)
            {
                b |= ReachBoundaryMessage.Boundary.Bottom;
            }

            this.Publish(new ReachBoundaryMessage(b));
        }

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            this.game.MessageDispatcher.DispatchMessage(this, message);
        }

        public void Subscribe<TMessage>(Action<object, TMessage> handler)
            where TMessage : IMessage
        {
            this.game.MessageDispatcher.RegisterHandler<TMessage>(handler);
        }

        public override string ToString() => this.Id.ToString();

    }
}
