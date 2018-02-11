using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ovow.Framework.Messaging.GeneralMessages;

namespace Ovow.Framework
{
    public abstract class Scene : VisibleComponent, IScene
    {
        private readonly List<IComponent> gameComponents = new List<IComponent>();

        protected Scene(IOvowGame game, Texture2D texture)
            : this(game, texture, Color.CornflowerBlue)
        { }

        protected Scene(IOvowGame game, Texture2D texture, Color backgroundColor) 
            : base(game, texture)
        {
            this.BackgroundColor = backgroundColor;
        }

        public int Count => gameComponents.Count;

        public bool IsReadOnly => false;

        public Color BackgroundColor { get; }

        public void Add(IComponent item)
        {
            gameComponents.Add(item);
        }

        public void Clear() => gameComponents.Clear();

        public bool Contains(IComponent item) => gameComponents.Contains(item);

        public void CopyTo(IComponent[] array, int arrayIndex) => gameComponents.CopyTo(array, arrayIndex);

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            gameComponents
                .Where(c => c is IVisibleComponent)
                .Select(c => c as IVisibleComponent)
                .ToList()
                .ForEach(vc => vc.Draw(gameTime, spriteBatch));

            spriteBatch.End();
        }

        public virtual void End()
        {
            Clear();
            Publish(new SceneEndedMessage(this));
        }

        public IEnumerator<IComponent> GetEnumerator() => gameComponents.GetEnumerator();

        public bool Remove(IComponent item) => gameComponents.Remove(item);

        public override void Update(GameTime gameTime)
        {
            gameComponents
                .ToList()
                .ForEach(c => c.Update(gameTime));
        }

        IEnumerator IEnumerable.GetEnumerator() => gameComponents.GetEnumerator();
    }
}
