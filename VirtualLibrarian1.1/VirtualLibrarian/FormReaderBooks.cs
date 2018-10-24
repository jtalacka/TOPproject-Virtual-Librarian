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

        public FormReaderBooks()
        {
            InitializeComponent();
        }

        private string s;
        public FormReaderBooks(string buttonShow)
        {
            this.s = buttonShow;
             InitializeComponent();
        }

        public static string returnedBookInfo;
        public string username;

        private void FormReaderBooks_Load(object sender, EventArgs e)
        {
            if(s != "show")
            { buttonSelect.Visible = true; }

            returnedBookInfo = "none";

            string line;        
            StreamReader file = new StreamReader(@"D:\" + username + ".txt");
            while ((line = file.ReadLine()) != null)
            {
                line = line.Replace(";", " --- ");
                listBox1.Items.Add(line);
            }
            file.Close();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            //get selected book info
            returnedBookInfo = listBox1.GetItemText(listBox1.SelectedItem);

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
