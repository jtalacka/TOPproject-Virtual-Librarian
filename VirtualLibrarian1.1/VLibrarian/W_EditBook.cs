using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Android.Media;
using Android.Graphics;
using System.Collections.Generic;

namespace VLibrarian
{
    [Activity(Label = "W_EditBook")]
    public class W_EditBook : Activity
    {
        //passed book
        public static Book passedBook;


        //fill ListView with genres on load
        string[] tempG = { "Adventure", "Art", "Children's", "Drama", "Encyclopedias", "Fantasy",
                "Health", "History", "Horror","Mystery", "Philosophy", "Poetry", "Romance", "Science-fiction", "Travel"};
        List<string> genresDisplay = new List<string>();
        List<string> genresSelected = new List<string>();



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_EditBook);

            EditText ISBN = FindViewById<EditText>(Resource.Id.textInputISBN);
            EditText Title = FindViewById<EditText>(Resource.Id.textInputTitle);
            EditText Author = FindViewById<EditText>(Resource.Id.textInputAuthor);
            EditText Quantity = FindViewById<EditText>(Resource.Id.textInputQuantity);
            ListView ListGenres = FindViewById<ListView>(Resource.Id.listViewGenres);
            Button GenreB = FindViewById<Button>(Resource.Id.buttonGenres);
            EditText Description = FindViewById<EditText>(Resource.Id.textInputDescription);

            EditText Picture = FindViewById<EditText>(Resource.Id.textInputPicture);
            Button ChoosePic = FindViewById<Button>(Resource.Id.buttonChoosePicture);

            Button EditBook = FindViewById<Button>(Resource.Id.buttonEditBook);

            //display info.
            ISBN.Text = passedBook.ISBN;
            Title.Text = passedBook.title;
            Author.Text = passedBook.author;
            Quantity.Text = passedBook.quantity.ToString();
            Description.Text = passedBook.description;




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
                foreach (string g in genresSelected)
                {
                    gs += " " + g;
                }
                Toast.MakeText(ApplicationContext, gs, ToastLength.Short).Show();
            };





            //edit
            EditBook.Click += (sender, e) =>
            {
                //get new info
                passedBook.ISBN = ISBN.Text;
                passedBook.title = Title.Text;
                passedBook.author = Author.Text;

                //check if valid quantity
                int qua;
                if (!Int32.TryParse(Quantity.Text, out qua))
                {
                    Toast.MakeText(ApplicationContext, "Please enter a valid quantity", ToastLength.Long).Show();
                    return;
                }
                passedBook.quantity = qua;
                passedBook.description = Description.Text;
                
                if(genresSelected.Count>0)
                {
                    passedBook.genres = genresSelected;
                }


                //save changes
                Controller_linker.runBookUpdate(LibrarySystem.edBook, passedBook);
                Toast.MakeText(ApplicationContext, "Changes saved", ToastLength.Long).Show();

                //exit
                Intent Exiting = new Intent(this, typeof(W_LibSys));
                this.StartActivity(Exiting);
            };




            //choose a picture
            ChoosePic.Click += (sender, e) =>
            {
                OnUpload(sender, e);
            };

            async void OnUpload(object sender, EventArgs e)
            {
                try
                {
                    // the dataarray of the file will be found in filedata.DataArray
                    // file name will be found in filedata.FileName;
                    FileData filedata = await CrossFilePicker.Current.PickFile();
                    //name of chosen pic
                    Picture.Text = filedata.FileName;

                    //for saving ito db
                    passedBook.picture = filedata.DataArray;

                }
                catch (Exception ex)
                {
                    Toast.MakeText(ApplicationContext, ex.Message, ToastLength.Long).Show();
                }
            }


        }
    }
}