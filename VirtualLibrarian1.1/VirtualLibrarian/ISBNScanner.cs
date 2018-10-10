using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace VirtualLibrarian
{
    public partial class ISBNScanner : Form
    {
        string file;
        public ISBNScanner()
        {
            InitializeComponent();
            file = "";

        }

        private void ISBNScanner_Load(object sender, EventArgs e)
        {





        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap barcodeBitmap;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files(*.jpg, *.jpeg,*.bmp,*.png) | *.jpg; *.jpeg;*.png;*.bmp;";
            openFileDialog1.Title = "Alllll";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFileDialog1.OpenFile();
                barcodeBitmap = new Bitmap(openFileDialog1.FileName);
                // MessageBox.Show(openFileDialog1.FileName);

                readISBN(barcodeBitmap);


            }

        }
        private void readISBN(Bitmap barcodeBitmap) {
            IBarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(barcodeBitmap);
            if (result != null)
            {
                //  MessageBox.Show(result.BarcodeFormat.ToString());
                MessageBox.Show(result.Text);
            }
            else {
                MessageBox.Show("ISBN was not found");
            }
        }
    }
}
