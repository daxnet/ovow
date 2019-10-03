using Ovow.Framework;

namespace PingPongGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : OvowGame
    {
        public Game1()
        {
            AddScene<GameScene>("main", true);
            AddScene<GameOverScene>("gameOver");
        }
    }
}
