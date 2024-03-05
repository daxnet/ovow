using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Framework
{
    public sealed class SpriteBatchDrawOptions
    {

        public SpriteBatchDrawOptions(SpriteSortMode spriteSortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect, Matrix? transformMatrix)
        {
            SpriteSortMode = spriteSortMode;
            BlendState = blendState;
            SamplerState = samplerState;
            DepthStencilState = depthStencilState;
            RasterizerState = rasterizerState;
            Effect = effect;
            TransformMatrix = transformMatrix;
        }

        public static readonly SpriteBatchDrawOptions Default = new(SpriteSortMode.Deferred, null, null, null, null, null, null);

        public SpriteSortMode SpriteSortMode { get; } = SpriteSortMode.Deferred;

        public BlendState BlendState { get; }

        public SamplerState SamplerState { get; }

        public DepthStencilState DepthStencilState { get; }

        public RasterizerState RasterizerState { get; }

        public Effect Effect { get; }

        public Matrix? TransformMatrix { get; }
    }
}
