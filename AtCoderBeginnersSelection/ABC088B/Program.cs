using System;
using System.Linq;

namespace ABC088B {
    class Program {
        static void Main (string[] args) {
            // input & decode
            var N = int.Parse (Console.ReadLine ());
            var a = Console.ReadLine ().Split (' ')
                .Select (c => int.Parse (c));

            // calculation
            var sortedA = a.OrderByDescending (x => x).ToList ();
            var evens = Enumerable.Range (0, N)
                .Where (i => i % 2 == 0);
            var odds = Enumerable.Range (0, N)
                .Where (i => i % 2 != 0);
            var alice = evens.Select (i => sortedA[i]).Sum ();
            var bob = odds.Select (i => sortedA[i]).Sum ();
            var sub = alice - bob;

            // encode & output
            Console.WriteLine (sub);
        }
    }
}