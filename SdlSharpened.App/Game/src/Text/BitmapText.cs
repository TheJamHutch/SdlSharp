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
        private Texture _dstTexture;
        private Rect _srcRect;
        private Rect _dstRect;
        private string _value = "721457432";

        private static readonly Dictionary<char, Point> _charFrameMap = new Dictionary<char, Point>()
        {
            { '0', new Point(0, 0)},
            { '1', new Point(1, 0)},
            { '2', new Point(2, 0)},
            { '3', new Point(3, 0)},
            { '4', new Point(0, 1)},
            { '5', new Point(1, 1)},
            { '6', new Point(2, 1)},
            { '7', new Point(3, 1)},
            { '8', new Point(0, 2)},
            { '9', new Point(1, 2)}
        };

        public BitmapText()
        {
            _sheetTexture = new Texture(Config.SpritesheetNumsheet, ColourType.Magenta);
            _dstTexture = new Texture(640, 480);
            _srcRect = new Rect(0, 0, 32, 32);
            _dstRect = new Rect(0, 0, 32, 32);

            //PreRender();
        }

        public void Render() 
        {
            // Game.RendererInstance.Copy(_dstTexture, _srcRect, _dstRect);
        }

        private void PreRender()
        {
            Game.RendererInstance.SetTarget(_dstTexture);

            var textChars = _value.ToCharArray();
            foreach (char ch in textChars)
            {
                _srcRect = SetSrcRect(ch);
                Game.RendererInstance.Copy(_sheetTexture, _srcRect, _dstRect);
                _dstRect.X += 32;
            }

             Game.RendererInstance.ResetTarget();
        }

        private void Update() 
        {

        }

        private Rect SetSrcRect(char val) 
        {
            Point point = _charFrameMap[val];

            point.X *= 32;
            point.Y *= 32;

            return new Rect(point.X, point.Y, 32, 32);
        }
    }
}
