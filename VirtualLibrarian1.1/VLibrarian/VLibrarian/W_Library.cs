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
    [Activity(Label = "W_Library")]
    public class W_Library : Activity
    {

        //define delegate for Lib.load... and create an instance
        public delegate void load();
        load loadL;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_Library);

            //determine, if the user is reader or employee
            if (Core.Login_or_Signup.user.type.ToString() == "employee")
            {
                //extra employee functions
                SetContentView(Resource.Layout.L_LibraryPlus);
                //buttonManageLibrary.Visible = true;
                //takebook.Visible = true;
            }
            else
            {
                SetContentView(Resource.Layout.L_Library);
            }

            EditText Search = FindViewById<EditText>(Resource.Id.inputText);
            Button SearchButton = FindViewById<Button>(Resource.Id.buttonSearch);
            Button AccButton = FindViewById<Button>(Resource.Id.buttonAcc);
            ListView ListViewMain = FindViewById<ListView>(Resource.Id.listView);

            //search
            SearchButton.Click += (sender, e) =>
            {
                Book.sortList.Clear();

                // define delegate loadL and call the method using the delegate object
                loadL = Library.loadLibraryBooks;
                loadL();

                List<string> toDisplay = new List<string>();
                //checks all the books in the bookList (filled on form load)
                foreach (Book tempBook in Book.bookList)
                {
                    string match = Library.searchAuthororTitle(Search.Text, tempBook);
                    toDisplay.Add(match);
                    //checks tempBook - if it fits, returns tempBook info to display            
                    if (match != "no match")
                    {
                        //ArrayAdapter<Book> adapter = new ArrayAdapter<Book>(this, Android.Resource.Layout.L_Library, Book.bookList);

                        //all search results to list for potential sorting
                        Book.sortList.Add(tempBook);
                        Console.WriteLine(tempBook);
                    }
                }
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewMain.Adapter = adapter;
            };

            //account
            AccButton.Click += (sender, e) =>
            {
                //to new form
                Intent Acc = new Intent(this, typeof(W_Account));
                this.StartActivity(Acc);
            };
        }
    }
}