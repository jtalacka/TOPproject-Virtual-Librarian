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

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Books", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string gs = reader.GetString(reader.GetOrdinal("Genres"));
                    List<string> genres = gs.Split(' ').ToList();

                    try
                    {
                        Book.bookList.Add(new Book(
                            reader.GetString(reader.GetOrdinal("ISBN")),
                            reader.GetString(reader.GetOrdinal("Title")),
                            reader.GetString(reader.GetOrdinal("Author")),
                            genres,
                            reader.GetInt32(reader.GetOrdinal("Quantity"))));
                    }
                    catch(System.Data.SqlClient.SqlException ex)
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
