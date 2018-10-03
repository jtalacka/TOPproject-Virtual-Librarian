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

        //file storage path
        public string books = @"C:\Users\books.txt";

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

            //check if ISBN already exists in file
            string line;
            string[] lineSplit;
            bool exists = false;
            StreamReader file = new StreamReader(books);
            while ((line = file.ReadLine()) != null)
            {
                lineSplit = line.Split(';');
                if (lineSplit[0] == textBoxISBN.Text)
                {
                    MessageBox.Show("Book with this ISBN code already exists");
                    textBoxISBN.Focus();
                    exists = true;
                    break;
                }
            }
            file.Close();

            //get which genres chosen
            List<string> checkedGenres = new List<string>();
            int q = 0;
            foreach (string g in checkedListBoxGenre.CheckedItems)
            {
                checkedGenres.Add(g);
                //how many genres selected
                q++;
            }
            if (q == 0)
            { MessageBox.Show("Please select a genre"); }

            //define Book
            Book book = new Book(ISBN, textBoxTitle.Text, textBoxAuthor.Text, checkedGenres);


            //if ISBN unique - add book to the file
            if (exists == false)
            {
                using (StreamWriter w = File.AppendText(books))
                {
                    //information layout in file
                    w.WriteLine(book.ISBN + ";" + book.title + ";" + book.author + ";" + string.Join(" ", checkedGenres));
                }
            }

            MessageBox.Show("Book " + book.title + " added");
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
