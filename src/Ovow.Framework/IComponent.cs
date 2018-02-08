using Microsoft.Xna.Framework;
using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    /// <summary>
    /// Represents that the implemented classes are game components.
    /// </summary>
    public interface IComponent : IEquatable<IComponent>
    {
        Guid Id { get; }

        void Update(GameTime gameTime);

    }
}
