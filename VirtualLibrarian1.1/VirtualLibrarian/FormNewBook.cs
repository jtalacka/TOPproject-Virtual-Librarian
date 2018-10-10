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

            int ISBN;
            //is ISBN integer?
            if (!int.TryParse(textBoxISBN.Text, out ISBN))
            {
                MessageBox.Show("Incorrect ISBN code type");
                textBoxISBN.Focus();
                return;
            }

            //get which genres chosen
            List<string> checkedGenres = Functions.genresSelected(checkedListBoxGenre.CheckedItems);
            if (checkedGenres.Count == 0) { MessageBox.Show("Please select a genre"); }

            //define Book
            Book book = new Book(ISBN, textBoxTitle.Text, textBoxAuthor.Text, checkedGenres);

            //check if ISBN already exists in file
            if (Functions.checkIfExistsInFile("books.txt", textBoxISBN.Text) == true)
            {
                MessageBox.Show("Book with this ISBN code already exists");
                textBoxISBN.Focus();
                return;
            }
            //if ISBN unique - add book to the file
            using (StreamWriter w = File.AppendText("books.txt"))
            {
                //information layout in file
                w.WriteLine(book.ISBN + ";" + book.title + ";" + book.author + ";" + string.Join(" ", checkedGenres));
            }

            MessageBox.Show("Book '" + book.title + "' added");
            textBoxISBN.Clear();
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
            foreach (int i in checkedListBoxGenre.CheckedIndices)
            {
                checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
