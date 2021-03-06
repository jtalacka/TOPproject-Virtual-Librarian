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
        User user;
        public FormLibSys(User _user)
        {
            InitializeComponent();
            //dependency injection?
            user = _user;
        }

        I_InLibrary Lib = new Library();
        I_InLibSystem LibSys = new Library_System();

        //an event in separate class
         OnDB_Update updateE = new OnDB_Update();


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

            //reload list
            updateE.UpadateEvent();

            //checks all the books in the list bookList
            foreach (Book tempBook in Book.bookList)
            {
                //checks tempBook - if it fits, returns tempBook info to display            
                if (Lib.searchAuthororTitle(textBoxBook.Text, tempBook) != "no match")
                {
                    listBoxMain.Items.Add(Lib.searchAuthororTitle(textBoxBook.Text, tempBook));
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
            updateE.UpadateEvent();
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

            //define book to edit
            Book bookToPass = null;

            foreach (var book in Book.bookList)
            {
               if (book.ISBN == lineSplit[0] && book.title == lineSplit[1])
                {
                    bookToPass = book;
                }
            }

            //pass defined book
            FormEditBook eb = new FormEditBook(bookToPass);
            eb.ShowDialog();

            //clear main window
            listBoxMain.Items.Clear();
            updateE.UpadateEvent();
        }

        //delete book
        private void buttonDel_Click(object sender, EventArgs e)
        {
            //gets selected info about the book
            string info = listBoxMain.GetItemText(listBoxMain.SelectedItem);
            if (info == "")
            { MessageBox.Show("Please select a book to delete"); return;}

            info = info.Replace(" --- ", ";");
            string[] lineSplit = info.Split(';');

            //temp variables
            string code = lineSplit[0];
            string t = lineSplit[1];

            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete '" + t + "'?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql =
                "Delete from Books Where ISBN='" + code + "' and Title='" + t + "'";
                Lib.updateReaderInfo(sql);

                MessageBox.Show("Book " + t + " deleted");
                //clear main window
                listBoxMain.Items.Clear();
                updateE.UpadateEvent();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            //didn't use user object, but have to pass it back
            FormLibrary lib = new FormLibrary(user);
            lib.Show();
        }

        //display all taken books
        private void buttonTaken_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();
            //Hide buttons that
            buttonAdd.Visible = false;
            buttonEdit.Visible = false;
            buttonDel.Visible = false;
            textBoxBook.Clear();
            label3.Visible = false;

            buttonTake.Visible = false;
            buttonReturn.Visible = false;
            buttonChange.Visible = false;
            textBoxReader.Clear();
            label4.Visible = false;

            //load all taken books and display
            List<string> ALLtaken = LibSys.allTakenBooks();
            foreach (var item in ALLtaken)
            {
                listBoxMain.Items.Add(item);
            }
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

            //reload list
            updateE.UpadateEvent();

            //checks all list
            foreach (User reader in User.readerList)
            {
                //checks reader - if it fits, returns reader info to display            
                if (LibSys.searchR(textBoxReader.Text, reader) != "no match")
                {
                    listBoxMain.Items.Add(LibSys.searchR(textBoxReader.Text, reader));
                }
            }
        }

        //add new taken book
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

                //ALL GOOD -> WRITE NEEDED INFO. INTO TABLES: Taken, Books
                Lib.takeORGiveBook(splitInfo, readerInfoSplit[0], quo);

                MessageBox.Show("Book \n" + splitInfo[1] + " \nadded to " + readerInfoSplit[0] + " file");

            }
            //reload list
            updateE.UpadateEvent();
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

            //new form
            FormReaderBooks rb = new FormReaderBooks(readerInfoSplit[0]);
            rb.ShowDialog();

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

                //delete in Taken and add quantity in Books
                string sql =
                "Delete from Taken where " +
                "ISBN='" + splitInfo[0] + "' and Username='" + readerInfoSplit[0] + "'";
                LibSys.deleteBookFromReader(sql, splitInfo);

                MessageBox.Show("Book\n" + splitInfo[1] + "\ndeleted from reader account");

            }
            updateE.UpadateEvent();
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

            FormAccountInfo accInfo = new FormAccountInfo("all", passUser);
            //pass defined user object to the new form
            accInfo.ShowDialog();

            //clear main window
            listBoxMain.Items.Clear();
            updateE.UpadateEvent();
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