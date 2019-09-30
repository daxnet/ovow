// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Copyright (C) 2019 by daxnet.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework.Messaging;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ovow.Framework
{
    public class OvowGame : Game, IOvowGame
    {
        #region Protected Fields

        protected SpriteBatch spriteBatch;

        #endregion Protected Fields

        #region Private Fields

        private static readonly object sync = new object();
        private readonly GraphicsDeviceManager graphicsDeviceManager;
        private readonly IMessageDispatcher messageDispatcher = new MessageDispatcher();
        private readonly List<IScene> scenes = new List<IScene>();
        private readonly OvowGameWindowSettings windowSettings;
        private bool disposed = false;
        private int sceneIndex = 0;

        #endregion Private Fields

        #region Public Constructors

        public OvowGame()
            : this(OvowGameWindowSettings.NormalScreenShowMouse)
        { }

        public OvowGame(OvowGameWindowSettings windowSettings)
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            this.windowSettings = windowSettings;
            Content.RootDirectory = "Content";

            this.messageDispatcher.RegisterHandler<SceneEndedMessage>((publisher, message) =>
            {
                if (message.Scene == this.scenes[sceneIndex])
                {
                    lock (sync)
                    {
                        if (message.Scene == this.scenes[sceneIndex])
                        {
                            ActiveScene?.Leave();

                            sceneIndex++;

                            if (sceneIndex == scenes.Count)
                            {
                                Exit();
                                return;
                            }

                            ActiveScene?.Enter();
                        }
                    }
                }
            });
        }

        #endregion Public Constructors

        #region Public Properties

        public IScene ActiveScene
        {
            get
            {
                if (sceneIndex >= scenes.Count)
                {
                    return null;
                }

                return scenes[sceneIndex];
            }
        }

        public int Count => scenes.Count;

        public bool IsReadOnly => false;

        public IMessageDispatcher MessageDispatcher => messageDispatcher;

        #endregion Public Properties

        #region Public Methods

        public void Add(IScene item) => scenes.Add(item);

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear() => scenes.Clear();

        public bool Contains(IScene item) => scenes.Contains(item);

        public void CopyTo(IScene[] array, int arrayIndex) => scenes.CopyTo(array, arrayIndex);

        public IEnumerator<IScene> GetEnumerator() => scenes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => scenes.GetEnumerator();

        public bool Remove(IScene item) => scenes.Remove(item);

        #endregion Public Methods

        #region Protected Methods

        protected void Add<TScene>()
            where TScene : Scene
            => Add((TScene)Activator.CreateInstance(typeof(TScene), this));

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    foreach (var scene in scenes)
                    {
                        scene.Dispose();
                    }
                }

                base.Dispose(disposing);
                disposed = true;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();

            ActiveScene?.Draw(gameTime, this.spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            graphicsDeviceManager.IsFullScreen = this.windowSettings.IsFullScreen;
            if (!this.windowSettings.IsFullScreen)
            {
                graphicsDeviceManager.PreferredBackBufferWidth = this.windowSettings.Width;
                graphicsDeviceManager.PreferredBackBufferHeight = this.windowSettings.Height;
            }
            else
            {
                graphicsDeviceManager.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
                graphicsDeviceManager.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            }

            Window.AllowUserResizing = this.windowSettings.AllowUserResizing;
            this.IsMouseVisible = this.windowSettings.MouseVisible;
            graphicsDeviceManager.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.scenes.ForEach(scene => scene.Load(Content));

            ActiveScene?.Enter();
        }

        protected override void Update(GameTime gameTime)
        {
            ActiveScene?.Update(gameTime);

            base.Update(gameTime);
        }

        #endregion Protected Methods
    }
}