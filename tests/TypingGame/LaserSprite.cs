using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Scenes;
using Ovow.Framework.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingGame
{
    internal sealed class LaserSprite : Sprite
    {
        public LaserSprite(IScene scene, Texture2D texture, Vector2 position, char letter) : base(scene, texture, position)
        {
            Letter = letter;
        }

        public override void Update(GameTime gameTime)
        {
            this.Y -= 20;
            base.Update(gameTime);
        }

        public char Letter { get; }
    }
}
