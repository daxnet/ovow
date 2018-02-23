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

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ovow.Framework.Sprites
{
    /// <summary>
    /// Represents the data structure of a Sprite Sheet.
    /// </summary>
    public class SpriteSheet : IDisposable
    {
        private readonly Bitmap bitmap;

        private SpriteSheet(string fileName, Color backgroundColor = default(Color))
        {
            this.bitmap = (Bitmap)Image.FromFile(fileName);
            this.Width = this.bitmap.Width;
            this.Height = this.bitmap.Height;
            this.BackgroundColor = backgroundColor;
        }

        public int Width { get; }

        public int Height { get; }

        public Color BackgroundColor { get; }

        public int[,] GetMaskMatrix()
        {
            var result = new int[Width, Height];
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    result[i, j] = IsBackgroundPixel(i, j) ? 0 : 1;
                }
            }
            return result;
        }

        public int[,] GetEdgeMatrix()
        {
            var result = new int[Width, Height];
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    result[i, j] = IsEdgePixel(i, j) ? 1 : 0;
                }
            }

            return result;
        }

        public IEnumerable<KeyValuePair<int, List<Point>>> GetIsland()
        {
            var edgeMatrix = GetEdgeMatrix();
            var index = 0;
            var result = new Dictionary<int, List<Point>>();

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    if (edgeMatrix[x, y] == 1)
                    {
                        var list = new List<Point>();
                        MarkIsland(edgeMatrix, x, y, index++, ref list);
                        result.Add(index, list);
                    }
                }
            }

            return result;
        }

        private bool IsEdgePixel(int x, int y)
        {
            var hasBackgroundPixelAround = false;
            var hasMaskPixelAround = false;

            for (var px = Math.Max(x - 1, 0); px <= Math.Min(x + 1, Width - 1); px++)
            {
                for (var py = Math.Max(y - 1, 0); py <= Math.Min(y + 1, Height - 1); py++)
                {
                    if (px == x && py == y)
                    {
                        continue;
                    }

                    if (IsBackgroundPixel(px, py))
                    {
                        hasBackgroundPixelAround = true;
                    }
                    else
                    {
                        hasMaskPixelAround = true;
                    }
                }
            }

            return hasBackgroundPixelAround && hasMaskPixelAround;
        }

        private bool IsBackgroundPixel(int x, int y)
            => BackgroundColor == default(Color) ? bitmap.GetPixel(x, y).A == 0 : bitmap.GetPixel(x, y) == BackgroundColor;

        private void MarkIsland(int[,] edgeMatrix, int x, int y, int index, ref List<Point> coordinates)
        {
            edgeMatrix[x, y] = -1;
            coordinates.Add(new Point(x, y));

            if (x - 1 >= 0)
            {
                // (i-1, j-1)
                if (y - 1 >= 0 && edgeMatrix[x - 1, y - 1] == 1)
                    MarkIsland(edgeMatrix, x - 1, y - 1, index, ref coordinates);
                // (i-1, j)
                if (edgeMatrix[x - 1, y] == 1)
                    MarkIsland(edgeMatrix, x - 1, y, index, ref coordinates);
                // (i-1, j+1)
                if (y + 1 < Height && edgeMatrix[x - 1, y + 1] == 1)
                    MarkIsland(edgeMatrix, x - 1, y + 1, index, ref coordinates);
            }
            if (x + 1 < Width)
            {
                // (i+1, j-1)
                if (y - 1 >= 0 && edgeMatrix[x + 1, y - 1] == 1)
                    MarkIsland(edgeMatrix, x + 1, y - 1, index, ref coordinates);
                // (i+1, j)
                if (edgeMatrix[x + 1, y] == 1)
                    MarkIsland(edgeMatrix, x + 1, y, index, ref coordinates);
                // (i+1, j+1)
                if (y + 1 < Height && edgeMatrix[x + 1, y + 1] == 1)
                    MarkIsland(edgeMatrix, x + 1, y + 1, index, ref coordinates);
            }
            // (i, j-1)
            if (y - 1 >= 0 && edgeMatrix[x, y - 1] == 1)
                MarkIsland(edgeMatrix, x, y - 1, index, ref coordinates);
            // (i, j+1)
            if (y + 1 < Height && edgeMatrix[x, y + 1] == 1)
                MarkIsland(edgeMatrix, x, y + 1, index, ref coordinates);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SpriteSheet() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}