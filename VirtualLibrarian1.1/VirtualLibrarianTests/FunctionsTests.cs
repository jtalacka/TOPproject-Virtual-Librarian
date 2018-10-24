using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualLibrarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

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

            List<string> g = new List<string> { "Adventure", "Mystery" };
            List<Book> bookList = new List<Book>
                {
                new Book("978-1786298997", "A Brush with Chaos", "Ken Melber", g, 1), 
                new Book("978-0486275437", "Alice in Woderland", "Lewis Carol", g, 2),
                new Book("978-0486474915", "The Adventures of Sherlock Holmes", "Arthur Conan Doyle", g, 1)
                };


            string forseenResult =
           "978-0486474915 --- The Adventures of Sherlock Holmes --- " +
           "Arthur Conan Doyle --- Adventure Mystery --- 1";
            string testRes = "";


            //checks all the books in the list bookList
            foreach (Book tempBook in bookList)
            {
                //checks tempBook - if it fits, returns tempBook info to display            
                if (Functions.search(infoToLookFor, tempBook) != "no match")
                {
                    testRes = Functions.search(infoToLookFor, tempBook);
                    break;
                }
            }
            //found the right book?
            Assert.AreEqual(testRes, forseenResult);
        }

        [TestMethod()]
        public void searchRTest()
        {
            //variables
            string infoToLookFor = "move4582";
            List<User> readerList = new List<User>
                {
                new User("user1", "Lazy", "Batch", "email.com", "2000"), 
                new User("test", "move", "4582", "bing.@com", "2018-10-24"),
                new User("move4582", "monika", "vedrickaite", "email@email.com", "1998")
                };

            string resultOfSearch = "";
            string forseenResult =
           "move4582 --- monika --- vedrickaite --- email@email.com --- 1998";

            //do the search
            foreach (User reader in readerList)
            {
                if (Functions.searchR(infoToLookFor, reader) != "no match")
                {
                    resultOfSearch = Functions.searchR(infoToLookFor, reader);
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