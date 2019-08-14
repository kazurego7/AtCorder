using System;

namespace ABC086A {
    class Program {
        static void Main (string[] args) {
            // input
            var input_ab = Console.ReadLine ().Split (' ');

            // decode
            var a = int.Parse (input_ab[0]);
            var b = int.Parse (input_ab[1]);

            // calculation
            var isEven = (a * b) % 2 == 0;

            // encode
            var output = "";
            output = isEven ? "Even" : "Odd";

            // output
            Console.WriteLine (output);
        }
    }
}