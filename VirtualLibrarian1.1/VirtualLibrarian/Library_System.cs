using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Library_System
    {
        //FUNCTIONALITY from FormLibSys/NewBook/EditBook/...:
        //      addBook,
        //      editBook,
        //      deleteBook
        //
        //      searchR,
        //      deleteBookFromReaderFile,
        //      

        public static void addBook(Book book, List<string> checkedGenres)
        {
            using (StreamWriter w = File.AppendText("books.txt"))
            {
                //information layout in file
                w.WriteLine(book.ISBN + ";" + book.title + ";" + book.author + ";" +
                    string.Join(" ", checkedGenres) + ";" + book.quantity.ToString());
            }
        }


        public static void editBook(Book book,
            string oGenres, string checkedG, bool genresChanged,
            string nISBN, string nTitle, string nAuthor, string nQuantity)
        {
            string line;
            StreamReader file = new StreamReader("books.txt");
            //read line by line and look for ISBN
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');

                //if found our line (unique ISBN)
                if (lineSplit[0] == book.ISBN)
                {
                    //save old info
                    string[] oInfo = { book.ISBN, book.title,
                                        book.author, oGenres, book.quantity.ToString() };
                    //all old info in one string
                    string oLine = string.Join(";", oInfo);
                    //new info
                    string nLine;

                    //if new genres selected 
                    if (genresChanged == true)
                    {
                        //form new info string
                        nLine = string.Join(";", nISBN, nTitle,
                                                nAuthor, checkedG, nQuantity);
                    }
                    else
                    {
                        //form new info string
                        nLine = string.Join(";", nISBN, nTitle,
                                                nAuthor, oGenres, nQuantity); ;
                    }
                    file.Close();

                    //read all text
                    string text = File.ReadAllText("books.txt");
                    //modifiy old text
                    text = text.Replace(oLine, nLine);
                    //write it back
                    File.WriteAllText("books.txt", text);

                    //end the madness
                    break;
                }
            }
        }


        public static void deleteBook(string code, string t)
        {
            //read all
            var Lines = File.ReadAllLines("books.txt");
            //ISBN must be unique, so look for it in the line
            var newLines = Lines.Where(line => !line.Contains(code + ";" + t));
            File.WriteAllLines("books.txt", newLines);
        }



        //searches User object - if it fits, returns obj. info to display as a string
        public static string searchR(string searchInfo, User currentU)
        {
            string infoToDisplay = "no match";

            if (currentU.username.ToLower().Contains(searchInfo.ToLower()) ||
                currentU.name.ToLower().Contains(searchInfo.ToLower())
                || currentU.surname.ToLower().Contains(searchInfo.ToLower()))
            {
                infoToDisplay = currentU.username + " --- " + currentU.name + " --- "
                              + currentU.surname + " --- " + currentU.email + " --- " + currentU.birth;
                return infoToDisplay;
            }
            return infoToDisplay;
        }


        public static void deleteBookFromReaderFile(string userBooks,
            string returnedBookInfo, string readerInfo, string[] splitInfo)
        {
            //1. delete in user file
            var Lines = File.ReadAllLines(userBooks);
            var newLines = Lines.Where(line => !line.Contains(returnedBookInfo));
            File.WriteAllLines(userBooks, newLines);

            //2. delete in taken.txt
            Lines = File.ReadAllLines("taken.txt");
            newLines = Lines.Where(line => !line.Contains(returnedBookInfo + ";" + readerInfo));
            File.WriteAllLines("taken.txt", newLines);

            //3. change (add) quantity in books.txt
            //read all text
            string Ftext = File.ReadAllText("books.txt");

            //what's the current quantity in list?
            int quo = 0;
            //checks all the books in the list bookList
            foreach (Book tempBook in Book.bookList)
            {
                if (tempBook.ISBN == splitInfo[0] && tempBook.title == splitInfo[1])
                {
                    quo = tempBook.quantity;
                    break;
                }
            }

            string infoAboutBook = splitInfo[0] + ";" + splitInfo[1] + ";" +
                                   splitInfo[2] + ";" + splitInfo[3];
            //old line
            string oLine = infoAboutBook + ";" + quo.ToString();

            quo = quo + 1;

            //new line
            string nLine = infoAboutBook + ";" + quo.ToString();


            //modifiy old text
            Ftext = Ftext.Replace(oLine, nLine);
            //write it back
            File.WriteAllText("books.txt", Ftext);
        }



    }

}
