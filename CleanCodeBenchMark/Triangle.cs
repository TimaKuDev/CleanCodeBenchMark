namespace CleanCodeBenchMark
{
    internal class Triangle : ShapeBase
    {
        private float _base;
        private float _height;

        public Triangle(float height, float @base)
        {
            _height = height;
            _base = @base;
        }

        public override float Area()
        {
            return 0.5f * _base * _height;
        }
    }
}
