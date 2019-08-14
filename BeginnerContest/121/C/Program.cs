using System;
using System.Collections.Generic;
using System.Linq;

namespace C {
    class Program {
        static void Main (string[] args) {
            var NM = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var N = NM[0];
            var M = NM[1];
            var ABs = new List<List<long>> ();
            foreach (var i in Enumerable.Range (0, N)) {
                ABs.Add (Console.ReadLine ().Split (' ').Select (c => long.Parse (c)).ToList ());
            }
            var sortedABs = ABs.OrderBy (AB => AB[0]).ToList ();

            var boughtNum = 0L;
            var sumYen = 0L;
            foreach (var i in Enumerable.Range (0, N)) {
                var needNum = M - boughtNum;
                var A = sortedABs[i][0];
                var B = sortedABs[i][1];
                if (needNum <= B) {
                    sumYen += needNum * A;
                    break;
                } else {
                    sumYen += B * A;
                    boughtNum += B;
                }
            }
            Console.WriteLine (sumYen);
        }
    }
}