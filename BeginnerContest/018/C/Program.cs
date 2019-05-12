using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderTemplate {
    class Program {
        static void Main (string[] args) {
            var RCK = ReadInts ();
            var R = RCK[0];
            var C = RCK[1];
            var K = RCK[2];
            var s = Enumerable.Range (0, R).Select (i => Console.ReadLine ().ToList ()).ToList ();

            var count = 0;
            foreach (var y in Enumerable.Range (K, (R - 2 * K + 2))) {
                foreach (var x in Enumerable.Range (K, (C - 2 * K + 2))) {
                    // ひし形の判定
                    // Console.WriteLine ($"{y}:{x}");
                    var isDiamond = Enumerable.Range (y - K + 1, 2 * (K - 1) + 1)
                        .All (j =>
                            Enumerable.Range (x - K + 1, 2 * (K - 1) + 1)
                            .Where (i => Math.Abs (i - x) + Math.Abs (j - y) <= K - 1)
                            .All (i => s[j - 1][i - 1] == 'o')
                        );
                    if (isDiamond) {
                        count++;
                    }
                }
            }
            Console.WriteLine (count);
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