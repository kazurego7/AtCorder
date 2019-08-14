using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var NK = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var N = NK[0];
            var K = NK[1];
            var T = Enumerable.Range (0, N)
                .Select (_ =>
                    Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ()
                ).ToList ();

            /*
            全探索をするとK^Nだが、最大でも5^5程度なのでOK
            全探索のための、5^5通りの選択肢の組み合わせのリストをComb関数で作り、あとはそのままXORして0になるような組み合わせが一つでもあればFound
             */
            var solve = Comb (N, K, 0).Any (choices =>
                0 == Enumerable.Range (0, N)
                .Select (i => T[i][choices[i]])
                .Aggregate ((accm, x) => accm ^ x));

            if (solve) {
                Console.WriteLine ("Found");
            } else {
                Console.WriteLine ("Nothing");
            }
        }
        static List<List<int>> Comb (int n, int k, int count) {
            if (count == n) {
                return new List<List<int>> { Enumerable.Empty<int> ().ToList () };
            } else {
                return Enumerable.Range (0, k).SelectMany (k1 => Comb (n, k, count + 1).Select (elm => elm.Append (k1).ToList ())).ToList ();
            }
        }
    }
}