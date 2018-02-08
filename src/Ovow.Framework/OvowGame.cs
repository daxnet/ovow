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
        private readonly IMessageDispatcher messageDispatcher = new MessageDispatcher();
        private readonly List<IComponent> ovowGameComponents = new List<IComponent>();

        protected SpriteBatch spriteBatch;

        public OvowGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            ovowGameComponents.ForEach(x => x.Update(gameTime));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            Parallel.ForEach(ovowGameComponents
                .Where(x => x is IVisibleComponent)
                .Select(x => x as IVisibleComponent), visibleComponent => visibleComponent.Draw(gameTime, this.spriteBatch));

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Add(IComponent component)
        {
            this.ovowGameComponents.Add(component);
        }

        public IEnumerable<IComponent> OvowGameComponents => this.ovowGameComponents;

        public IEnumerable<Scene> Scenes => throw new NotImplementedException();

        public IMessageDispatcher MessageDispatcher => messageDispatcher;

        public GraphicsDeviceManager GraphicsDeviceManager => graphicsDeviceManager;
    }
}
