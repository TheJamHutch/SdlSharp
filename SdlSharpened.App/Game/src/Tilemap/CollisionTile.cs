using System;
using System.Collections.Generic;
using System.Text;
using SdlSharpened;

namespace SdlSharpened.App
{
    public struct CollisionTile
    {
        public TileEffect Effect { get; }

        public Rect WorldRect { get; }

        public CollisionTile(TileEffect effect, Rect worldRect)
        {
            Effect = effect;
            WorldRect = worldRect;
        }
    }
}
