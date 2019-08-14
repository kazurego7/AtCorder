using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var n = int.Parse (Console.ReadLine ());
            var a = new List<int> ();
            var b = new List<int> ();
            foreach (var i in Enumerable.Range (0, n)) {
                var ab = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
                a.Add (ab[0]);
                b.Add (ab[1]);
            }

            /*
            いもす法を用いる
            いもす法は、f(x) = if (A <= x <= B) 1 else 0 (ただし 0 <= A <= B <= T) の形となるようなN個の関数F_i(i=1,2,...,N)の和の最大値を求める方法。
            具体的には、
            1. 関数F_iの和の差分を求める
            2. 差分の累積和を求める
            3. 最大値を求める
            の3つの手順に分割し、1.の差分の求め方が計算量を減らすキモになる。
            */

            var k = 1000000;
            var diff = new int[(k + 1) + 1];
            foreach (var i in Enumerable.Range (0, n)) {
                diff[a[i]] += 1;
                diff[b[i] + 1] -= 1;
            }

            var cum = new int[(k + 1) + 1];
            cum[0] = diff[0];
            foreach (var i in Enumerable.Range (1, k + 1)) {
                cum[i] = diff[i] + cum[i - 1];
            }
            Console.WriteLine (cum.Max ());
        }
    }
}