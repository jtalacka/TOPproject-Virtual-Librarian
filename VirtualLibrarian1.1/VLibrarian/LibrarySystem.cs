using System;
namespace VLibrarian
{
    //
    // checkIfExistsInDBBooks

    // addBook
    // editBook
    // deleteBook

    // takeORGiveBook
    // returnBook
    //


    public class LibrarySystem
    {
        //check if ISBN exists in db Books, before adding a new one
        public static bool checkIfExistsInDBBooks(string whatToLookFor)
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
        public static void AddBook(Book book)
        {
            Database.conn.Insert(book);
        }

        //edit book
        public static void editBook(Book book)
        {
            Database.conn.Update(book);
        }

        //delete book
        public static void deleteBookInfo(Book book)
        {
            Database.conn.Delete(book);
        }



        //When a book is being taken/given - 
        //WRITE NEW INFO. INTO TABLES: Taken, Books
        public static void takeORGiveBook(User user, Book book)
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
        public static void returnBook(Book book, Taken taken)
        {
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