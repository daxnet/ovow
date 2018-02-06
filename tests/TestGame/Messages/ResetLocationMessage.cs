using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame.Messages
{
    public class ResetLocationMessage : IMessage
    {
        private readonly Guid id = Guid.NewGuid();
        private readonly DateTime timestamp = DateTime.UtcNow;

        public Guid Id => id;

        public DateTime Timestamp => timestamp;
    }
}
