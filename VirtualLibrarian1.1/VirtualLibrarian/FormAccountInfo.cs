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
    public partial class FormAccountInfo : Form
    {
        public FormAccountInfo()
        {
            InitializeComponent();
        }

        //for passing User class object parameters between forms
        internal User user { get; set; }

        private void FormAccountInfo_Load(object sender, EventArgs e)
        {
            //on form load - display user info
            labelUserName.Text = user.username;
            labelName.Text = user.name;
            labelSurname.Text = user.surname;
            labelEmail.Text = user.email;
            labelBirth.Text = user.birth;
        }
    }
}
