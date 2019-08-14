using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var N = int.Parse (Console.ReadLine ());
            var qq = Enumerable.Range (1, 9).Select (i => Enumerable.Range (1, 9).Select (k => i * k).Sum ()).Sum (); // 1 * 1 ~ 9 * 9 までの総和
            var forgotten = qq - N;
            /*
            忘れた答えf = N - (1 * 1 ~ 9 * 9 までの総和)
            割られた数は、条件より、1~9の範囲かつ同じ数が二度と現れないことを考える。
            （同じ数が二度と現れない、とは f = n * mとなるようなn,mがあるとき、nについてn=kと固定してみると
              f = k * m1, f = k * m2 (m1 != m2)
              となるようなm2が存在しない、つまりnを固定するとただ一つのmが求まる、という意味。)
             */
            var divided = Enumerable.Range (1, 9).Where (i => forgotten / i <= 9 && forgotten % i == 0).ToList ();
            var divisor = divided.Select (i => forgotten / i).ToList ();
            foreach (var i in Enumerable.Range (0, divided.Count)) {
                Console.WriteLine ($"{divided[i]} x {divisor[i]}");
            }
        }
    }
}