using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public FormEditBook()
        {
            InitializeComponent();
        }
        //for passing Book class object parameters between forms
        internal Book book { get; set; }

        bool genresChanged = false;
        string checkedG;

        //on load display information
        private void FormEditBook_Load(object sender, EventArgs e)
        {
            textBoxISBN.Text = book.ISBN.ToString();
            textBoxTitle.Text = book.title;
            textBoxAuthor.Text = book.author;
            textBoxQ.Text = book.quantity.ToString();
            textBoxGenres.Text = String.Join(" ", book.genres);
        }

        //if genres clicked
        private void checkedListBoxGenre_Click(object sender, EventArgs e)
        {
            genresChanged = true;

            //get which genres chosen and put into List
            List<string> checkedGenres = Library.genresSelected(checkedListBoxGenre.CheckedItems);
            //List into string
            checkedG = string.Join(" ", checkedGenres.ToArray());
        }

        //save changes
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //check if valid ISBN w regex
            if (Login_or_Signup.inputCheck(textBoxISBN.Text, 3) == 0)
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

            //update info.
            string sql = "Update Books set " +
                "ISBN='" + textBoxISBN.Text + "', " + "Title='" + textBoxTitle.Text + "', " +
                "Author='" + textBoxAuthor.Text + "', " + "Genres='" + checkedG + "', " +
                "Quantity='" + textBoxQ.Text + "' Where ISBN='" + book.ISBN + "'";
            Library_System.editBook(sql);

            MessageBox.Show("Changes saved");
            this.Close();
        }
    }
}
