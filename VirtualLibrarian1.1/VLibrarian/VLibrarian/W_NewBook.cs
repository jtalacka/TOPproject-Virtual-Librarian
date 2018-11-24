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
    [Activity(Label = "W_NewBook")]
    public class W_NewBook : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_NewBook);
            // Create your application here

            EditText ISBN = FindViewById<EditText>(Resource.Id.textInputISBN);
            EditText Title = FindViewById<EditText>(Resource.Id.textInputTitle);
            EditText Author = FindViewById<EditText>(Resource.Id.textInputAuthor);
            EditText Quantity = FindViewById<EditText>(Resource.Id.textInputQuantity);
            CheckBox Genres = FindViewById<CheckBox>(Resource.Id.checkBoxGenres);
            EditText Description = FindViewById<EditText>(Resource.Id.textInputDescription);
            Button AddNewBook = FindViewById<Button>(Resource.Id.buttonAddNewBook);


            ////display genres
            //string[] gs = { "Adventure", "Art", "Children's", "Drama", "Encyclopedias", "Fantasy",
            //                    "Health", "History", "Horror", "Mystery", "Philosophy", "Poetry",
            //                    "Romance", "Science-fiction", "Travel" };
            //List<string> toDisplay = gs.ToList();
            //ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
           


            AddNewBook.Click += (sender, e) =>
            {
                //check if valid ISBN
                if (Login_or_Signup.inputCheck(ISBN.Text, 3) == 0)
                {
                    Toast.MakeText(ApplicationContext, "Please enter a valid email (ex.:email@gmail.com)", ToastLength.Long).Show();
                    return;
                }

                //check if ISBN already exists in table
                if (LibrarySystem.checkIfExistsInDBBooks(ISBN.Text) == true)
                {
                    Toast.MakeText(ApplicationContext, "Book with this ISBN code already exists", ToastLength.Long).Show();
                    return;
                }
                //check if valid quantity
                int qua;
                if (!Int32.TryParse(Quantity.Text, out qua) && qua == 0)
                {
                    Toast.MakeText(ApplicationContext, "Please enter a valid quantity", ToastLength.Long).Show();
                    return;
                }
                //get which genres chosen





            };
        }
    }
}