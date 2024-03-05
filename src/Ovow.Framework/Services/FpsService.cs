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
    public sealed class FpsService : GameService
    {
        private double _now = 0;
        private double _elapsed = 0;
        private double _last = 0;
        private double _updates = 0;
        private double _updateFrequency = 0;

        public FpsService(IScene scene, double updateFrequency = 1) : base(scene)
        {
            _updateFrequency = updateFrequency;
        }

        public override void Update(GameTime gameTime)
        {
            _now = gameTime.TotalGameTime.TotalSeconds;
            _elapsed = (double)(_now - _last);
            if (_elapsed > _updateFrequency)
            {
                Publish(new FpsMessage((float)(_updates / _elapsed)));
                _elapsed = 0;
                _last = _now;
                _updates = 0;
            }

            _updates++;
        }
    }
}
