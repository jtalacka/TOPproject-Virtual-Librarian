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

        private void FormGiveBook_Load(object sender, EventArgs e)
        {
            foreach (Book tempBook in Book.bookList)
            {               
                listBox1.Items.Add(Functions.objectToString(tempBook));
            }
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
