using BenchmarkDotNet.Running;

namespace HashArrayBenchMark
{
    class Program
    {
        static void Main(string[] args) {
            BenchmarkRunner.Run<Tester>();
        }
    }
}
