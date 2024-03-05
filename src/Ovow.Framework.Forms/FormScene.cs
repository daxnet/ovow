// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Author: daxnet.
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
using Ovow.Framework.Scenes;
using System.Collections.Concurrent;

namespace Ovow.Framework.Forms
{
    /// <summary>
    /// Represents the scene that can run in the Windows Forms context.
    /// </summary>
    public abstract class FormScene : Scene, IFormScene
    {
        #region Private Fields

        private readonly ConcurrentDictionary<string, string> _parameters = new ConcurrentDictionary<string, string>();

        #endregion Private Fields

        #region Protected Constructors

        /// <inheritdoc/>
        protected FormScene(IOvowGame game)
            : base(game)
        {
        }

        /// <inheritdoc/>
        protected FormScene(IOvowGame game, Texture2D sceneTexture)
            : base(game, sceneTexture)
        {
        }

        /// <inheritdoc/>
        protected FormScene(IOvowGame game, Color backgrounColor)
            : base(game, backgrounColor)
        {
        }

        /// <inheritdoc/>
        protected FormScene(IOvowGame game, Texture2D sceneTexture, Color backgroundColor)
            : base(game, sceneTexture, backgroundColor)
        {
        }

        #endregion Protected Constructors

        #region Public Methods

        /// <inheritdoc/>
        public string GetParameter(string name)
        {
            if (_parameters.TryGetValue(name, out var value))
                return value;
            return null;
        }

        /// <inheritdoc/>
        public void SetParameter(string name, string value)
        {
            _parameters.AddOrUpdate(name,
            _ =>
            {
                Publish(new ParameterChangedMessage(name, null, value));
                return value;
            },
            (k, v) =>
            {
                if (v != value)
                {
                    Publish(new ParameterChangedMessage(name, v, value));
                }

                return value;
            });
        }

        #endregion Public Methods
    }
}