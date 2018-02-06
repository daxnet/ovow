using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ovow.Framework
{
    public class Sprite : VisibleComponent
    {
        private readonly Texture2D texture;

        public Sprite(IOvowGame game, Texture2D texture) : base(game)
        {
            this.texture = texture;
            this.X = 200;
            this.Y = 200;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Vector2(this.X, this.Y), Color.Wheat);
        }

        public override void Update(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
    }
}
