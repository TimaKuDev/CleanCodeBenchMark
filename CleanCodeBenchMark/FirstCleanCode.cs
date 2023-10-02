﻿using BenchmarkDotNet.Attributes;
using CleanCodeBenchMark;

namespace Benchmark
{
    [Config(typeof(AntiVirusFriendlyConfig))]
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class FirstCleanCode
    {
        [Params(10, 100, 1_000, 10_000, 100_000)] public int Size { get; set; }
        private List<ShapeBase> _shapesClass;
        private List<ShapeUnion> _shapeUnion;
        private List<ShapeUnion> _shapeUnion2;

        [GlobalSetup]
        public void Setup()
        {
            _shapesClass = new List<ShapeBase>(Size);
            _shapeUnion = new List<ShapeUnion>(Size);
            _shapeUnion2 = new List<ShapeUnion>(Size);
            int shapreCreator = 0;
            for (int i = 0; i < Size; i++)
            {
                int firstRandomNumber = new Random().Next();
                int secondRandomNumber = new Random().Next();
                switch (shapreCreator)
                {
                    case 0:
                        _shapesClass.Add(new Square(firstRandomNumber));
                        _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Square, Width = firstRandomNumber });
                        _shapeUnion2.Add(new ShapeUnion() { Type = ShapeType.Square, Width = firstRandomNumber, Height = firstRandomNumber });
                        break;
                    case 1:
                        _shapesClass.Add(new Rectangle(firstRandomNumber, secondRandomNumber));
                        _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Rectangle, Width = firstRandomNumber, Height = secondRandomNumber });
                        _shapeUnion2.Add(new ShapeUnion() { Type = ShapeType.Rectangle, Width = firstRandomNumber, Height = secondRandomNumber });
                        break;
                    case 2:
                        _shapesClass.Add(new Triangle(firstRandomNumber, secondRandomNumber));
                        _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Triangle, Width = firstRandomNumber, Height = secondRandomNumber });
                        _shapeUnion2.Add(new ShapeUnion() { Type = ShapeType.Triangle, Width = firstRandomNumber, Height = secondRandomNumber });
                        break;
                    default:
                        _shapesClass.Add(new Circle(firstRandomNumber));
                        _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Circle, Width = firstRandomNumber });
                        _shapeUnion2.Add(new ShapeUnion() { Type = ShapeType.Circle, Width = firstRandomNumber, Height = 1 });
                        break;
                }

                shapreCreator = (shapreCreator + 1) % 4;
            }
        }

        [Benchmark]
        public void TotalAreaVTBL()
        {
            float accum = CleanCodeTotalArea(_shapesClass);
        }

        private float CleanCodeTotalArea(List<ShapeBase> shapes)
        {
            float accum = 0;
            for (int i = 0; i < shapes.Count; i++)
            {
                accum += shapes[i].Area();
            }

            return accum;
        }

        [Benchmark]
        public void TotalAreaSwitch()
        {
            float accum = DirtyCodeTotalArea(_shapeUnion);
        }

        private float DirtyCodeTotalArea(List<ShapeUnion> shapeUnion)
        {
            float accum = 0;
            for (int i = 0; i < shapeUnion.Count; i++)
            {
                accum += GetAreaSwitchCaseStatment(shapeUnion[i]);
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

        [Benchmark]
        public void TotalAreaTable()
        {
            float accum = GetAreaUnion(_shapeUnion2);
        }

        private float GetAreaUnion(List<ShapeUnion> shapeUnion2)
        {
            float accum = 0;
            for (int i = 0; i < shapeUnion2.Count; i++)
            {
                accum += GetAreaUnion(shapeUnion2[i]);
            }

            return accum;
        }

        private readonly float[] CTable = new float[] { 1.0f, 1.0f, 0.5f, (float)Math.PI };

        private float GetAreaUnion(ShapeUnion shapeUnion2)
        {
            float result = CTable[(int)shapeUnion2.Type] * shapeUnion2.Width * shapeUnion2.Height;
            return result;
        }

    }
}