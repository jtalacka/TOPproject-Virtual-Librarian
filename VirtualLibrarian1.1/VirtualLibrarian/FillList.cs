using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VirtualLibrarian
{
    static class FillList
    {
        static public void fillBookList(this List<Book> bookList) {
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
    }
}
