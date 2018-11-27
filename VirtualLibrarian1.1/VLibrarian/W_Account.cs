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
        //==== define this before going to this window ===============
        public static User passedUser;
        //============================================================

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_AccountSet);


            TextView Username = FindViewById<TextView>(Resource.Id.textViewUsername);
            TextView Password = FindViewById<TextView>(Resource.Id.textViewPass);
            TextView Name = FindViewById<TextView>(Resource.Id.textViewName);
            TextView Surname = FindViewById<TextView>(Resource.Id.textViewSurname);
            TextView Email = FindViewById<TextView>(Resource.Id.textViewEmail);
            TextView Birth = FindViewById<TextView>(Resource.Id.textViewBirth);


            Username.Text = Login_or_Signup.user.username;
            Password.Text = Login_or_Signup.user.password;
            Name.Text = Login_or_Signup.user.name;
            Surname.Text = Login_or_Signup.user.surname;
            Email.Text = Login_or_Signup.user.email;
            Birth.Text = Login_or_Signup.user.birth;

            Button Save = FindViewById<Button>(Resource.Id.buttonSave);
            Button Delete = FindViewById<Button>(Resource.Id.buttonDelAcc);
            ListView ListViewTaken = FindViewById<ListView>(Resource.Id.listViewTakenBooks);

            //display taken books
            List<String> toDisplay = Library.selectTakenBooks(Login_or_Signup.user.username);
            ArrayAdapter<String> adapter = new ArrayAdapter<String>
                    (this, Android.Resource.Layout.SimpleListItem1, toDisplay);
            ListViewTaken.Adapter = adapter;



            //1. Save
            Save.Click += (sender, e) =>
            {
                //check if valid email w regex
                if (Login_or_Signup.inputCheck(Email.Text, 1) == 0)
                {
                    Toast.MakeText(ApplicationContext, "Please enter a valid email (ex.:email@gmail.com)", ToastLength.Long).Show();
                    return;
                }
                //check if date the right format
                if (Login_or_Signup.inputCheck(Birth.Text, 2) == 0)
                {
                    Toast.MakeText(ApplicationContext, "Incorrect date of birth format (ex.: 1989.11.05 or 1989-11-05)", ToastLength.Long).Show();
                    return;
                }

                //take new info.
                Username = FindViewById<TextView>(Resource.Id.textViewUsername);
                Password = FindViewById<TextView>(Resource.Id.textViewPass);
                Name = FindViewById<TextView>(Resource.Id.textViewName);
                Surname = FindViewById<TextView>(Resource.Id.textViewSurname);
                Email = FindViewById<TextView>(Resource.Id.textViewEmail);
                Birth = FindViewById<TextView>(Resource.Id.textViewBirth);

                //change current user object
                Login_or_Signup.user.username = Username.Text;
                Login_or_Signup.user.password = Password.Text;
                Login_or_Signup.user.name = Name.Text;
                Login_or_Signup.user.surname = Surname.Text;
                Login_or_Signup.user.email = Email.Text;
                Login_or_Signup.user.birth = Birth.Text;

                //update database
                Library.updateReaderInfo(Login_or_Signup.user);

                Toast.MakeText(ApplicationContext, "Changes saved", ToastLength.Long).Show();

            };

            //2. Delete
            Save.Click += (sender, e) =>
            {
                Library.deleteReaderInfo(Login_or_Signup.user);
            };


        }
    }
}