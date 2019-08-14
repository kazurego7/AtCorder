using AtCoderTemplate;
// 以下にAtCoder Unit Test のコードをペーストする
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtCoder {
    [TestClass]
    public class ProgramTest {
        [TestMethod]
        public void 入力例_1 () {
            string input =
                @"4 2";
            string output =
                @"3";

            AssertIO (input, output);
        }

        [TestMethod]
        public void 入力例_2 () {
            string input =
                @"1 1";
            string output =
                @"1";

            AssertIO (input, output);
        }

        [TestMethod]
        public void 入力例_3 () {
            string input =
                @"15 11";
            string output =
                @"5";

            AssertIO (input, output);
        }

        private void AssertIO (string input, string output) {
            StringReader reader = new StringReader (input);
            Console.SetIn (reader);

            StringWriter writer = new StringWriter ();
            Console.SetOut (writer);

            Program.Main (new string[0]);

            Assert.AreEqual (output + Environment.NewLine, writer.ToString ());
        }
    }
}