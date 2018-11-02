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
        static public void fillBookList(this List<Book> bookList)

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

                try
                {
                    Book.bookList.Add(new Book(lineSplit[0], lineSplit[1], lineSplit[2], genres, Int32.Parse(lineSplit[4])));
                }
                catch (System.IndexOutOfRangeException e)
                {
                    System.Windows.Forms.MessageBox.Show("Error: array index out of bounds. " +
                        "\nSomething wrong in file data layout.", "Error message", 
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Exit();
                }
            }
            file.Close();
        }
    }
}
