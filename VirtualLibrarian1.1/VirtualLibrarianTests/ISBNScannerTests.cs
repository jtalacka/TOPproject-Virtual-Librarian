using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualLibrarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VirtualLibrarian.Tests
{
    [TestClass()]
    public class ISBNScannerTests
    {
        [TestMethod()]
        public void ISBNScannerTest()
        {
            ISBNScanner test = new ISBNScanner();
            Bitmap barcodeBitmap = new Bitmap(@"c:\xampp\htdocs\psi\1.jpg");
            string wantedresults = "0109312345678907";
            string result=test.readISBN(barcodeBitmap);

            Assert.AreEqual(wantedresults, result);

        }

    }
}