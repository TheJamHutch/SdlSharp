using System;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Sprite
    {
        private int _cellCounter = 0;
        private int _frameCounter = 0;
        private Texture _texture;
        private Rect _clipRect;
        private Rect _viewRect;
        private Animation _currentAnimation;

        private Dictionary<string, Animation> _animationDictionary = new Dictionary<string, Animation>()
        {
            // Directional idle animations
            { "IdleSouth", new Animation(0, 1, AnimationSpeed.Slow) },
            { "IdleEast", new Animation(5, 1, AnimationSpeed.Slow) },
            { "IdleNorth", new Animation(10, 1, AnimationSpeed.Slow) },
            { "IdleWest", new Animation(15, 1, AnimationSpeed.Slow) },
            // Directional walking animations
            { "WalkSouth", new Animation(0, 5, AnimationSpeed.Fast) },
            { "WalkEast", new Animation(5, 5, AnimationSpeed.Fast) },
            { "WalkNorth", new Animation(10, 5, AnimationSpeed.Fast) },
            { "WalkWest", new Animation(15, 5, AnimationSpeed.Fast) },
            //
            { "Attack", new Animation(30, 8, AnimationSpeed.VeryFast) }
        };

        public Sprite(string sheetPath, Point spriteSize)
        {
            _texture = new Texture(sheetPath, ColourType.Magenta);
            _clipRect = new Rect(0, 0, spriteSize.X, spriteSize.Y);
            _viewRect = new Rect(0, 0, spriteSize.X, spriteSize.Y);
            _currentAnimation = _animationDictionary["IdleSouth"];
        }

        public Rect ClipRect { get { return _clipRect; } }

        public void Render(Renderer renderer) 
        {
            renderer.Copy(_texture, _clipRect, _viewRect);
        }

        public void SetAnimation(string name)
        {
            if (_animationDictionary.TryGetValue(name, out var animation))
            {
                _currentAnimation = animation;
                _cellCounter = 0;
            }
        }

        // Called every frame
        public void Animate()
        {
            // On animation start/ restart
            if (_cellCounter == 0)
            {
                _cellCounter++;
                SetFrame(_currentAnimation.StartIndex);
            }

            int waitFrames = (int)_currentAnimation.Speed;

            if (_frameCounter % waitFrames == 0)
            {
                _cellCounter++;

                if (_cellCounter == _currentAnimation.CellCount + 1)
                {
                    _cellCounter = 0;
                }
                else
                {
                    NextFrame();
                }
            }

            // TODO: Reset frame counter eventually, even though it will take ~ 2.2 years to overflow at 30 FPS.
            // TODO: Consider moving frameCounter to Game and calling from here.
            _frameCounter++;
        }

        // Advances the clipRect along one position in the spritesheet texture, wraps around.
        private void NextFrame()
        {
            _clipRect.X += _clipRect.W;
            if (_clipRect.X + _clipRect.W >= _texture.Width)
            {
                _clipRect.X = 0;
                _clipRect.Y += _clipRect.H;

                if (_clipRect.Y + _clipRect.H >= _texture.Height)
                {
                    _clipRect.Y = 0;
                    _clipRect.X = 0;
                }
            }
        }

        private void SetFrame(int startIndex)
        {
            int x = 0;
            int y = 0;
            // Calculate how many rows in spritesheet
            int cellsX = _texture.Width / _clipRect.W;

            for (int i = 0; i < startIndex; i++)
            {
                x += 1;
                if (x >= cellsX)
                {
                    x = 0;
                    y += 1;
                }
            }

            _clipRect.X = x * _clipRect.W;
            _clipRect.Y = y * _clipRect.H;
        }
    }
}
