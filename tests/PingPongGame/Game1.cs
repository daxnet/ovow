using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ovow.Framework;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using PingPongGame.Messages;

namespace PingPongGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : OvowGame
    {
        public Game1()
        {
            Add<GameScene>();
            Add<GameOverScene>();
        }
    }
}
