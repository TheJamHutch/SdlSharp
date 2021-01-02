using System;
using System.Collections.Generic;
using System.Text;

namespace SdlSharpened.App
{
    public interface ITilemap
    {
        Point Area { get; }
        Point Resolution { get; }

        void Save();

        void Load();

        int[ , ] LocalTiles(Point tilePos);

        void Render(Camera camera);
    }
}
