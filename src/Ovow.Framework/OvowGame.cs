using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
