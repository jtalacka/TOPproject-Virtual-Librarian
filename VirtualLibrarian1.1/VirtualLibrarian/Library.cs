using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    class Library
    {
        //
        // FUNCTIONALITY from FormLibrary and Functions:
        //          loadLibraryBooks,
        //          loadReaders,
        //          searchAuthororTitle,
        //          genresSelected,
        //          genresToDisplay,
        //          takeORGiveBook,
        //          reccomendations

        //Gets all books from file into list
        public static void loadLibraryBooks()
        {
            //clear book list
            Book.bookList.fillBookList();
        }

        //Gets all readers from file into list
        public static void loadReaders()
        {
            User.readerList.Clear();
            string line;
            StreamReader file = new StreamReader("login.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                User.readerList.Add(new User(lineSplit[0], lineSplit[1], lineSplit[2], lineSplit[3], lineSplit[4], lineSplit[5]));
            }
            file.Close();
        }

        //searches Book object - if it fits, returns obj. info to display as a string
        public static string searchAuthororTitle(string searchInfo, Book currentBook)
        {
            string infoToDisplay = "no match";

            if (currentBook.title.ToLower().Contains(searchInfo.ToLower())
                || currentBook.author.ToLower().Contains(searchInfo.ToLower()))
            {
                return currentBook.ObToString(currentBook);
            }
            return infoToDisplay;
        }

        //get which genres chosen
        public static List<string> genresSelected(CheckedListBox.CheckedItemCollection checkedItems)
        {
            List<string> checkedGenres = new List<string>();
            foreach (string g in checkedItems)
            {
                checkedGenres.Add(g);
            }
            return checkedGenres;
        }

        //returns genres as string
        public static string genresToDisplay(List<string> genres)
        {
            string tempGenres = "";
            foreach (string g in genres)
            {
                tempGenres += g;
                tempGenres += " ";
            }
            tempGenres = tempGenres.Remove(tempGenres.Length - 1);
            return tempGenres;
        }

        //When a book is being taken/given - 
        //WRITE NEW INFO. INTO FILES: username.txt, taken.txt, books.txt
        public static void takeORGiveBook(string[] splitInfo, string text, string userBooks, string user, int quo)
        {
            //form date when taken
            string dateTaken = DateTime.Now.ToShortDateString();
            //form return date
            var dateReturn = DateTime.Now.AddMonths(1).ToShortDateString();
            //form information to write
            string infoAboutBook = splitInfo[0] + ";" + splitInfo[1] + ";" + splitInfo[2] + ";" +
                                   splitInfo[3] + ";" + dateTaken + ";" + dateReturn;

            using (StreamWriter sw = File.AppendText(userBooks))
            { sw.WriteLine(infoAboutBook); }

            //track all taken books
            using (StreamWriter sw = File.AppendText("taken.txt"))
            { sw.WriteLine(infoAboutBook + ";" + user); }

            //change quantity in file
            //read all text
            string Ftext = File.ReadAllText("books.txt");
            //old line (in format isbn;title;author;genres;old_quantity)
            string oLine = text;
            //new line
            string nLine = splitInfo[0] + ";" + splitInfo[1] + ";" + splitInfo[2] + ";" +
                           splitInfo[3] + ";" + quo.ToString();
            //modifiy old text
            Ftext = Ftext.Replace(oLine, nLine);
            //write it back
            File.WriteAllText("books.txt", Ftext);
        }


        public static List<string> reccomendations(string userBooks)
        {
            List<string> genres = new List<string>();
            string line;
            StreamReader file = new StreamReader(userBooks);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                string[] genreSplit = lineSplit[3].Split(' ');
                for (int i = 0; i < genreSplit.Length; i++)
                {
                    if (!genres.Contains(genreSplit[i]))
                        genres.Add(genreSplit[i]);
                }
            }
            file.Close();
            return genres;
        }
    }
}
