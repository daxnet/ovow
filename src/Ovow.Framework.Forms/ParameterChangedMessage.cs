using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework.Forms
{
    public class ParameterChangedMessage : Message
    {
        public ParameterChangedMessage(string name, string oldValue, string newValue)
            => (Name, OldValue, NewValue) = (name, oldValue, newValue);

        public string Name { get; }

        public string OldValue { get; }

        public string NewValue { get; }
    }
}
