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

        bool genresChanged = false;

        //on load display information
        private void FormEditBook_Load(object sender, EventArgs e)
        {
            textBoxISBN.Text = book.ISBN.ToString();
            textBoxTitle.Text = book.title;
            textBoxAuthor.Text = book.author;
            textBoxQ.Text = book.quantity.ToString();
            textBoxGenres.Text = String.Join(" ", book.genres);
        }

        //if genres clicked
        private void checkedListBoxGenre_Click(object sender, EventArgs e)
        {
            genresChanged = true;
        }

        //save changes
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //check if valid ISBN w regex
            if (Functions.inputCheck(textBoxISBN.Text, 3) == 0)
            {
                MessageBox.Show("Please enter a valid ISBN (ex. of ISBN-13 code: 978-0486474915");
                textBoxISBN.Focus();
                return;
            }
            //check quantity
            int qua;
            if (!Int32.TryParse(textBoxQ.Text, out qua))
            {
                MessageBox.Show("Please enter a valid quantity");
                textBoxQ.Focus();
                return;
            }

            string line;
            StreamReader file = new StreamReader("books.txt");
            //read line by line and look for ISBN
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(';');

                //if found our line (unique ISBN)
                if (lineSplit[0] == book.ISBN)
                {
                    //save old info
                    string[] oInfo = { book.ISBN, book.title,
                                        book.author, textBoxGenres.Text, book.quantity.ToString() };
                    //all old info in one string
                    string oLine = string.Join(";", oInfo);
                    //new info
                    string nLine;

                    //if new genres selected 
                    if (genresChanged == true)
                    {
                        //get which genres chosen and put into List
                        List<string> checkedGenres = Functions.genresSelected(checkedListBoxGenre.CheckedItems);
                        //List into string
                        string checkedG = string.Join(" ", checkedGenres.ToArray());

                        //form new info string
                        nLine = string.Join(";", textBoxISBN.Text, textBoxTitle.Text,
                                                textBoxAuthor.Text, checkedG, textBoxQ.Text);
                    }
                    else
                    {
                        //form new info string
                        nLine = string.Join(";", textBoxISBN.Text, textBoxTitle.Text,
                                                textBoxAuthor.Text, textBoxGenres.Text, textBoxQ.Text); ;
                    }
                    file.Close();

                    //read all text
                    string text = File.ReadAllText("books.txt");
                    //modifiy old text
                    text = text.Replace(oLine, nLine);
                    //write it back
                    File.WriteAllText("books.txt", text);

                    //end the madness
                    break;
                }
            }

            MessageBox.Show("Changes saved");
            this.Close();
        }
    }
}
