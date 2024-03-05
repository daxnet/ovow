using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using Ovow.Framework.Transitions;

namespace Ovow.Framework.Scenes
{
    public abstract class Scene : IScene
    {

        #region Private Fields

        private static readonly object endingSyncLock = new();
        private readonly ConcurrentDictionary<Guid, IComponent> gameComponents = new();
        private volatile bool ended = false;
        private volatile bool ending = false;

        #endregion Private Fields

        #region Protected Constructors

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
            this.Game = game;
            this.Texture = sceneTexture;
            this.BackgroundColor = backgroundColor;
            this.OffsetX = 0F;
            this.OffsetY = 0F;
            AutoRemoveInactiveComponents = true;
        }

        #endregion Protected Constructors

        #region Private Destructors

        ~Scene()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        #endregion Private Destructors

        #region Public Properties

        public bool AutoRemoveInactiveComponents { get; protected set; }

        public Color BackgroundColor { get; }
        public Rectangle BoundingBox => new Rectangle((int)OffsetX, (int)OffsetX, Width, Height);
        public bool CollisionDetective => false;
        public int Count => gameComponents.Count;
        public bool Ended => ended;
        public IOvowGame Game { get; }
        public int Height => Texture == null ? 0 : Texture.Height;
        public Guid Id { get; } = Guid.NewGuid();
        public ITransition In { get; protected set; }
        public bool IsActive { get; set; }
        public bool IsReadOnly => false;
        public IScene Next
        {
            get
            {
                if (string.IsNullOrEmpty(NextSceneName))
                {
                    return null;
                }

                return Game.GetSceneByName(NextSceneName);
            }
        }

        public float OffsetX { get; set; }

        public float OffsetY { get; set; }

        public ITransition Out { get; protected set; }
        public Vector2 Position => new Vector2(OffsetX, OffsetY);
        public Texture2D Texture { get; }
        public int ViewportHeight => Game.GraphicsDeviceInstance.Viewport.Height;
        public int ViewportWidth => Game.GraphicsDeviceInstance.Viewport.Width;
        public int Width => Texture == null ? 0 : Texture.Width;

        #endregion Public Properties

        #region Protected Properties

        protected virtual string NextSceneName { get; set; }

        #endregion Protected Properties

        #region Public Methods

        public void Add(IComponent item) => gameComponents.TryAdd(item.Id, item);

        public void Clear() => gameComponents.Clear();
        public bool Contains(IComponent item) => gameComponents.ContainsKey(item.Id);

        public void CopyTo(IComponent[] array, int arrayIndex)
        {
            var list = gameComponents.Values.ToList();
            list.CopyTo(array, arrayIndex);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.Game.GraphicsDeviceInstance.Clear(BackgroundColor);

            var query = from c in gameComponents
                        where c.Value is IVisibleComponent
                        select c.Value as IVisibleComponent;
            foreach(var item in query)
            {
                item.Draw(gameTime, spriteBatch);
            }

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

        public void EndTo(string sceneName)
        {
            NextSceneName = sceneName;
            End();
        }
        public virtual void Enter() { }

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

            return Id.Equals(otherScene.Id);
        }

        public IEnumerator<IComponent> GetEnumerator() => gameComponents.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => gameComponents.GetEnumerator();

        public virtual void Leave() { }

        public abstract void Load(ContentManager contentManager);

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            Game.MessageDispatcher.DispatchMessageAsync(this, message);
        }

        public bool Remove(IComponent item) => gameComponents.TryRemove(item.Id, out var _);

        public void RemoveAll<TComponent>(Predicate<TComponent> predicate = null)
            where TComponent : IComponent
        {
            foreach (var kvp in from kvp in gameComponents
                                where kvp.Value is TComponent tc && predicate(tc)
                                select kvp)
            {
                kvp.Value.IsActive = false;
            }
        }

        public void Subscribe<TMessage>(Action<object, TMessage> handler) where TMessage : IMessage => Game.MessageDispatcher.RegisterHandler(handler);

        public virtual void Update(GameTime gameTime)
        {
            var inactiveIdList = from c in gameComponents
                      where !c.Value.IsActive
                      select c.Key;

            Parallel.ForEach(inactiveIdList, id => gameComponents.TryRemove(id, out var _));

            var activeComponents = from c in gameComponents
                                 where c.Value.IsActive
                                 select c.Value;

            Parallel.ForEach(activeComponents, c => c.Update(gameTime));

            if (ending && !ended && this.Out != null)
            {
                this.Out.Update(gameTime);
                if (this.Out.Ended)
                {
                    DoEnd();
                }
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing) { }

        #endregion Protected Methods

        #region Private Methods

        private void DoEnd()
        {
            Clear();
            Publish(new SceneEndedMessage(this));
            ended = true;
        }

        #endregion Private Methods

    }
}
