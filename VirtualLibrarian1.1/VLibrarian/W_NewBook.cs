﻿using System;
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
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;

namespace VLibrarian
{
    [Activity(Label = "W_NewBook")]
    public class W_NewBook : Activity
    {

        byte[] temp;
        string picN;

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

            EditText Picture = FindViewById<EditText>(Resource.Id.textInputPicture);
            Button ChoosePic = FindViewById<Button>(Resource.Id.buttonChoosePicture);

            
            //choose a picture
            ChoosePic.Click += async (sender, e) =>
            {
                //OnUpload(sender, e);

                FileData filedata = await CrossFilePicker.Current.PickFile();

                //name of chosen pic
                Picture.Text = filedata.FileName;
                //for saving ito db
                temp = filedata.DataArray;

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
                //default genre
                List<string> L = new List<string>();
                L.Add("Mystery");


                Toast.MakeText(ApplicationContext, picN, ToastLength.Long).Show();

                //define new book
                Book bp = new Book(ISBN.Text, Title.Text, Author.Text, L, qua, Description.Text, temp);
                //add a book to table
                Controller_linker.runBookUpdate(LibrarySystem.newBook, bp);


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