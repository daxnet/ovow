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
using Ovow.Framework.Scenes;

namespace Ovow.Framework.Forms
{
    /// <summary>
    /// Represents the scene that can run in a Windows Forms control.
    /// </summary>
    public interface IFormScene : IScene
    {
        #region Public Methods

        /// <summary>
        /// Gets the parameter value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The parameter value.</returns>
        string GetParameter(string name);

        /// <summary>
        /// Sets a parameter to the scene from the Windows Forms context.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The parameter value.</param>
        void SetParameter(string name, string value);

        #endregion Public Methods
    }
}