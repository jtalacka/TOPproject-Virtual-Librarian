﻿using System;
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
            buttonChange.Visible = false;
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
            { MessageBox.Show("Please select a book to edit"); return; }

            info = info.Replace(" --- ", ";");
            string[] lineSplit = info.Split(';');

            //define book
            Book book = new Book(lineSplit[0], lineSplit[1], lineSplit[2],
                lineSplit[3].Split(' ').ToList(), Int32.Parse(lineSplit[4]));

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
            string code = lineSplit[0];
            string t = lineSplit[1];

            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete '" + t + "'?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //read all
                var Lines = File.ReadAllLines("books.txt");
                //ISBN must be unique, so look for it in the line
                var newLines = Lines.Where(line => !line.Contains(code + ";" + t));
                File.WriteAllLines("books.txt", newLines);

                MessageBox.Show("Book " + t + " deleted");
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
        //display all taken books
        private void buttonTaken_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();
            //Hide buttons realted to library management
            buttonAdd.Visible = false;
            buttonEdit.Visible = false;
            buttonDel.Visible = false;
            textBoxBook.Clear();
            label3.Visible = false;

            string line;
            StreamReader file = new StreamReader("taken.txt");
            while ((line = file.ReadLine()) != null)
            {
                listBoxMain.Items.Add(line.Replace(";", " --- "));
            }
            file.Close();
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
            buttonChange.Visible = true;
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
            { MessageBox.Show("Please select a reader account"); return; }

            readerInfo = readerInfo.Replace(" --- ", ";");
            string[] readerInfoSplit = readerInfo.Split(';');

            //new form - to get info. about the book being taken
            FormGiveBook gb = new FormGiveBook();
            gb.ShowDialog();

            //info about book being taken => givenBookInfo
            string givenBookInfo = FormGiveBook.givenBookInfo;
            //format of the info   isbn;title;author;genres;quantity
            givenBookInfo = givenBookInfo.Replace(" --- ", ";");
            string[] splitInfo = givenBookInfo.Split(';');

            if (givenBookInfo != "none")
            {
                //is quantity != 0?
                int quo = Int32.Parse(splitInfo[4]);
                if (quo == 0)
                { MessageBox.Show("All copies of this book are taken"); return; }
                quo = quo - 1;

                //write info about book into their file 
                string userBooks = @"D:\" + readerInfoSplit[0] + ".txt";

                //exists in reader file?
                bool exists = false;
                if (System.IO.File.Exists(userBooks))
                {
                    exists = Functions.checkIfExistsInFile(userBooks, splitInfo[0]);
                }
                if (exists == true)
                { MessageBox.Show("You have already taken this book"); return; }

                //ALL GOOD -> WRITE NEEDED INFO. INTO FILES: username.txt, taken.txt, books.txt
                Functions.takeORGiveBook(splitInfo, givenBookInfo, userBooks, readerInfoSplit[0], quo);

                MessageBox.Show("Book \n" + splitInfo[1] + " \nadded to " + readerInfoSplit[0] + " file");

                //if changes ever made to file --- reload the list!
                Functions.loadLibraryBooks();
            }
        }

        //delete book from reader file
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            //get info about selected reader
            string readerInfo = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (readerInfo == "")
            { MessageBox.Show("Please select a reader account"); return; }

            readerInfo = readerInfo.Replace(" --- ", ";");
            string[] readerInfoSplit = readerInfo.Split(';');

            //their file  
            string userBooks = @"D:\" + readerInfoSplit[0] + ".txt";

            if (!System.IO.File.Exists(userBooks))
            {
                MessageBox.Show("Selected reader has never taken any books (no file created)");
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
            string returnedBookInfo = FormReaderBooks.returnedBookInfo;
            //format of returnedBookInfo   isbn;title;author;genres;date taken;date returned
            returnedBookInfo = returnedBookInfo.Replace(" --- ", ";");
            string[] splitInfo = returnedBookInfo.Split(';');

            if (returnedBookInfo != "none")
            {
                //is reader late to return?
                string dateToday = DateTime.Now.ToShortDateString();
                if (DateTime.Parse(splitInfo[5]) < DateTime.Parse(dateToday))
                {
                    var late = DateTime.Parse(dateToday) - DateTime.Parse(splitInfo[5]);
                    MessageBox.Show(readerInfoSplit[0] + " is late to return this book by: " + late.Days + "days");
                }

                //delete in user file
                var Lines = File.ReadAllLines(userBooks);
                var newLines = Lines.Where(line => !line.Contains(returnedBookInfo));
                File.WriteAllLines(userBooks, newLines);

                MessageBox.Show("Book\n" + splitInfo[1] + "\ndeleted from reader account");

                //delete in taken.txt
                Lines = File.ReadAllLines("taken.txt");
                newLines = Lines.Where(line => !line.Contains(returnedBookInfo + ";" + readerInfoSplit[0]));
                File.WriteAllLines("taken.txt", newLines);


                //change (add) quantity in books.txt
                //read all text
                string Ftext = File.ReadAllText("books.txt");

                //what's the current quantity in list?
                int quo = 0;
                //checks all the books in the list bookList
                foreach (Book tempBook in Book.bookList)
                {
                    if (tempBook.ISBN == splitInfo[0] && tempBook.title == splitInfo[1])
                    {
                        quo = tempBook.quantity;
                        break;
                    }
                }

                string infoAboutBook = splitInfo[0] + ";" + splitInfo[1] + ";" +
                                       splitInfo[2] + ";" + splitInfo[3];
                //old line
                string oLine = infoAboutBook + ";" + quo.ToString();

                quo = quo + 1;

                //new line
                string nLine = infoAboutBook + ";" + quo.ToString();


                //modifiy old text
                Ftext = Ftext.Replace(oLine, nLine);
                //write it back
                File.WriteAllText("books.txt", Ftext);

                //if changes ever made to file --- reload the list!
                Functions.loadLibraryBooks();
            }
        }


        //change account info.
        private void buttonChange_Click(object sender, EventArgs e)
        {
            //get info about selected reader
            User passUser = new User();
            string readerInfo = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (readerInfo == "")
            { MessageBox.Show("Please select a reader account"); return; }

            readerInfo = readerInfo.Replace(" --- ", ";");
            string[] readerInfoSplit = readerInfo.Split(';');
            //get ALL info. about reader
            foreach (User reader in User.readerList)
            {
                if (reader.username == readerInfoSplit[0])
                {
                    passUser = reader;
                    break;
                }
            }

            FormAccountInfo accInfo = new FormAccountInfo("all");
            //pass defined user object to the new form
            accInfo.user = passUser;
            accInfo.ShowDialog();

            //clear main window
            listBoxMain.Items.Clear();
            Functions.loadReaders();
        }



        //ISBN scanner
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