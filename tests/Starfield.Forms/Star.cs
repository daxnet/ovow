using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Scenes;
using Ovow.Framework.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfield.Forms
{
    public sealed class Star : Sprite
    {
        private readonly Color[] _colors;
        private readonly Random _rnd = new Random(DateTime.Now.Millisecond);
        private double _deltaX;
        private double _deltaY;

        public Star(IScene scene, Texture2D texture, Vector2 position) : base(scene, texture, position)
        {
            _colors = new Color[16];
            for (var x = 0; x < 16; x++) _colors[x] = Color.White;

            texture.SetData(_colors);
            _deltaX = _rnd.NextDouble() * 10 * (_rnd.Next(2) == 1 ? 1 : -1);
            _deltaY = _rnd.NextDouble() * 10 * (_rnd.Next(2) == 1 ? 1 : -1);
        }

        public override void Update(GameTime gameTime)
        {
            X += (float)_deltaX;
            Y += (float)_deltaY;

            base.Update(gameTime);
        }

        protected override void DoDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.DoDraw(gameTime, spriteBatch);
        }
    }
}
