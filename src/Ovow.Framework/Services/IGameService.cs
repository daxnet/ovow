using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Services
{
    public interface IGameService : IComponent
    {
        IOvowGame Game { get; }
    }
}
