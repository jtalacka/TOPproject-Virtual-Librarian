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

        //file storage path
        public readonly string books = @"C:\Users\books.txt";

        private void FormLibrary_Load(object sender, EventArgs e)
        {
            //determine, if the user is reader or employee
            if (user.type.ToString() == "employee")
            {
                //extra employee functions
                buttonManageLibrary.Visible = true;
                buttonManageReaderAcc.Visible = true;
            }
            else
            {
                buttonManageLibrary.Visible = false;
                buttonManageReaderAcc.Visible = false;
            }
        }

        //search by genre
        private void buttonGenre_Click(object sender, EventArgs e)
        {
            //clear main window
            listBoxMain.Items.Clear();

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

            //search for books with selected genres
            string line;
            StreamReader file = new StreamReader(books);
            while ((line = file.ReadLine()) != null)
            {
                //split line into strings
                string[] lineSplit = line.Split(';');
                //lineSplit[2] contains the genres separated with spaces
                //get genres into genreSplit array
                string[] genreSplit = lineSplit[2].Split(' ');

                foreach (string g in checkedGenres)
                {
                    for (int i = 0; i < genreSplit.Length; i++)
                    {
                        //if matches - add to main listBox
                        if (genreSplit[i] == g)
                        {
                            listBoxMain.Items.Add(lineSplit[0] + " --- " + lineSplit[1] + " --- " + lineSplit[2]);
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

            //search for books with selected genres
            string line;
            string searchBA = textBox1.Text; // search book or author
            StreamReader file = new StreamReader(books);
            if (searchBA != "")
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
                            listBoxMain.Items.Add(lineSplit[0] + " --- " + lineSplit[1] + " --- " + lineSplit[2]);
                            break;

                        }
                    }
                }
                //clear checked items
                foreach (int i in checkedListBoxGenre.CheckedIndices)
                {
                    checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else
            {
                MessageBox.Show("Please enter author or Book");
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

        private void buttonManageLibrary_Click(object sender, EventArgs e)
        {

        }
    }
}
