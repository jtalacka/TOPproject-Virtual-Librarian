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
    public partial class FormEditBook : Form
    {
        public FormEditBook()
        {
            InitializeComponent();
        }
        //for passing Book class object parameters between forms
        internal Book book { get; set; }
        //file storage path
        public string books = @"C:\Users\books.txt";

         //on load display information
        private void FormEditBook_Load(object sender, EventArgs e)
        {
            textBoxISBN.Text = book.ISBN.ToString();
            textBoxTitle.Text = book.title;
            textBoxAuthor.Text = book.author;
        }

        //save changes
        private void buttonEdit_Click(object sender, EventArgs e)
        {          
            string text = File.ReadAllText(books);
            text = text.Replace(book.ISBN.ToString(), textBoxISBN.Text);
            text = text.Replace(book.title, textBoxTitle.Text);
            text = text.Replace(book.author, textBoxAuthor.Text);
            File.WriteAllText(books, text);

            MessageBox.Show("Changes saved");
            this.Close();
        }
    }
}
