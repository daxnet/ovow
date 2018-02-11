using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    public interface IScene : ICollection<IComponent>, IVisibleComponent
    {
        Color BackgroundColor { get;}

        void End();
    }
}
