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
        void Add(IComponent component);

        IEnumerable<Scene> Scenes { get; }

        IEnumerable<IComponent> OvowGameComponents { get; }

        IMessageDispatcher MessageDispatcher { get; }
    }
}
