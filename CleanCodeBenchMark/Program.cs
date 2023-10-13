using Benchmark;
using BenchmarkDotNet.Running;
using CleanCodeBenchMark;

internal class Program
{
    private static void Main(string[] args)
    {
        //BenchmarkRunner.Run<FirstCleanCode>();
        //BenchmarkRunner.Run<SecondCleanCode>();
        //BenchmarkRunner.Run<BestCases>();
        //BenchmarkRunner.Run<BestCases_>();
        //BenchmarkRunner.Run<WorstCases>();
        BenchmarkRunner.Run<WorstCases_>();
        ///hola
        ///that
        ///is a
        ///test
        ///2
    }
}
