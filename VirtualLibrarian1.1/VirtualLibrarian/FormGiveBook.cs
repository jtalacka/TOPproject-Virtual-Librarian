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

        public static string givenBookInfo;

        private void FormGiveBook_Load(object sender, EventArgs e)
        {
            //display books, that are available => quantity > 0
            foreach (Book tempBook in Book.bookList)
            {   
                if(tempBook.quantity > 0)
                    listBox1.Items.Add(tempBook.ObToString(tempBook));
            }
            givenBookInfo = "none";
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {    
            //get selected book info
            givenBookInfo = listBox1.GetItemText(listBox1.SelectedItem);

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


        //search
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //clear main window
            listBox1.Items.Clear();

            foreach (Book tempBook in Book.bookList)
            {
                //checks tempBook - if it fits, returns tempBook info to display            
                if (Functions.search(textBox1.Text, tempBook) != "no match")
                {
                    listBox1.Items.Add(Functions.search(textBox1.Text, tempBook));
                }
            }
        }
    }
}
