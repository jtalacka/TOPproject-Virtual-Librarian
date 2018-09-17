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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Button Login
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxName.Text;
            string pass = textBoxPassword.Text;

            //check if textBox empty
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
               string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter login info."); return;
            }

            //check if input exists in login info database
            // --- code --- //

            //if all input ok, goto new form
            FormLibrary library = new FormLibrary();
            library.Show();
            this.Hide();
        }

        //Button Sign up
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            FormSignup signup = new FormSignup();
            signup.Show();
            this.Hide();
        }

        //Buton exit
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
