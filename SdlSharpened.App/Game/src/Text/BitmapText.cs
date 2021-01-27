using System;
using System.Collections.Generic;
using System.Text;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class BitmapText
    {
        private Texture _sheetTexture;
        private TextBox _textBox;

        public BitmapText()
        {
            _sheetTexture = new Texture("D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\img\\charsheet2.bmp", ColourType.Magenta);
            _textBox = new TextBox("Map saved", _sheetTexture, new Rect(10, 10, 220, 40));
        }

        public void Update() 
        {
            _textBox.Visible = false;
        }

        public void Render(Renderer renderer)
        {
            if (_textBox.Visible)
            {
                _textBox.Render(renderer);
            }
        }
    }
}
