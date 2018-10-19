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
    public partial class FormLibSys : Form
    {
        public FormLibSys()
        {
            InitializeComponent();
        }
        internal User user;

        //search for a book
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            //Hide buttons related to user management
            buttonTake.Visible = false;
            buttonReturn.Visible = false;
            textBoxReader.Clear();
            label4.Visible = false;
            //Show library management buttons
            buttonAdd.Visible = true;
            buttonEdit.Visible = true;
            buttonDel.Visible = true;
            label3.Visible = true;

            //clear main window
            listBoxMain.Items.Clear();

            //reload books in case changes were made in file
            Functions.loadLibraryBooks();

            //checks all the books in the list bookList
            foreach (Book tempBook in Book.bookList)
            {
                //checks tempBook - if it fits, returns tempBook info to display            
                if (Functions.search(textBoxBook.Text, tempBook) != "no match")
                {
                    listBoxMain.Items.Add(Functions.search(textBoxBook.Text, tempBook));
                }
            }
        }

        //add a book
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormNewBook nb = new FormNewBook();
            nb.ShowDialog();

            //clear main window
            listBoxMain.Items.Clear();
        }

        //edit a book
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //gets selected info about the book
            string info = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (info == "")
            {
                MessageBox.Show("Please select a book to edit");
                return;
            }
            info = info.Replace(" --- ", ";");
            string[] lineSplit = info.Split(';');

            //define book
            Book book = new Book(Int32.Parse(lineSplit[0]), lineSplit[1], lineSplit[2],
                lineSplit[3].Split(new char[] { ' ' }).ToList());

            FormEditBook eb = new FormEditBook();
            //pass defined book
            eb.book = book;
            eb.ShowDialog();

            //clear main window
            listBoxMain.Items.Clear();
        }

        //delete book
        private void buttonDel_Click(object sender, EventArgs e)
        {
            //gets selected info about the book
            string info = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (info == "")
            {
                MessageBox.Show("Please select a book to delete");
                return;
            }
            info = info.Replace(" --- ", ";");
            string[] lineSplit = info.Split(';');

            //temp variables
            int code = Int32.Parse(lineSplit[0]);
            string t = lineSplit[1];

            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete '" + t + "'?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var Lines = File.ReadAllLines("books.txt");
                //ISBN must be unique, so look for it in the line
                var newLines = Lines.Where(line => !line.Contains(code.ToString() + ";" + t));
                File.WriteAllLines("books.txt", newLines);

                MessageBox.Show("Book deleted");
                //clear main window
                listBoxMain.Items.Clear();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLibrary lib = new FormLibrary();
            //didn't use user object, but have to pass it back
            lib.user = user;
            lib.Show();
        }



        // = = = = = = Reader acc. related functions = = = = = = 


        //search reader ccounts
        private void buttonSearchReader_Click(object sender, EventArgs e)
        {
            //Hide buttons realted to library management
            buttonAdd.Visible = false;
            buttonEdit.Visible = false;
            buttonDel.Visible = false;
            textBoxBook.Clear();
            label3.Visible = false;
            //Show reader management functions
            buttonTake.Visible = true;
            buttonReturn.Visible = true;
            label4.Visible = true;

            //clear main window
            listBoxMain.Items.Clear();

             //checks all list
            foreach (User reader in User.readerList)
            {
                //checks reader - if it fits, returns reader info to display            
                if (Functions.searchR(textBoxReader.Text, reader) != "no match")
                {
                    listBoxMain.Items.Add(Functions.searchR(textBoxReader.Text, reader));
                }
            }
        }

        //add new taken book to user account
        private void buttonTake_Click(object sender, EventArgs e)
        {
            //get info about selected reader
            string readerInfo = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (readerInfo == "")
            { MessageBox.Show("Please select a reader account"); }
            else
            {
                readerInfo = readerInfo.Replace(" --- ", ";");
                string[] readerInfoSplit = readerInfo.Split(';');
                //new form - to get info. about the book being taken
                FormGiveBook gb = new FormGiveBook();
                gb.ShowDialog();

                //info about book being taken => givenBookInfo
                string givenBookInfo = FormGiveBook.givenBookInfo;
                givenBookInfo = givenBookInfo.Replace(" --- ", ";");
                if (givenBookInfo != "none")
                {
                    //write info about book into their file
                    //their file  
                    string userBooks = @"D:\" + readerInfoSplit[0] + ".txt";

                    //is this book already taken by this reader?
                    int exists = 0;
                    string line;
                    //file already exists
                    if (System.IO.File.Exists(userBooks))
                    {
                        StreamReader file = new StreamReader(userBooks);
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line == givenBookInfo)
                            {
                                MessageBox.Show("This reader has already taken this book");
                                exists = 1;
                                break;
                            }
                        }
                        file.Close();
                    }
                    //if book new - write it in

                    //form date when taken
                    string dateTaken = DateTime.Now.ToShortDateString();
                    //form return date
                    var dateReturn = DateTime.Now.AddMonths(1).ToShortDateString();

                    if (exists == 0)
                    {
                        using (StreamWriter sw = File.AppendText(userBooks))
                        {
                            sw.WriteLine(givenBookInfo + ";" + dateTaken + ";" + dateReturn);
                            MessageBox.Show("Book \n" + givenBookInfo + " \nadded to reader account");
                        }
                    }
                }
            }
        }

        //delete book from reader file
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            string returnedBookInfo = "none";

            //get info about selected reader
            string readerInfo = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (readerInfo == "")
            { MessageBox.Show("Please select a reader account"); }
            else
            {
                readerInfo = readerInfo.Replace(" --- ", ";");
                string[] readerInfoSplit = readerInfo.Split(';');

                //their file  
                string userBooks = @"D:\" + readerInfoSplit[0] + ".txt";

                if (!System.IO.File.Exists(userBooks))
                {
                    MessageBox.Show("This reader has never taken any books (no file created)");
                    return;
                }
                else
                {
                    //new form
                    FormReaderBooks rb = new FormReaderBooks();
                    rb.username = readerInfoSplit[0];
                    rb.ShowDialog();
                }

                //info about book being returned => returnedBookInfo
                returnedBookInfo = FormReaderBooks.returnedBookInfo;
                returnedBookInfo = returnedBookInfo.Replace(" --- ", ";");
                if (returnedBookInfo != "none")
                {
                    //is reader late to return?
                    string[] temp = returnedBookInfo.Split(';');
                    string dateToday = DateTime.Now.ToShortDateString();
                    if (DateTime.Parse(temp[5]) < DateTime.Parse(dateToday))
                    {
                        var late = DateTime.Parse(dateToday) - DateTime.Parse(temp[5]);
                        MessageBox.Show("This reader is late to return this book by: " + late + "days");
                    }

                    //delete
                    var Lines = File.ReadAllLines(userBooks);
                    var newLines = Lines.Where(line => !line.Contains(returnedBookInfo));
                    File.WriteAllLines(userBooks, newLines);
                    MessageBox.Show("Book\n" + returnedBookInfo + "\ndeleted from reader account");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         ISBNScanner isbn = new ISBNScanner();
            if (isbn.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(ISBNScanner.results);
                if (ISBNScanner.results != "")
                {
                    textBoxBook.Text = ISBNScanner.results;
                    buttonSearchBook_Click(sender, e);
                    ISBNScanner.results = "";
                }
            }

        }


    }
}