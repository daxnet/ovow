using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGame
{
    internal sealed class GameOverScene : Scene
    {
        private const string Message = "Press SPACE to Exit...";
        private SpriteFont font;

        public GameOverScene(IOvowGame game)
            : base(game, Color.Black)
        { }

        public override void Load(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("text");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var vector2 = font.MeasureString(Message);
            var posx = (Game.GraphicsDevice.Viewport.Width - vector2.X) / 2;
            var posy = (Game.GraphicsDevice.Viewport.Height - vector2.Y) / 2;
            spriteBatch.DrawString(font, Message, new Vector2(posx, posy), Color.Red);

            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Ended && Keyboard.GetState().IsKeyDown(Keys.Space))
                End();

            base.Update(gameTime);
        }
    }
}
