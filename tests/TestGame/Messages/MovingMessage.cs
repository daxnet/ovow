using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame.Messages
{
    public class MovingMessage : IMessage
    {
        private readonly Guid id = Guid.NewGuid();
        private readonly DateTime timestamp = DateTime.UtcNow;

        public MovingMessage(Direction movingDirection, float delta)
        {
            this.MovingDirection = movingDirection;
            this.Delta = delta;
        }

        public Guid Id => id;

        public DateTime Timestamp => timestamp;

        public Direction MovingDirection { get; }

        public float Delta { get; }


        [Flags]
        public enum Direction
        {
            Up = 1,
            Down = 2,
            Left = 4,
            Right = 8
        }
    }
}
