using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class FormAccountInfo : Form
    {
        public FormAccountInfo()
        {
            InitializeComponent();
        }

        //what functions to display?
        private string displayAll = "none";
        public FormAccountInfo(string buttonShow)
        {
            this.displayAll = buttonShow;
            InitializeComponent();
        }

        //for passing User class object parameters between forms
        internal User user { get; set; }

        private void FormAccountInfo_Load(object sender, EventArgs e)
        {
            //what functions available in this case?
            if (displayAll == "all")
            {
                //display all functions
                textBoxUsername.ReadOnly = false;
                textBoxPass.PasswordChar = '*';
                textBoxPass.ReadOnly = false;
                textBoxName.ReadOnly = false;
                textBoxSurname.ReadOnly = false;
                textBoxEmail.ReadOnly = false;
                textBoxBirth.ReadOnly = false;
                buttonDel.Visible = true;
            }
            else
            {
                //display only 2 first
                textBoxUsername.ReadOnly = false;
                textBoxPass.ReadOnly = false;
            }

            //on form load - display user info
            textBoxUsername.Text = user.username;
            textBoxPass.Text = user.password;
            textBoxName.Text = user.name;
            textBoxSurname.Text = user.surname;
            textBoxEmail.Text = user.email;
            textBoxBirth.Text = user.birth;
        }

        //Save changes
        private void buttonSave_Click(object sender, EventArgs e)
        {
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

            string sql = 
                "Update Users set " +
                "Username='" + textBoxUsername.Text + "', " + "Password='" + textBoxPass.Text + "', " + 
                "Name='" + textBoxName.Text + "', " + "Surname='" + textBoxSurname.Text + "', " + 
                "Email='" + textBoxEmail.Text + "', " + "Birth='" + textBoxBirth.Text + "'" + 
                "Where Username='" + user.username + "'";
            //update table Users
            Library.updateReaderInfo(sql);

            //change current user object
            user.username = textBoxUsername.Text;
            user.password = textBoxPass.Text;
            user.name = textBoxName.Text;
            user.surname = textBoxSurname.Text;
            user.email = textBoxEmail.Text;
            user.birth = textBoxBirth.Text;

            Library.loadReaders();
            MessageBox.Show("Changes saved");
            this.Close();
        }


        private void buttonDel_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete " + user.username + " account?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql =
                "Delete from Users where " +
                "Username='"+user.username+"' and Name='"+user.name+"' and Surname='"+user.surname+"'";
                Library.updateReaderInfo(sql);

                MessageBox.Show("User " + user.username + " deleted");
            }
            this.Close();
        }
    }
}