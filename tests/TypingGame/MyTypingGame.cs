using Ovow.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingGame
{
    internal sealed class MyTypingGame : OvowGame
    {
        public MyTypingGame()
            : base(new OvowGameWindowSettings
            {
                MouseVisible = true,
                Width = 1024,
                Height = 768,
                AllowUserResizing = false,
                IsFullScreen = false
            })
        {
            Add<GameScene>();
        }
    }
}
