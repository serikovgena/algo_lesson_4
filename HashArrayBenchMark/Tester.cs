using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using lesson4;

namespace HashArrayBenchMark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Tester
    {
        string wantedString;

        string[] testedArray;
        HashSet<string> testedHashSet;

        public Tester() {
            RandomStringCollection randomStringCollection = new();
            testedArray = randomStringCollection.GetStringsArray(10_000);
            testedHashSet = new HashSet<string>(testedArray);

            wantedString = testedArray[900];
        }

        [Benchmark]
        public void TestSearchingInArray() {
            foreach (var item in testedArray)
            {
                if (item.Equals(wantedString))
                    break;
            }
        }

        [Benchmark]
        public void TestSearchingInHashSet() {
            testedHashSet.TryGetValue(wantedString, out string searchingResult);
        }
    }
}
