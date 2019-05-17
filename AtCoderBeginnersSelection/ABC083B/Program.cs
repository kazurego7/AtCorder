using System;
using System.Linq;

namespace ABC083B {
    class Program {
        static void Main (string[] args) {
            // input & decode
            var NAB = Console.ReadLine ().Split (' ');
            var N = int.Parse (NAB[0]);
            var A = int.Parse (NAB[1]);
            var B = int.Parse (NAB[2]);

            // calculation
            var ans = Enumerable.Range (1, N).Where (z => {
                    var sum = DigitSum (z.ToString ());
                    return A <= sum && sum <= B;
                })
                .Sum ();

            // encode & output
            Console.WriteLine (ans);
        }

        static int DigitSum (string str) {
            return str.Aggregate (0, (accm, c) => accm + int.Parse (c.ToString ()));
        }
    }
}