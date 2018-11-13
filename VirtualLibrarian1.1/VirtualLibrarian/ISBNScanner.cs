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
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;


namespace VirtualLibrarian
{
    public delegate void CloseDelagate();
    public partial class ISBNScanner : Form
    {
       public static string results="";
        string file;
        VideoCaptureDevice FinalVideo;
        FilterInfoCollection VideoCaptureDevices;
        public ISBNScanner()
        {
            InitializeComponent();
            file = "";

        }

        private void ISBNScanner_Load(object sender, EventArgs e)
        {
            VideoCaptureDevices= new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices) {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            if (comboBox1.Items.Count > 0) {
                comboBox1.SelectedIndex = 0;
            }

        }
        public string returnisbn() {
            return results;
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // get new frame
            Bitmap bitmap = eventArgs.Frame;
            // process the frame
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap barcodeBitmap;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files(*.jpg, *.jpeg,*.bmp,*.png) | *.jpg; *.jpeg;*.png;*.bmp;";
            openFileDialog1.Title = "All";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFileDialog1.OpenFile();
                barcodeBitmap = new Bitmap(openFileDialog1.FileName);
           //      MessageBox.Show(openFileDialog1.FileName);

                readISBN(barcodeBitmap);


            }

        }
        public string readISBN(Bitmap barcodeBitmap) {
            IBarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(barcodeBitmap);
            if (result != null)
            {
                  MessageBox.Show(result.BarcodeFormat.ToString());
                     MessageBox.Show(result.Text);
                results = result.Text;
                if (FinalVideo!=null)
                {
                    FinalVideo.SignalToStop();
                }
                
                return results;
            }
            return "";
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (FinalVideo != null)
                {
                    if (FinalVideo.IsRunning == true) { FinalVideo.Stop(); FinalVideo = null;}
                }
                else
                {
                    FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
                    FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                    FinalVideo.Start();
                    
                }
            }
        }
        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            string res="";
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            Bitmap video2 = new Bitmap(video);
            pictureBox1.Image = video;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            res=readISBN(video2);
            if (res != "") {
                this.BeginInvoke((MethodInvoker)delegate { this.Close(); });
            }

 
        }
    }
}
