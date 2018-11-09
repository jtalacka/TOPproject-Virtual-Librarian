using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class FormEditBook : Form
    {
        //for passing Book class object parameters between forms
        private Book book;
        public FormEditBook(Book B)
        {
            InitializeComponent();
            book = B;
        }

        I_NewLogin L_or_S = new Login_or_Signup();
        I_InLibrary Lib = new Library();
        I_InLibSystem LibSys = new Library_System();

        bool genresChanged = false;
        string checkedG;

        //for connecting to the db
        static string conectionS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";

        //for saving pictures to db
        String strFilePath = "";
        Byte[] ImageByteArray = new byte[] { };
        bool picChosen = false;

        //on load display information
        private void FormEditBook_Load(object sender, EventArgs e)
        {
            textBoxISBN.Text = book.ISBN.ToString();
            textBoxTitle.Text = book.title;
            textBoxAuthor.Text = book.author;
            textBoxQ.Text = book.quantity.ToString();
            textBoxGenres.Text = String.Join(" ", book.genres);
            textBoxText.Text = book.description;
            if (book.picture != null)
                textBox2.Text = "some picture is saved for this book";
            else
                 textBox2.Text = "no picture saved for this book";
        }

        //if genres clicked
        private void checkedListBoxGenre_Click(object sender, EventArgs e)
        {
            genresChanged = true;

            //get which genres chosen and put into List
            List<string> checkedGenres = Lib.genresSelected(checkedListBoxGenre.CheckedItems);
            //List into string
            checkedG = string.Join(" ", checkedGenres.ToArray());
        }

        //save changes
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //check if valid ISBN w regex
            if (L_or_S.inputCheck(textBoxISBN.Text, 3) == 0)
            {
                MessageBox.Show("Please enter a valid ISBN (ex. of ISBN-13 code: 978-0486474915");
                textBoxISBN.Focus();
                return;
            }
            //check if valid quantity
            int qua;
            if (!Int32.TryParse(textBoxQ.Text, out qua))
            {
                MessageBox.Show("Please enter a valid quantity");
                textBoxQ.Focus();
                return;
            }

            //depending if new genres were selected, we pass diferent checkedG value
            if (genresChanged == false)
                checkedG = textBoxGenres.Text;

            //new picture chosen?
            if (picChosen == true && strFilePath != "")
            {
                Image temp = new Bitmap(strFilePath);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = strm.ToArray();
            }
            else if (picChosen == false && book.picture != null)
                ImageByteArray = book.picture;
            else
                ImageByteArray = null;

            //update info.
            using (SqlConnection conn = new SqlConnection(conectionS))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = "UPDATE Books SET " +
                        "ISBN = @code, Title = @title, Author= @auth, Genres= @g, Quantity= @q, Description= @des, Picture= @im " +
                        "Where ISBN = @old";
                    command.Parameters.AddWithValue("@code", textBoxISBN.Text);
                    command.Parameters.AddWithValue("@title", textBoxTitle.Text);
                    command.Parameters.AddWithValue("@auth", textBoxAuthor.Text);
                    command.Parameters.AddWithValue("@g", checkedG);
                    command.Parameters.AddWithValue("@q", textBoxQ.Text);
                    command.Parameters.AddWithValue("@des", textBoxText.Text);
                    command.Parameters.AddWithValue("@im", ImageByteArray);
                    command.Parameters.AddWithValue("@old", book.ISBN);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            

            MessageBox.Show("Changes saved");
            this.Close();
        }

        //choose a picture
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picChosen = true;
                strFilePath = ofd.FileName;
                textBox2.Text = System.IO.Path.GetFileName(strFilePath);
            }
            else
                picChosen = false;
        }
    }
}
