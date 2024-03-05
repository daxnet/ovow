using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Components;
using Ovow.Framework.Messaging;
using Ovow.Framework.Scenes;
using Ovow.Framework.Services;
using Ovow.Framework.Sprites;
using Ovow.Framework.Transitions;
using System;

namespace PingPongGameDemo
{
    internal sealed class GameScene : Scene
    {
        private const int NumOfBalls = 10;
        private const int MaxDelta = 10;

        // private int times = 0;
        private static readonly object sync = new object();

        private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);
        private Texture2D spriteTexture;
        private SpriteFont font;
        private Text fpsText;

        public GameScene(IOvowGame game)
            : base(game)
        {
            NextSceneName = "gameOver";
            Subscribe<FpsMessage>((sender, e) =>
            {
                fpsText.Value = $"FPS: {e.Fps}";
            });
            Out = new DelayTransition(this, TimeSpan.FromMilliseconds(200));
        }

        public override void Load(ContentManager contentManager)
        {
            spriteTexture = contentManager.Load<Texture2D>("football");

            var screenWidth = Game.GraphicsDeviceInstance.Viewport.Width;
            var screenHeight = Game.GraphicsDeviceInstance.Viewport.Height;

            for (var i = 0; i < NumOfBalls; i++)
            {
                var initialX = rnd.Next(1, screenWidth - spriteTexture.Width);
                var initialY = rnd.Next(1, screenHeight - spriteTexture.Height);
                var dX = (rnd.Next(1, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);
                var dY = (rnd.Next(1, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);

                var footballSprite = new JumpingSprite(this, spriteTexture, new Vector2(initialX, initialY), dX, dY);

                this.Add(footballSprite);
            }

            font = contentManager.Load<SpriteFont>("text");
            fpsText = new Text("", this, font, Color.White) { CollisionDetective = false };
            Add(fpsText);

            this.Add(new FpsService(this));
            this.Add(new CollisionDetectionService(this));
        }

        public override void Update(GameTime gameTime)
        {
            if (!Ended && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                End();
            }

            base.Update(gameTime);
        }


        private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    spriteTexture.Dispose();
                }
                disposed = true;
            }
        }
    }
}
