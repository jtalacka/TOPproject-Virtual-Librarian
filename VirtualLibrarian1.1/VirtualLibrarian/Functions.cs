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
        //Gets all books into list
        public static void loadLibraryBooks(List<Book> bookList)
        {
            //clear book list
            bookList.Clear();
            string line;
            string templine;
            StreamReader file = new StreamReader("books.txt");
            while ((line = file.ReadLine()) != null)
            {
                templine = line;
                //split line into strings
                string[] lineSplit = line.Split(';');
                //lineSplit[3] contains the genres separated with spaces
                //get genres into genreSplit array
                string[] genreSplit = lineSplit[3].Split(' ');

                List<string> genres = new List<string>();
                for (int i = 0; i < genreSplit.Length; i++)
                {
                    genres.Add(genreSplit[i]);
                }
                bookList.Add(new Book(Int32.Parse(lineSplit[0]), lineSplit[1], lineSplit[2], genres, templine));
            }
            file.Close();
        }


        //search with input or display all
        public static string search(string searchInfo, string readLine)
        {
            string infoToDisplay = "no match";
            //split line into strings
            string[] lineSplit = readLine.Split(';');
            for (int i = 0; i < lineSplit.Length; i++)
            {
                if (lineSplit[i].Contains(searchInfo))
                {
                    infoToDisplay = readLine.Replace(";", " --- ");
                    return infoToDisplay;
                }
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
            else
                return 1;
        }


        //check if username / ISBN exists in file 
        public static bool checkIfExistsInFile (string fileName, string whatToLookFor)
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
