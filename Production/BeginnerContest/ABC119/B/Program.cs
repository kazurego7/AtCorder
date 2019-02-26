using System;
using System.Collections.Generic;
using System.Linq;

namespace B {
    class Program {
        static void Main (string[] args) {
            var n = int.Parse (Console.ReadLine ());
            var xs = new List<double> ();
            var us = new List<string> ();
            foreach (var i in Enumerable.Range (0, n)) {
                var xu = Console.ReadLine ().Split (' ');
                var x = xu[0];
                var u = xu[1];
                xs.Add (double.Parse (x));
                us.Add (u);
            }

            var fullAmount = 0.0;
            foreach (var i in Enumerable.Range (0, n)) {
                if (us[i] == "JPY") {
                    fullAmount += xs[i];
                } else {
                    var bc2yen = xs[i] * 380000.0;
                    fullAmount += bc2yen;
                }
            }

            Console.WriteLine (fullAmount);
        }
    }
}