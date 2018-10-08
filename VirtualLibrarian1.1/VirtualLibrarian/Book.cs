using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Book
    {
        //a constructor
        public Book(int isbn, string t, string a, List<string> g)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.image = "";
        }
        public Book(int isbn, string t, string a, List<string> g,string lineRead)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.image = "";
            this.bookLineRead = lineRead;
        }


        public Book(string line) {
        }
        public Book() { }

        //properties (in same order as written in in the file)
        public int ISBN;
        public string title;
        public string image;
        public string description;
        public string author;
        public string bookLineRead;//the line read from file
        public List<string> genres;
        public DateTime Dtaken;
        public DateTime Dreturned;


        //search with input or display all
        public string search(string searchInfo, string readLine)
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
        }//end method search





        public string genresToDisplay() {
            string tempGenres="";
            foreach (string g in genres) {
                tempGenres += g;
                tempGenres += " ";
            }
            tempGenres = tempGenres.Remove(tempGenres.Length - 1);
            return tempGenres;
        }

    }
}
