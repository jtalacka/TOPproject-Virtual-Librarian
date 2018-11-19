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

        I_NewLogin L_or_S = new Login_or_Signup();
        I_InLibrary Lib = new Library();
        I_InLibSystem LibSys = new Library_System();

        //for saving pictures to db
        String strFilePath = "";
        Byte[] ImageByteArray = new byte[] { };
        bool picChosen = false;

        //add book to file
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //check if any textbox's empty
            //if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            //{ MessageBox.Show("Please enter all info."); return; }

            //check if valid ISBN w regex
            string ISBN = textBoxISBN.Text;
            if (L_or_S.inputCheck(ISBN, 3) == 0)
            {
                MessageBox.Show("Please enter a valid ISBN (ex. of ISBN-13 code: 978-0486474915");
                textBoxISBN.Focus();
                return;
            }
            //check if ISBN already exists in file
            //string comma = "Select ISBN from Books";
            if (LibSys.checkIfExistsInDBBooks(textBoxISBN.Text) == true)
            {
                MessageBox.Show("Book with this ISBN code already exists");
                textBoxISBN.Focus();
                return;
            }
            //check if valid quantity
            int qua;
            if (!Int32.TryParse(textBoxQ.Text, out qua) && qua == 0)
            {
                MessageBox.Show("Please enter a valid quantity");
                textBoxQ.Focus();
                return;
            }

            //get which genres chosen
            List<string> checkedGenres = Lib.genresSelected(checkedListBoxGenre.CheckedItems);
            if (checkedGenres.Count == 0) { MessageBox.Show("Please select a genre"); return; }

            //new picture chosen?
            if (picChosen == true)
            {
                Image temp = new Bitmap(strFilePath);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = strm.ToArray();
            }

            //define Book
            Book book = new Book(ISBN, textBoxTitle.Text, textBoxAuthor.Text, checkedGenres, qua, textBoxText.Text, ImageByteArray);

            //if ISBN unique - add book to table Books
            LibSys.addBook(book, checkedGenres, ImageByteArray);

            MessageBox.Show("Book '" + book.title + "' added");
            textBoxISBN.Clear();
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
            textBoxQ.Clear();
            textBoxText.Clear();
            textBox2.Clear();
            foreach (int i in checkedListBoxGenre.CheckedIndices)
            {
                checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private async void isbn_Click(object sender, EventArgs e)
        {
            ISBNScanner isbn = new ISBNScanner();
            if (isbn.ShowDialog() != DialogResult.OK)
            {
                if (ISBNScanner.results != "")
                {
                    Book tempBook = await GoogleBooks.Search(ISBNScanner.results);
                    if (tempBook != null)
                    {
                        textBoxISBN.Text = tempBook.ISBN;
                        textBoxTitle.Text = tempBook.title;
                        textBoxAuthor.Text = tempBook.author;
                    }

                    ISBNScanner.results = "";
                }
            }

        }
    }
}
