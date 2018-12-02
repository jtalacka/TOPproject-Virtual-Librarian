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
using ZXing.Mobile;
using static Android.Net.Sip.SipAudioCall;

namespace VLibrarian
{
    [Activity(Label = "W_Library")]
    public class W_Library : Activity
    {
        public static Book bookToPass = null;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Button ToSystem = null;
            //determine, if the user is reader or employee
            if (Login_or_Signup.user.UserType == User.userType.employee)
            {
                //extra employee functions
                SetContentView(Resource.Layout.L_LibraryPlus);
                ToSystem = FindViewById<Button>(Resource.Id.buttonSys);
            }
            else
            {
                SetContentView(Resource.Layout.L_Library);
            }

            EditText Search = FindViewById<EditText>(Resource.Id.inputText);
            Button Sort = FindViewById<Button>(Resource.Id.buttonSort);
            Button SearchButton = FindViewById<Button>(Resource.Id.buttonSearch);
            ListView ListViewMain = FindViewById<ListView>(Resource.Id.listView);
            Button AccButton = FindViewById<Button>(Resource.Id.buttonAcc);
            Button readISBN = FindViewById<Button>(Resource.Id.buttonISBN);
            //search
            SearchButton.Click +=  (sender, e) =>
            {
                Book.sortList.Clear();

                // define delegate loadL and call the method using the delegate object
                Library.loadL();
                List<string> toDisplay = new List<string>();
                //checks all the books in the bookList (filled on form load)
                foreach (Book tempBook in Book.bookList)
                    {
                        string match = Library.searchAuthororTitle(Search.Text, tempBook);
                        //checks tempBook - if it fits, returns tempBook info to display            
                        if (match != "no match")
                        {
                            //ArrayAdapter<Book> adapter = new ArrayAdapter<Book>(this, Android.Resource.Layout.L_Library, Book.bookList);

                            //all search results to list for potential sorting
                            Book.sortList.Add(tempBook);
                            toDisplay.Add(match);
                        }
                    } 
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewMain.Adapter = adapter;
            };

            readISBN.Click += async (sender, e) =>
            {

                string isbn = "";
                try
                {
                    MobileBarcodeScanner.Initialize(Application);
                    var MScanner = new MobileBarcodeScanner();
                    var Result = await MScanner.Scan();
                    isbn = Result.ToString();

                    Search.Text = isbn;
                    SearchButton.PerformClick();
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong with ISBN scanner in W_Library.cs");

                }
            };

             //sort
             Sort.Click += (sender, e) =>
            {
                //sort it by title
                Book.sortList.Sort();

                //display
                List<string> toDisplay = new List<string>();
                foreach (Book currentBook in Book.sortList)
                {
                    string genres = string.Join(" ", currentBook.genres);
                    string infoToDisplay = currentBook.title + " --- "
                                         + currentBook.author + " --- " + genres + " --- "
                                         + currentBook.quantity;
                    toDisplay.Add(infoToDisplay);
                }
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewMain.Adapter = adapter;
            };

            //on selecting a book
            ListViewMain.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                //get selected? does it actually??
                string selectedT = Convert.ToString(ListViewMain.GetItemAtPosition(e.Position));

                if (selectedT == null)
                {
                    Toast.MakeText(ApplicationContext, "Please select a book to view", ToastLength.Long).Show();
                    return;
                }

                //LINQ gets all info about selected book
                var aboutBook = from book in Book.bookList
                                where selectedT.Contains(book.ISBN + " --- " + book.title) ||
                                      selectedT.Contains(book.title + " --- " + book.author)
                                select book;
                
                foreach (var book in aboutBook)
                {
                    bookToPass = book;
                }

                //to new form
                Intent System = new Intent(this, typeof(W_AboutBook));
                this.StartActivity(System);
            };

            //account
            AccButton.Click += (sender, e) =>
            {
                //to new form
                Intent Acc = new Intent(this, typeof(W_Account));
                this.StartActivity(Acc);
            };


            if (ToSystem != null)
            {
                ToSystem.Click += (sender, e) =>
                {
                //to new form
                Intent System = new Intent(this, typeof(W_LibSys));
                    this.StartActivity(System);
                };
            }


        }
    }
}