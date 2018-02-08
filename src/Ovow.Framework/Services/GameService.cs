using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ovow.Framework.Services
{
    public abstract class GameService : Component, IGameService
    {
        private readonly IOvowGame game;

        protected GameService(IOvowGame game)
        {
            this.game = game;
        }

        public IOvowGame Game => game;
    }
}
