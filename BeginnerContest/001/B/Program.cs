using System;

namespace B {
    class Program {
        static void Main (string[] args) {
            // input
            var m = int.Parse (Console.ReadLine ());
            // calc
            var result = 0;
            if (m < 100) {
                result = 0;
            } else if (100 <= m && m <= 5000) {
                result = m / 100;
            } else if (6000 <= m && m <= 30000) {
                result = m / 1000 + 50;
            } else if (35000 <= m && m <= 70000) {
                result = (m / 1000 - 30) / 5 + 80;
            } else {
                result = 89;
            }
            Console.WriteLine ($"{result:D2}");
        }
    }
}