using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using Android.Graphics;
using ZXing.Mobile;

namespace VLibrarian
{
    public class ReadIsbn : Activity
    {
        public static string isbn = "";

            public async void readISBN()
            {
                isbn = "";
                MobileBarcodeScanner.Initialize(Application);
                var MScanner = new MobileBarcodeScanner();
                var Result = await MScanner.Scan();
                isbn = Result.ToString();
            }
        }

}

