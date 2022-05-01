using Ovow.Framework;

namespace PingPongGameDemo
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
