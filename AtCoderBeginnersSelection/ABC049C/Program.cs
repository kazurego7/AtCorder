using System;
using System.Linq;

namespace ABC049C {
    class Program {
        static void Main (string[] args) {
            var S = Console.ReadLine ();

            var Srev = String.Concat (S.Reverse ());

            var dreamRev = String.Concat ("dream".Reverse ());
            var eraseRev = String.Concat ("erase".Reverse ());
            var eraserRev = String.Concat ("eraser".Reverse ());
            var dreamerRev = String.Concat ("dreamer".Reverse ());

            var ans = "YES";
            var i = 0;
            while (i < Srev.Length) {
                if (EqualSubstring (Srev, i, dreamRev) || EqualSubstring (Srev, i, eraseRev)) {
                    i = i + 5;
                    continue;
                } else if (EqualSubstring (Srev, i, eraserRev)) {
                    i = i + 6;
                    continue;
                } else if (EqualSubstring (Srev, i, dreamerRev)) {
                    i = i + 7;
                    continue;
                } else {
                    ans = "NO";
                    break;
                }
            }

            Console.WriteLine (ans);
        }

        static bool EqualSubstring (string str, int subHeadIndex, string compared) {
            if (compared.Length > str.Length - subHeadIndex + 1) return false;
            var ans = true;
            foreach (var i in Enumerable.Range (0, compared.Length)) {
                if (str[subHeadIndex + i] != compared[i]) {
                    ans = false;
                }
            }
            return ans;
        }
    }
}