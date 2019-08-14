using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderTemplate {
    class Program {
        static void Main (string[] args) {
            var NM = ReadInts ();
            var N = NM[0];
            var M = NM[1];
            var lrs = ReadSequence (N);
            var l = lrs[0];
            var r = lrs[1];
            var s = lrs[2];

            Console.WriteLine (ImosuCalc (N, M, l, r, s));
        }
        /*
            解説より
            ・連続した整数を覆う区間と、その区間に対する得点がいくつか与えられる
            ・1からMまでの全てが登場しないように区間の集合を選ぶ
            ・選んだ区間の得点の合計を最大化する
            1 ≦ N ≦ 10^5
            1 ≦ M ≦ 10^5
        */

        /*
        部分点解法1(30点)
        全探索
        ・N個の区間について、それらの組み合わせを要素とする集合Sを考える
        ・集合Sの各要素について、数字mを覆う区間があるかを判定し、m=1,2,...M全てに存在すれば、その要素は条件を満たさない。
        (集合Sの各要素は区間を選んだか選んでないかをN回繰り返すのでn(S)=2^N、最大N個の区間に対してM回判定を繰り返すのでO(N * M * 2^N))
        */
        static int FullSerch (int N, int M, List<int> l, List<int> r, List<int> s) {
            var flags = Enumerable.Range (0, (int) Math.Pow (2, N)) // bitフラグ
                .Where (flag => !Enumerable.Range (1, M).All (m =>
                    Enumerable.Range (0, N).Where (i => (flag >> i) % 2 == 1)
                    .Any (i => l[i] <= m && m <= r[i])
                ));
            var sums = flags.Select (flag =>
                Enumerable.Range (0, N)
                .Where (i => (flag >> i) % 2 == 1)
                .Select (i => s[i]).Sum ()
            );
            return sums.Max ();
        }

        /*
        部分点解法2(30+70点)
        条件を満たす集合の全探索
        ・「1からMまでの全てが登場しないように区間の集合を選ぶ」という条件を、「選んだ各区間に少なくとも1つの数字が登場しない」ととらえる
        ・登場しない数字Xを固定したとき、N個の区間でXを含まないものを選んだ合計得点は「各区間に少なくとも数字Xが登場しない」ものの最大となるので、全てXについてさらにその最大を求めればよい
        (全M通りのXについて、最大でN個の和を求めるので、全体でO(N*M))
        */
        static int ConditionalFullSearch (int N, int M, List<int> l, List<int> r, List<int> s) {
            return Enumerable.Range (1, M)
                .Select (m =>
                    Enumerable.Range (0, N)
                    .Where (i => !(l[i] <= m && m <= r[i]))
                    .Select (i => s[i])
                    .Sum ()
                ).Max ();
        }

        /*
        満点解法
        いもす法による最大得点の計算
        ・部分点解法2より、各区間に少なくとも数字Xが登場しない区間について考えると、「全区間を含む合計得点から、Xを含む区間の合計得点の内最小を引く」とすればよい
        (各数字XについてXを含む区間の合計得点をそれぞれもとめるために、いもす法を使うとO(N+M)で解ける)
         */

        static int ImosuCalc (int N, int M, List<int> l, List<int> r, List<int> s) {
            // いもす法より、合計得点の差分を求める dff[i] = sums[i] - sums[i-1]
            var diff = new int[M + 2]; // 0とM+1を含んでおかないと面倒なのでM+2
            foreach (var i in Enumerable.Range (0, N)) {
                diff[l[i]] += s[i];
                diff[r[i] + 1] += -s[i]; // r[i]だとm<r[i]の範囲になってしまうので、r[i]+1
            }
            // いもす法より、差分から合計得点を求める
            var sums = new int[M + 1];
            foreach (var m in Enumerable.Range (1, M)) {
                sums[m] = sums[m - 1] + diff[m];
            }
            var full = s.Sum ();
            var min = sums.Skip (1).Min ();
            return full - min;

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