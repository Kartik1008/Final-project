using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace FinalProject
{
    [Activity(Label = "EmployeeProfile")]
    public class EmployeeProfile : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.results);
            TextView profile = FindViewById<TextView>(Resource.Id.tvResult);
            int position = Intent.GetIntExtra("Position", -1);
            Employee.Employees.ElementAt(position).List = false;
            profile.Text = Employee.Employees.ElementAt(position).ToString();

        }

    }
}