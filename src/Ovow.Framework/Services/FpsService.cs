using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Ovow.Framework.Scenes;

namespace Ovow.Framework.Services
{
    public sealed class FpsService : GameService
    {
        public FpsService(IScene scene) : base(scene)
        {
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
