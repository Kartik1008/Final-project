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
    class Motorbike : Vehicle
    {
        private bool? sidecar;

        public bool? Sidecar { get => sidecar; set => sidecar = value; }

        public Motorbike(string category, bool? sidecar, string model, string plate, string color)
        {
            this.Category = category;
            this.Sidecar = sidecar;
            this.Model = model;
            this.Plate = plate;
            this.Color = color;
        }

        public override string ToString()
        {
            string profile = null;

            if (Sidecar == true)
            {
                profile = "Employee has a " + Category + "\n - Model: " + Model + "\n - Plate: " + Plate + "\n - Color: " + Color + "\n - With a side car";
            }
            else if (Sidecar == false)
            {
                profile = "Employee has a " + Category + "\n - Model: " + Model + "\n - Plate: " + Plate + "\n - Color: " + Color + "\n - Without a side car";
            }

            return profile;
        }

    }
}