namespace SdlSharpened.App
{
    public struct Animation
    {
        private int _startIndex;
        private int _cellCount;
        private AnimationSpeed _speed;

        public Animation(int startIndex, int cellCount, AnimationSpeed speed)
        {
            _startIndex = startIndex;
            _cellCount = cellCount;
            _speed = speed;
        }

        public int StartIndex { get { return _startIndex; } }
        public int CellCount { get { return _cellCount; } }
        public AnimationSpeed Speed { get { return _speed; } }
    }
}
