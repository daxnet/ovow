using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using PingPongGame.Messages;

namespace PingPongGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : OvowGame
    {
        private const int NumOfBalls = 10;
        private const int MaxDelta = 20;

        private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

        protected override void LoadContent()
        {
            base.LoadContent();
            Texture2D spriteTexture = Content.Load<Texture2D>("football");

            var screenWidth = GraphicsDevice.Viewport.Width;
            var screenHeight = GraphicsDevice.Viewport.Height;

            for (var i = 0; i < NumOfBalls; i++)
            {
                var initialX = rnd.Next(1, screenWidth - spriteTexture.Width);
                var initialY = rnd.Next(1, screenHeight - spriteTexture.Height);
                var dX = (rnd.Next(5, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);
                var dY = (rnd.Next(5, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);

                var footballSprite = new JumpingSprite(this, spriteTexture, new Vector2(initialX, initialY), dX, dY);

                this.AddGameComponent(footballSprite);
            }

            var collisionDetectionService = new CollisionDetectionService(this);
            this.AddGameComponent(collisionDetectionService);
        }
    }
}
