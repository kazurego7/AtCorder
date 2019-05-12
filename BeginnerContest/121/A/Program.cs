using System;
using System.Collections.Generic;
using System.Linq;

namespace A {
    class Program {
        static void Main (string[] args) {
            var HW = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var hw = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var H = HW[0];
            var W = HW[1];
            var h = hw[0];
            var w = hw[1];

            Console.WriteLine ((H - h) * (W - w));
        }
    }
}