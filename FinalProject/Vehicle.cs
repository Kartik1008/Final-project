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

namespace FinalProject
{
    class Vehicle
    {
        private string category;
        private string model;
        private string plate;
        private string color;

        public string Category { get => category; set => category = value; }
        public string Model { get => model; set => model = value; }
        public string Plate { get => plate; set => plate = value; }
        public string Color { get => color; set => color = value; }


    }
}