using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    class Library : I_InLibrary
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
        //          updateReaderInfo

        //          selectTakenBooks
        //


        //for connecting to the db
        public static SqlConnection conn = new SqlConnection();
        static string conectionS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
        //query
        public static SqlCommand command;


        //Gets all books from DB into list
       public void loadLibraryBooks()
        {
            //clear book list
            Book.bookList.fillBookList();
             //FillList class extended method to fill bookList with all books from file
        }

        //Gets all readers from DB into list
        public void loadReaders()
        {
            User.readerList.Clear();

            conn.ConnectionString = conectionS;
            conn.Open();
            command = new SqlCommand("Select * from Users", conn);
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User.readerList.Add(new User(
                             reader.GetString(reader.GetOrdinal("Username")),
                             reader.GetString(reader.GetOrdinal("Password")),
                             reader.GetString(reader.GetOrdinal("Name")),
                             reader.GetString(reader.GetOrdinal("Surname")),
                             reader.GetString(reader.GetOrdinal("Email")),
                             reader.GetString(reader.GetOrdinal("Birth"))));
                    }
                }
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error: Sql Exception " +
                "\nSomething went wrong when connecting to the database.", "Error message",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //searches Book object - if it fits, returns obj. info to display as a string
        public string searchAuthororTitle(string searchInfo, Book currentBook)
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
        public List<string> genresSelected(CheckedListBox.CheckedItemCollection checkedItems)
        {
            List<string> checkedGenres = new List<string>();
            foreach (string g in checkedItems)
            {
                checkedGenres.Add(g);
            }
            return checkedGenres;
        }

        //returns genres as string
        public string genresToDisplay(List<string> genres)
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
        //WRITE NEW INFO. INTO TABLES: Taken, Books
        public void takeORGiveBook(string[] splitInfo, string user, int quo)
        {
            //form date when taken
            string dateTaken = DateTime.Now.ToShortDateString();
            //form return date
            var dateReturn = DateTime.Now.AddMonths(1).ToShortDateString();

            string code = splitInfo[0];

            conn.ConnectionString = conectionS;
            conn.Open();
            //track all taken books in table Taken
            string sql = "Insert into Taken " +
                         "(ISBN, Username, DateTaken, DateReturn) " +
                         "values('"+code+"', '"+user+"', '"+dateTaken+"', '"+dateReturn+"')";
            using (conn)
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            conn.ConnectionString = conectionS;
            conn.Open();
            //change quantity in table Books
            sql = "Update Books set Quantity='" + quo + "' where ISBN='" + splitInfo[0] + "'";
            using (conn)
            {
                using (command = new SqlCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            conn.Close();
        }

        //get genres of books that the user has taken
        public List<string> reccomendations(string username)
        {
            List<string> genres = new List<string>();

            conn.ConnectionString = conectionS;
            conn.Open();
            command = new SqlCommand("Select Books.Genres " +
                                     "From Books INNER JOIN Taken " +
                                     "On Books.ISBN=Taken.ISBN " +
                                     "Where Username=@Username", conn);
            command.Parameters.AddWithValue("Username", username);
            using (SqlDataReader reader = command.ExecuteReader())
            {             
                // Check is the reader has any rows at all before starting to read.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] genreSplit = reader.GetString(reader.GetOrdinal("Genres")).Split(' ');
                        for (int i = 0; i < genreSplit.Length; i++)
                        {
                            if (!genres.Contains(genreSplit[i]))
                                genres.Add(genreSplit[i]);
                        }
                    }
                }
                conn.Close();
            }
            return genres;
        }


        //update/delete User info in table
        public void updateReaderInfo(string COMMAND)
        {
            conn.ConnectionString = conectionS;
            conn.Open();
            using (conn)
            {
                using (command = new SqlCommand(COMMAND, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            conn.Close();
        }



        //gets all taken reader books into list
        public List<string> selectTakenBooks(string user)
        {
            List<string> taken = new List<string>();
            string item;

            conn.ConnectionString = conectionS;
            conn.Open();
            command = new SqlCommand("Select Taken.ISBN, Books.Title, Books.Author, Books.Genres, Taken.DateTaken, Taken.DateReturn " +
                                     "From Books INNER JOIN Taken " +
                                     "On Books.ISBN=Taken.ISBN " +
                                     "Where Taken.Username='" + user + "'", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Check is the reader has any rows at all before starting to read.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = reader.GetString(reader.GetOrdinal("ISBN")) + " --- " +
                            reader.GetString(reader.GetOrdinal("Title")) + " --- " +
                            reader.GetString(reader.GetOrdinal("Author")) + " --- " +
                            reader.GetString(reader.GetOrdinal("Genres")) + " --- " +
                            reader.GetString(reader.GetOrdinal("DateTaken")) + " --- " +
                            reader.GetString(reader.GetOrdinal("DateReturn"));
                        taken.Add(item);
                    }
                }
            }
            conn.Close();
            return taken;
        }
    }
}
