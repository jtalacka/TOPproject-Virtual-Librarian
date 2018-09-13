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
    public partial class FormLoginEmployee : Form
    {
        public FormLoginEmployee()
        {
            InitializeComponent();
        }

        //Button login
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            int id;

            //check if empty
            if (string.IsNullOrWhiteSpace(name) ||
               string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Please enter login info."); return;
            }

            //check if input correct type
            if (!(Int32.TryParse(textBox3.Text, out id)))
            {
                MessageBox.Show("Id has to be a number"); return;
            }

            //check if input exists in login info database
            //for now just fill in with whatever
            // --- code --- //

            //if all input ok, goto new form
            FormLibrarySystem libsys = new FormLibrarySystem();
            libsys.Show();
            this.Close();
        }

        //Button exit
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
