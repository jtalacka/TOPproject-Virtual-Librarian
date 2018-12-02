using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
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

                //check if title / author empty
                if (string.IsNullOrWhiteSpace(Title.Text) ||
                    string.IsNullOrWhiteSpace(Author.Text))
                {
                    Toast.MakeText(ApplicationContext, "Please enter a title and author", ToastLength.Long).Show();
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
                //default genre
                List<string> L = new List<string>();
                L.Add("Mystery");


                //define new book
                Book bp = new Book(ISBN.Text, Title.Text, Author.Text, L, qua);
                //add a book to table
                LibrarySystem.AddBook(bp);


                Toast.MakeText(ApplicationContext, "Book " + bp.title + " added.", ToastLength.Long).Show();
                ISBN.Text = "ISBN";
                Title.Text = "Title";
                Author.Text = "Author";
                Quantity.Text = "Quantity";
                Description.Text = "Description";

            };
        }
    }
}