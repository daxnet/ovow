using Ovow.Framework.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Messaging.GeneralMessages
{
    public sealed class SceneEndedMessage : Message
    {
        public SceneEndedMessage(IScene scene)
        {
            this.Scene = scene;
        }

        public IScene Scene { get; }
    }
}
