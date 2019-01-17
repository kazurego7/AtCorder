using System;
using System.Collections.Generic;
using System.Linq;

namespace c {
    class Program {
        static void Main (string[] args) {
            var t = int.Parse (Console.ReadLine ());
            var n = int.Parse (Console.ReadLine ());
            var a = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var m = int.Parse (Console.ReadLine ());
            var b = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();

            // calc
            var maxAwithinB = b.Select (bi => a.TakeWhile (ai => ai <= bi).Last ()).ToList ();
            var isYes = false;
            if (n < m) {
                isYes = false;
            } else {
                isYes = Enumerable.Range (0, b.Count).All (i => b[i] - maxAwithinB[i] >= t);
            }

        }
    }
}