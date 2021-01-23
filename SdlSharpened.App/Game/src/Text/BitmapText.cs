using System;
using System.Collections.Generic;
using System.Text;
using SdlSharpened;
using SDL2;

namespace SdlSharpened.App
{
    

    public class BitmapText
    {
        private Texture _sheetTexture;
        private Rect _clipRect;
        private Rect _viewRect;
        //Text box
        private string _textContent = "rustuv";
        private const int ASCII_OFFSET = 32;

        public BitmapText()
        {
            _sheetTexture = new Texture("D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\img\\charsheet2.bmp", ColourType.Magenta);
            _clipRect = new Rect(0, 0, 24, 24);
            _viewRect = new Rect(20, 300, 600, 160);
        }

        public void Render(Renderer renderer)
        {
            renderer.FillRect(_viewRect, ColourType.Blue);
            renderer.DrawRect(_viewRect, ColourType.White);

            Rect dstRect = new Rect(_viewRect.X + 10, _viewRect.Y + 10, _clipRect.W, _clipRect.H);

            var textChars = _textContent.ToCharArray();
            foreach (char ch in textChars)
            {
                SetClipRect(ch);
                renderer.Copy(_sheetTexture, _clipRect, dstRect);
                dstRect.X += 24;
                if (dstRect.X > _viewRect.W)
                {
                    dstRect.X = 24;
                    dstRect.Y += 30;
                }
            }
        }

        private void SetClipRect(char ch) 
        {
            int pos = (int)ch - ASCII_OFFSET;
            int x = 0;
            int y = 0;

            for (int i = 0; i < pos; i++)
            {
                x += 1;
                if (x > 9)
                {
                    x = 0;
                    y += 1;
                }
            }

            _clipRect.X = x * 23;
            _clipRect.Y = y * 23;


            Console.WriteLine($"{x}, {y}");
        }
    }
}
