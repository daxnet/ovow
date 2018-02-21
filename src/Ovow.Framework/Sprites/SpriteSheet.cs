// ----------------------------------------------------------------------------
//   ____                    ____                                   __
//  / __ \_  _____ _    __  / __/______ ___ _  ___ _    _____  ____/ /__
// / /_/ / |/ / _ \ |/|/ / / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
// \____/|___/\___/__,__/ /_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
//
// A 2D gaming framework on MonoGame
//
// Copyright (C) 2018 by daxnet.
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

namespace Ovow.Framework.Sprites
{
    /// <summary>
    /// Represents the data structure of a Sprite Sheet.
    /// </summary>
    public struct SpriteSheet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteSheet"/> struct.
        /// </summary>
        /// <param name="frameWidth">Width of each frame in the sprite sheet.</param>
        /// <param name="frameHeight">Height of each frame in the sprite sheet.</param>
        /// <param name="totalFrames">The total frames in the sprite sheet.</param>
        /// <param name="offsetX">The offset x-coordinate of the sprite sheet.</param>
        /// <param name="offsetY">The offset y-coordinate of the sprite sheet.</param>
        public SpriteSheet(int frameWidth, int frameHeight, int totalFrames, int offsetX, int offsetY)
            : this()
        {
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.TotalFrames = totalFrames;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }

        public int FrameWidth { get; set; }

        public int FrameHeight { get; set; }

        public int TotalFrames { get; set; }

        public int OffsetX { get; set; }

        public int OffsetY { get; set; }
    }
}