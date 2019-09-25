using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Scenes;

namespace Ovow.Framework.Sprites
{
    public sealed class DumbSprite : Sprite
    {
        public DumbSprite(IScene scene, Texture2D texture, Vector2 position) : base(scene, texture, position)
        {
        }

        public override bool CollisionDetective { get => false; set { } }
    }
}
