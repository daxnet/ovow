using Ovow.Framework.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Transitions
{
    public interface ITransition : IVisibleComponent
    {
        IScene Scene { get; }

        bool Ended { get; }
    }
}
