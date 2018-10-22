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

namespace VirtualLibrarian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Button Log in
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //check if any textBox empty (LINQ method)
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            { MessageBox.Show("Please enter login info."); return; }

            string username = textBoxName.Text;
            string pass = textBoxPassword.Text;
            string line;
            bool correct = false;

            //check if input exists in login info file
            // Read the file line by line unti end 
            StreamReader file = new StreamReader("login.txt");
            while ((line = file.ReadLine()) != null)
            {
                //split line into strings
                string[] lineSplit = line.Split(';');
                //check if input correct / exists
                //first two strings in file are username and password
                //the 6th string is user type (reader or employee)
                if (lineSplit[0] == username)
                {
                    if (lineSplit[1] == pass)
                    {
                        //define user object parameters
                        User user = new User(username, pass, lineSplit[2], lineSplit[3], lineSplit[4], lineSplit[5]);
                        if (lineSplit[6] == "reader")
                        { user.type = User.userType.reader; }
                        else if (lineSplit[6] == "employee")
                        { user.type = User.userType.employee; }
                        else
                            MessageBox.Show("Wrong user type");

                        correct = true;
                        //if all input ok, goto new form
                        this.Hide();
                        FormLibrary library = new FormLibrary();
                        //pass defined user object to the new form
                        library.user = user;
                        library.Show();

                        break;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password");
                        textBoxPassword.Focus();
                        return;
                    }
                }
            }
            file.Close();

            if (correct == false)
            {
                MessageBox.Show("User with this username doesn't exist");
                textBoxName.Focus();
                return;
            }     
        }

        //Button Sign up
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            FormSignup signup = new FormSignup();
            signup.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //on form load, focus on username textbox
            this.ActiveControl = textBoxName;
        }
    }
}
