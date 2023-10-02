namespace CleanCodeBenchMark
{
    internal class Square_ : Shape_Base
    {
        private float _side;

        public Square_(float side)
        {
            _side = side;
        }

        public override float Area()
        {
            return _side * _side;
        }

        public override uint CornnerCount()
        {
            return 4;
        }
    }
}
