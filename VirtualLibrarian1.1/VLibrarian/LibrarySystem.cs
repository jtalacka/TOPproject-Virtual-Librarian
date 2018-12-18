using System;
namespace VLibrarian
{
    //
    // checkIfExistsInDBBooks

    // addBook
    // editBook
    // deleteBook

    // giveBook
    // returnBook
    //

    public class LibrarySystem : I_InLibSystem
    {
        //interface object
        static I_InLibSystem LibSys = new LibrarySystem();

        public static Controller_linker.ch checkIfExists = LibSys.checkIfExistsInDBBooks;
        public static Controller_linker.bookChange newBook = LibSys.addBook;
        public static Controller_linker.bookChange edBook = LibSys.editBook;
        public static Controller_linker.bookChange delBook = LibSys.deleteBook;
        public static Controller_linker.givB giving = LibSys.giveBook;
        public static Controller_linker.retB returning = LibSys.returnBook;



        //check if ISBN exists in db Books, before adding a new one
        public bool checkIfExistsInDBBooks(string whatToLookFor)
        {
            bool ExistsResult = false;

            var table = Database.conn.Table<Book>();
            foreach (var line in table)
            {
                if (line.ISBN == whatToLookFor)
                {
                    ExistsResult = true;
                    return ExistsResult;
                }
            }
            return ExistsResult;
        }

        //add new book
        public void addBook(Book book)
        {
            Database.conn.Insert(book);
        }

        //edit book
        public void editBook(Book book)
        {
            Database.conn.Update(book);
        }

        //delete book
        public void deleteBook(Book book)
        {
            Database.conn.Delete(book);
        }



        //When a book is being taken/given - 
        //WRITE NEW INFO. INTO TABLES: Taken, Books
        public void giveBook(User user, Book book)
        {
            //form date when taken
            string dateTaken = DateTime.Now.ToShortDateString();
            //form return date
            var dateReturn = DateTime.Now.AddMonths(1).ToShortDateString();

            //form Taken object
            Taken takenBook = new Taken(book.ISBN, user.username, dateTaken, dateReturn);
            //track all taken books in table Taken
            Database.conn.Insert(takenBook);

            //edit book quantity
            Database.conn.Update(book);
        }


        //When a book is being returned - 
        //WRITE NEW INFO. INTO TABLES: Taken, Books
        public void returnBook(Book book, Taken taken)
        {
            //get taken object
            var table = Database.conn.Table<Taken>();
            foreach (var line in table)
            {
                if (line.ISBN == taken.ISBN && line.Username == taken.Username)
                {
                    taken.DateTaken = line.DateTaken;
                    taken.DateReturn = line.DateReturn;
                }
            }
            //delete in Taken
            Database.conn.Delete(taken);


            //change (add) quantity in Books
            //get current quantity in list
            int quo = 0;
            //checks all the books in the list bookList
            foreach (Book tempBook in Book.bookList)
            {
                if (tempBook.ISBN == book.ISBN && tempBook.title == book.title)
                {
                    quo = tempBook.quantity;
                    break;
                }
            }
            book.quantity = quo + 1;

            //change quantity in table
            Database.conn.Update(book);
        }


    }
}