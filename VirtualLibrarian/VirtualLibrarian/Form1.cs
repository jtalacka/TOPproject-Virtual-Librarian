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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Button Library reader
        private void button1_Click(object sender, EventArgs e)
        {
            //close this form, show / goto new one
            FormLoginReader readerLogIn = new FormLoginReader();
            readerLogIn.Show();
            this.Hide();
        }

        //Button Library emloyee
        private void button2_Click(object sender, EventArgs e)
        {
            FormLoginEmployee employeeLogIn = new FormLoginEmployee();
            employeeLogIn.Show();
            this.Hide();
        }

        //Button Sign up
        private void button3_Click(object sender, EventArgs e)
        {
            FormSignup signup = new FormSignup();
            signup.Show();
            this.Hide();
        }

        //Buton exit
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
