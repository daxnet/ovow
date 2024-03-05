// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Author: daxnet.
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
using MonoGame.Forms.Controls;
using Ovow.Framework.Messaging;
using Ovow.Framework.Scenes;
using System;
using System.Collections.Generic;

namespace Ovow.Framework.Forms
{
    public partial class OvowGameControl : MonoGameControl, IOvowGame
    {
        #region Private Fields

        private static readonly object _sync = new object();
        private readonly Dictionary<string, IFormScene> scenes = new Dictionary<string, IFormScene>();

        #endregion Private Fields

        #region Public Constructors

        public OvowGameControl()
        {
            InitializeComponent();
            this.MessageDispatcher.RegisterHandler<SceneEndedMessage>((publisher, message) =>
            {
                lock (_sync)
                {
                    ActiveScene?.Leave();

                    ActiveScene = ActiveScene.Next;

                    if (ActiveScene == null)
                    {
                        Exit();
                        return;
                    }

                    ActiveScene?.Enter();
                }
            });
        }

        #endregion Public Constructors

        #region Public Properties

        public IFormScene ActiveFormScene => ActiveScene as IFormScene;
        public IScene ActiveScene { get; set; }
        public GraphicsDevice GraphicsDeviceInstance => base.GraphicsDevice;
        public IMessageDispatcher MessageDispatcher { get; } = new MessageDispatcher();

        public SpriteBatchDrawOptions SpriteBatchDrawOptions { get; set; } = SpriteBatchDrawOptions.Default;

        #endregion Public Properties

        #region Public Methods

        public void AddScene(string name, IFormScene item, bool isEntryScene = false)
        {
            if (isEntryScene)
            {
                if (ActiveScene == null)
                {
                    ActiveScene = item;
                }
                else
                {
                    throw new InvalidOperationException("There is already a scene that is marked as the entry scene.");
                }
            }

            this.scenes.Add(name, item);
        }

        public void AddScene<TScene>(string name, bool isEntryScene = false)
            where TScene : IFormScene
            => AddScene(name, (TScene)Activator.CreateInstance(typeof(TScene), this), isEntryScene);

        public void Exit()
        { }

        public IScene GetSceneByName(string sceneName) => scenes[sceneName];

        #endregion Public Methods

        #region Protected Methods

        protected override void Draw()
        {
            base.Draw();

            var gameTime = new GameTime();

            Editor.spriteBatch.Begin(
                SpriteBatchDrawOptions.SpriteSortMode,
                SpriteBatchDrawOptions.BlendState,
                SpriteBatchDrawOptions.SamplerState,
                SpriteBatchDrawOptions.DepthStencilState,
                SpriteBatchDrawOptions.RasterizerState,
                SpriteBatchDrawOptions.Effect,
                SpriteBatchDrawOptions.TransformMatrix);

            ActiveScene?.Draw(gameTime, Editor.spriteBatch);

            Editor.spriteBatch.End();
        }

        protected override void Initialize()
        {
            base.Initialize();
            foreach (var kvp in this.scenes)
            {
                kvp.Value.Load(this.Editor.Content);
            }

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