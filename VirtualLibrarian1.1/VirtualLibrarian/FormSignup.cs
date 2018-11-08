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
        I_NewLogin L_or_S;
        public FormSignup(I_NewLogin newLog)
        {
            InitializeComponent();
            //dependency injection from Form1
            L_or_S = newLog;
        }

        //define generic delegate with placeholder for L_or_S.signup
        public delegate T add<T>(T n, T s, T u, T p, T b, T e);
        static string runAdelegate(add<string> d, string n, string s, string u, string p, string b, string e)
        {
            return d(n, s, u, p, b, e);
        }

        //Signup button
        private void button1_Click(object sender, EventArgs e)
        {
            //check if any textbox's empty
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
                { MessageBox.Show("Please enter login info."); return; }

            //check if valid email w regex
            if (L_or_S.inputCheck(textBoxEmail.Text, 1) == 0)
            {
                MessageBox.Show("Please enter a valid email (ex.:email@gmail.com)");
                textBoxEmail.Focus();
                return;
            }
            //check if date the right format
            if (L_or_S.inputCheck(textBoxBirth.Text, 2) == 0)
            {
                MessageBox.Show("Incorrect date of birth format (ex.: 1989.11.05 or 1989-11-05)");
                textBoxBirth.Focus();
                return;
            }

            //check if username already exists in db table Users
            bool exists = L_or_S.checkIfExistsInDBUsers(textBoxUsername.Text);

            //if username unique - add user info. to db
            if (exists == false)
            {
                //point delegate to a method
                //add = L_or_S.signup;
                 add<string> add = L_or_S.signup;
                //call the method using the delegate object
                string result = runAdelegate(add, 
                                textBoxName.Text, textBoxSurname.Text, textBoxUsername.Text,
                                textBoxPassword.Text, textBoxBirth.Text, textBoxEmail.Text);

                if (result == "new reader added")
                {
                    this.Close();
                    //pass defined user object to the new form
                    FormLibrary library = new FormLibrary(Login_or_Signup.user);              
                    library.Show();
                }
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different one");
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
