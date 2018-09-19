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

        //Class User object
        User user = new User();

        //for passing value to different form
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
         

        //Button Login
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //check if any textBox empty
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
               string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter login info."); return;
            }

            string username = textBoxName.Text;
            string pass = textBoxPassword.Text;
            string line;
            bool correct = false;

            //check if input exists in login info file
            // Read the file line by line  
            StreamReader file = new StreamReader(@"C:\Users\juliu\OneDrive\Stalinis kompiuteris\VirtualLibrarian1.1\login.txt");
            while ((line = file.ReadLine()) != null)
            {
                //split line into strings
                string[] lineSplit = line.Split(';');
                //check if input correct / exists
                //first two strings in file are username and password
                //the 6th string is uder type (reader or employee)
                if (lineSplit[0] == username)
                {
                   if (lineSplit[1] == pass)
                   {
                     //save user information
                     user.username = username;
                     user.password = pass;
                        if (lineSplit[6] == "reader")
                        {
                            user.type = User.userType.reader;
                            Type = "reader";
                        }
                        else if (lineSplit[6] == "employee")
                        {
                            user.type = User.userType.employee;
                            Type = "employee";
                        }
                        else
                            MessageBox.Show("Wrong user type");

                        correct = true;
                     //if all input ok, goto new form
                     this.Hide();
                     FormLibrary library = new FormLibrary();
                     library.Show();
                     
                     break;
                    }
                   else
                        MessageBox.Show("Incorrect password"); return;
                }  
            }

            if (correct==false)
                    MessageBox.Show("User doesn't exist");
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

        }
    }
}
