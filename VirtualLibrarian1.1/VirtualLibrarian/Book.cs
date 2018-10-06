﻿using System;
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
        }
        public Book() { }

        //properties (in same order as written in in the file)
        public int ISBN;
        public string title;
        public string author;
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

    }
}
