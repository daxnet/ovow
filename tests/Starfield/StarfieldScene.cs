using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework;
using Ovow.Framework.Components;
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

namespace Starfield
{
    public sealed class StarfieldScene : Scene
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private const int NumOfStars = 300;
        private Texture2D _starTexture;
        private SpriteFont font;
        private Text fpsText;

        public StarfieldScene(IOvowGame game) : base(game, Color.Black)
        {
            Subscribe<FpsMessage>((sender, e) =>
            {
                fpsText.Value = $"FPS: {e.Fps}";
            });

            Subscribe<ReachBoundaryMessage>(HandleReachBoundaryMessage);

            this.Add(new FpsService(this));
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
            fpsText = new Text("", this, font, Color.White) { CollisionDetective = false };
            Add(fpsText);
        }

        public override void Update(GameTime gameTime)
        {
            for (var i = 0; i < 2; i++)
            {
                Add(new Star(this, _starTexture, new Vector2(this.ViewportWidth / 2, this.ViewportHeight / 2)));
            }

            base.Update(gameTime);
        }
    }
}
