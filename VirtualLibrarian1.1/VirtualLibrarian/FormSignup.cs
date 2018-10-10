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

            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string username = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            string birth = textBoxBirth.Text;
            string email = textBoxEmail.Text;
            //check if valid email w regex
            if (Functions.inputCheck(email, 1) == 0)
            {
                MessageBox.Show("Please enter a valid email (ex.:email@gmail.com)");
                textBoxEmail.Focus();
                return;
            }
            //check if date the right format
            if (Functions.inputCheck(birth, 2) == 0)
            {
                MessageBox.Show("Incorrect date of birth format (ex.: 1989.11.05 or 1989-11-05)");
                textBoxBirth.Focus();
                return;
            }

            //check if username already exists in login info file
            bool exists = Functions.checkIfExistsInFile("login.txt", username);

            //Class User object
            User user;
            //if username unique - add user info. to the file
            if (exists == false)
            {
                //define user class object user
                user = new User(username, pass, name, surname, email, birth);
                //by default any new user is a reader
                user.type = User.userType.reader;

                using (StreamWriter w = File.AppendText("login.txt"))
                {
                    //information layout in file
                    w.WriteLine(username + ";" + pass + ";" + name + ";" + surname + ";" + email + ";" + birth + ";" + user.type);
                }

                this.Close();
                FormLibrary library = new FormLibrary();
                //pass defined user object to the new form
                library.user = user;
                library.Show();
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
