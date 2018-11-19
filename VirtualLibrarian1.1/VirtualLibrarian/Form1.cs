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
using System.Data.SqlClient;

namespace VirtualLibrarian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //interface object, through which we will be accessing the controller class methods
        I_NewLogin L_or_S = new Login_or_Signup();

        //define delegate that will point to L_or_S.login
        public delegate string del(string N, string P);
        del check;
        static string runAdelegate(del d, string n, string p)
        {
            return d(n, p);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //on form load, focus on username textbox
            this.ActiveControl = textBoxName;
        }

        //Button Log in
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //check if any textBox empty (LINQ method)
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
                { MessageBox.Show("Please enter login info."); return; }
          
            //point defined delegate to method
            check = L_or_S.login;
            //call the method using the delegate object
            string result = runAdelegate(check, textBoxName.Text, textBoxPassword.Text);

            //check if login info. correct
            if (result == "correct" && Login_or_Signup.user != null)
            {
                //if all input ok, goto new form
                this.Hide();
                //pass defined user object to the new form
                FormLibrary library = new FormLibrary(Login_or_Signup.user);               
                library.Show();
            }
            else if (result == "Incorrect password")
            {
                MessageBox.Show("Incorrect password");
                textBoxPassword.Focus();
                return;
            }
            else if (result == "User with this username doesn't exist")
            {
                MessageBox.Show("User with this username doesn't exist");
                textBoxName.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Something's wrong in the database");
                this.Close();
            }
        }

        //Button Sign up
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            FormSignup signup = new FormSignup(L_or_S);
            signup.Show();
            this.Hide();
        }
    }
}
