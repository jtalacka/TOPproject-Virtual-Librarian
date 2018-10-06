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
    public partial class FormReaderBooks : Form
    {
        private string v;

        public FormReaderBooks()
        {
            InitializeComponent();
        }
    
        public static string returnedBookInfo;
        public string username;

        private void FormReaderBooks_Load(object sender, EventArgs e)
        {
            returnedBookInfo = "none";
            string line;
            string path = @"D:\" + username + ".txt";         
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                listBox1.Items.Add(lineSplit[0] + " --- " + lineSplit[1] + " --- " 
                    + lineSplit[2] + " --- " + lineSplit[3] + " --- " 
                    + lineSplit[4] + " --- " + lineSplit[5]);
            }
            file.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected book info
            returnedBookInfo = listBox1.GetItemText(listBox1.SelectedItem);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (returnedBookInfo == "none")
            {
                MessageBox.Show("Select a book");
                return;
            }
            else
            {
                this.Close();
            }
        }

    }
}
