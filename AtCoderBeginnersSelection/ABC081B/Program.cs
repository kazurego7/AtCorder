using System;
using System.Linq;

namespace ABC081B {
    class Program {
        static void Main (string[] args) {
            // input
            var input_N = Console.ReadLine ();
            var input_A = Console.ReadLine ();

            // decode
            var N = int.Parse (input_N);
            var A = input_A.Split (' ').Select (Ai => long.Parse (Ai));

            // calculation
            var count = 0;
            while (A.All (Ai => Ai % 2 == 0)) {
                A = A.Select (Ai => Ai / 2);
                count = count + 1;
            }

            // encode
            var output_count = count.ToString ();

            // output
            Console.WriteLine (output_count);
        }
    }
}