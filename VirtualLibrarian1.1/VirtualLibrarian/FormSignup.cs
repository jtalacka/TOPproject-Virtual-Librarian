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
using System.Globalization;
using System.Text.RegularExpressions;

namespace VirtualLibrarian
{
    public partial class FormSignup : Form
    {
        public FormSignup()
        {
            InitializeComponent();
        }

        //Signup button
        private void button1_Click(object sender, EventArgs e)
        {
            //check if any textbox's empty
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            { MessageBox.Show("Please enter login info."); return; }

            //check if valid email w regex
            if (Login_or_Signup.inputCheck(textBoxEmail.Text, 1) == 0)
            {
                MessageBox.Show("Please enter a valid email (ex.:email@gmail.com)");
                textBoxEmail.Focus();
                return;
            }
            //check if date the right format
            if (Login_or_Signup.inputCheck(textBoxBirth.Text, 2) == 0)
            {
                MessageBox.Show("Incorrect date of birth format (ex.: 1989.11.05 or 1989-11-05)");
                textBoxBirth.Focus();
                return;
            }

            //check if username already exists in db table Users
            bool exists = Login_or_Signup.checkIfExistsInDBUsers(textBoxUsername.Text);

            //if username unique - add user info. to db
            if (exists == false)
            {
                string result =
                Login_or_Signup.signup(textBoxName.Text, textBoxSurname.Text, textBoxUsername.Text,
                textBoxPassword.Text, textBoxBirth.Text, textBoxEmail.Text);

                if (result == "new reader added")
                {
                    this.Close();
                    FormLibrary library = new FormLibrary();
                    //pass defined user object to the new form
                    library.user = Login_or_Signup.user;
                    library.Show();
                }
            }
            else
            {
                MessageBox.Show("Username already exists");
                textBoxUsername.Focus();
                return;
            }
        }

        //Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
