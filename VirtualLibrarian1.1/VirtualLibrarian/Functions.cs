﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
