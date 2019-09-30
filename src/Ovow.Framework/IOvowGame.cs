using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using Ovow.Framework.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    /// <summary>
    /// Represents that the implemented classes are the games created by Ovow Framework.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.ICollection{Ovow.Framework.Scenes.IScene}" />
    /// <seealso cref="System.IDisposable" />
    public interface IOvowGame : ICollection<IScene>, IDisposable
    {
        IScene ActiveScene { get; }

        IMessageDispatcher MessageDispatcher { get; }

        GraphicsDevice GraphicsDevice { get; }

        void Exit();
    }
}
