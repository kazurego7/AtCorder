using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var nabc = Console.ReadLine ().Split (' ');
            var N = int.Parse (nabc[0]);
            var A = int.Parse (nabc[1]);
            var B = int.Parse (nabc[2]);
            var C = int.Parse (nabc[3]);
            var L = new List<int> ();
            foreach (var i in Enumerable.Range (0, N)) {
                L.Add (int.Parse (Console.ReadLine ()));
            }

            int Dfs (int cur, int a, int b, int c) {
                if (cur == N) {
                    var minabc = new List<int> { a, b, c }.OrderBy (x => x).First ();
                    if (minabc > 0) {
                        return Math.Abs (a - A) + Math.Abs (b - B) + Math.Abs (c - C) - 30;
                    } else {
                        return 1000000000;
                    }
                }
                var res0 = Dfs (cur + 1, a, b, c);
                var res1 = Dfs (cur + 1, a + L[cur], b, c) + 10;
                var res2 = Dfs (cur + 1, a, b + L[cur], c) + 10;
                var res3 = Dfs (cur + 1, a, b, c + L[cur]) + 10;
                var ress = new List<int> { res0, res1, res2, res3 }.OrderBy (x => x).First ();
                return ress;
            }

            Console.WriteLine (Dfs (0, 0, 0, 0));
        }
    }
}