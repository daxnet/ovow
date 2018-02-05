using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Messaging
{
    public interface IMessage
    {
        Guid Id { get; }

        DateTime Timestamp { get; }


    }
}
