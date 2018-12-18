using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VLibrarian
{
    [Activity(Label = "W_AboutBook")]
    public class W_AboutBook : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_AboutBook);

            TextView Title = FindViewById<TextView>(Resource.Id.textViewBTitle);
            TextView Author = FindViewById<TextView>(Resource.Id.textViewBAuthor);
            TextView Genres = FindViewById<TextView>(Resource.Id.textViewBGenres);
            TextView Descr = FindViewById<TextView>(Resource.Id.textViewBDescription);
            ImageView image = FindViewById<ImageView>(Resource.Id.imageView1);


            //display information
            //Title.Text = W_Library.bookToPass.title;
            Title.Text = W_Library.bookToPass.picture.Length.ToString();
            Author.Text = W_Library.bookToPass.author;
            Descr.Text = W_Library.bookToPass.description;

            string tempString = "";
            foreach (string g in W_Library.bookToPass.genres)
            {
                tempString += g;
                tempString += " ";
            }
            Genres.Text = tempString;


            //Toast.MakeText(ApplicationContext, W_Library.bookToPass.picture.Length, ToastLength.Long).Show();
            //Bitmap bmp = BitmapFactory.DecodeByteArray(W_Library.bookToPass.picture, 0, W_Library.bookToPass.picture.Length);
            //image.SetImageBitmap(bmp);



            //show default image or picture from db
            //if (W_Library.bookToPass.picture != null)
            //{
            //Toast.MakeText(ApplicationContext, W_Library.bookToPass.picture.ToString(), ToastLength.Long).Show();
            //Bitmap bmp = BitmapFactory.DecodeByteArray(W_Library.bookToPass.picture, 0, W_Library.bookToPass.picture.Length);
            //image.SetImageBitmap(Bitmap.CreateScaledBitmap(bmp, image.Width, image.Height, false));
            //image.SetImageBitmap(bmp);

            //}
        }
    }
}