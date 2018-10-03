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
        Book book = new Book();

        //if something gets selected
        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show 'Edit' and 'Delete'
            buttonDel.Visible = true;
            buttonEdit.Visible = true;
        }

        //search for a book
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();

            //search for books with selected genres
            string line;
            string searchBA = textBoxBook.Text; // search book or author
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
            eb.book = book;
            eb.Show();
        }

        //delete line
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

            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete '" + book.title + "'?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var Lines = File.ReadAllLines(books);
                var newLines = Lines.Where(line => !line.Contains(book.ISBN.ToString()));
                File.WriteAllLines(books, newLines);

                MessageBox.Show("Book deleted");
                //clear main window
                listBoxMain.Items.Clear();
            }
        }
    }
}