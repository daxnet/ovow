// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Copyright (C) 2019 by daxnet.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging;
using Ovow.Framework.Messaging.GeneralMessages;
using Ovow.Framework.Scenes;
using System;

namespace Ovow.Framework
{
    public abstract class VisibleComponent : Component, IVisibleComponent
    {
        private readonly IScene scene;

        protected VisibleComponent(IScene scene, Texture2D texture)
            : this(scene, texture, Vector2.Zero)
        {
        }

        protected VisibleComponent(IScene scene, Texture2D texture, Vector2 position)
        {
            this.scene = scene;
            this.Texture = texture;
            this.X = position.X;
            this.Y = position.Y;
            CollisionDetective = true;
        }

        public Texture2D Texture { get; }

        public Vector2 Position => new Vector2(X, Y);

        public float X { get; set; }

        public float Y { get; set; }

        public int Width => this.Texture.Width;

        public int Height => this.Texture.Height;

        protected IScene Scene => this.scene;

        public bool OutOfViewport
        {
            get
            {
                var viewport = scene.Game.GraphicsDevice.Viewport;
                return (X + Width <= 0) || (Y + Height <= 0) || (X >= viewport.Width) || (Y >= viewport.Height);
            }
        }

        public bool HitViewportBoundary
        {
            get
            {
                var viewport = scene.Game.GraphicsDevice.Viewport;
                return (X <= 0) || (Y <= 0) || (X >= viewport.Width - Width) || (Y >= viewport.Height - Height);
            }
        }

        public Rectangle BoundingBox => new Rectangle((int)X, (int)Y, Width, Height);

        public virtual bool CollisionDetective { get; set; }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public override void Update(GameTime gameTime)
        {
            var viewport = scene.Game.GraphicsDevice.Viewport;
            var b = Boundary.None;
            if (X <= 0)
            {
                b |= Boundary.Left;
            }
            if (Y <= 0)
            {
                b |= Boundary.Top;
            }
            if (X >= viewport.Width - Width)
            {
                b |= Boundary.Right;
            }
            if (Y >= viewport.Height - Height)
            {
                b |= Boundary.Bottom;
            }

            this.Publish(new ReachBoundaryMessage(b));
        }

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            scene.Game.MessageDispatcher.DispatchMessageAsync(this, message);
        }

        public void Subscribe<TMessage>(Action<object, TMessage> handler)
            where TMessage : IMessage
        {
            scene.Game.MessageDispatcher.RegisterHandler<TMessage>(handler);
        }

        public override string ToString() => this.Id.ToString();
    }
}