using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Services;
using System;

namespace PingPongGame
{
    internal sealed class GameScene : Scene
    {
        private const int NumOfBalls = 10;
        private const int MaxDelta = 15;

        private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

        public GameScene(IOvowGame game)
            : base(game)
        {
        }

        public override void Load(ContentManager contentManager)
        {
            Texture2D spriteTexture = contentManager.Load<Texture2D>("football");

            var screenWidth = Game.GraphicsDevice.Viewport.Width;
            var screenHeight = Game.GraphicsDevice.Viewport.Height;

            for (var i = 0; i < NumOfBalls; i++)
            {
                var initialX = rnd.Next(1, screenWidth - spriteTexture.Width);
                var initialY = rnd.Next(1, screenHeight - spriteTexture.Height);
                var dX = (rnd.Next(5, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);
                var dY = (rnd.Next(5, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);

                var footballSprite = new JumpingSprite(this, spriteTexture, new Vector2(initialX, initialY), dX, dY);

                this.Add(footballSprite);
            }

            this.Add(new CollisionDetectionService(this));
        }

        public override void Update(GameTime gameTime)
        {
            if (!Ended && Keyboard.GetState().IsKeyDown(Keys.Escape))
                End();

            base.Update(gameTime);
        }
    }
}
