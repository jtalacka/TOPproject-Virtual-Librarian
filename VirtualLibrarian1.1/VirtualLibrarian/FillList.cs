using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace VirtualLibrarian
{
    static class FillList
    {
        static public void fillBookList(this List<Book> bookList)
        {
            //clear book list
            Book.bookList.Clear();
            string gs;
            List<string> genres;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Books", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    gs = reader.GetString(reader.GetOrdinal("Genres"));
                    genres = gs.Split(' ').ToList();
                    string descr = "Not added";

                    try
                    {
                        if (reader.IsDBNull(reader.GetOrdinal("Description")))
                            descr = "Not added";
                        else if (reader.GetString(reader.GetOrdinal("Description")) == "")
                            descr = "Not added";
                        else
                            descr = reader.GetString(reader.GetOrdinal("Description"));

                        Book.bookList.Add(new Book(
                            reader.GetString(reader.GetOrdinal("ISBN")),
                            reader.GetString(reader.GetOrdinal("Title")),
                            reader.GetString(reader.GetOrdinal("Author")),
                            genres,
                            reader.GetInt32(reader.GetOrdinal("Quantity")),
                            descr,
                            reader["Picture"] as byte[] ?? null));
                    }
                    catch(System.Data.SqlClient.SqlException)
                    {
                        System.Windows.Forms.MessageBox.Show("Error: Sql Exception. " +
                        "\nSomething went wrong when connecting to the database.", "Error message",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            conn.Close();
        }
    }
}
