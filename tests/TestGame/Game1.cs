using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using TestGame.Messages;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : OvowGame
    {
        private const float MovingDelta = 10;
        private Texture2D star;

        public Game1()
        {

        }

        protected override void LoadContent()
        {
            base.LoadContent();
            star = this.Content.Load<Texture2D>("star");
            var starSprite = new Sprite(this, star, new Vector2(200, 200));
            starSprite.Subscribe<MovingMessage>(mm =>
            {
                switch (mm.MovingDirection)
                {
                    case MovingMessage.Direction.Up:
                        starSprite.Y -= mm.Delta;
                        break;
                    case MovingMessage.Direction.Down:
                        starSprite.Y += mm.Delta;
                        break;
                    case MovingMessage.Direction.Left:
                        starSprite.X -= mm.Delta;
                        break;
                    case MovingMessage.Direction.Right:
                        starSprite.X += mm.Delta;
                        break;
                }
            });

            starSprite.Subscribe<ResetLocationMessage>(rm =>
            {
                starSprite.X = 200; starSprite.Y = 200;
            });

            this.Add(starSprite);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                this.MessageDispatcher.DispatchMessage<MovingMessage>(new MovingMessage(MovingMessage.Direction.Up, MovingDelta));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this.MessageDispatcher.DispatchMessage<MovingMessage>(new MovingMessage(MovingMessage.Direction.Down, MovingDelta));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.MessageDispatcher.DispatchMessage<MovingMessage>(new MovingMessage(MovingMessage.Direction.Left, MovingDelta));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.MessageDispatcher.DispatchMessage<MovingMessage>(new MovingMessage(MovingMessage.Direction.Right, MovingDelta));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                this.MessageDispatcher.DispatchMessage(new ResetLocationMessage());
            }

            base.Update(gameTime);
        }
    }
}
