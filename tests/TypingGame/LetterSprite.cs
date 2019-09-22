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
    internal sealed class LetterSprite : Sprite
    {
        public LetterSprite(IScene scene, 
            Texture2D texture, 
            Vector2 position, 
            char letter, 
            float speed) 
            : base(scene, texture, position)
        {
            Speed = speed;
            Letter = letter;
        }

        public override void Update(GameTime gameTime)
        {
            this.Y += Speed;
            base.Update(gameTime);
        }

        public bool IsRemovable { get; set; }

        public char Letter { get; }

        public float Speed { get; }
    }
}
