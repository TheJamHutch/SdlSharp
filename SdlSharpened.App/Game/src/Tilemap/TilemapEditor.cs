using System;
using System.Collections.Generic;
using System.Text;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class TilemapEditor
    {
        private Rect _cursorRect = new Rect(0, 0, 32, 32);
        private Rect _menuRect = new Rect(540, 1, 99, 479);

        private ITilemap _tilemap;

        public TilemapEditor(ITilemap tilemap)
        {
            _tilemap = tilemap;
        }

        public void Update() 
        {
        
        }

        public void Render(Renderer renderer) 
        {
            // Render menu
            renderer.FillRect(_menuRect, ColourType.Red);
            renderer.DrawRect(_menuRect, ColourType.White);
        }

    }
}
