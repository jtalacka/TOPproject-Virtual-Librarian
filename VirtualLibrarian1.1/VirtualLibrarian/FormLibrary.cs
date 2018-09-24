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
        public string books = @"C:\Users\books.txt";
        public bool pressedtakenbooks = false;

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

        private void takebook_Click(object sender, EventArgs e)// writes books into the file called username+.txt
        {
            string text = listBoxMain.GetItemText(listBoxMain.SelectedItem); // gets selected info about the book
            if (text == "")
            {
                MessageBox.Show("Please select a book");
            }
            else {
                MessageBox.Show(text);
                text = text.Replace(" --- ",";"); // saves the text into the format name;author;genre


                string path = @"D:\"+user.name+".txt";// couldnt use C:/users because on launch didnt have permission to create file
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text); //

                }

            }
        }

        private void buttonTakenBooks_Click(object sender, EventArgs e) // toggles between taken book view and all books
        {
            if (pressedtakenbooks == false)
            {
                pressedtakenbooks = true;
                buttonTakenBooks.BackColor = Color.Gray;
                books = @"D:\" + user.name + ".txt"; // sets the name and the path of the file
                takebook.Enabled = false;
                buttonSearch_Click(sender,e);
            }
            else {
                pressedtakenbooks = false;
                buttonTakenBooks.BackColor = SystemColors.Control; ;
                books = @"C:\Users\books.txt";
                takebook.Enabled = true;
            }


            }
    }
}
