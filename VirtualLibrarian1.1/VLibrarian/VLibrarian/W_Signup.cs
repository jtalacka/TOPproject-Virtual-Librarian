using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace VLibrarian
{
    [Activity(Label = "W_Signup")]
    public class W_Signup : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_Signup);

            EditText Username = FindViewById<EditText>(Resource.Id.EditTextUser);
            EditText Pass = FindViewById<EditText>(Resource.Id.EditTextPass);
            EditText Name = FindViewById<EditText>(Resource.Id.EditTextName);
            EditText Surname = FindViewById<EditText>(Resource.Id.EditTextSurname);
            EditText Email = FindViewById<EditText>(Resource.Id.EditTextEmail);
            EditText Birth = FindViewById<EditText>(Resource.Id.EditTextBirth);
            Button SignupButton = FindViewById<Button>(Resource.Id.buttonSign);
            Button Ex = FindViewById<Button>(Resource.Id.buttonEx);


            //signup
            SignupButton.Click += (sender, e) =>
            {
                //check if any textbox's empty
                if (TextUtils.IsEmpty(Username.ToString()) ||
                    TextUtils.IsEmpty(Pass.ToString()) ||
                    TextUtils.IsEmpty(Name.ToString()) ||
                    TextUtils.IsEmpty(Surname.ToString()) ||
                    TextUtils.IsEmpty(Email.ToString()) ||
                    TextUtils.IsEmpty(Birth.ToString()))
                {
                    Toast.MakeText(ApplicationContext, "Please, fill in all the fields", ToastLength.Long).Show();
                    return;
                }

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

                //check if username already exists in db table Users
                //bool exists = Login_or_Signup.checkIfExistsInDBUsers(Username.Text);
                bool exists = Login_or_Signup.runAdelegate(Login_or_Signup.check2, Username.Text);

                //if username unique - add user info. to db
                if (exists == false)
                {
                    string result = Login_or_Signup.runAdelegate3(Login_or_Signup.check3,
                                    Username.Text, Pass.Text, Name.Text, Surname.Text, Birth.Text, Email.Text);

                    if (result == "new reader added")
                    {
                        //to new form
                        Intent Library = new Intent(this, typeof(W_Library));
                        this.StartActivity(Library);
                    }
                }
                else
                {
                    Toast.MakeText(ApplicationContext, "Username already exists. Please choose a different one", ToastLength.Long).Show();
                    return;
                }

            };


            //exit
            Ex.Click += (sender, e) =>
            {
                //to new form
                Intent main = new Intent(this, typeof(MainActivity));
                this.StartActivity(main);
            };


        }
    }
}