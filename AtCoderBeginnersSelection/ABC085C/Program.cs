using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC085C {
    class Program {
        static void Main (string[] args) {
            // input & decode
            var NY = Console.ReadLine ().Split (' ').ToList ();
            var N = int.Parse (NY[0]);
            var Y = long.Parse (NY[1]);

            // calculation

            var xyz = new List<int> {-1, -1, -1 };
            foreach (var x in Enumerable.Range (0, N + 1)) {
                foreach (var y in Enumerable.Range (0, N + 1)) {
                    if (x + y <= N && 10000L * x + 5000L * y + 1000L * (N - x - y) == Y) {
                        xyz = new List<int> { x, y, (N - x - y) };
                    }
                }
            }

            // encode & output
            {
                var x = xyz[0];
                var y = xyz[1];
                var z = xyz[2];
                Console.WriteLine ($"{x} {y} {z}");
            }
        }
    }
}