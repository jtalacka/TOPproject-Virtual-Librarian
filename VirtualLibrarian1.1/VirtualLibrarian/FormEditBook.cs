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

            //update info.
            string sql = "Update Books set " +
                "ISBN='" + textBoxISBN.Text + "', " + "Title='" + textBoxTitle.Text + "', " +
                "Author='" + textBoxAuthor.Text + "', " + "Genres='" + checkedG + "', " +
                "Quantity='" + textBoxQ.Text + "' Where ISBN='" + book.ISBN + "'";
            LibSys.editBook(sql);

            MessageBox.Show("Changes saved");
            this.Close();
        }
    }
}
