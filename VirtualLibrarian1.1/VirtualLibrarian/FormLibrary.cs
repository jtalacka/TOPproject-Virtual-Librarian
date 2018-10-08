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
        List<Book> bookList = new List<Book>();

        //for passing User class object parameters between forms
        internal User user { get; set; }

        //file storage path
        public string books = @"C:\Users\books.txt";
        public string userBooks;
        public bool pressedtakenbooks = false;

        private void FormLibrary_Load(object sender, EventArgs e)
        {
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

        private void loadLibraryBooks() {
            bookList.Clear();
            string line;
            string templine;
            StreamReader file = new StreamReader(books);
            while ((line = file.ReadLine()) != null)
            {
                templine = line;
                //split line into strings
                string[] lineSplit = line.Split(';');
                //lineSplit[2] contains the genres separated with spaces
                //get genres into genreSplit array
                string[] genreSplit = lineSplit[3].Split(' ');

                List<string> genres = new List<string>();
                for (int i = 0; i < genreSplit.Length; i++) {
                    genres.Add(genreSplit[i]);
                }
                bookList.Add(new Book(Int32.Parse(lineSplit[0]), lineSplit[1], lineSplit[2],genres,templine));

            }
            file.Close();








        }

        //search by genre
        private void buttonGenre_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();
            loadLibraryBooks();

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

            foreach (Book tempBook in bookList) //checks all the books in the list bookList
            {


                foreach (string g in checkedGenres)
                {
                    foreach(string bg in tempBook.genres) //genres from book class
                    {
                        //if matches - add to main listBox
                        if (bg == g)
                        {
                            listBoxMain.Items.Add(tempBook.ISBN + " --- " +tempBook.title + " --- " + tempBook.author + " --- " + tempBook.genresToDisplay());//genrestodisplay is a function that returns genres as string
                        }
                    }
                }


            }


            //clear checked items and serch
            foreach (int i in checkedListBoxGenre.CheckedIndices)
            {
                checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
            }
            textBox1.Clear();
        }

        //Search by author or book title
        private void buttonSearch_Click(object sender, EventArgs e) //same implementation as search by genre
        {
            //clear main window
            listBoxMain.Items.Clear();
            loadLibraryBooks();

            //write info
            string searchBA = textBox1.Text;

            foreach (Book tempBook in bookList) //checks all the books in the list bookList
            {


                string readInfo = tempBook.search(textBox1.Text, tempBook.bookLineRead);
                if (readInfo != "no match")
                {
                    listBoxMain.Items.Add(readInfo);
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
            {
                MessageBox.Show("Please select a book");
            }
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

        // toggles between taken book view and all books
        private void buttonTakenBooks_Click_1(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(userBooks))
            {
                if (pressedtakenbooks == false)
                {
                    pressedtakenbooks = true;
                    buttonTakenBooks.BackColor = Color.Gray;
                    books = userBooks; // sets the name and the path of the file
                    takebook.Enabled = false;
                    buttonSearch_Click(sender, e);
                }
                else
                {
                    pressedtakenbooks = false;
                    buttonTakenBooks.BackColor = SystemColors.Control; ;
                    books = @"C:\Users\books.txt";
                    takebook.Enabled = true;
                }
                buttonSearch_Click(sender, e);
            }
            else
            {
                MessageBox.Show("You haven't taken any books yet");
            }
        }

        private void buttonMore_Click(object sender, EventArgs e)// opens a new form more about the book
        {
            string text = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            foreach (Book tempBook in bookList) {
                if (text == tempBook.ISBN + " --- " + tempBook.title + " --- " + tempBook.author + " --- " + tempBook.genresToDisplay()) {//searches for a book that matches the selected
                    new BookView(tempBook).Show();
                    break;
                }
            }

        }

    }
}




//OLD SEARCH

//// search book or author
//string line;
//string searchBA = textBox1.Text;
//StreamReader file = new StreamReader(books);
//if (searchBA != null)  // was "" just a test method for the use of same function to see all the books
//{
//    while ((line = file.ReadLine()) != null)
//    {
//        //split line into strings
//        string[] lineSplit = line.Split(';');

//        for (int i = 0; i < lineSplit.Length; i++)
//        {
//            //if matches - add to main listBox
//            if (lineSplit[i].Contains(searchBA))
//            {
//                listBoxMain.Items.Add(lineSplit[1] + " --- " + lineSplit[2] + " --- " + lineSplit[3]);
//                break;
//            }
//        }
//    }
//    file.Close();