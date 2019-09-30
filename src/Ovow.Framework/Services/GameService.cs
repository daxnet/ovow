using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Ovow.Framework.Messaging;
using Ovow.Framework.Scenes;

namespace Ovow.Framework.Services
{
    public abstract class GameService : Component, IGameService
    {
        private readonly IScene scene;

        protected GameService(IScene scene)
        {
            this.scene = scene;
        }

        public IScene Scene => scene;

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            scene.Game.MessageDispatcher.DispatchMessageAsync(this, message);
        }
    }
}
