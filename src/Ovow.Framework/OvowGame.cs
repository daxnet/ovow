using Microsoft.Xna.Framework;
using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    public class OvowGame : Game, IOvowGame
    {
        private readonly IMessageDispatcher messageDispatcher = new MessageDispatcher();

        public OvowGame()
        {
        }

        public IEnumerable<Scene> Scenes => throw new NotImplementedException();

        public IMessageDispatcher MessageDispatcher => messageDispatcher;
    }
}
