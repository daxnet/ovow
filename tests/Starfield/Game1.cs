using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;

namespace Starfield
{
    public class Game1 : OvowGame
    {
        public Game1()
        {
            AddScene<StarfieldScene>("starField", true);
        }
    }
}