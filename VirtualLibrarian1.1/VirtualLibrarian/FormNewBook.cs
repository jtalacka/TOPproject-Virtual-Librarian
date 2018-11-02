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
    public partial class FormNewBook : Form
    {
        public FormNewBook()
        {
            InitializeComponent();
        }

        //add book to file
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //check if any textbox's empty
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            { MessageBox.Show("Please enter login info."); return; }

            //check if valid ISBN w regex
            string ISBN = textBoxISBN.Text;
            if (Login_or_Signup.inputCheck(ISBN, 3) == 0)
            {
                MessageBox.Show("Please enter a valid ISBN (ex. of ISBN-13 code: 978-0486474915");
                textBoxISBN.Focus();
                return;
            }
            //check if ISBN already exists in file
            if (Login_or_Signup.checkIfExistsInFile("books.txt", textBoxISBN.Text) == true)
            {
                MessageBox.Show("Book with this ISBN code already exists");
                textBoxISBN.Focus();
                return;
            }
            //check if valid quantity
            int qua;
            if(!Int32.TryParse(textBoxQ.Text, out qua) && qua == 0)
            {
                MessageBox.Show("Please enter a valid quantity");
                textBoxQ.Focus();
                return;
            }

            //get which genres chosen
            List<string> checkedGenres = Library.genresSelected(checkedListBoxGenre.CheckedItems);
            if (checkedGenres.Count == 0) { MessageBox.Show("Please select a genre"); }

            //define Book
            Book book = new Book(ISBN, textBoxTitle.Text, textBoxAuthor.Text, checkedGenres, qua);

            //if ISBN unique - add book to the file
            Library_System.addBook(book, checkedGenres);

            MessageBox.Show("Book '" + book.title + "' added");
            textBoxISBN.Clear();
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
            textBoxQ.Clear();
            foreach (int i in checkedListBoxGenre.CheckedIndices)
            {
                checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
