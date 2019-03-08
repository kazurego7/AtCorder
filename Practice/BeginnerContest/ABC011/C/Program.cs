using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var N = int.Parse (Console.ReadLine ());
            var NG1 = int.Parse (Console.ReadLine ());
            var NG2 = int.Parse (Console.ReadLine ());
            var NG3 = int.Parse (Console.ReadLine ());
            var NGs = new List<int> { NG1, NG2, NG3 }.Where (k => k <= N);

            /*
            解法2より、貪欲法を使った解法
            1. NG=NとなるNGが一つでもあればダメ
            2. 貪欲法で、Nから3,2,1の内できる限り大きな数字を引いていき、100回繰り返して0以下ならOK
               また途中、3,2,1のいずれも引けない場合（NGが13,14,15のように3連続になる場合）もダメ
             */
            if (NGs.Any (NG => NG == N)) {
                Console.WriteLine ("NO");
                return;
            }

            var subSum = N;
            foreach (var i in Enumerable.Range (0, 100)) {
                if (NGs.All (NG => subSum - 3 != NG)) {
                    subSum -= 3;
                } else if (NGs.All (NG => subSum - 2 != NG)) {
                    subSum -= 2;
                } else if (NGs.All (NG => subSum - 1 != NG)) {
                    subSum -= 1;
                } else {
                    Console.WriteLine ("NO");
                    return;
                }
            }

            if (subSum <= 0) {
                Console.WriteLine ("YES");
                return;
            } else {
                Console.WriteLine ("NO");
                return;
            }

        }
    }
}