using System;
using System.Linq;

namespace ABC081A {
    class Program {
        static void Main (string[] args) {
            // input
            var input_s1s2s3 = Console.ReadLine ();

            // decode
            var s1s2s3 = input_s1s2s3.AsEnumerable ();

            // calculation
            var count = s1s2s3.Count (s => s == '1');

            // encode
            var output_count = count.ToString ();

            // output
            Console.WriteLine (output_count);
        }
    }
}