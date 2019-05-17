using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC085B {
    class Program {
        static void Main (string[] args) {
            // input & decode
            var N = int.Parse (Console.ReadLine ());
            var d = new List<int> ();
            foreach (var i in Enumerable.Range (0, N)) {
                d.Add (int.Parse (Console.ReadLine ()));
            }

            // calculation
            var count = d.OrderBy (x => x).Distinct ().Count ();

            // encode & output
            Console.WriteLine (count);

        }
    }
}