using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Components;
using Ovow.Framework.Scenes;
using Ovow.Framework.Sprites;

namespace PingPongGame
{
    internal sealed class GameOverScene : Scene
    {
        private const string Message = "Press ESC to Exit...";
        private SpriteFont font;

        public GameOverScene(IOvowGame game)
            : base(game, Color.MediumVioletRed)
        { }

        public override void Load(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("text");
            this.Add(new Text(Message, this, font, new TextRenderingOptions(false, Color.Yellow), new Vector2(100, 100)));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
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
