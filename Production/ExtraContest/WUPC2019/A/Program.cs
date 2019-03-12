using System;
using System.Collections.Generic;
using System.Linq;

namespace A {
    class Program {
        static void Main (string[] args) {
            var s = Console.ReadLine ().ToCharArray ();
            var n = s.Count ();
            var w0 = 0;
            while (w0 < n) {
                // 一つ目のwの位置w0を探す
                if (s[w0] == 'W') {
                    // 連続するwの最後の位置weを探す
                    var we = w0;
                    while (true) {
                        if (we == n) {
                            Console.WriteLine (s);
                            return;
                        }
                        if (s[we] != 'W') {
                            break;
                        } else {
                            we += 1;
                        }
                    }
                    if (s[we] == 'A') {
                        s[w0] = 'A';
                        foreach (var i in Enumerable.Range (w0 + 1, we - w0)) {
                            s[i] = 'C';
                        }

                        // s = s.Remove (w0, we - w0 + 1);
                        // s = s.Insert (w0, "A" + string.Concat (Enumerable.Repeat ('C', we - w0)));
                    }
                    w0 = we + 1;
                } else {
                    w0 += 1;
                }
            }

            Console.WriteLine (s);
        }
    }
}