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
    class Car : Vehicle
    {
        private string carType;

        public string CarType { get => carType; set => carType = value; }

        public Car(string category, string carType, string model, string plate, string color)
        {
            this.Category = category;
            this.CarType = carType;
            this.Model = model;
            this.Plate = plate;
            this.Color = color;
        }

        public override string ToString()
        {
            return "Employee has a " + Category + "\n - Model: " + Model + "\n - Plate: " + Plate +
                    "\n - Color: " + Color + "\n - Type: " + CarType;
        }

    }
}