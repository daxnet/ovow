﻿using Ovow.Framework;
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
                IsFullScreen = true
            })
        {
            
            Add<GameScene>();
        }
    }
}