using System;
using System.Linq;

namespace ABC087B {
    class Program {
        static void Main (string[] args) {
            // input & decode
            var A = int.Parse (Console.ReadLine ());
            var B = int.Parse (Console.ReadLine ());
            var C = int.Parse (Console.ReadLine ());
            var X = int.Parse (Console.ReadLine ());

            // calculation
            var count = 0;
            foreach (var a in Enumerable.Range (0, A + 1)) {
                foreach (var b in Enumerable.Range (0, B + 1)) {
                    foreach (var c in Enumerable.Range (0, C + 1)) {
                        if (500 * a + 100 * b + 50 * c == X) {
                            count = count + 1;
                        }
                    }
                }
            }

            // encode & output
            Console.WriteLine (count);
        }
    }
}