/* Class represents a TextBox, which is an area of the screen dedicated to rendering bitmap text.
** When rendering bitmap text, a text box can either have no background (transparent), a solid 
** colour background, or a texture background. 
*/
using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class TextBox
    {
        public bool Visible { get; set; } = true;
        public string Content { get; set; }
        public Rect ViewRect { get; set; }

        private Rect _clipRect = new Rect(0, 0, 24, 24);

        private Texture _sheetTexture;

        public TextBox(string content, Texture sheetTexture, Rect viewRect)
        {
            _sheetTexture = sheetTexture;

            Content = content;
            ViewRect = viewRect;
        }

        public void Render(Renderer renderer) 
        {
            renderer.FillRect(ViewRect, ColourType.Blue);
            renderer.DrawRect(ViewRect, ColourType.White);

            Rect dstRect = new Rect(ViewRect.X + 10, ViewRect.Y + 10, _clipRect.W, _clipRect.H);

            var textChars = Content.ToCharArray();
            foreach (char ch in textChars)
            {
                SetClipRect(ch);
                renderer.Copy(_sheetTexture, _clipRect, dstRect);
                dstRect.X += 22;
                if (dstRect.X > ViewRect.W)
                {
                    dstRect.X = 22;
                    dstRect.Y += 30;
                }
            }
        }

        private void SetClipRect(char ch)
        {
            const int ASCII_OFFSET = 32;

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
        }
    }
}
