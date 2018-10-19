using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    class Functions
    {
        //Gets all books from file into list
        public static void loadLibraryBooks()
        {
            //clear book list
            Book.bookList.Clear();
            string line;
            string templine;
            StreamReader file = new StreamReader("books.txt");
            while ((line = file.ReadLine()) != null)
            {
                templine = line;
                //split line into strings
                string[] lineSplit = line.Split(';');
                //lineSplit[3] contains the genres separated with spaces
                string[] genreSplit = lineSplit[3].Split(' ');

                List<string> genres = new List<string>();
                for (int i = 0; i < genreSplit.Length; i++)
                {
                    genres.Add(genreSplit[i]);
                }
                Book.bookList.Add(new Book(lineSplit[0], lineSplit[1], lineSplit[2], genres, templine));
            }
            file.Close();
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
        public static string search(string searchInfo, Book currentBook)
        {
            string infoToDisplay = "no match";

            if (currentBook.title.Contains(searchInfo) || currentBook.author.Contains(searchInfo))
            {
                return currentBook.ObToString(currentBook);
            }

            return infoToDisplay;
        }

        //searches User object - if it fits, returns obj. info to display as a string
         public static string searchR(string searchInfo, User currentU)
        {
            string infoToDisplay = "no match";

            if (currentU.username.Contains(searchInfo) || currentU.name.Contains(searchInfo)
                || currentU.surname.Contains(searchInfo))
            {
                infoToDisplay = currentU.username + " --- " + currentU.name + " --- "
                              + currentU.surname + " --- " + currentU.email + " --- " + currentU.birth;
                return infoToDisplay;
            }

            return infoToDisplay;
        }


        //function that returns genres as string
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


        //input validation - email, date of birth
        public static int inputCheck(string whatToCheck, int c)
        {
            Regex emailRegex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");         
            var dateFormats = new[] { "yyyy.MM.dd", "yyyy-MM-dd" };
            Regex ISBNRegex = new Regex(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$");

            if (c == 1)
            {
                //1. email check - if NOT ok - returns 0
                if (!emailRegex.IsMatch(whatToCheck))
                    return 0;
                else
                    return 1;
            }
            else if (c == 2)
            {
                //2.Birth date check - if NOT ok - returns 0
                DateTime date;
                bool validDate = DateTime.TryParseExact(whatToCheck, dateFormats,
                    DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out date);
                if (!validDate)
                    return 0;
                else
                    return 1;
            }
            else if (c == 3)
            {
                //3. isbn check - if NOT ok - returns 0
                if (ISBNRegex.IsMatch(whatToCheck))
                    return 1;
                else
                    return 0;
            }
            else
                return 1;
        }


        //check if username / ISBN exists in file 
        public static bool checkIfExistsInFile(string fileName, string whatToLookFor)
        {
            bool ExistsResult = false;
            string line;
            string[] lineSplit;
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                lineSplit = line.Split(';');
                if (lineSplit[0] == whatToLookFor)
                {
                    //found that already exists
                    ExistsResult = true;
                    file.Close();
                    return ExistsResult;
                }
            }
            file.Close();
            return ExistsResult;
        }

    }
}
