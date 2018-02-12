using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Sprites
{
    public class Text : VisibleComponent
    {
        private readonly SpriteFont font;
        private readonly string textString;
        private readonly TextRenderingOptions options;

        public Text(string textString, IScene scene, SpriteFont font) 
            : this(textString, scene, font, TextRenderingOptions.DefaultOptions, Vector2.Zero)
        {
        }

        public Text(string textString, IScene scene, SpriteFont font, TextRenderingOptions options, Vector2 position) 
            : base(scene, font.Texture, position)
        {
            this.font = font;
            this.textString = textString;
            this.options = options;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.textString, this.Position, this.options.Color);
        }
    }
}
