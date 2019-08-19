using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace FinalProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ArrayAdapter var_adapter;
        SearchView var_search;
        ListView var_list;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);



            Button addButton = FindViewById<Button>(Resource.Id.button1);

            addButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(RegistrationForm));
                StartActivity(intent);
            };

            var_search = FindViewById<SearchView>(Resource.Id.searchView1);
            var_search.QueryTextChange += (s, e) =>
            {
                var_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Employee.Employees);
                var_list.Adapter = var_adapter;
                var_adapter.Filter.InvokeFilter(e.NewText);
            };

            var_list = FindViewById<ListView>(Resource.Id.listView1);
            var_list.ItemClick += (s, e) =>
            {
                string textId = var_adapter.GetItem(e.Position).ToString();

                textId = textId.Substring(textId.IndexOf("\n") + 5);
                int position = Employee.Ids.IndexOf(textId);

                Intent intent = new Intent(this, typeof(EmployeeProfile));
                intent.PutExtra("Position", position);
                StartActivity(intent);
            };




        }

        protected override void OnRestart()
        {
            base.OnRestart();
            var_search.SetQuery("", false);
            var_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Employee.Employees);
            var_list.Adapter = var_adapter;
        }
    }
}