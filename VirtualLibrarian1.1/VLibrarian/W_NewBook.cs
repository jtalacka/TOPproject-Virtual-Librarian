using Android.App;
using Android.OS;
using Android.Widget;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VLibrarian
{
    [Activity(Label = "W_NewBook")]
    public class W_NewBook : Activity
    {

        byte[] temp;
        string picN;

        //fill ListView with genres on load
        string[] tempG = { "Adventure", "Art", "Children's", "Drama", "Encyclopedias", "Fantasy",
                "Health", "History", "Horror","Mystery", "Philosophy", "Poetry", "Romance", "Science-fiction", "Travel"};
        List<string> genresDisplay = new List<string>();
        List<string> genresSelected = new List<string>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_NewBook);

            EditText ISBN = FindViewById<EditText>(Resource.Id.textInputISBN);
            EditText Title = FindViewById<EditText>(Resource.Id.textInputTitle);
            EditText Author = FindViewById<EditText>(Resource.Id.textInputAuthor);
            EditText Quantity = FindViewById<EditText>(Resource.Id.textInputQuantity);
            ListView ListGenres = FindViewById<ListView>(Resource.Id.listViewGenres);
            Button GenreB = FindViewById<Button>(Resource.Id.buttonGenres);
            EditText Description = FindViewById<EditText>(Resource.Id.textInputDescription);
            Button AddNewBook = FindViewById<Button>(Resource.Id.buttonAddNewBook);

            EditText Picture = FindViewById<EditText>(Resource.Id.textInputPicture);
            Button ChoosePic = FindViewById<Button>(Resource.Id.buttonChoosePicture);


            //show genres
            GenreB.Click += (sender, e) =>
            {
                for (int i = 0; i < tempG.Length; i++)
                {
                    genresDisplay.Add(tempG[i]);
                }

                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, genresDisplay);
                ListGenres.Adapter = adapter;
            };

            //save picked genres
            ListGenres.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                //get selected
                string selectedG = Convert.ToString(ListGenres.GetItemAtPosition(e.Position));

                genresSelected.Add(selectedG);

                string gs = "";
                foreach(string g in genresSelected)
                {
                    gs += " " + g;
                }
                Toast.MakeText(ApplicationContext, gs, ToastLength.Short).Show();
            };


            AddNewBook.Click += (sender, e) =>
            {
                //check if valid ISBN
                if (Controller_linker.runAnInputdelegate(Login_or_Signup.inputC, ISBN.Text, 3) == 0)
                {
                    Toast.MakeText(ApplicationContext, "Please enter a valid ISBN", ToastLength.Long).Show();
                    return;
                }

                //check if ISBN already exists in table
                if (Controller_linker.runABookcheck(LibrarySystem.checkIfExists, ISBN.Text) == true)
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
                if (genresSelected.Count == 0)
                {
                    Toast.MakeText(ApplicationContext, "Please select at least one genre", ToastLength.Long).Show();
                    return;
                }


                Toast.MakeText(ApplicationContext, picN, ToastLength.Long).Show();

                //define new book
                Book bp = new Book(ISBN.Text, Title.Text, Author.Text, genresSelected, qua, Description.Text, temp);
                try
                {
                    //add a book to table
                    Controller_linker.runBookUpdate(LibrarySystem.newBook, bp);
                }
                catch { }


                Toast.MakeText(ApplicationContext, "Book " + bp.title + " added.", ToastLength.Long).Show();
                ISBN.Text = "ISBN";
                Title.Text = "Title";
                Author.Text = "Author";
                Quantity.Text = "Quantity";
                Description.Text = "Description";

            };




            //choose a picture
            ChoosePic.Click += async (sender, e) =>
            {
                //OnUpload(sender, e);

                try
                {
                    FileData filedata = await CrossFilePicker.Current.PickFile();
                    //name of chosen pic
                    Picture.Text = filedata.FileName;
                    //for saving ito db
                    temp = filedata.DataArray;

                    Toast.MakeText(ApplicationContext, filedata.FileName, ToastLength.Long).Show();

                }
                catch { }
            };
        }



    }
}