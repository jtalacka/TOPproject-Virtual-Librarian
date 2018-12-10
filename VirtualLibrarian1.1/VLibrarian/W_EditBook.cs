using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Android.Media;
using Android.Graphics;

namespace VLibrarian
{
    [Activity(Label = "W_EditBook")]
    public class W_EditBook : Activity
    {
        //passed book
        public static Book passedBook;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_EditBook);

            EditText ISBN = FindViewById<EditText>(Resource.Id.textInputISBN);
            EditText Title = FindViewById<EditText>(Resource.Id.textInputTitle);
            EditText Author = FindViewById<EditText>(Resource.Id.textInputAuthor);
            EditText Quantity = FindViewById<EditText>(Resource.Id.textInputQuantity);
            CheckBox Genres = FindViewById<CheckBox>(Resource.Id.checkBoxGenres);
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



                //save changes
                Controller_linker.runBookUpdate(LibrarySystem.edBook, passedBook);
                Toast.MakeText(ApplicationContext, "Changes saved", ToastLength.Long).Show();

                //exit
                Intent Exiting = new Intent(this, typeof(W_LibSys));
                this.StartActivity(Exiting);
            };
        }
    }
}