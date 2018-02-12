using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Scenes;
using Ovow.Framework.Services;
using System;
using System.Threading;

namespace PingPongGame
{
    internal sealed class GameScene : Scene
    {
        private const int NumOfBalls = 3;
        private const int MaxDelta = 15;

        private TimeSpan ts = TimeSpan.Zero;

        private int times = 0;
        private bool endFired = false;
        private static readonly object sync = new object();

        private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

        public GameScene(IOvowGame game)
            : base(game)
        {
            Subscribe<CollisionDetectedMessage>((publisher, message) =>
            {
                lock (sync)
                {
                    times++;
                    if (times >= 10)
                    {
                        End();
                    }
                }
            });
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
                var dX = (rnd.Next(1, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);
                var dY = (rnd.Next(1, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);

                var footballSprite = new JumpingSprite(this, spriteTexture, new Vector2(initialX, initialY), dX, dY);

                this.Add(footballSprite);
            }

           this.Add(new CollisionDetectionService(this));
        }

        public override void Update(GameTime gameTime)
        {
            if (!Ended && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                endFired = true;
            }

            if (endFired)
            {
                ts += gameTime.ElapsedGameTime;
                if (ts > TimeSpan.FromMilliseconds(150))
                {
                    End();
                }
            }

            base.Update(gameTime);
        }
    }
}
