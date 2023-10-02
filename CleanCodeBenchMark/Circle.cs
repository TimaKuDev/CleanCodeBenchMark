namespace CleanCodeBenchMark
{
    internal class Circle : ShapeBase
    {
        private float _radius;

        public Circle(float radius)
        {
            _radius = radius;
        }

        public override float Area()
        {
            return (float)(Math.PI * _radius);
        }
    }
}
