using System;
using System.Collections.Generic;
using System.Linq;

namespace B {
    class Program {
        static void Main (string[] args) {
            var NMC = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var N = NMC[0];
            var M = NMC[1];
            var C = NMC[2];
            var BMs = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var ANss = Enumerable.Range (0, N).Select (_ => Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ()).ToList ();

            var sol = ANss.Select (ANs => Enumerable.Range (0, M).Select (k => ANs[k] * BMs[k]).Sum () + C).Where (sum => sum > 0).Count ();
            Console.WriteLine (sol);
        }
    }
}