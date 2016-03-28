using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TextServices;

namespace Tests
{
    [TestFixture]
    public class WordCountTests : TestBase
    {
        [Test]
        public void TestCore()
        {
            var input = "Go do that thing that you do so well";

            WordCounter wordCounter =  new WordCounter();
            RunInstanceMethod(typeof(TextServices.WordCounter), "TokenizeAndCount", wordCounter, new object[] { input });

            var d = wordCounter.WordDictionary;

            Assert.AreEqual(d["Go"],1);
            Assert.AreEqual(d["do"], 2);
            Assert.AreEqual(d["that"], 2);
            Assert.AreEqual(d["thing"], 1);
            Assert.AreEqual(d["you"], 1);
            Assert.AreEqual(d["so"], 1);
            Assert.AreEqual(d["well"], 1);
        }
    }
}