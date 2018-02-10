using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestGame.Messages;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : OvowGame
    {
        private const int NumOfBalls = 8;
        private const int MaxDelta = 10;

        private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

        private Texture2D football;

        public Game1()
        {

        }

        protected override void Initialize()
        {
            GraphicsDeviceManager.IsFullScreen = false;
            // GraphicsDeviceManager.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            // GraphicsDeviceManager.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            GraphicsDeviceManager.PreferredBackBufferWidth = 1024;
            GraphicsDeviceManager.PreferredBackBufferHeight = 768;
            GraphicsDeviceManager.ApplyChanges();
            base.Initialize();
            Window.AllowUserResizing = true;
            GraphicsDeviceManager.ApplyChanges();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            football = this.Content.Load<Texture2D>("football");

            var screenWidth = GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
            var screenHeight = GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

            for (var i = 0; i < NumOfBalls; i++)
            {
                var initialX = rnd.Next(1, screenWidth - football.Width);
                var initialY = rnd.Next(1, screenHeight - football.Height);
                var dX = (rnd.Next(5, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);
                var dY = (rnd.Next(5, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);

                var footballSprite = new JumpingSprite(this, football, new Vector2(initialX, initialY), dX, dY);
                footballSprite.Subscribe<ReachBoundaryMessage>((publisher, message) =>
                {
                    if (publisher == footballSprite)
                    {
                        if ((message.ReachedBoundary & ReachBoundaryMessage.Boundary.Left) == ReachBoundaryMessage.Boundary.Left ||
                        (message.ReachedBoundary & ReachBoundaryMessage.Boundary.Right) == ReachBoundaryMessage.Boundary.Right)
                        {
                            footballSprite.DX *= -1;
                        }

                        if ((message.ReachedBoundary & ReachBoundaryMessage.Boundary.Top) == ReachBoundaryMessage.Boundary.Top ||
                        (message.ReachedBoundary & ReachBoundaryMessage.Boundary.Bottom) == ReachBoundaryMessage.Boundary.Bottom)
                        {
                            footballSprite.DY *= -1;
                        }
                    }
                });

                footballSprite.Subscribe<CollisionDetectedMessage>((publisher, message) =>
                {
                    if (message.A.Equals(footballSprite))
                    {
                        var selfOrientation = footballSprite.Orientation;
                        var collisionOrientation = message.CollisionInformationA.Orientation;
                        if ((selfOrientation & collisionOrientation & Orientation.East) == Orientation.East ||
                            (selfOrientation & collisionOrientation & Orientation.West) == Orientation.West)
                        {
                            footballSprite.DX *= -1;
                        }

                        if ((selfOrientation & collisionOrientation & Orientation.North) == Orientation.North ||
                            (selfOrientation & collisionOrientation & Orientation.South) == Orientation.South)
                        {
                            footballSprite.DY *= -1;
                        }
                    }
                });

                this.Add(footballSprite);
            }

            var collisionDetectionService = new CollisionDetectionService(this);
            this.Add(collisionDetectionService);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Parallel.ForEach(this.OvowGameComponents, component =>
            {
                var viewportWidth = GraphicsDevice.Viewport.Width;
                var viewportHeight = GraphicsDevice.Viewport.Height;
                if (component is JumpingSprite)
                {
                    var js = component as JumpingSprite;
                    
                    // Fix the issue that when the sprite X or Y plus the delta is out of the viewport boundary.
                    if (js.X + js.DX <= 0 || js.X + js.DX >= viewportWidth - js.Width)
                    {
                        js.DX *= -1;
                    }

                    if (js.Y + js.DY <= 0 || js.Y + js.DY >= viewportHeight - js.Height)
                    {
                        js.DY *= -1;
                    }

                    js.X += js.DX;
                    js.Y += js.DY;
                }
            });

            base.Update(gameTime);
        }
    }
}
