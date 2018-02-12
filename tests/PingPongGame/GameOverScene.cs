using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Scenes;
using Ovow.Framework.Sprites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGame
{
    internal sealed class GameOverScene : Scene
    {
        private const string Message = "Press SPACE to Exit...";

        public GameOverScene(IOvowGame game)
            : base(game, Color.Black)
        { }

        public override void Load(ContentManager contentManager)
        {
            var font = contentManager.Load<SpriteFont>("text");
            this.Add(new Text(Message, this, font, new TextRenderingOptions(false, Color.Yellow), Vector2.Zero));
        }
          
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //var vector2 = font.MeasureString(Message);
            //var posx = (Game.GraphicsDevice.Viewport.Width - vector2.X) / 2;
            //var posy = (Game.GraphicsDevice.Viewport.Height - vector2.Y) / 2;
            //spriteBatch.DrawString(font, Message, new Vector2(posx, posy), Color.Red);

            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Ended && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                End();
            }

            base.Update(gameTime);
        }
    }
}
