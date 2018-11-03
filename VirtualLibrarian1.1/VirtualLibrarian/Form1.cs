using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace VirtualLibrarian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //on form load, focus on username textbox
            this.ActiveControl = textBoxName;
        }

        //Button Log in
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //check if any textBox empty (LINQ method)
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            { MessageBox.Show("Please enter login info."); return; }

            //check if login info. correct
            string checkRes = Login_or_Signup.login(textBoxName.Text, textBoxPassword.Text);
            if (checkRes == "correct" && Login_or_Signup.user != null)
            {
                //if all input ok, goto new form
                this.Hide();
                FormLibrary library = new FormLibrary();
                //pass defined user object to the new form
                library.user = Login_or_Signup.user;
                library.Show();
            }
            else if (checkRes == "Incorrect password")
            {
                MessageBox.Show("Incorrect password");
                textBoxPassword.Focus();
                return;
            }
            else if (checkRes == "User with this username doesn't exist")
            {
                MessageBox.Show("User with this username doesn't exist");
                textBoxName.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Something's wrong in the database");
                this.Close();
            }
        }

        //Button Sign up
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            FormSignup signup = new FormSignup();
            signup.Show();
            this.Hide();
        }
    }
}
