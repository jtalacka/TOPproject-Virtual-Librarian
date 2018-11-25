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
    [Activity(Label = "W_LibSys")]
    public class W_LibSys : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_LibSystem);

            Button buttonAdd = FindViewById<Button>(Resource.Id.buttonAdd);
            Button buttonEdit = FindViewById<Button>(Resource.Id.buttonEdit);
            Button buttonDel = FindViewById<Button>(Resource.Id.buttonDel);
            ListView ListViewBooks = FindViewById<ListView>(Resource.Id.listViewBooks);


            //display books
            List<string> toDisplay = new List<string>();
            foreach (Book tempBook in Book.bookList)
            {
                string match = tempBook.ObToString(tempBook);
                toDisplay.Add(match);
            }
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
            ListViewBooks.Adapter = adapter;


            //NewBook
            buttonAdd.Click += (sender, e) =>
            {
                //to new form
                Intent Adding = new Intent(this, typeof(W_NewBook));
                this.StartActivity(Adding);
            };
            //EditBook
            buttonEdit.Click += (sender, e) =>
            {
                Intent Editing = new Intent(this, typeof(W_EditBook));
                this.StartActivity(Editing);
            };
            //Delete book
            buttonDel.Click += (sender, e) =>
            {
                ListViewBooks.ItemClick += delegate (object sender2, AdapterView.ItemClickEventArgs e2)
                {
                    int selected = e2.Position;
                    var selectedB = toDisplay.ElementAt(selected);
                    //Console.Write(selectedB);
                };


            };


        }
    }
}