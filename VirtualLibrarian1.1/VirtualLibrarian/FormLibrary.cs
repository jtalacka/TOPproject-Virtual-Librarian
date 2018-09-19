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

        private void FormLibrary_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(user.type.ToString()); 
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
            StreamReader file = new StreamReader(@"C:\Users\user\Desktop\VirtualLibrarian1.1\books.txt");
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

            //clear checked items
            foreach (int i in checkedListBoxGenre.CheckedIndices)
            {
                checkedListBoxGenre.SetItemCheckState(i, CheckState.Unchecked);
            }

        }



    }
}
