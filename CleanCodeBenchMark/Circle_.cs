namespace CleanCodeBenchMark
{
    internal class Circle_ : Shape_Base
    {
        private float _radius;

        public Circle_(float radius)
        {
            _radius = radius;
        }

        public override float Area()
        {
            return (float)(Math.PI * _radius);
        }

        public override uint CornnerCount()
        {
            return 0;
        }
    }
}
