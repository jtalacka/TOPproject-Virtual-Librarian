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
            if (t.Type == "employee")
            {
                buttonManageLibrary.Visible = true;
                buttonManageReaderAcc.Visible = true;
            }
            else
            {
                buttonManageLibrary.Visible = false;
                buttonManageReaderAcc.Visible = false;
            }


            for (int i = 0; i < 10; i++)
            {
                flowLayoutPanel1.Controls.Add(groupBox(i));
            }

        }
        private FlowLayoutPanel groupBox(int y)
        {
            FlowLayoutPanel gr = new FlowLayoutPanel();
            gr.BackColor = Color.FromArgb(100, 0, y * 20, 0);
            Padding myMargin = new Padding();
            myMargin.All = 0;
            myMargin.Top = 1;
            gr.Margin = myMargin;
            gr.FlowDirection = FlowDirection.LeftToRight;
            gr.Width = flowLayoutPanel1.Width;
            flowLayoutPanel1.AutoScroll = true;
            gr.Height =(int)(flowLayoutPanel1.Height/1.5);

            gr.Controls.Add(pictureBox());


            return gr;
        }
        private PictureBox pictureBox()
        {
            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Height= (int)(flowLayoutPanel1.Height / 1.5);
            pb.ImageLocation= "https://thumb.knygos-static.lt/YMDHgyvVbGFdZ4yGNt5hfyFkp-g=/fit-in/2048x2048/filters:cwatermark(static/wm.png,500,75,30)/images/books/1290188/1534927349_Seethaler_tabaconist_72max.jpg";



            return pb;
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
