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

        bool Collision(Camera camera, Player player);

        void Render(Camera camera);
    }
}
