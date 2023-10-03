using BenchmarkDotNet.Attributes;
using CleanCodeBenchMark;

namespace Benchmark
{

    [Config(typeof(AntiVirusFriendlyConfig))]
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BestCases_
    {
        [Params(10, 100, 1_000, 10_000, 100_000)] public int Size { get; set; }
        private List<Shape_Base> _shapesClass;
        private List<ShapeUnion> _shapeUnion;
        private List<ShapeUnion> _shapeUnion2;

        [GlobalSetup]
        public void Setup()
        {
            _shapesClass = new List<Shape_Base>(Size);
            _shapeUnion = new List<ShapeUnion>(Size);
            _shapeUnion2 = new List<ShapeUnion>(Size);
            for (int i = 0; i < Size; i++)
            {
                int firstRandomNumber = new Random().Next();
                _shapesClass.Add(new Square_(firstRandomNumber));
                _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Square, Width = firstRandomNumber });
                _shapeUnion2.Add(new ShapeUnion() { Type = ShapeType.Square, Width = firstRandomNumber, Height = firstRandomNumber });
            }
        }

        [Benchmark]
        public void CornerAreaVTBLBestCases_()
        {
            float accum = CleanCodeTotalArea(_shapesClass);
        }

        private float CleanCodeTotalArea(List<Shape_Base> shapes)
        {
            float accum = 0;
            for (int i = 0; i < shapes.Count; i++)
            {
                accum += (1.0f / (1.0f + (float)shapes[i].CornnerCount())) * shapes[i].Area();
            }

            return accum;
        }

        [Benchmark]
        public void CornerAreaSwitchBestCases_()
        {
            float accum = DirtyCodeTotalArea(_shapeUnion);
        }

        private float DirtyCodeTotalArea(List<ShapeUnion> shapeUnion)
        {
            float accum = 0;
            for (int i = 0; i < shapeUnion.Count; i++)
            {
                accum += (1.0f / (1.0f + (float)GetCorrnerCountSwitch(shapeUnion[i].Type))) * GetAreaSwitchCaseStatment(shapeUnion[i]);
            }

            return accum;
        }

        private float GetAreaSwitchCaseStatment(ShapeUnion shapeUnion)
        {
            float result = 0;
            switch (shapeUnion.Type)
            {
                case ShapeType.Square:
                    result = shapeUnion.Width * shapeUnion.Width;
                    break;
                case ShapeType.Rectangle:
                    result = shapeUnion.Width * shapeUnion.Height;
                    break;
                case ShapeType.Triangle:
                    result = 0.5f * shapeUnion.Width * shapeUnion.Height;
                    break;
                case ShapeType.Circle:
                    result = (float)(Math.PI * shapeUnion.Width * shapeUnion.Height);
                    break;
                case ShapeType.Count:
                    break;
            }

            return result;
        }

        private float GetCorrnerCountSwitch(ShapeType shapeType)
        {
            float result = 0;
            switch (shapeType)
            {
                case ShapeType.Square:
                    result = 4;
                    break;
                case ShapeType.Rectangle:
                    result = 4;
                    break;
                case ShapeType.Triangle:
                    result = 3;
                    break;
                case ShapeType.Circle:
                    result = 0;
                    break;
                case ShapeType.Count:
                    break;
            }

            return result;
        }

        [Benchmark]
        public void CornerAreaTableBestCases_()
        {
            float accum = GetCornerAreaTable(_shapeUnion2);
        }

        //private const float[] CTable = new float[(int)ShapeType.Count] { 1.0f, 1.0f, 0.5f, (float)Math.PI }; had to write it like below
        private readonly float[] CTable = new float[] { 1.0f / (1.0f + 4.0f), 1.0f / (1.0f + 4.0f), 0.5f / (1.0f + 3.0f), (float)Math.PI };
        private float GetCornerAreaTable(List<ShapeUnion> shapeUnion2)
        {
            float accum = 0;
            for (int i = 0; i < shapeUnion2.Count; i++)
            {
                accum += GetCornerAreaTable(shapeUnion2[i]);
            }

            return accum;
        }

        private float GetCornerAreaTable(ShapeUnion shapeUnion2)
        {
            float result = CTable[(int)shapeUnion2.Type] * shapeUnion2.Width * shapeUnion2.Height;
            return result;
        }
    }
}