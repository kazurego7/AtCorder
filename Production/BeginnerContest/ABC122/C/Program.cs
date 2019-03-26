using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderTemplate {
    class Program {
        static void Main (string[] args) {
            var NQ = ReadInts ();
            var N = NQ[0];
            var Q = NQ[1];
            var S = Console.ReadLine ();
            var lris = Enumerable.Range (0, Q).Select (i => ReadInts ().Append (i).ToList ());

            var sorted_lris = lris
                .OrderBy (lri => lri[0])
                .GroupBy (lri => lri[0])
                .SelectMany (lris2 => lris2.OrderByDescending (lri => lri[1])).ToList ();

            var result = new int[Q];
            foreach (var k in Enumerable.Range (0, Q)) {
                var lri = sorted_lris[k];
                var l = lri[0];
                var r = lri[1];
                var i = lri[2];
                var middleLeft = S.Skip (l - 1);
                foreach (var m in Enumerable.Range (2, r - l - 1).Reverse ()) {
                    var middle = middleLeft.Take (m);
                    var lastTwo = middle.Skip (m - 2);
                    if (string.Concat (lastTwo) == "AC") {

                    }
                }
            }
            /* Input & Output*/
            static int ReadInt () {
                return int.Parse (Console.ReadLine ());
            }
            static List<int> ReadInts () {
                return Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            }
            static List<List<int>> ReadColumns (int n) {
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
            static void PrintEnum<T> (IEnumerable<T> list) {
                Console.Write (list.First ());
                foreach (var item in list.Skip (1)) {
                    Console.Write ($" {item}");
                }
                Console.Write ("\n");
            }
            static void PrintLnEnum<T> (IEnumerable<T> list) {
                foreach (var item in list) {
                    Console.WriteLine (item);
                }
            }

            /* Numeric Function */
            static int Fact (int n) {
                return Enumerable.Range (1, n).Aggregate (1, ((i, k) => i * k));
            }
            static int PermNum (int n, int m) {
                if (m > n) {
                    return 0;
                }
                return Enumerable.Range (n - m, m + 1).Aggregate (1, ((i, k) => i * k));
            }
            static int CombNum (int n, int m) {
                return PermNum (n, m) / Fact (m);
            }
            // 最大公約数 (m ≧ n)
            static int GCD (int m, int n) {
                if (n == 0) {
                    return m;
                } else {
                    return GCD (n, m % n);
                }
            }
            // 最小公倍数 (m ≧ n)
            static int LCM (int m, int n) {
                return GCD (m, n) / (m * n);
            }

        }
    }