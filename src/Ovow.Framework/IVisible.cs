using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    public interface IVisible : IComponent
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
