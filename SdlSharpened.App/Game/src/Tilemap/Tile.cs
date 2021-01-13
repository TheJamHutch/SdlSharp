using System;
using System.Collections.Generic;
using System.Text;

namespace SdlSharpened.App
{
    public struct Tile
    {
        private int _type;
        private TileEffect _tileEffect;

        public Tile(int type, TileEffect tileEffect)
        {
            _type = type;
            _tileEffect = tileEffect;
        }

        public int Type { get { return _type; } }

        public TileEffect Effect { get { return _tileEffect; } }
    }
}
