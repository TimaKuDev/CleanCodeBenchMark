namespace CleanCodeBenchMark
{
    internal class Rectangle_ : Shape_Base
    {
        private float _width;
        private float _height;

        public Rectangle_(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public override float Area()
        {
            return _height * _width;
        }

        public override uint CornnerCount()
        {
            return 4;
        }
    }
}
