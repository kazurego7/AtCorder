using System;
using System.Collections.Generic;
using System.Linq;
using static AtCoderTemplate.MyInputOutputs;

namespace AtCoderTemplate {
    public class Program {
        public static void Main (string[] args) {
            var NK = ReadLongs ();
            var N = NK[0];
            var K = NK[1];
            var ab = ReadIntColumns ((int) N);
            var a = ab[0];
            var b = ab[1];

            var sortIndex = a.SortIndex ().ToList ();
            var sortB = sortIndex.Select (i => (long) b[i]);
            var cumsum = sortB.Scanl1 ((x, y) => x + y);
            var ansIndex = cumsum.TakeWhile (cum => cum < K).Count () + 1 - 1;
            Print (a[sortIndex[ansIndex]]);
        }
    }

    public static class MyInputOutputs {
        /* Input & Output*/
        public static List<int> ReadInts () {
            return Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
        }
        public static List<long> ReadLongs () {
            return Console.ReadLine ().Split (' ').Select (c => long.Parse (c)).ToList ();
        }
        public static List<List<int>> ReadIntColumns (int n) {
            /*
            入力例
            A1 B1
            A2 B2
            ...
            An Bn

            出力例
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var rows = Enumerable.Range (0, n).Select (i => ReadInts ()).ToList ();
            var m = rows.FirstOrDefault ()?.Count () ?? 0;
            return Enumerable.Range (0, m).Select (i => rows.Select (items => items[i]).ToList ()).ToList ();
        }
        public static void Print<T> (T item) {
            Console.WriteLine (item);
        }
    }

    public static class MyExtensions {

        /// <summary>
        /// 累積項を要素にもつシーケンスを得る（初項は、source.First()）
        /// <para>O(N)</para>
        /// </summary>
        /// <param name="source">元のシーケンス</param>
        /// <param name="func">2引数関数f</param>
        /// <example> [1,2,3].Scanl1(f) => [1, f(1,2), f(f(1,2),3)]</example>
        public static IEnumerable<T> Scanl1<T> (this IEnumerable<T> source, Func<T, T, T> func) {
            var list = source.ToList ();
            var result = new List<T> { list[0] };
            foreach (var i in Enumerable.Range (1, source.Count () - 1)) {
                result.Add (func (result[i - 1], list[i]));
            }
            return result;
        }

        /// <summary>
        /// 昇順にソートしたインデックスを得る
        /// </summary>
        /// <para>O(N * log N)</para>
        public static IEnumerable<int> SortIndex<T> (this IEnumerable<T> source) {
            return source
                .Select ((item, i) => new { Item = item, Index = i })
                .OrderBy (x => x.Item)
                .Select (x => x.Index);
        }
    }
}