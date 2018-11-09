using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Library_System : I_InLibSystem
    {
        //FUNCTIONALITY from FormLibSys/NewBook/EditBook/...:
        //      checkIfExistsInDBBooks
        //      addBook,
        //      
        //
        //      allTakenBooks
        //      searchR,
        //      deleteBookFromReaderFile,
        //     


        //for connecting to the db
        public static SqlConnection conn = new SqlConnection();
        static string conectionS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
        //query
        public static SqlCommand command;


        //check if ISBN exists in db Books, before adding a new one
        public bool checkIfExistsInDBBooks(string whatToLookFor)
        {
            bool ExistsResult = false;

            conn.ConnectionString = conectionS;
            conn.Open();
            command = new SqlCommand("Select ISBN from Books", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("ISBN")) == whatToLookFor)
                    {
                        //found that already exists
                        conn.Close();
                        ExistsResult = true;
                        return ExistsResult;
                    }
                }
                conn.Close();
                return ExistsResult;
            }
        }

        public void addBook(Book book, List<string> checkedGenres, Byte[] ImageByteArray)
        {
            using (SqlConnection conn = new SqlConnection(conectionS))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = "Insert into Books " +
                        "(ISBN, Title, Author, Genres, Quantity, Description, Picture)" +
                        "Values (@code, @title, @auth, @g, @q, @des, @pic) ";
                    command.Parameters.AddWithValue("@code", book.ISBN);
                    command.Parameters.AddWithValue("@title", book.title);
                    command.Parameters.AddWithValue("@auth", book.author);
                    command.Parameters.AddWithValue("@g", string.Join(" ", checkedGenres));
                    command.Parameters.AddWithValue("@q", book.quantity.ToString());
                    command.Parameters.AddWithValue("@des", book.description);
                    command.Parameters.AddWithValue("@pic", ImageByteArray);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        //edit/delete Book info. in table
        //public void editBook(SqlCommand command)
        //{
        //    conn.ConnectionString = conectionS;
        //    conn.Open();
        //    using (conn)
        //    {
        //        using (command)
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    conn.Close();
        //}


        //gets all taken books into list
        public List<string> allTakenBooks()
        {
            List<string> taken = new List<string>();
            string item;

            conn.ConnectionString = conectionS;
            conn.Open();
            command = new SqlCommand("Select * From  Taken", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Check is the reader has any rows at all before starting to read.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = reader.GetString(reader.GetOrdinal("ISBN")) + " --- " +
                            reader.GetString(reader.GetOrdinal("Username")) + " --- " +
                            reader.GetString(reader.GetOrdinal("DateTaken")) + " --- " +
                            reader.GetString(reader.GetOrdinal("DateReturn"));
                        taken.Add(item);
                    }
                }
            }
            conn.Close();
            return taken;
        }




        //searches User object - if it fits, returns obj. info to display as a string
        public string searchR(string searchInfo, User currentU)
        {
            string infoToDisplay = "no match";

            if (currentU.username.ToLower().Contains(searchInfo.ToLower()) ||
                currentU.name.ToLower().Contains(searchInfo.ToLower())
                || currentU.surname.ToLower().Contains(searchInfo.ToLower()))
            {
                infoToDisplay = currentU.username + " --- " + currentU.name + " --- "
                              + currentU.surname + " --- " + currentU.email + " --- " + currentU.birth;
                return infoToDisplay;
            }
            return infoToDisplay;
        }


        //When a book is being returned - 
        //WRITE NEW INFO. INTO TABLES: Taken, Books
        public void deleteBookFromReader(string COMMAND, string[] splitInfo)
        {
            //delete in Taken
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

            //change (add) quantity in Books
            //what's the current quantity in list?
            int quo = 0;
            //checks all the books in the list bookList
            foreach (Book tempBook in Book.bookList)
            {
                if (tempBook.ISBN == splitInfo[0] && tempBook.title == splitInfo[1])
                {
                    quo = tempBook.quantity;
                    break;
                }
            }
            quo = quo + 1;
            
            COMMAND = "Update Books set " +
            "Quantity='" + quo + "' Where ISBN='" + splitInfo[0] + "'";
            
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



    }

}
