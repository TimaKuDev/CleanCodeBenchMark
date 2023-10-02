using Benchmark;
using BenchmarkDotNet.Running;
using CleanCodeBenchMark;

internal class Program
{
    private static void Main(string[] args)
    {
        //BenchmarkRunner.Run<FirstCleanCode>();
        BenchmarkRunner.Run<SecondCleanCode>();
        //List<ShapeBase> _shapesClass = new List<ShapeBase>(20);
        //List<ShapeUnion> _shapeUnion = new List<ShapeUnion>();
        //int shapreCreator = 0;
        //for (int i = 0; i < 20; i++)
        //{
        //    int firstRandomNumber = new Random().Next();
        //    int secondRandomNumber = new Random().Next();
        //    switch (shapreCreator)
        //    {
        //        case 0:
        //            _shapesClass.Add(new Square(firstRandomNumber));
        //            _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Square, Width = firstRandomNumber });
        //            break;
        //        case 1:
        //            _shapesClass.Add(new Rectangle(firstRandomNumber, secondRandomNumber));
        //            _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Rectangle, Width = firstRandomNumber, Height = secondRandomNumber });
        //            break;
        //        case 2:
        //            _shapesClass.Add(new Triangle(firstRandomNumber, secondRandomNumber));
        //            _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Triangle, Width = firstRandomNumber, Height = secondRandomNumber });
        //            break;
        //        default:
        //            _shapesClass.Add(new Circle(firstRandomNumber));
        //            _shapeUnion.Add(new ShapeUnion() { Type = ShapeType.Circle, Width = firstRandomNumber });
        //            break;
        //    }

        //    shapreCreator = (shapreCreator + 1) % 4;
        //}


    }
}