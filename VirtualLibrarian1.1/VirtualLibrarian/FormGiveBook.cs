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
    public partial class FormGiveBook : Form
    {
        public FormGiveBook()
        {
            InitializeComponent();
        }

        public static string givenBookInfo = "none";

        //file storage path
        //public string books = @"C:\Users\books.txt";

        private void FormGiveBook_Load(object sender, EventArgs e)
        {
            string line;
            StreamReader file = new StreamReader("books.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                listBox1.Items.Add(lineSplit[0] + " --- " + lineSplit[1] + " --- " + lineSplit[2] + " --- " + lineSplit[3]);
            }
            file.Close();
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected book info
            givenBookInfo = listBox1.GetItemText(listBox1.SelectedItem);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {          
            if (givenBookInfo == "none")
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
