using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace W
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        static List<string> items = new List<string>();
        //string[] items;

        static ListView mainList;

        static int clickCounter = 0;

        //ArrayAdapter adapter;        
        //private ListView mListView;


        protected override void OnCreate(Bundle savedInstanceState)
        {



            /*
            items = new string[] {
            "Xamarin",
            "Android",
            "IOS",
            "Windows",
            "Xamarin-Native",
            "Xamarin-Forms",
            "Xamarin",
            "Android",
            "IOS",
            "Windows",
            "Xamarin-Native",
            "Xamarin-Forms",
            "Xamarin",
            "Android",
            "IOS",
            "Windows",
            "Xamarin-Native",
            "Xamarin-Forms"
            };
            */



            base.OnCreate(savedInstanceState);   //in java this is super.OnCreate instead of base.OnCreate
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            mainList = FindViewById<ListView>(Resource.Id.mainlistview);
            mainList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, items);

            


            mainList.ItemClick += (s, e) => {
                var t = items[e.Position];
                Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Long).Show();
            };




            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);  //so older verisons of andriod have a toolbar which is the same as the new and nowadays used actionbar and this is just trying to support older versions and newer ones at the same time
            SetSupportActionBar(toolbar);

            //adapter = new ArrayAdapter<string>(this, Resource.Layout.contacts, listItems);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab); //this is subscribing and adding the blue mail button that I will most likely delete or move
            fab.Click += FabOnClick;

            Button addbutton = FindViewById<Button>(Resource.Id.addBtn);
            addbutton.Click += Addbutton_Click;

        }

        




        private void Addbutton_Click(object sender, EventArgs e)
        {
            
            items.Add("bruh :" + clickCounter++);
            mainList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, items);
            
        }
        



        /*
        public void addItems(View v)
        {
            listItems.Add("Clicked :" + clickCounter++);
            adapter.NotifyDataSetChanged();
        }
        */

        //private void addButtonOnClick(object sender, EventArgs eventArgs) { }



        public override bool OnCreateOptionsMenu(IMenu menu)     //  is just the 3 dots
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)   //eventhandler for 3 dots
        {
            int id = item.ItemId;   //whatever the user clicks on is stored
            if (id == Resource.Id.action_settings)     //settings button clicked
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {

            Android.Content.Intent myIntent = new Intent(this, typeof(conversation));

            StartActivity(myIntent);


            /*
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)        //shows an alert message at the bottom of the screen, could be useful for when something does not work and need to notify user      
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            */
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
