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
    public partial class FormLibrary : Form
    {
        public FormLibrary()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void FormLibrary_Load(object sender, EventArgs e)
        {
            Form1 t = new Form1();
            //MessageBox.Show(t.Type); 
            if ( t.Type == "employee")
            {
                buttonManageLibrary.Visible = true ;
                buttonManageReaderAcc.Visible = true;
            }
            else
            {
                buttonManageLibrary.Visible = false;
                buttonManageReaderAcc.Visible = false;
            }
        }
    }
}
