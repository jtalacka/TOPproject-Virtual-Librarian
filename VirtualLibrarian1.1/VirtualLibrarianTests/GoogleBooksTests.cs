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
    public class GoogleBooksTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            GoogleBooks book;
            book = new GoogleBooks();
            book.Search("9789986029199");

        }
    }
}