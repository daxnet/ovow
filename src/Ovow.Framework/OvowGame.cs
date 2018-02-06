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
        private readonly List<IVisible> gameVisibles = new List<IVisible>();

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

            gameVisibles.ForEach(x => x.Update(gameTime));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            gameVisibles.ForEach(x => x.Draw(gameTime, this.spriteBatch));
            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        protected IList<IVisible> GameVisibles => gameVisibles;

        public IEnumerable<Scene> Scenes => throw new NotImplementedException();

        public IMessageDispatcher MessageDispatcher => messageDispatcher;
    }
}
