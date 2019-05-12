using System;
using System.Collections.Generic;
using System.Linq;

namespace A {
    class Program {
        static void Main (string[] args) {
            var N = int.Parse (Console.ReadLine ());
            var S = Console.ReadLine ();
            var a2z = Enumerable.Range ('a', 'z' - 'a' + 1).Select (i => (char) i);

        }
        static int Comb (int n, int m) {
            if (m == 0) return 1;
            if (n == 0) return 0;
            return n * Comb (n - 1, m - 1) / m;
        }
        static int SolveHead (string S, int N, int i, int k) {
            if (k == N) {
                return Comb (k - i, );
            } else if (S[i] == S[k]) {
                return SolveHip (S, N, i, k);
            } else {
                return SolveHead (S, N, i, k + 1);
            }
        }

        static int SolveHip (string S, int N, int i, int k) {
            if (k == N) {
                return 0;
            } else if (i == k) {
                return SolveHead (S, N, i, k);
            } else {
                return Comb (i - k)
            }
        }
    }
}