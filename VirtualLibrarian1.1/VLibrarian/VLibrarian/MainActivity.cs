using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Database.Sqlite;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using SQLite;
using System.IO;

namespace VLibrarian
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {
        public static SQLiteConnection conn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AssetManager asset = this.Assets;
            Database db = new Database(asset);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //= = = = = OUR CODE = = = = = = = = = = = = = = = = = = = = = = 

            // Get our UI controls from the loaded layout
            EditText UsernameText = FindViewById<EditText>(Resource.Id.EditText1);
            EditText PasswordText = FindViewById<EditText>(Resource.Id.EditText2);
            Button LoginButton = FindViewById<Button>(Resource.Id.button);
            Button SignupButton = FindViewById<Button>(Resource.Id.button2);


    
            //1. code after pressing LOGIN
            LoginButton.Click += (sender, e) =>
                {
                    //check if empty
                    if (string.IsNullOrWhiteSpace(UsernameText.Text) || string.IsNullOrWhiteSpace(PasswordText.Text))
                    { return; }

                    //do the function
                    //string result = Login_or_Signup.login(UsernameText.Text, PasswordText.Text);
                    //call the method using the delegate object
                    string result = Login_or_Signup.runAdelegate(Login_or_Signup.check, UsernameText.Text, PasswordText.Text);

                    //Toast.MakeText(ApplicationContext, result, ToastLength.Long).Show();

                    //check if login info. correct
                    if (result == "correct" && Login_or_Signup.user != null)
                    {
                        //if all input ok, goto new window
                        Intent Lib = new Intent(this, typeof(Library));
                        this.StartActivity(Lib);

                    }
                    else if (result == "Incorrect password")
                    {
                        Toast.MakeText(ApplicationContext, "Incorrect password", ToastLength.Long).Show();
                        return;
                    }
                    else if (result == "User with this username doesn't exist")
                    {
                        Toast.MakeText(ApplicationContext, "User with this username doesn't exist", ToastLength.Long).Show();
                        return;
                    }
                    else
                    {
                        Toast.MakeText(ApplicationContext, "Something's wrong in the database", ToastLength.Long).Show();
                        return;
                    }
                };


            //2. code after pressing SIGNUP
            SignupButton.Click += (sender, e) =>
            {
                //to new form
                Intent Sign = new Intent(this, typeof(W_Signup));
                this.StartActivity(Sign);
            };


        }
    }
}