using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Ovow.Framework
{
    public abstract class Component : IComponent
    {
        private readonly Guid id = Guid.NewGuid();

        public Guid Id => id;

        public bool Equals(IComponent other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is null)
            {
                return false;
            }

            return other.Id.Equals(this.id);
        }

        public abstract void Update(GameTime gameTime);
    }
}
