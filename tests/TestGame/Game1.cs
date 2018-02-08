using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Messaging.GeneralMessages;
using TestGame.Messages;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : OvowGame
    {
        // private const float MovingDelta = 8;
        private Texture2D football;

        private float xDelta1 = 15;
        private float yDelta1 = 12;

        private float xDelta2 = -15;
        private float yDelta2 = -12;

        private Sprite footballSprite1;
        private Sprite footballSprite2;

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

            footballSprite1 = new Sprite(this, football, new Vector2(200, 200));
            footballSprite1.Subscribe<ReachBoundaryMessage>(m =>
            {
                if ((m.ReachedBoundary & ReachBoundaryMessage.Boundary.Left) == ReachBoundaryMessage.Boundary.Left ||
                (m.ReachedBoundary & ReachBoundaryMessage.Boundary.Right) == ReachBoundaryMessage.Boundary.Right)
                {
                    xDelta1 = -xDelta1;
                }

                if ((m.ReachedBoundary & ReachBoundaryMessage.Boundary.Top) == ReachBoundaryMessage.Boundary.Top ||
                (m.ReachedBoundary & ReachBoundaryMessage.Boundary.Bottom) == ReachBoundaryMessage.Boundary.Bottom)
                {
                    yDelta1 = -yDelta1;
                }
            });

            footballSprite2 = new Sprite(this, football, new Vector2(50, 50));
            footballSprite2.Subscribe<ReachBoundaryMessage>(m =>
            {
                if ((m.ReachedBoundary & ReachBoundaryMessage.Boundary.Left) == ReachBoundaryMessage.Boundary.Left ||
                (m.ReachedBoundary & ReachBoundaryMessage.Boundary.Right) == ReachBoundaryMessage.Boundary.Right)
                {
                    xDelta2 = -xDelta2;
                }

                if ((m.ReachedBoundary & ReachBoundaryMessage.Boundary.Top) == ReachBoundaryMessage.Boundary.Top ||
                (m.ReachedBoundary & ReachBoundaryMessage.Boundary.Bottom) == ReachBoundaryMessage.Boundary.Bottom)
                {
                    yDelta2 = -yDelta2;
                }
            });

            this.Add(footballSprite1);
            this.Add(footballSprite2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            footballSprite1.X += xDelta1;
            footballSprite1.Y += yDelta1;

            footballSprite2.X += xDelta2;
            footballSprite2.Y += yDelta2;

            base.Update(gameTime);
        }
    }
}
