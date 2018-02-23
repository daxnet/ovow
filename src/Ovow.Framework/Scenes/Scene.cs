﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Transitions;

namespace Ovow.Framework.Scenes
{
    public abstract class Scene : IScene
    {
        private readonly Guid id = Guid.NewGuid();
        private readonly IOvowGame game;
        private readonly Texture2D sceneTexture;
        private readonly List<IComponent> gameComponents = new List<IComponent>();
        private volatile bool ended = false;
        private volatile bool ending = false;
        private static readonly object endingSyncLock = new object();

        protected Scene(IOvowGame game)
            : this(game, null, Color.CornflowerBlue)
        { }

        protected Scene(IOvowGame game, Texture2D sceneTexture)
            : this(game, sceneTexture, Color.CornflowerBlue)
        { }

        protected Scene(IOvowGame game, Color backgrounColor)
            : this(game, null, backgrounColor)
        { }

        protected Scene(IOvowGame game, Texture2D sceneTexture, Color backgroundColor)
        {
            this.game = game;
            this.sceneTexture = sceneTexture;
            this.BackgroundColor = backgroundColor;
            this.OffsetX = 0F;
            this.OffsetY = 0F;
        }

        public float OffsetX { get; set; }

        public float OffsetY { get; set; }

        public int Width => sceneTexture == null ? 0 : sceneTexture.Width;

        public int Height => sceneTexture == null ? 0 : sceneTexture.Height;

        public int Count => gameComponents.Count;

        public bool IsReadOnly => false;

        public bool Ended => ended;

        public Color BackgroundColor { get; }

        public IOvowGame Game => this.game;

        public Rectangle BoundingBox => new Rectangle((int)OffsetX, (int)OffsetX, Width, Height);

        public Vector2 Position => new Vector2(OffsetX, OffsetY);

        public Texture2D Texture => sceneTexture;

        public Guid Id => id;

        public ITransition In { get; protected set; }

        public ITransition Out { get; protected set; }

        public void Add(IComponent item)
        {
            gameComponents.Add(item);
        }

        public void Clear() => gameComponents.Clear();

        public bool Contains(IComponent item) => gameComponents.Contains(item);

        public void CopyTo(IComponent[] array, int arrayIndex) => gameComponents.CopyTo(array, arrayIndex);

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.game.GraphicsDevice.Clear(BackgroundColor);

            gameComponents
                .Where(c => c is IVisibleComponent)
                .Select(c => c as IVisibleComponent)
                .ToList()
                .ForEach(vc => vc.Draw(gameTime, spriteBatch));

            if (this.ending && !this.ended && this.Out != null)
            {
                this.Out.Draw(gameTime, spriteBatch);
            }

        }

        public virtual void End()
        {
            if (!ended)
            {
                lock (endingSyncLock)
                {
                    if (!ended)
                    {
                        ending = true;
                        if (this.Out == null)
                        {
                            DoEnd();
                        }
                    }
                }
            }
        }

        public bool Equals(IComponent other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var otherScene = other as IScene;
            if (otherScene == null)
            {
                return false;
            }

            return id.Equals(otherScene.Id);
        }

        public IEnumerator<IComponent> GetEnumerator() => gameComponents.GetEnumerator();

        public abstract void Load(ContentManager contentManager);

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            Game.MessageDispatcher.DispatchMessageAsync(this, message);
        }

        public bool Remove(IComponent item) => gameComponents.Remove(item);

        public void Subscribe<TMessage>(Action<object, TMessage> handler) where TMessage : IMessage => Game.MessageDispatcher.RegisterHandler(handler);

        public virtual void Update(GameTime gameTime)
        {
            gameComponents
                .ToList()
                .ForEach(c => c.Update(gameTime));

            if (ending && !ended && this.Out != null)
            {
                this.Out.Update(gameTime);
                if (this.Out.Ended)
                {
                    DoEnd();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => gameComponents.GetEnumerator();

        private void DoEnd()
        {
            Clear();
            Publish(new SceneEndedMessage(this));
            ended = true;
        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing) { }

        ~Scene()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}