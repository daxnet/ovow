using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Ovow.Framework.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Scenes
{
    public interface IScene : ICollection<IComponent>, IVisibleComponent, IDisposable
    {
        IOvowGame Game { get; }

        ITransition In { get; }

        ITransition Out { get; }

        void Load(ContentManager contentManager);

        Color BackgroundColor { get;}

        void Enter();

        void Leave();

        void End();

        bool Ended { get; }
    }
}
