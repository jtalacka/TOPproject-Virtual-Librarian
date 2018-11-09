using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    partial class BookView : Form
    {
        Book book;
        public BookView(Book book)
        {
            InitializeComponent();
            this.book = book;
        }

        // displays information about the book
        private void BookView_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = book.title;
            richTextBox2.Text = book.author;
            string tempString = "";
            foreach (string g in book.genres)
            {
                tempString += g;
                tempString += " ";
            }
            richTextBox3.Text = tempString;
            richTextBox4.Text = book.description;

            //show default image or picture from db
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (book.image == "show default" || book.picture == null || book.picture.Length == 0)
            {
                pictureBox1.ImageLocation = "https://cdn.pixabay.com/photo/2018/01/03/09/09/book-3057901_960_720.png";
            }
            else
            {
                MemoryStream mstream = new MemoryStream(book.picture);
                pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
            }
        }
    }
}
