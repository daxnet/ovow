using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Scenes
{
    public interface IScene : ICollection<IComponent>, IVisibleComponent
    {
        IOvowGame Game { get; }

        void Load(ContentManager contentManager);

        Color BackgroundColor { get;}

        void End();

        bool Ended { get; }
    }
}
