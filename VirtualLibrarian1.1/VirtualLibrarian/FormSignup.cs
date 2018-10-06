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

        //file storage path
        public readonly string loginInfo=@"C:\Users\login.txt";

        //Signup button
        private void button1_Click(object sender, EventArgs e)
        {
            //check if any textbox's empty
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            { MessageBox.Show("Please enter login info."); return; }

            //Class User object
            User user = new User();

            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string username = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            //check if valid email
            Regex regex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
            if (!regex.IsMatch(email))
            {
                MessageBox.Show("Please enter a valid email (ex.:email@gmail.com)");
                textBoxEmail.Focus();
                return;
            }

            string birth = textBoxBirth.Text;
            //check if date the right format
            var dateFormats = new[] { "yyyy.MM.dd", "yyyy-MM-dd" };
            DateTime date;
            bool validDate = DateTime.TryParseExact(birth, dateFormats,
                DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out date);
            if (!validDate)
            {
                MessageBox.Show("Incorrect date of birth format (ex.: 1989.11.05 or 1989-11-05)");
                textBoxBirth.Focus();
                return;
            }

            string line;
            bool exists = false;

            //check if username already exists in login info file
            StreamReader file = new StreamReader(loginInfo);
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');
                if (lineSplit[0] == username)
                {
                    MessageBox.Show("Username already exists");
                    textBoxUsername.Focus();
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
                //by default any new user is a reader
                user.type = User.userType.reader;

                using (StreamWriter w = File.AppendText(loginInfo))
                {
                    //information layout in file
                    w.WriteLine(username + ";" + pass + ";" + name + ";" + surname + ";" + email + ";" + birth + ";" + user.type);
                }

                //if all input ok, goto new form
                this.Close();
                FormLibrary library = new FormLibrary();
                //pass defined user object to the new form
                library.user = user;
                library.Show();
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
