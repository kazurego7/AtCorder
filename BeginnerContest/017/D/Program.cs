using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderTemplate {
    class Program {
        static void Main (string[] args) {
            var NM = ReadInts ();
            var N = NM[0];
            var M = NM[1];
            var f = ReadSequence (N) [0];

            var dp = new long[N + 1];
            dp[0] = 1;
            foreach (var i in Enumerable.Range (1, N)) {
                var j = 0;
                foreach (var k in Enumerable.Range (0, i)) {
                    var range = f.Take (i).Skip (k);
                    if (range.Distinct ().Count () == range.Count ()) {
                        j = k;
                        break;
                    }
                }
                // Console.WriteLine ($"j : {j}");
                dp[i] = dp.Take (i).Skip (j).Sum ();
            }

            Console.WriteLine (dp[N] % 1000000007L);
        }
        static int ReadInt () {
            return int.Parse (Console.ReadLine ());
        }
        static List<int> ReadInts () {
            return Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
        }
        static List<List<int>> ReadSequence (int n) {
            /*
            入力例
            A1 B1
            A2 B2
            ...
            An Bn

            出力例
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var seq = Enumerable.Range (0, n).Select (i => ReadInts ()).ToList ();
            return Enumerable.Range (0, seq.First ().Count ()).Select (i => seq.Select (items => items[i]).ToList ()).ToList ();
        }
        static void PrintList<T> (IEnumerable<T> list) {
            foreach (var item in list) {
                Console.WriteLine (item);
            }
        }
    }
}