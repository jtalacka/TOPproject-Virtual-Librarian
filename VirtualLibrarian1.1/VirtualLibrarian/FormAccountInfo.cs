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
            if (displayAll == "all" || user.type.ToString() == "employee")
            {
                //display all functions
                textBoxUsername.ReadOnly = false;
                textBoxPass.PasswordChar = '*';
                textBoxPass.ReadOnly = false;
                textBoxName.ReadOnly = false;
                textBoxSurname.ReadOnly = false;
                textBoxEmail.ReadOnly = false;
                textBoxBirth.ReadOnly = false;
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
            if (Functions.inputCheck(textBoxEmail.Text, 1) == 0)
            {
                MessageBox.Show("Please enter a valid email (ex.:email@gmail.com)");
                textBoxEmail.Focus();
                return;
            }
            //check if date the right format
            if (Functions.inputCheck(textBoxBirth.Text, 2) == 0)
            {
                MessageBox.Show("Incorrect date of birth format (ex.: 1989.11.05 or 1989-11-05)");
                textBoxBirth.Focus();
                return;
            }


            string line;
            StreamReader file = new StreamReader("login.txt");
            //read line by line and look for Username
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');

                //if found our line (unique Username)
                if (lineSplit[0] == user.username)
                {
                    //save old info
                    string[] oInfo = { user.username, user.password,
                                        user.name, user.surname,
                                        user.email, user.birth };
                    //all old info in one string
                    string oLine = string.Join(";", oInfo);

                    //new info
                    string nLine;
                    //form new info string
                    nLine = string.Join(";", textBoxUsername.Text, textBoxPass.Text,
                                            textBoxName.Text, textBoxSurname.Text, 
                                            textBoxEmail.Text, textBoxBirth.Text);
                    //change current user
                    user.username = textBoxUsername.Text;
                    user.password = textBoxPass.Text;
                    user.name = textBoxName.Text;
                    user.surname = textBoxSurname.Text;
                    user.email = textBoxEmail.Text;
                    user.birth = textBoxBirth.Text;

                    file.Close();

                    //read all text
                    string text = File.ReadAllText("login.txt");
                    //modifiy old text
                    text = text.Replace(oLine, nLine);
                    //write it back
                    File.WriteAllText("login.txt", text);

                    //end the madness
                    break;
                }
            }

            Functions.loadReaders();
            MessageBox.Show("Changes saved");
            this.Close();
        }
    }
}