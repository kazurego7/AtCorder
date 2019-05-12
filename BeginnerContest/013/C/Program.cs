using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var NH = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var ABCDE = Console.ReadLine ().Split (' ').Select (c => long.Parse (c)).ToList ();

            var N = NH[0];
            var H = NH[1];
            var A = ABCDE[0];
            var B = ABCDE[1];
            var C = ABCDE[2];
            var D = ABCDE[3];
            var E = ABCDE[4];

            /*
            100点について、線形計画問題ととらえることができる
            普通の食事の回数をX回、質素な食事の回数をY回と定める（食事抜きはN-X-Y回）
            あとは、XとYについて制約式
            H+B*X+D*Y-(N-X-Y)*E>0
            の条件を満たすX,Yを探索する(O(n^2))
            そのうちの最小のA*X+C*Yを出せばよい。
             */
            // var sol = Enumerable
            //     .Range (0, N + 1)
            //     .SelectMany (X =>
            //         Enumerable
            //         .Range (0, N - X + 1)
            //         .Where (Y => H + B * X + D * Y - (N - X - Y) * E > 0)
            //         .Select (Y => A * X + C * Y))
            //     .Min ();
            var sol = Enumerable
                .Range (0, N + 1)
                .Select (X => {
                    var Y = (long) Math.Floor ((double) ((N - X) * E - H - B * X) / (D + E)) + 1;
                    //Console.WriteLine (X + ":" + Y);
                    if (0 <= Y && Y <= N - X) {
                        return A * X + C * Y;
                    } else {
                        return long.MaxValue;
                    }
                })
                .Min ();
            Console.WriteLine (sol);
        }
    }
}