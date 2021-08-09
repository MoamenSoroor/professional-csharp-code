using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProCSharpCode.ExtensionMethods;
using System.Linq;

namespace ProCsharpCode.ExtensionMethods.Tests
{
    [TestClass]
    public class StringExtensionMethodsTests
    {

        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [TestMethod]
        public void SplitAtTest()
        {
            string text = string.Join(" ",Enumerable.Repeat("hello", 4));

            var indices = new[] { 5, 10, 15, 20,23 };

            var expected = new[] { "hello"," hell", "o hel", "lo he", "llo","" };
            //hello - hell - o hel - lo he - llo
            var actual = text.SplitAt(indices);

            TestContext.WriteLine(string.Join("-", actual));

            CollectionAssert.AreEqual(expected, actual);

        }
    }
}
