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
        //file storage path
        public string books = @"C:\Users\books.txt";
        public readonly string loginInfo = @"C:\Users\login.txt";
        Book book = new Book();
        internal User user;

        //search for a book
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            //Hide buttons realted to user management
            buttonTake.Visible = false;
            buttonReturn.Visible = false;
            textBoxReader.Clear();
            //Show library management buttons
            buttonAdd.Visible = true;         
            buttonEdit.Visible = true;
            buttonDel.Visible = true;

            //clear main window
            listBoxMain.Items.Clear();

            string line;
            // search book or author
            string searchBA = textBoxBook.Text; 
            StreamReader file = new StreamReader(books);
            // was "" just a test method for the use of same function to see all the books
            if (searchBA != null)
            {
                while ((line = file.ReadLine()) != null)
                {
                    //split line into strings
                    string[] lineSplit = line.Split(';');
                    for (int i = 0; i < lineSplit.Length; i++)
                    {
                        //if matches - add to main listBox
                        if (lineSplit[i].Contains(searchBA))
                        {
                            listBoxMain.Items.Add(lineSplit[0] + " --- " + lineSplit[1] + " --- " + lineSplit[2] + " --- " + lineSplit[3]);
                            break;
                        }
                    }
                }
                file.Close();
            }
        }

        //add a book
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormNewBook nb = new FormNewBook();
            nb.Show();
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
            book.ISBN = Int32.Parse(lineSplit[0]);
            book.title = lineSplit[1];
            book.author = lineSplit[2];
            List<string> tempGenres = lineSplit[3].Split(new char[] { ' ' }).ToList();
            book.genres = tempGenres;

            FormEditBook eb = new FormEditBook();
            //pass defined book
            eb.book = book;
            eb.Show();
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

            //define book
            book.ISBN = Int32.Parse(lineSplit[0]);
            book.title = lineSplit[1];

            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete '" + book.title + "'?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var Lines = File.ReadAllLines(books);
                //ISBN must be unique, so look for it in the line
                var newLines = Lines.Where(line => !line.Contains(book.ISBN.ToString()));
                File.WriteAllLines(books, newLines);

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



        //search reader ccounts
        private void buttonSearchReader_Click(object sender, EventArgs e)
        {
            //Hide buttons realted to library management
            buttonAdd.Visible = false;
            buttonEdit.Visible = false;
            buttonDel.Visible = false;
            textBoxBook.Clear();
            //Shoe reader management functions
            buttonTake.Visible = true;
            buttonReturn.Visible = true;

            //clear main window
            listBoxMain.Items.Clear();

            string line;
            string searchR = textBoxReader.Text; 
            StreamReader file = new StreamReader(loginInfo);
            if (searchR != null)
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] lineSplit = line.Split(';');
                    for (int i = 0; i < lineSplit.Length; i++)
                    {
                        //if matches - add to main listBox
                        if (lineSplit[i].Contains(searchR))
                        {
                            //lineSplit[1] is password - DONT SHOW IT
                            listBoxMain.Items.Add(lineSplit[0] + " --- " + lineSplit[2] + " --- " + lineSplit[3] + " --- " + lineSplit[4] + " --- " + lineSplit[5]);
                            break;
                        }
                    }
                }
                file.Close();
            }
        }
        //add new taken book to user account
        private void buttonTake_Click(object sender, EventArgs e)
        {
            //write book info into correct file

        }
    }
}