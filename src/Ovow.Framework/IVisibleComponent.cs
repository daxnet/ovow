﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    public interface IVisibleComponent : IComponent, IMessagePublisher, IMessageSubscriber
    {
        Rectangle BoundingBox { get; }

        Vector2 Position { get; }

        Texture2D Texture { get; }

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        bool CollisionDetective { get; }
    }
}
