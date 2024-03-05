using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework;
using Ovow.Framework.Components;
using Ovow.Framework.Forms;
using Ovow.Framework.Messaging;
using Ovow.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGameDemo.Forms
{
    public sealed class GameScene : FormScene
    {
        private const int NumOfBalls = 20;
        private const int MaxDelta = 10;

        // private int times = 0;
        private static readonly object sync = new object();

        private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);
        private Texture2D spriteTexture;
        private SpriteFont font;
        private Text fpsText;

        public GameScene(IOvowGame game) : base(game)
        {
            Subscribe<FpsMessage>((sender, e) =>
            {
                fpsText.Value = $"FPS: {e.Fps}";
            });

            Subscribe<ParameterChangedMessage>((sender, e) =>
            {
                switch (e.Name)
                {
                    case "balls":
                        UpdateBalls(Convert.ToInt32(e.NewValue));
                        break;
                }
            });
        }

        private void UpdateBalls(int num)
        {
            this.RemoveAll<JumpingSprite>(x => x is JumpingSprite);
            CreateBalls(num);
        }

        public override void Load(ContentManager contentManager)
        {
            spriteTexture = contentManager.Load<Texture2D>("football");


            CreateBalls(NumOfBalls);
            

            font = contentManager.Load<SpriteFont>("text");
            fpsText = new Text("", this, font, Color.White) { CollisionDetective = false };
            Add(fpsText);

            this.Add(new FpsService(this));
            this.Add(new CollisionDetectionService(this));
        }

        private void CreateBalls(int num)
        {
            var screenWidth = Game.GraphicsDeviceInstance.Viewport.Width;
            var screenHeight = Game.GraphicsDeviceInstance.Viewport.Height;
            for (var i = 0; i < num; i++)
            {
                var initialX = rnd.Next(1, screenWidth - spriteTexture.Width);
                var initialY = rnd.Next(1, screenHeight - spriteTexture.Height);
                var dX = (rnd.Next(1, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);
                var dY = (rnd.Next(1, MaxDelta + 1)) * (rnd.Next(2) == 0 ? -1 : 1);

                var footballSprite = new JumpingSprite(this, spriteTexture, new Vector2(initialX, initialY), dX, dY);

                this.Add(footballSprite);
            }
        }
    }
}
