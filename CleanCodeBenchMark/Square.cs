namespace CleanCodeBenchMark
{
    internal class Square : ShapeBase
    {
        private float _side;

        public Square(float side)
        {
            _side = side;
        }

        public override float Area()
        {
            return _side * _side;
        }
    }
}
