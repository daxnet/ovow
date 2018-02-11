// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Copyright (C) 2018 by daxnet.
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ovow.Framework
{
    public class OvowGame : Game, IOvowGame
    {
        private readonly GraphicsDeviceManager graphicsDeviceManager;
        private readonly OvowGameWindowSettings windowSettings;
        private readonly IMessageDispatcher messageDispatcher = new MessageDispatcher();
        private readonly List<IComponent> ovowGameComponents = new List<IComponent>();

        protected SpriteBatch spriteBatch;

        public OvowGame()
            : this(OvowGameWindowSettings.NormalScreenShowMouse)
        { }

        public OvowGame(OvowGameWindowSettings windowSettings)
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            this.windowSettings = windowSettings;
            Content.RootDirectory = "Content";
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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ovowGameComponents
                .ToList()
                .ForEach(c => c.Update(gameTime));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            ovowGameComponents
                .Where(c => c is IVisibleComponent)
                .Select(c => c as IVisibleComponent)
                .ToList()
                .ForEach(vc => vc.Draw(gameTime, this.spriteBatch));

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        public void AddGameComponent(IComponent component)
        {
            this.ovowGameComponents.Add(component);
        }

        public IEnumerable<IComponent> OvowGameComponents => this.ovowGameComponents;

        public IEnumerable<Scene> Scenes => throw new NotImplementedException();

        public IMessageDispatcher MessageDispatcher => messageDispatcher;
    }
}