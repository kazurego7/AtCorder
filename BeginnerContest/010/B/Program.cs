using System;
using System.Collections.Generic;
using System.Linq;

namespace B {
    class Program {
        static void Main (string[] args) {
            var n = int.Parse (Console.ReadLine ());
            var ans = Console.ReadLine ().Split (' ').Select (c => int.Parse (c));

            /*
            好きを0、嫌いを1、大好きを2、とおくと各パターンについて、
            A:01
            B:012
            のA,Bの2つの列を考えることができる。
            ここで、列Aは2個、列Bは3個ごとにパターンを繰り返すので、両方のパターンが6個毎に周期ができる
            A: 010101 010101 ...
            B: 012012 012012 ...
            なので、花びらを6つに分けて、さいごに余った花びらの数rから、ちぎる必要のある枚数kを見ればよい。

            r: 123450
            ---------
            A: 010101
            B: 012012
            ---------
            k: 010123
            */

            var k = new int[6] { 0, 1, 0, 1, 2, 3 };

            Console.WriteLine (ans.Select (a => k[(a - 1) % 6]).Sum ());
        }
    }
}