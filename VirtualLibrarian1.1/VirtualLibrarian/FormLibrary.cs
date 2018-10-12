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
            //Functions class method to fill bookList with all books from file
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

        //search by genre
        private void buttonGenre_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();

            //get which genres chosen
            List<string> checkedGenres = Functions.genresSelected(checkedListBoxGenre.CheckedItems);
            if (checkedGenres.Count == 0) { MessageBox.Show("Please select a genre"); }

            //checks all books in bookList
            foreach (Book tempBook in Book.bookList)
            {
                bool matchFound = false;
                foreach (string g in checkedGenres)
                {
                    foreach (string bg in tempBook.genres) //genres from book class
                    {
                        //if matches - add to main listBox
                        if (bg == g)
                        {
                            //returns object parameter string
                            listBoxMain.Items.Add(Functions.objectToString(tempBook));
                            matchFound = true;
                            break;
                        }
                    }
                    if (matchFound)
                    {
                        break;
                    }
                }
            }

            //clear checked items and search box
            foreach (int i in checkedListBoxGenre.CheckedIndices)
            {
                checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
            }
            textBox1.Clear();
        }

        //Search by author or book title
        private void buttonSearch_Click(object sender, EventArgs e) //same implementation as search by genre
        {
            buttonSort.Visible = true;
            Book.sortList.Clear();
            //clear main window
            listBoxMain.Items.Clear();

            //checks all the books in the list bookList
            foreach (Book tempBook in Book.bookList)
            {
                //checks tempBook - if it fits, returns tempBook info to display            
                if (Functions.search(textBox1.Text, tempBook) != "no match")
                {
                    listBoxMain.Items.Add(Functions.search(textBox1.Text, tempBook));
                }
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


        private void takebook_Click(object sender, EventArgs e)// writes books into the file called username+.txt
        {
            // gets selected info about the book
            string text = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (text == "")
            { MessageBox.Show("Please select a book"); }
            else
            {
                // saves the text into the format name;author;genre
                text = text.Replace(" --- ", ";");
                int exists = 0;

                string path = userBooks;
                string line;
                if (System.IO.File.Exists(path))
                {
                    StreamReader file = new StreamReader(userBooks);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line == text)
                        {
                            MessageBox.Show(line);
                            MessageBox.Show(text);

                            exists = 1;
                            break;
                        }
                    }
                    file.Close();
                }
                if (exists == 0)
                {
                    MessageBox.Show(text);
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(text);
                    }
                }
                else
                {
                    MessageBox.Show("You have already taken this book");
                }
            }
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
                MessageBox.Show("You haven't taken any books (no file created)");
                return;
            }
        }

        // opens a new form with more about the book
        private void buttonMore_Click(object sender, EventArgs e)
        {
            string text = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            foreach (Book tempBook in Book.bookList)
            {
                if (text == tempBook.ISBN + " --- " + tempBook.title + " --- "
                    + tempBook.author + " --- " + Functions.genresToDisplay(tempBook.genres))
                {
                    //searches for a book that matches the selected
                    new BookView(tempBook).Show();
                    break;
                }
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
                listBoxMain.Items.Add(item.title + " --- " + item.author + " --- " + genres);
            }

        }


        private void buttonReccomend_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();

            //get genres of books this reader has taken
            List<string> genres = new List<string>();
            string line;         
            StreamReader file = new StreamReader(userBooks);
            while (( line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                string[] genreSplit = lineSplit[3].Split(' ');
                for (int i=0; i<genreSplit.Length; i++)
                {
                    if(!genres.Contains(genreSplit[i]))
                        genres.Add(genreSplit[i]);
                }
            }

            foreach (Book tempBook in Book.bookList)
            {
                bool matchFound = false;
                foreach (string g in genres)
                {
                    foreach (string bg in tempBook.genres)
                    {
                        //if matches - add to main listBox
                        if (bg == g)
                        {
                            //returns object parameter string
                            listBoxMain.Items.Add(Functions.objectToString(tempBook));
                            matchFound = true;
                            break;
                        }
                    }
                    if (matchFound)
                    {
                        break;
                    }
                }
            }

        }
    }
}