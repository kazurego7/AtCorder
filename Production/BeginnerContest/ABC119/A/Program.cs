using System;
using System.Collections.Generic;
using System.Linq;

namespace A {
    class Program {
        static void Main (string[] args) {
            var s = Console.ReadLine ();
            var dateInfos = s.Split ('/').Select (str => int.Parse (str)).ToList ();
            var yyyy = dateInfos[0];
            var mm = dateInfos[1];
            var dd = dateInfos[2];

            if (yyyy != 2019) {
                if (yyyy < 2019) {
                    Console.WriteLine ("Heisei");
                } else {
                    Console.WriteLine ("TBD");
                }
            } else if (mm != 4) {
                if (mm < 4) {
                    Console.WriteLine ("Heisei");
                } else {
                    Console.WriteLine ("TBD");
                }
            } else {
                if (dd <= 30) {
                    Console.WriteLine ("Heisei");
                } else {
                    Console.WriteLine ("TBD");
                }
            }
        }
    }
}