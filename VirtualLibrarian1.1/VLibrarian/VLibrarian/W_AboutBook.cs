using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
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

            Title.Text = W_Library.bookToPass.title;
            Author.Text = W_Library.bookToPass.author;
            Descr.Text = W_Library.bookToPass.description;

            string tempString = "";
            foreach (string g in W_Library.bookToPass.genres)
            {
                tempString += g;
                tempString += " ";
            }
            Genres.Text = tempString;


            //show default image or picture from db
            Bitmap bmp = BitmapFactory.DecodeByteArray(W_Library.bookToPass.picture, 0, W_Library.bookToPass.picture.Length);
            image.SetImageBitmap(bmp);


            //if (W_Library.bookToPass.image == "show default" || W_Library.bookToPass.picture == null
            //                        || W_Library.bookToPass.picture.Length == 0)
            //{pictureBox1.ImageLocation = "https://cdn.pixabay.com/photo/2018/01/03/09/09/book-3057901_960_720.png";}
            //else
            //{ image.SetImageBitmap(bmp);}
        }
    }
}