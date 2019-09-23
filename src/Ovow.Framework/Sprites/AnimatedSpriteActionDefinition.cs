using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Sprites
{
    public sealed class AnimatedSpriteActionDefinition
    {
        public AnimatedSpriteActionDefinition()
        {
            Frames = new List<AnimatedSpriteActionFrameDefinition>();
        }

        public string Name { get; set; }

        public List<AnimatedSpriteActionFrameDefinition> Frames { get; set; }
    }
}
