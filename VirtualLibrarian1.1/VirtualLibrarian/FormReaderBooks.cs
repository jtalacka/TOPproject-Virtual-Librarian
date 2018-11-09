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
        public FormReaderBooks(string user)
        {
            InitializeComponent();
            returnedBookInfo = "none";
            username = user;
        }

        //what to retun
        public static string returnedBookInfo;
        //what username passed
        string username;
        string showSelect = "show";

        public FormReaderBooks(string buttonShow, string user)
        {
            InitializeComponent();
            returnedBookInfo = "none";
            showSelect = buttonShow;
            username = user;
        }

        private void FormReaderBooks_Load(object sender, EventArgs e)
        {
            //determine if show button 'Select'
            if (showSelect == "show")
            { buttonSelect.Visible = true; }

            returnedBookInfo = "none";

            //get taken books from table Taken into list
            I_InLibrary Lib = new Library();
            List<string> taken = Lib.selectTakenBooks(username);
            foreach (string item in taken)
            {
                listBox1.Items.Add(item);
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            //get selected book info
            returnedBookInfo = listBox1.GetItemText(listBox1.SelectedItem);
            MessageBox.Show(returnedBookInfo);
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
