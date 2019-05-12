using System;
using System.Collections.Generic;
using System.Linq;

namespace B {
    class Program {
        static void Main (string[] args) {
            var HW = Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
            var H = HW[0];
            var W = HW[1];
            var A = Enumerable.Range (0, H).Select (_ => Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ()).ToList ();

            if (A.SelectMany (AH => AH.Where (AHW => AHW == 5)).Count () == 0 && !(A.All (AH => AH.All (AHW => AHW == 0)))) {
                // 全て0でなく、5が一つもない場合 ×
                Console.WriteLine ("No");
            } else if ((H == 1 && A[0][0] != 5 && A[0][W - 1] != 5) || (W == 1 && A[0][0] != 5 && A[H - 1][0] != 5)) {
                // 1列または1行で、端に5がない(=真ん中に5があり非連結な領域が2つある状態)
                List<int> A1;
                var length = 0;
                if (H == 1) {
                    A1 = A[0]; // 1行
                    length = W;

                } else {
                    A1 = A.Select (AH => AH[0]).ToList (); // 1列
                    length = H;

                }
                var fiveIndexs = Enumerable.Range (1, length - 2).Where (i => A1[i] == 5).ToList ();
                var maxs = fiveIndexs.Select (i => solve (A1.Take (i + 1)) + solve (A1.Skip (i))).ToList ();
                var maxFiveIndex = fiveIndexs[Enumerable.Range (0, fiveIndexs.Count ()).OrderBy (i => maxs[i]).First ()];

                Console.WriteLine (solve (A1.Take (maxFiveIndex + 1)) + solve (A1.Skip (maxFiveIndex)) - 1);
            } else {
                Console.WriteLine ("Yes " + solve (A.SelectMany (AH => AH))); // 2次元配列を1次元に
            }
        }
        static int solve (IEnumerable<int> A) {
            if (A.All (AHW => AHW == 0)) {
                return 0;
            } else if (A.Where (AHW => AHW == 9).Count () != 0) {
                return 4;
            } else if (A.Where (AHW => AHW == 8).Count () != 0) {
                return 3;
            } else if (A.Where (AHW => AHW == 7 || AHW == 6).Count () != 0) {
                return 2;
            } else {
                return 1;
            }
        }
    }
}