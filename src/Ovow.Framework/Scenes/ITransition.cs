using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Scenes
{
    public interface ITransition : IVisibleComponent
    {
        IScene Scene { get; }
    }
}
