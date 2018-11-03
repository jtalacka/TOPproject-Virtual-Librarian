﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        //Gets all books from DB into list
        public static void loadLibraryBooks()
        {
            //clear book list
            Book.bookList.fillBookList();
        }

        //Gets all readers from DB into list
        public static void loadReaders()
        {
            User.readerList.Clear();
            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Users", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        User.readerList.Add(new User(
                             reader.GetString(reader.GetOrdinal("Username")),
                             reader.GetString(reader.GetOrdinal("Password")),
                             reader.GetString(reader.GetOrdinal("Name")),
                             reader.GetString(reader.GetOrdinal("Surname")),
                             reader.GetString(reader.GetOrdinal("Email")),
                             reader.GetDataTypeName(reader.GetOrdinal("Birth"))));
                    }
                     catch(System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show("Error: Sql Exception. " +
                        "\nSomething went wrong when connecting to the database.", "Error message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            conn.Close();
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