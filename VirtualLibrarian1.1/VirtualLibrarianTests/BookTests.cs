using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualLibrarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Tests
{
    [TestClass()]
    public class BookTests
    {
        [TestMethod()]
        public void ObToStringTest()
        {
            List<string> g = new List<string>{ "advent", "thrill", "horror" };
            Book testBook = new Book("97856325899", "title", "author", g, 10);
            string wantedRes = "97856325899 --- title --- author --- " +
                "advent thrill horror --- 10";

            string testRes = testBook.ObToString(testBook);

            Assert.AreEqual(wantedRes, testRes);
        }
    }
}