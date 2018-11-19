using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualLibrarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian.Tests
{
    [TestClass()]
    public class GoogleBooksTests
    {
        [TestMethod()]
        public void SearchTest()
        {


            Book tempBook = GoogleBooks.Search("9789986029199").Result;
            if (tempBook != null)
            {
                MessageBox.Show(tempBook.ISBN + tempBook.title + tempBook.author);
            }

        }
    }
}