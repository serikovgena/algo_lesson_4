using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lesson4
{
    class Program {
        static void Main() {
          TestSearchingInArrayAndHashSet();
        }

        static void TestSearchingInArrayAndHashSet() {
            var randomCollection = new RandomStringCollection();
            var array = randomCollection.GetStringsArray(10000);
            var wantedString = array[900];

            Console.Write("estimated time of searching in array: ");
            using (new TimeLogger()) {
                foreach (var item in array) {
                    if (item.Equals(wantedString))
                        break;
                }
            }

            HashSet<string> hashSet = new HashSet<string>(array);
            Console.Write("estimated time of searching in hash set: ");
            using (new TimeLogger()) {
                hashSet.TryGetValue(wantedString, out string searchingResult);
            }
        }
    }

    class TimeLogger : IDisposable {
        Stopwatch timer;
        public TimeLogger() {
            timer = new Stopwatch();
            timer.Start();
        }

        public void Dispose() {
            timer.Stop();
            Console.WriteLine($"{timer.Elapsed.TotalMilliseconds} ms");
        }
    }
}

