namespace CleanCodeBenchMark
{
    internal class Triangle_ : Shape_Base
    {
        private float _base;
        private float _height;

        public Triangle_(float height, float @base)
        {
            _height = height;
            _base = @base;
        }

        public override float Area()
        {
            return 0.5f * _base * _height;
        }

        public override uint CornnerCount()
        {
            return 3;
        }
    }
}
