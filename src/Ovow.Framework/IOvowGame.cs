using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    public interface IOvowGame
    {
        void AddGameComponent(IComponent component);

        IEnumerable<Scene> Scenes { get; }

        IEnumerable<IComponent> OvowGameComponents { get; }

        IMessageDispatcher MessageDispatcher { get; }

        GraphicsDevice GraphicsDevice { get; }
    }
}
