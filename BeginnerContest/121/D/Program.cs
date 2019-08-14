using System;
using System.Collections.Generic;
using System.Linq;

namespace D {
    class Program {
        static void Main (string[] args) {
            var AB = Console.ReadLine ().Split (' ').Select (c => long.Parse (c)).ToList ();
            var A = AB[0];
            var B = AB[1];

            /*
            どんな非負整数nについても
            n ⊕ n   = 0
            なので、
            F(A,B)  = A ⊕ (A + 1) ⊕ ... ⊕ B
            より
            F(A,B)  = A ⊕ (A + 1) ⊕ ... ⊕ B ⊕ (0 ⊕ 0) ⊕ (1 ⊕ 1) ⊕ ... ⊕ ((A - 1) ⊕ (A - 1)) 
                    = {0 ⊕ 1 ⊕ ... ⊕ B} ⊕ {0 ⊕ 1 ⊕ ... ⊕ (A - 1)} (ただしA > 0)
            ゆえに
            F(A,B) = F(0,B) ⊕ F(0,A-1) (A != 0)
            また、任意の偶数eについて、
            e ⊕ (e+1) = 1
            が成り立つことを考えると、偶数Eについて
            F(0,E)  = 0 ⊕ 1 ⊕ 2 ⊕ 3 ⊕ ... ⊕ (E - 2) ⊕ (E - 1) ⊕ E
                    = (0 ⊕ 1) ⊕ (2 ⊕ 3) ⊕ ... ⊕ {(E - 2) ⊕ (E - 1)} ⊕ E
                    = 1 ⊕ 1 ⊕ ... ⊕ 1 ⊕ E
            が成り立つ。
            このとき、1の数が偶数であれば、
            F(0,E) = E
            また、F(0,E)の1の数が奇数であれば、
            F(0,E) = 1 ⊕ E = (E + 1)

            同様に、奇数Oについても、
            F(0, O) = 1 ⊕ 1 ⊕ ... ⊕ 1 ⊕ 1
            が成り立つ。
            このとき、F(0,O)の1の数が偶数であれば、F(0, O) = 0
            また、1の数が奇数であれば、F(0,O) = 1
            が成り立つ
            
             */
            if (A == 0) {
                Console.WriteLine (F (B));
            } else {
                Console.WriteLine (F (A - 1) ^ F (B));
            }
        }

        static long F (long K) {
            if (K % 2 == 0) {
                if (K % 4 == 0) {
                    return K;
                } else {
                    return K + 1;
                }
            } else {
                if (K % 4 == 3) {
                    return 0;
                } else {
                    return 1;
                }
            }
        }
    }
}