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
    public class Controller_linker
    {

        //1. Delegates for Login_or_Signup

        //LOGIN (used in MainActivity)
        //define delegate that will point to L_or_S.login
        public delegate string del(string N, string P);
        public static string runAdelegate(Controller_linker.del d, string n, string p)
        { return d(n, p); }

        //CHECK BEFORE SIGNUP (used in W_Signup)
        //define a delegate
        public delegate bool del2(string w);
        public static bool runAdelegate(Controller_linker.del2 d, string w)
        { return d(w); }


        //SIGNUP (used in W_Signup)
        //define a placeholder delegate
        public delegate T del3<T>(T u, T p, T n, T s, T b, T e);
        public static string runAdelegate3(Controller_linker.del3<string> d, string u, string p, string n, string s, string b, string e)
        { return d(u, p, n, s, b, e); }


        //INPUT VALIDATION (used in W_Signup / W_NewBook)
        public delegate int delIN(string what, int c);
        public static int runAnInputdelegate(Controller_linker.delIN d, string what, int c)
        { return d(what, c); }




        //2. Delegates for Library = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        //LOAD BOOKS
        public delegate void load();
        public static void runLoad(load d)
        {
            d();
        }

        //SEARCH
        public delegate string s(string what, Book book);
        public static string runSearch(s d, string what, Book book)
        {
            return d(what, book);
        }


        //UPADATE / DELETE READER
        public delegate void readerUpdate(User user);
        public static void runUpdate(readerUpdate d, User user)
        {
            d(user);
        }

        //TAKEN BOOKS
        //define delegate that will point to Lib.selectTakenBooks
        public delegate List<String> selectTaken(string U);
        public static List<String> runSelectTaken(selectTaken d, string u)
        {
            return d(u);
        }




        //3. Delegates for LibrarySystem = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        //CHECK BEFORE ADDING NEW BOOK
        public delegate bool ch(string what);
        public static bool runABookcheck(ch d, string what)
        {
            return d(what);
        }

        //ADD / EDIT / DELETE BOOK
        public delegate void bookChange(Book book);
        public static void runBookUpdate(bookChange d, Book book)
        {
            d(book);
        }

        //GIVE BOOK
        public delegate void givB(User user, Book book);
        public static void runGiveBook(givB d, User u, Book b)
        {
            d(u, b);
        }
        //RETURN BOOK
        public delegate void retB(Book book, Taken taken);
        public static void runReturnBook(retB d, Book b, Taken t)
        {
            d(b, t);
        }
    }
}