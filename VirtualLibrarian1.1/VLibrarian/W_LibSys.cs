using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VLibrarian
{
    [Activity(Label = "W_LibSys")]
    public class W_LibSys : Activity
    {
        //for displaying info
        // List<string> toDisplay;
        //ArrayAdapter<String> adapter;

        //for selecting book/account/takenBook
        string whatToSelect = "";        //book/user
        public static Book bookToPass = null;
        public static User userToPass = null;
        public static Taken takenBtoPass = null;


        User tempSave = null;


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
            Button TakenBooks = FindViewById<Button>(Resource.Id.buttonlTaken);
            Button ReturnBook = FindViewById<Button>(Resource.Id.buttonReturn);

            ListView ListViewBooks = FindViewById<ListView>(Resource.Id.listViewBooks);


            //1. Display Library books
            Books.Click += (sender, e) =>
            {
                whatToSelect = "book";
                bookToPass = null;
                // userToPass = null;

                //List<string>  toDisplay = new List<string>();
                //foreach (Book tempBook in Book.bookList)
                //{
                //    string match = tempBook.ObToString(tempBook);
                //    toDisplay.Add(match);
                //}
                //ArrayAdapter<String>  adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                //ListViewBooks.Adapter = adapter;

                List<string> toDisplay = new List<string>();
                //checks all the books in the bookList
                foreach (Book tempBook in Book.bookList)
                {
                    //run delegate method
                    string match = Controller_linker.runSearch(Library.searchB, "", tempBook);
                    toDisplay.Add(match);
                }
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewBooks.Adapter = adapter;
            };

            //5. Display accounts
            Accounts.Click += (sender, e) =>
            {
                whatToSelect = "user";
                //bookToPass = null;
                userToPass = null;

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
            //if selecting a BOOK
            ListViewBooks.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                if (whatToSelect == "book")
                {
                    //get selected
                    string selectedTitle = Book.bookList[e.Position].title;

                    //LINQ gets all info about selected book
                    var aboutBook = from book in Book.bookList
                                    where selectedTitle == book.title
                                    select book;
                    foreach (var book in aboutBook)
                    { bookToPass = book; }

                    Toast.MakeText(ApplicationContext, "You selected: " + bookToPass.title, ToastLength.Short).Show();
                }

                if (whatToSelect == "user")
                {
                    //get selected
                    string selectedUsername = User.readerList[e.Position].username;

                    //LINQ gets all info about selected user
                    var aboutUser = from user in User.readerList
                                    where selectedUsername == user.username
                                    select user;
                    foreach (var user in aboutUser)
                    { userToPass = user; }

                    Toast.MakeText(ApplicationContext, "You selected: " + userToPass.username, ToastLength.Short).Show();
                }

                if(whatToSelect == "takenBook")
                {
                    //get selected
                    string selectedTaken = Taken.allTaken[e.Position].ISBN;
                    string selectedTaken2 = Taken.allTaken[e.Position].Username;

                    //LINQ gets all info about selected user
                    var aboutTaken = from taken in Taken.allTaken
                                    where selectedTaken == taken.ISBN
                                    where selectedTaken2 == taken.Username
                                    select taken;
                    foreach (var taken in aboutTaken)
                    { takenBtoPass = taken; }

                    Toast.MakeText(ApplicationContext, "You selected: " + takenBtoPass.ISBN, ToastLength.Short).Show();

                }
            };



            //2. Add Book
            buttonAdd.Click += (sender, e) =>
            {
                //to new form
                Intent Adding = new Intent(this, typeof(W_NewBook));
                this.StartActivity(Adding);
            };
            //3. Edit Book
            buttonEdit.Click += (sender, e) =>
            {
                if (bookToPass == null && whatToSelect != "book")
                {
                    Toast.MakeText(ApplicationContext, "Please select a book to edit", ToastLength.Short).Show();
                    return;
                }
                //pass selected book
                W_EditBook.passedBook = bookToPass;

                Intent Editing = new Intent(this, typeof(W_EditBook));
                this.StartActivity(Editing);
            };
            //4. Delete book
            buttonDel.Click += (sender, e) =>
            {
                if (bookToPass == null && whatToSelect != "book")
                {
                    Toast.MakeText(ApplicationContext, "Please select a book to delete", ToastLength.Short).Show();
                    return;
                }

                //check if user really wants to delete
                var builder = new AlertDialog.Builder(this);
                builder.SetTitle("Confirmation");
                builder.SetMessage("Are you sure you want to delete " + bookToPass.title + " ?");
                builder.SetPositiveButton("Yes", (send, args) =>
                {
                    //delete on confirmation
                    Controller_linker.runBookUpdate(LibrarySystem.delBook, bookToPass);
                });
                builder.SetNegativeButton("No", (send, args) => { return; });
                builder.SetCancelable(false);
                builder.Show();
            };




            //8. change acc info.
            ChangeAccInfo.Click += (sender, e) =>
            {
                if (userToPass == null)
                {
                    Toast.MakeText(ApplicationContext, "Please select an account to edit", ToastLength.Short).Show();
                    return;
                }

                //pass selected user
                W_Account.passedUser = userToPass;
                //go as an employee
                W_Account.employee = true;

                //to new form
                Intent Acc = new Intent(this, typeof(W_Account));
                this.StartActivity(Acc);
            };



            //6. give a book
            GiveBook.Click += (sender, e) =>
            {
                //select an account => userToPass
                if (userToPass == null)
                {
                    Toast.MakeText(ApplicationContext, "Please select an account", ToastLength.Short).Show();
                    return;
                }

                //afterwards a book needs to be selected => bookToPass
                if (bookToPass == null)
                {
                    tempSave = userToPass;

                    List<string> toDisplay = new List<string>();
                    //checks all the books in the bookList
                    foreach (Book tempBook in Book.bookList)
                    {
                        //run delegate method
                        string match = Controller_linker.runSearch(Library.searchB, "", tempBook);
                        toDisplay.Add(match);
                    }
                    ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                    ListViewBooks.Adapter = adapter;

                    whatToSelect = "book";

                    Toast.MakeText(ApplicationContext, "Please select a book to give to " + userToPass.username, ToastLength.Short).Show();
                    return;
                }

                //check quantity
                if (bookToPass.quantity == 0)
                {
                    Toast.MakeText(ApplicationContext, "All books taken", ToastLength.Short).Show();
                    return;
                }
                bookToPass.quantity = bookToPass.quantity - 1;

                try
                {//ALL GOOD -> WRITE NEEDED INFO. INTO TABLES: Taken, Books
                    Controller_linker.runGiveBook(LibrarySystem.giving, tempSave, bookToPass);
                }
                catch (Exception ex)
                { //Toast.MakeText(ApplicationContext, ex.Message, ToastLength.Long).Show(); 
                }

                Toast.MakeText(ApplicationContext, "Book " + bookToPass.title + " given to " + userToPass.username, ToastLength.Short).Show();
                bookToPass = null;
                userToPass = null;
            };

            //7. return book
            ReturnBook.Click += (sender, e) =>
            {
                //select an account
                if (userToPass == null)
                {
                    Toast.MakeText(ApplicationContext, "Please select an account", ToastLength.Short).Show();
                    return;
                }

                if (takenBtoPass == null)
                {
                    tempSave = userToPass;

                    //display user's taken books and get what book is being returned
                    List<String> toDisplay = Controller_linker.runSelectTaken(Library.getTaken, userToPass.username);
                    ArrayAdapter<String> adapter = new ArrayAdapter<String>
                            (this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                    ListViewBooks.Adapter = adapter;

                    whatToSelect = "takenBook";

                    Toast.MakeText(ApplicationContext, "Please select a book to return", ToastLength.Short).Show();
                    return;
                }

                try
                {
                    //delete in Taken and add quantity in Books
                    Controller_linker.runReturnBook(LibrarySystem.returning, bookToPass, takenBtoPass);
                }
                catch(Exception ) { }

                Toast.MakeText(ApplicationContext, "Book " + takenBtoPass.ISBN + " returned by " + userToPass.username, ToastLength.Short).Show();
                takenBtoPass = null;
                userToPass = null;
            };


            //all taken books
            TakenBooks.Click += (sender, e) =>
            {
                //get all taken books
                List<String> toDisplay = Library.selectAllTakenBooks();
                

                //display
                ArrayAdapter<String> adapter = new ArrayAdapter<String>
                        (this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                ListViewBooks.Adapter = adapter;
                //adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, toDisplay);
                //ListViewBooks.Adapter = adapter;
            };

        }
    }
}