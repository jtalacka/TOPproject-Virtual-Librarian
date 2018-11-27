using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VLibrarian
{
    [Activity(Label = "W_EditBook")]
    public class W_EditBook : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.L_EditBook);

            EditText ISBN = FindViewById<EditText>(Resource.Id.textInputISBN);
            EditText Title = FindViewById<EditText>(Resource.Id.textInputTitle);
            EditText Author = FindViewById<EditText>(Resource.Id.textInputAuthor);
            EditText Quantity = FindViewById<EditText>(Resource.Id.textInputQuantity);
            CheckBox Genres = FindViewById<CheckBox>(Resource.Id.checkBoxGenres);
            EditText Description = FindViewById<EditText>(Resource.Id.textInputDescription);
            Button EditBook = FindViewById<Button>(Resource.Id.buttonEdit);

            base.OnCreate(savedInstanceState);



        }
    }
}