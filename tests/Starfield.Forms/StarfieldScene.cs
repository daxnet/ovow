using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework;
using Ovow.Framework.Components;
using Ovow.Framework.Forms;
using Ovow.Framework.Messaging;
using Ovow.Framework.Scenes;
using Ovow.Framework.Services;
using Ovow.Framework.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Starfield.Forms
{
    public sealed class StarfieldScene : FormScene
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private const int NumOfStars = 17;
        private Texture2D _starTexture;
        private SpriteFont font;
        private Text fpsText;
        private Text paramText;

        public StarfieldScene(IOvowGame game) : base(game, Color.Black)
        {
            Subscribe<FpsMessage>((sender, e) =>
            {
                fpsText.Value = $"FPS: {e.Fps}";
            });

            Subscribe<ReachBoundaryMessage>(HandleReachBoundaryMessage);

            this.Add(new FpsService(this));

            SetParameter("numOfStars", "2");
        }

        private void HandleReachBoundaryMessage(object sender, ReachBoundaryMessage message)
        {
            if (sender is Star s && message.ReachedBoundary != Boundary.None)
            {
                s.IsActive = false;
            }
        }

        public override void Load(ContentManager contentManager)
        {
            _starTexture = new Texture2D(Game.GraphicsDeviceInstance, 4, 4, true, SurfaceFormat.Color);

            font = contentManager.Load<SpriteFont>("text");
            fpsText = new Text("", this, font, Color.White, new Vector2(10, 0)) { CollisionDetective = false };
            Add(fpsText);

            paramText = new Text("", this, font, Color.Yellow, new Vector2(280, 0)) { CollisionDetective = false };
            Add(paramText);
        }

        public override void Update(GameTime gameTime)
        {
            var numStars = NumOfStars;
            var numStarsVal = GetParameter("numOfStars");
            
            if (!string.IsNullOrEmpty(numStarsVal))
            {
                int.TryParse(numStarsVal, out numStars);
                paramText.Value = $"Number of Stars in a batch: {numStarsVal}";
            }
            for (var i = 0; i < numStars; i++)
            {
                Add(new Star(this, _starTexture, new Vector2(this.ViewportWidth / 2, this.ViewportHeight / 2)));
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
