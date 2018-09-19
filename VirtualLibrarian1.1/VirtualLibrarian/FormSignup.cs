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
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSurname.Text) ||
                string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxBirth.Text))
            { MessageBox.Show("Please enter login info."); return; }

            //Class User object
            User user = new User();

            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string username = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            int birth;
            //check if input is the right type
            if (int.TryParse(textBoxBirth.Text, out birth))
            {
                //parsing successful 
                birth = Convert.ToInt32(textBoxBirth.Text);
            }
            else
            {
                //parsing failed 
                MessageBox.Show("Date of birth has to be a number"); return;
            }

            string line;
            bool exists = false;

            //check if username already exists in login info file
            StreamReader file = new StreamReader(@"C:\Users\juliu\OneDrive\Stalinis kompiuteris\VirtualLibrarian1.1\login.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                if (lineSplit[0] == username)
                {
                    MessageBox.Show("Username already exists");
                    exists = true;
                    break;
                }
            }
            file.Close();
            //if username unique - add user info. to the file
            if (exists == false)
            {
                //define user class object user
                user.name = name;
                user.surname = surname;
                user.username = username;
                user.password = pass;
                user.email = email;
                user.birth = birth;
                user.type = User.userType.reader;

                using (StreamWriter w = File.AppendText(@"C:\Users\juliu\OneDrive\Stalinis kompiuteris\VirtualLibrarian1.1\login.txt"))
                {
                    //inormation layout in file
                    w.WriteLine(username + ";" + pass + ";" + name + ";" + surname + ";" + email + ";" + birth + ";" + user.type);
                }


                //if all input ok, goto new form
                FormLibrary library = new FormLibrary();
                library.Show();
                this.Close();
            }
        }

        //Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void FormSignup_Load(object sender, EventArgs e)
        {

        }
    }
}
