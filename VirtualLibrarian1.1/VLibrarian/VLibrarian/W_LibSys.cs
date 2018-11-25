using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using static Android.Widget.AdapterView;

namespace VLibrarian
{
    [Activity(Label = "W_LibSys")]
    public class W_LibSys : Activity
    {
        bool AccountsSelected = false;
        public static string selectedBook = null;
        public static string selectedAccount = null;

        public static Book bookToPass = null;
        public static User userToPass = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_LibSystem);

            Button Books = FindViewById<Button>(Resource.Id.buttonLibBooks);
            Button Accounts = FindViewById<Button>(Resource.Id.buttonAccounts);

            Button buttonAdd = FindViewById<Button>(Resource.Id.buttonAdd);
            Button buttonEdit = FindViewById<Button>(Resource.Id.buttonEdit);
            Button buttonDel = FindViewById<Button>(Resource.Id.buttonDel);

            Button ChangeAccInfo = FindViewById<Button>(Resource.Id.buttonChangeAcc);

            Button GiveBook = FindViewById<Button>(Resource.Id.buttonGive);
            Button ReturnBook = FindViewById<Button>(Resource.Id.buttonReturn);
            
            ListView ListViewBooks = FindViewById<ListView>(Resource.Id.listViewBooks);


            //1. Display Library books
            Books.Click += (sender, e) =>
            {
                AccountsSelected = false;
                selectedAccount = null;

                List<string> toDisplay = new List<string>();
                foreach (Book tempBook in Book.bookList)
                {
                    string match = tempBook.ObToString(tempBook);
                    toDisplay.Add(match);
                }
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewBooks.Adapter = adapter;
            };

            //5. Display accounts
            Accounts.Click += (sender, e) =>
            {
                AccountsSelected = true;
                selectedBook = null;

                List<string> toDisplay = new List<string>();
                foreach (User user in User.readerList)
                {
                    string match = user.ObToString(user);
                    toDisplay.Add(match);
                }
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewBooks.Adapter = adapter;
            };

            //ON SELECTING something - save it
            ListViewBooks.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                //get selected? does it actually??
                string select = Convert.ToString(ListViewBooks.GetItemAtPosition(e.Position));

                //selected a book OR account?
                if (AccountsSelected == false)
                    selectedBook = select;
                else
                    selectedAccount = select;
            };


            //2. NewBook
            buttonAdd.Click += (sender, e) =>
            {
                //to new form
                Intent Adding = new Intent(this, typeof(W_NewBook));
                this.StartActivity(Adding);
            };
            //3. EditBook
            buttonEdit.Click += (sender, e) =>
            {
                Intent Editing = new Intent(this, typeof(W_EditBook));
                this.StartActivity(Editing);
            };

            //4. Delete book
            buttonDel.Click += (sender, e) =>
            {
                if (selectedBook == null)
                {
                    Toast.MakeText(ApplicationContext, "Please select a book to delete", ToastLength.Long).Show();
                    return;
                }
                //LINQ gets all info about selected book
                var aboutBook = from book in Book.bookList
                                where selectedBook.Contains(book.ISBN + " --- " + book.title) ||
                                      selectedBook.Contains(book.title + " --- " + book.author)
                                select book;
                foreach (var book in aboutBook)
                {
                    bookToPass = book;
                }

                //check if user really wants to delete
                var builder = new AlertDialog.Builder(this);
                builder.SetTitle("Confirmation");
                builder.SetMessage("Are you sure you want to delete " + bookToPass.title + " ?");
                builder.SetPositiveButton("Yes", (send, args) =>
                {
                    //delete on confirmation
                    LibrarySystem.deleteBookInfo(bookToPass);
                });
                builder.SetNegativeButton("No", (send, args) => { return; });
                builder.SetCancelable(false);
                builder.Show();

            };


            //8. change acc
            ChangeAccInfo.Click += (sender, e) =>
            {
                if (selectedAccount == null)
                {
                    Toast.MakeText(ApplicationContext, "Please select an account to edit", ToastLength.Long).Show();
                    return;
                }
                //LINQ gets all info about selected user
                var aboutUser = from user in User.readerList
                                where selectedAccount.Contains(user.username + " --- " + user.password)
                                select user;
                foreach (var user in aboutUser)
                {
                    userToPass = user;
                }

                //define user to pass
                W_Account.passedUser = userToPass;
                //to new form
                Intent Acc = new Intent(this, typeof(W_Account));
                this.StartActivity(Acc);
            };

            //give a book
            GiveBook.Click += (sender, e) =>
            {
                //select an account
                if (selectedAccount == null)
                {Toast.MakeText(ApplicationContext, "Please select an account", ToastLength.Long).Show();
                    return;}
                //LINQ gets all info about selected user
                var aboutUser = from user in User.readerList
                                where selectedAccount.Contains(user.username + " --- " + user.password)
                                select user;
                foreach (var user in aboutUser)
                { userToPass = user; }

                AccountsSelected = true;
                selectedBook = null;

                //display books to choose from
                List<string> toDisplay = new List<string>();
                foreach (Book tempBook in Book.bookList)
                { string match = tempBook.ObToString(tempBook);
                    toDisplay.Add(match);  }
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewBooks.Adapter = adapter;

                //select a book
                if (selectedBook == null)
                { Toast.MakeText(ApplicationContext, "Please select a book to give", ToastLength.Long).Show();
                    return;
                }
                //LINQ gets all info about selected book
                var aboutBook = from book in Book.bookList
                                where selectedBook.Contains(book.ISBN + " --- " + book.title) ||
                                      selectedBook.Contains(book.title + " --- " + book.author)
                                select book;
                foreach (var book in aboutBook)
                { bookToPass = book; }

                if (bookToPass.quantity == 0)
                {Toast.MakeText(ApplicationContext, "All books taken", ToastLength.Long).Show();
                    return;
                }
                bookToPass.quantity = bookToPass.quantity - 1;

                //ALL GOOD -> WRITE NEEDED INFO. INTO TABLES: Taken, Books
                LibrarySystem.takeORGiveBook(userToPass, bookToPass);

            };
        }
    }
}