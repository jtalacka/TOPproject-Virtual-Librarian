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
    [Activity(Label = "W_Account")]
    public class W_Account : Activity
    {
        //==== define these before going to this window ===============
        public static User passedUser;
        public static bool employee = false;
        //============================================================


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_AccountSet);

            EditText Username = FindViewById<EditText>(Resource.Id.textEditUsername);
            EditText Password = FindViewById<EditText>(Resource.Id.textEditPass);
            EditText Name = FindViewById<EditText>(Resource.Id.textEditName);
            EditText Surname = FindViewById<EditText>(Resource.Id.textEditSurname);
            EditText Email = FindViewById<EditText>(Resource.Id.textEditEmail);
            EditText Birth = FindViewById<EditText>(Resource.Id.textEditBirth);

            //display info of the passed user
            Username.Text = passedUser.username;
            Password.Text = passedUser.password;
            Name.Text = passedUser.name;
            Surname.Text = passedUser.surname;
            Email.Text = passedUser.email;
            Birth.Text = passedUser.birth;

            Button Save = FindViewById<Button>(Resource.Id.buttonSave);
            Button Delete = FindViewById<Button>(Resource.Id.buttonDelAcc);
            ListView ListViewTaken = FindViewById<ListView>(Resource.Id.listViewTakenBooks);

            //display taken books
            List<String> toDisplay = Controller_linker.runSelectTaken(Library.getTaken, passedUser.username);

            ArrayAdapter<String> adapter = new ArrayAdapter<String>
                    (this, Android.Resource.Layout.SimpleListItem1, toDisplay);
            ListViewTaken.Adapter = adapter;


            //1. Save changes
            Save.Click += (sender, e) =>
            {
                //take new info.
                Username = FindViewById<EditText>(Resource.Id.textEditUsername);
                Password = FindViewById<EditText>(Resource.Id.textEditPass);
                Name = FindViewById<EditText>(Resource.Id.textEditName);
                Surname = FindViewById<EditText>(Resource.Id.textEditSurname);
                Email = FindViewById<EditText>(Resource.Id.textEditEmail);
                Birth = FindViewById<EditText>(Resource.Id.textEditBirth);

                //check if valid email
                if (Controller_linker.runAnInputdelegate(Login_or_Signup.inputC, Email.Text, 1) == 0)
                {
                    Toast.MakeText(ApplicationContext, "Please enter a valid email (ex.:email@gmail.com)", ToastLength.Long).Show();
                    return;
                }
                //check if date the right format
                if (Controller_linker.runAnInputdelegate(Login_or_Signup.inputC, Birth.Text, 2) == 0)
                {
                    Toast.MakeText(ApplicationContext, "Incorrect date of birth format (ex.: 1989.11.05 or 1989-11-05)", ToastLength.Long).Show();
                    return;
                }

                //change passed user object
                passedUser.username = Username.Text;
                passedUser.password = Password.Text;
                passedUser.name = Name.Text;
                passedUser.surname = Surname.Text;
                passedUser.email = Email.Text;
                passedUser.birth = Birth.Text;


                //if this window accessed by a reader, not employee
                if(employee == false)
                {
                    //change current user information
                    Login_or_Signup.user = passedUser;
                }


                //update database
                Controller_linker.runUpdate(Library.update, passedUser);
                Toast.MakeText(ApplicationContext, "Changes saved", ToastLength.Long).Show();

            };

            //2. Delete
            Save.Click += (sender, e) =>
            {
                Controller_linker.runUpdate(Library.delete, passedUser);
            };


        }
    }
}