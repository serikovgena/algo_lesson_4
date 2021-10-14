using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lesson4
{
    class Program {
        static void Main() {
          TestSearchingInArrayAndHashSet();
          TestBTree();
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

        static void TestBTree() {
            BTree tree = new BTree();
            tree.AddItem(6);
            tree.AddItem(2);
            tree.AddItem(11);
            tree.AddItem(3);
            tree.AddItem(9);
            tree.AddItem(30);

            tree.PrintTree();
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

