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
    public class FunctionsTests
    {
        [TestMethod()]
        public void searchTest()
        {
            //variables
            string infoToLookFor = "Sherlock";
            string resultOfSearch = "none";
            string forseenResult =
           "978-0486474915;The Adventures of Sherlock Holmes;Arthur Conan Doyle;Adventure Mystery;0";

            //do the search in bookList
            foreach (Book bookFromList in Book.bookList)
            {
                if (Functions.search(infoToLookFor, bookFromList) != "no match")
                {
                    resultOfSearch = Functions.search(infoToLookFor, bookFromList);
                    resultOfSearch = resultOfSearch.Replace(" --- ", ";");
                    break;
                }
            }
            //found the right book?
            StringAssert.Contains(resultOfSearch, forseenResult);
        }

        [TestMethod()]
        public void searchRTest()
        {
            //variables
            string infoToLookFor = "move";
            string resultOfSearch = "none";
            string forseenResult =
           "move4582 --- monika --- vedrickaite --- email@email.com  --- 1998";

            //do the search
            foreach (User reader in User.readerList)
            {
                if (Functions.searchR(infoToLookFor, reader) != "no match")
                {
                    resultOfSearch = Functions.searchR(infoToLookFor, reader);
                    resultOfSearch = resultOfSearch.Replace(" --- ", ";");
                    break;
                }
            }
            //found the right user?
            Assert.AreEqual(forseenResult, resultOfSearch);
        }

        [TestMethod()]
        public void inputCheckTest()
        {
            string email = "me@gm.com";
            int ExRe = 1;
            int result = Functions.inputCheck(email, 1);
            Assert.AreEqual(ExRe, result);

        }
    }
}