using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC086C {
    class Program {
        static void Main (string[] args) {
            var N = int.Parse (Console.ReadLine ());
            var txy = new List<List<string>> ();
            foreach (var i in Enumerable.Range (0, N)) {
                txy.Add (Console.ReadLine ().Split (' ').ToList ());
            }
            var t = Enumerable.Range (0, N).Select (i => int.Parse (txy[i][0])).ToList ();
            var x = Enumerable.Range (0, N).Select (i => int.Parse (txy[i][1])).ToList ();
            var y = Enumerable.Range (0, N).Select (i => int.Parse (txy[i][2])).ToList ();

            var dt = new List<int> { t[0] };
            foreach (var i in Enumerable.Range (1, N - 1)) {
                dt.Add (Math.Abs (t[i] - t[i - 1]));
            }

            var dx = new List<int> { x[0] };
            foreach (var i in Enumerable.Range (1, N - 1)) {
                dx.Add (Math.Abs (x[i] - x[i - 1]));
            }

            var dy = new List<int> { y[0] };
            foreach (var i in Enumerable.Range (1, N - 1)) {
                dy.Add (Math.Abs (y[i] - y[i - 1]));
            }

            var ans = "Yes";
            foreach (var i in Enumerable.Range (0, N)) {
                var isOverTime = dx[i] + dy[i] > dt[i];
                var cannotJustStop = (dt[i] - dx[i] + dy[i]) % 2 != 0;
                if (isOverTime || cannotJustStop) {
                    ans = "No";
                }
            }

            Console.WriteLine (ans);
        }
    }
}