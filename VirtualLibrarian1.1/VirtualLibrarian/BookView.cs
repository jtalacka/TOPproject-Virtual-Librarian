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
    partial class BookView : Form
    {
        Book book;
        public BookView(Book book) {
            InitializeComponent();
            this.book = book;
        }


        private void BookView_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = "https://cdn.pixabay.com/photo/2018/01/03/09/09/book-3057901_960_720.png";
        }
    }
}
