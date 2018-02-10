using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Ovow.Framework.Messaging.GeneralMessages;

namespace Ovow.Framework.Services
{
    public sealed class CollisionDetectionService : GameService
    {
        private static readonly CollisionDetector detector = new CollisionDetector();

        public CollisionDetectionService(IOvowGame game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            var list = this.Game.OvowGameComponents.Where(c => c is IVisibleComponent).ToList();
            var aArray = new IVisibleComponent[list.Count];
            var bArray = new IVisibleComponent[list.Count];
            list.CopyTo(aArray);
            list.CopyTo(bArray);
            foreach (var elementA in aArray)
            {
                foreach (var elementB in bArray)
                {
                    if (elementA.Equals(elementB))
                    {
                        continue;
                    }

                    if (detector.Collides(elementA, elementB, out var infoA, out var infoB, true))
                    {
                        var message = new CollisionDetectedMessage(elementA, elementB, infoA, infoB);
                        this.Game.MessageDispatcher.DispatchMessage(this, message);
                    }
                }
            }
        }
    }
}
