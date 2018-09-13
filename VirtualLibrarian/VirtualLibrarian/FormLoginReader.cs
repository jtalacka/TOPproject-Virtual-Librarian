using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class FormLoginReader : Form
    {
        public FormLoginReader()
        {
            InitializeComponent();
        } 

        //Button login
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;

            //check if textBox empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter login info."); return;
            }

            //check if input exists in login info database
            // --- code --- //

            //if all input ok, goto new form
            FormLibrary library = new FormLibrary();
            library.Show();
            this.Close();
        }

        //Button exit
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

    }
}
