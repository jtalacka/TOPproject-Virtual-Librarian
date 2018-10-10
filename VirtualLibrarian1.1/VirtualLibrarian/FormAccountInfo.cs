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
    public partial class FormAccountInfo : Form
    {
        public FormAccountInfo()
        {
            InitializeComponent();
        }
        //file storage path
        //public readonly string loginInfo = @"C:\Users\login.txt";
        //for passing User class object parameters between forms
        internal User user { get; set; }

        private void FormAccountInfo_Load(object sender, EventArgs e)
        {
            //on form load - display user info
            labelUserName.Text = user.username;
            labelPass.Text = user.password;
            labelName.Text = user.name;
            labelSurname.Text = user.surname;
            labelEmail.Text = user.email;
            labelBirth.Text = user.birth;
        }

        //button Change username
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
            labelUserName.Visible = false;
            textBoxUsername.Visible = true;
            button1.Visible = false;
            buttonSave.Visible = true;
        }
        //button Change password
        private void button2_Click(object sender, EventArgs e)
        {
            textBoxPass.Focus();
            labelPass.Visible = false;
            textBoxPass.Visible = true;
            button2.Visible = false;
            buttonSave.Visible = true;
        }
        //Save changes
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string oldUsername = user.username;
            string oldPass = user.password;

            //if one of them not empty - save and display
            if (!string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
                !string.IsNullOrWhiteSpace(textBoxPass.Text))
            {
                //save new info. in User object and in file
                if (!string.IsNullOrWhiteSpace(textBoxUsername.Text))
                {
                    user.username = textBoxUsername.Text;

                    string text = File.ReadAllText("login.txt");
                    //username must be unique - so look for it
                    text = text.Replace(oldUsername, user.username);
                    File.WriteAllText("login.txt", text);
                }
                if (!string.IsNullOrWhiteSpace(textBoxPass.Text))
                {
                    user.password = textBoxPass.Text;

                    string text = File.ReadAllText("login.txt");
                    //some passwords may be the same
                    text = text.Replace(oldPass, user.password);
                    File.WriteAllText("login.txt", text);
                }

                textBoxUsername.Visible = false;
                textBoxPass.Visible = false;

                labelUserName.Text = user.username;
                labelPass.Text = user.password;

                labelUserName.Visible = true;
                labelPass.Visible = true;

                button1.Visible = true;
                button2.Visible = true;

                buttonSave.Visible = false;
            }
        }
    }
}