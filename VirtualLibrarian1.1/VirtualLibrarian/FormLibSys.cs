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

        //search for a book
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            buttonDel.Visible = true;
            buttonEdit.Visible = true;

            //clear main window
            listBoxMain.Items.Clear();

            //search for books with selected genres
            string line;
            string searchBA = textBoxBook.Text; // search book or author
            StreamReader file = new StreamReader(books);
            if (searchBA != null)  // was "" just a test method for the use of same function to see all the books
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
    }
}
