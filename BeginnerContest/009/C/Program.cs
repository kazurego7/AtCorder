using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var NK = Console.ReadLine ().Split (' ').Select (c => int.Parse (c));
            var N = NK.First ();
            var K = NK.Take (2).Last ();
            var S = Console.ReadLine ();

            var sol = LimitedSort (N, K, S, string.Concat (S.OrderBy (a => a)), 0, 0, "");
            Console.WriteLine (sol);

            // Console.WriteLine (CountMinDifference ("oder", "deor"));

        }

        /* 答え概略
        目的：
        　元の文字列Sから、動く文字がK個以内で辞書順最小の文字列Tを求める。
        方法：
        1. 文字列Tのi番目の文字を決めるため、Tでまだ使われていない最小の文字C_iを文字列Sから探す
        　  例)
            S = program
            T = aro まで決まっている
            i = 4 のとき、Tでまだ使われていないSの文字は"p,g,m,r*2"(rは2個)
            よって、Tで使われていないSの最小の文字C_4は、g
        2. 最小の文字C_iをTのi番目の文字にしたとき、残りの文字の不一致が最も小さくなるように並び替えるとKを超えてしまうか？
            例)
            K = 3
            S = program
            T = aro まで決まっている
            ここで、C_4 = g まで決めると、
            T = arog***
            となる(***はm,p,rのいずれか)
            このとき、Tの残りの3文字の不一致が最も小さくなるように並び替えると、
            T = arogrpm
            S = program
            Sと比較して、不一致の数が2個となるので、まだ並び替えることができる

         2.a 超えていれば、また残りの文字から次に最小の文字となるものを探す。1.へ
         2.b そうでなければC_iは決定、i+1をして繰り返す。1.へ
         3. 残りの文字がなくなれば終わり
        */

        static string LimitedSort (int N, int K, string source, string sortedRest, int index, int differCount, string target) {
            if (index == N) {
                return target;
            } else {
                //Console.WriteLine (sortedRest);
                foreach (var i in Enumerable.Range (0, sortedRest.Count ())) {
                    var nextRest = sortedRest.Remove (i, 1);
                    var minRestDifferenceCount = CountMinDifference (string.Concat (source.Skip (index + 1)), nextRest);
                    var nextDifferCount = differCount + (source[index] != sortedRest[i] ? 1 : 0);

                    // Console.WriteLine (minRestDifferenceCount);
                    // Console.WriteLine (string.Concat (source.Skip (index + 1)));
                    // Console.WriteLine (nextRest);
                    // Console.WriteLine (nextDifferCount);
                    if (minRestDifferenceCount + nextDifferCount <= K) {
                        return LimitedSort (N, K, source, nextRest, index + 1, nextDifferCount, target + sortedRest[i]);
                    }
                }
                return target;
            }
        }

        /* 2つの文字列の各文字の組み合わせについて、異なる文字が最小となったときの不一致の文字数、を求める関数

        2つの文字列S',T'について、
        S' = aaabbc
        T' = aabccc
        とおいてみる
        文字aについて、S'の3つに対して、T'の2つだけ一致する。
        文字bについて、T'の2つに対して、S'の1つだけ一致する。
        このように、a~zの各文字について、S'とT'の内最小の方の文字数が一致する文字数となる。
        よって、S'とT'の各文字の組み合わせについて、異なる文字が最小となった時の一致する文字数Mが、以下の式で求められる。

        M = min(S'のaの数, T'のaの数)
        + min(S'のbの数, T'のbの数)
        ~~
        + min(S'のyの数, T'のyの数)
        + min(S'のzの数, T'のzの数)

        ゆえに、S'とT'の文字列の各文字の組み合わせについて、異なる文字が最小となったときの不一致の文字数は、以下の式で求められる。
        S'の文字数 - M        

        */
        static int CountMinDifference (string source, string target) {
            var a2z = Enumerable.Range ('a', 'z' - 'a' + 1).Select (i => (char) i);
            var minSameCount = a2z.Select (c => Math.Min (CountChar (source, c), CountChar (target, c))).Sum ();
            return source.Count () - minSameCount;
        }
        static int CountChar (string source, char c) {
            return source.Where (x => x == c).Count ();
        }
    }
}