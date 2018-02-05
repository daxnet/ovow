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
        IEnumerable<Scene> Scenes { get; }

        IMessageDispatcher MessageDispatcher { get; }
    }
}
