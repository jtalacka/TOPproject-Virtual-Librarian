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
    public partial class FormLibrary : Form
    {
        public FormLibrary()
        {
            InitializeComponent();
        }

        //for passing User class object parameters between forms
        internal User user { get; set; }

        //FILES: BOOKS.TXT AND LOGIN.TXT ARE IN BIN/DEBUG
        //this is for taken user books
        public string userBooks;

        private void FormLibrary_Load(object sender, EventArgs e)
        {
            //FillList class extended method to fill bookList with all books from file
            Functions.loadLibraryBooks();
            Functions.loadReaders();

            //form a path to taken user books
            userBooks = @"D:\" + user.username + ".txt";

            //determine, if the user is reader or employee
            if (user.type.ToString() == "employee")
            {
                //extra employee functions
                buttonManageLibrary.Visible = true;
                takebook.Visible = true;
            }
            else
            {
                buttonManageLibrary.Visible = false;
                takebook.Visible = false;
            }
        }

        //Search by author or book title
        private void buttonSearch_Click(object sender, EventArgs e) //same implementation as search by genre
        {
            Book.sortList.Clear();
            buttonSort.Visible = true;
            //clear main window
            listBoxMain.Items.Clear();

            //checks all the books in the bookList (filled on form load)
            foreach (Book tempBook in Book.bookList)
            {
                //checks tempBook - if it fits, returns tempBook info to display            
                if (Functions.search(textBox1.Text, tempBook) != "no match")
                {
                    listBoxMain.Items.Add(Functions.search(textBox1.Text, tempBook));

                    //all search results to list for potential sorting
                    Book.sortList.Add(tempBook);
                }
            }
        }

        //search by genre
        private void buttonGenre_Click(object sender, EventArgs e)
        {
            Book.sortList.Clear();
            buttonSort.Visible = true;
            //clear main window
            listBoxMain.Items.Clear();
            textBox1.Clear();

            //get which genres chosen
            List<string> checkedGenres = Functions.genresSelected(checkedListBoxGenre.CheckedItems);
            if (checkedGenres.Count == 0) { MessageBox.Show("Please select a genre"); return; }

            //checks all books in bookList
            foreach (Book tempBook in Book.bookList)
            {
                foreach (string g in checkedGenres)
                {
                    foreach (string bg in tempBook.genres) //genres from book class
                    {
                        //if matches - add to main listBox
                        if (bg == g)
                        {
                            //returns object parameter string
                            listBoxMain.Items.Add(tempBook.ObToString(tempBook));

                            //all search results to list for potential sorting
                            Book.sortList.Add(tempBook);
                        }
                    }
                }
            }

            //clear checked items and search box
            foreach (int i in checkedListBoxGenre.CheckedIndices)
            {
                checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void buttonAccSettings_Click(object sender, EventArgs e)
        {
            FormAccountInfo accInfo = new FormAccountInfo();
            //pass defined user object to the new form
            accInfo.user = user;
            accInfo.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Form1 form = new Form1();
                form.Show();
            }
        }

        //Go to employee only form
        private void buttonManageLibrary_Click(object sender, EventArgs e)
        {
            FormLibSys sys = new FormLibSys();
            sys.user = user;
            sys.Show();
            this.Close();
        }


        //Take a book
        private void takebook_Click(object sender, EventArgs e)
        {
            //gets selected info about the book
            string text = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (text == "")
            { MessageBox.Show("Please select a book"); return; }

            // saves the text in format ( isbn;title;author;genres;old_quantity )
            text = text.Replace(" --- ", ";");
            string[] splitInfo = text.Split(';');

            //is quantity = 0?
            int quo = Int32.Parse(splitInfo[4]);
            if (quo == 0)
            { MessageBox.Show("All copies of this book are taken"); return; }
            quo = quo - 1;

            //exists in reader file?
            bool exists = false;
            if (System.IO.File.Exists(userBooks))
            {
                exists = Functions.checkIfExistsInFile(userBooks, splitInfo[0]);
            }
            if (exists == true)
            { MessageBox.Show("You have already taken this book"); return; }


            //ALL GOOD -> WRITE INFO. INTO FILES: username.txt, taken.txt, books.txt
            Functions.takeORGiveBook(splitInfo, text, userBooks, user.username, quo);

            MessageBox.Show("Book \n" + text + " \nadded ");

            listBoxMain.Items.Clear();
            //if changes ever made to file --- reload the list!
            Functions.loadLibraryBooks();
        }

        //show new form with taken books
        private void buttonTakenBooks_Click_1(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(userBooks))
            {
                FormReaderBooks rb = new FormReaderBooks("show");
                rb.username = user.username;
                rb.ShowDialog();
            }
            else
            {
                MessageBox.Show("You haven't ever taken any books (no file created)");
                return;
            }
        }

        // opens a new form with more about the book
        private void buttonMore_Click(object sender, EventArgs e)
        {
            string text = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (text == "")
            {
                MessageBox.Show("Please select a book to view");
                return;
            }

            //LINQ 
            var aboutBook = from book in Book.bookList
                            where text.Contains(book.ISBN + " --- " + book.title) ||
                                  text.Contains(book.title + " --- " + book.author)
                            select book;
            foreach (var book in aboutBook)
            {
                new BookView(book).Show();
            }

        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();
            //sort it by title
            Book.sortList.Sort();
            //display
            foreach (Book item in Book.sortList)
            {
                string genres = string.Join(" ", item.genres);
                listBoxMain.Items.Add(item.title + " --- " + item.author + " --- " + genres + " --- " + item.quantity);
            }
        }


        private void buttonReccomend_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();

            if (!System.IO.File.Exists(userBooks))
            {
                MessageBox.Show("You don't have any books taken, so recommendations can't be formed");
                return;
            }

            //get genres of books this reader has taken
            List<string> genres = new List<string>();
            string line;
            StreamReader file = new StreamReader(userBooks);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                string[] genreSplit = lineSplit[3].Split(' ');
                for (int i = 0; i < genreSplit.Length; i++)
                {
                    if (!genres.Contains(genreSplit[i]))
                        genres.Add(genreSplit[i]);
                }
            }
            file.Close();

            foreach (Book tempBook in Book.bookList)
            {
                foreach (string g in genres)
                {
                    foreach (string bg in tempBook.genres)
                    {
                        //if matches - add to main listBox
                        if (bg == g)
                        {
                            //returns object parameter string
                            listBoxMain.Items.Add(tempBook.ObToString(tempBook));
                            break;
                        }
                    }
                }
            }
        }



    }
}