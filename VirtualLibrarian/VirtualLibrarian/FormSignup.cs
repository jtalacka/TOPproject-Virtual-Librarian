using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string name = textBox1.Text;
            string surname = textBox2.Text;
            int birth;
            //check if input is the right type
            if (int.TryParse(textBox3.Text, out birth))
            {
                //parsing successful 
                birth = Convert.ToInt32(textBox3.Text);
            }
            else
            {
                //parsing failed 
                MessageBox.Show("Date of birth has to be a number"); return;
            }
            int personalID;
            if (int.TryParse(textBox4.Text, out personalID))
            {
                personalID = Convert.ToInt32(textBox4.Text);
            }
            else
            {
                MessageBox.Show("Personal ID nr. has to be a number"); return;
            }
            string address = textBox5.Text;
            string email = textBox6.Text;
            int phone;
            if (int.TryParse(textBox7.Text, out phone))
            {
                phone = Convert.ToInt32(textBox7.Text);
            }
            else
            {
                MessageBox.Show("Phone nr. has to be a number"); return;
            }

            //check if any textbox's empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                birth==0 || personalID==0 || phone == 0 ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter login info."); return;
            }

            //Add new information into database
            // --- code --- //

            //if all input ok, goto new form
            FormLibrary library = new FormLibrary();
            library.Show();
            this.Close();
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
