using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProCSharpCode;

namespace ProfessionalCSharpCode.Tests
{
    [TestClass]
    public class ScriptsTest
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }


        [TestMethod]
        public void TestConvertTextToMaxCharsPerLineTest_LongText_TextWithEachLineHasWordsMax15CharPerLine()
        {
            // prepare
            var text = @"hello my name is moamen i am happy to see  you today.
if you are fine, please say i am fine
, don't be like foolish.
bad one";
            // this with 15 char per line
            var expected = @"hello my name 
is moamen i am
happy to see 
you today.
, don't be like
foolish.
bad one";

            //act 
            var actual = Scripts.ConvertTextToMaxCharsPerLine(text, 15);

            TestContext.WriteLine(actual);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}
