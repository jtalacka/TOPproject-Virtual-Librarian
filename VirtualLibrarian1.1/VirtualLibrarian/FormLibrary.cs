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
    public partial class FormLibrary : Form
    {
        //for passing User class object between forms
        User user;
        public FormLibrary(User _user)
        {
            InitializeComponent();
            //dependency injection?
            user = _user;
        }

        I_InLibrary Lib = new Library();

        //define delegate for Lib.load... and create an instance
        public delegate void load();
        load loadL;

        private void FormLibrary_Load(object sender, EventArgs e)
        {
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
        private async void buttonSearch_Click(object sender, EventArgs e)
        {

            buttonSearch.Enabled = false;
            buttonSort.Enabled = false;
            buttonGenre.Enabled = false;
            buttonMore.Enabled = false;
            buttonTakenBooks.Enabled = false;
            buttonReccomend.Enabled = false;
            takebook.Enabled = false;

            Task tas = new Task(() =>
            {

                Book.sortList.Clear();
                buttonSort.Visible = true;
                //clear main window
                listBoxMain.Items.Clear();

                // define delegate loadL and call the method using the delegate object
                loadL = Lib.loadLibraryBooks;
                loadL();

                //checks all the books in the bookList (filled on form load)
                foreach (Book tempBook in Book.bookList)
                {
                    //checks tempBook - if it fits, returns tempBook info to display            
                    if (Lib.searchAuthororTitle(textBox1.Text, tempBook) != "no match")
                    {
                        listBoxMain.Items.Add(Lib.searchAuthororTitle(textBox1.Text, tempBook));

                        //all search results to list for potential sorting
                        Book.sortList.Add(tempBook);
                    }
                }

            });
           tas.Start();
            await tas;


            buttonSearch.Enabled = true;
            buttonSort.Enabled = true;
            buttonGenre.Enabled = true;
            buttonMore.Enabled = true;
            buttonTakenBooks.Enabled = true;
            buttonReccomend.Enabled = true;
            takebook.Enabled = true;
        }

        //search by genre
        private async void ButtonGenre_Click(object sender, EventArgs e)
        {

            buttonSearch.Enabled = false;
            buttonSort.Enabled = false;
            buttonGenre.Enabled = false;
            buttonMore.Enabled = false;
            buttonTakenBooks.Enabled = false;
            buttonReccomend.Enabled = false;
            takebook.Enabled = false;


            Task tas = new Task(() =>
            {

                Book.sortList.Clear();
                buttonSort.Visible = true;
                //clear main window
                listBoxMain.Items.Clear();
                textBox1.Clear();

                // define delegate loadL and call the method using the delegate object
                loadL = Lib.loadLibraryBooks;
                loadL();

                //get which genres chosen
                List<string> checkedGenres = Lib.genresSelected(checkedListBoxGenre.CheckedItems);
                if (checkedGenres.Count == 0) { MessageBox.Show("Please select a genre"); return; }

                //checks all books in bookList
                foreach (Book tempBook in Book.bookList)
                {
                    foreach (string g in checkedGenres)
                    {
                        //genres from book class
                        foreach (string bg in tempBook.genres)
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

                    buttonSearch.Enabled = true;
                    buttonSort.Enabled = true;
                    buttonGenre.Enabled = true;
                    buttonMore.Enabled = true;
                    buttonTakenBooks.Enabled = true;
                    buttonReccomend.Enabled = true;
                    takebook.Enabled = true;
                }

                //clear checked items
                foreach (int i in checkedListBoxGenre.CheckedIndices)
                {
                    checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
                }

            });
            tas.Start();
            await tas;



        }

        private void buttonAccSettings_Click(object sender, EventArgs e)
        {
            //pass defined user object to the new form
            FormAccountInfo accInfo = new FormAccountInfo(user);
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
            FormLibSys sys = new FormLibSys(user);
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
            int quo = Int32.Parse(splitInfo[splitInfo.Length - 1]);
            if (quo == 0)
            { MessageBox.Show("All copies of this book are taken"); return; }
            quo = quo - 1;

            //ALL GOOD -> WRITE INFO. INTO FILES: username.txt, taken.txt, books.txt
            Lib.takeORGiveBook(splitInfo, user.username, quo);

            MessageBox.Show("Book \n" + splitInfo[1] + " \nadded");

            listBoxMain.Items.Clear();
        }

        //show new form with taken books
        private void buttonTakenBooks_Click_1(object sender, EventArgs e)
        {
            FormReaderBooks rb = new FormReaderBooks("no_select", user.username);
            rb.ShowDialog();
        }

        //opens a new form with more about the book
        private void buttonMore_Click(object sender, EventArgs e)
        {
            string text = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (text == "")
            { MessageBox.Show("Please select a book to view"); return; }

            //LINQ gets all info about selected book
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

            //get genres of books this reader has taken
            List<string> genres = Lib.reccomendations(user.username);

            if (genres.Count == 0)
            {
                MessageBox.Show("You don't have any books taken, so recommendations can't be formed");
                return;
            }
            string test = null;
            foreach (string item in genres)
            { test += " " + item; }
            MessageBox.Show("Favourite genres: " + test + " " );

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
                        }
                        break;
                    }
                }
            }
        }



    }
}