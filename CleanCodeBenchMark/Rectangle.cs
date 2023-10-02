namespace CleanCodeBenchMark
{
    internal class Rectangle : ShapeBase
    {
        private float _width;
        private float _height;

        public Rectangle(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public override float Area()
        {
            return _height * _width;
        }
    }
}
