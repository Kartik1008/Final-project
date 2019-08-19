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
    [Activity(Label = "RegistrationForm")]
    public class RegistrationForm : Activity
    {

        RadioButton carRadioButton;
        RadioButton motorbikeRadioButton;
        RadioButton yesRadioButton;
        RadioButton noRadioButton;
        EditText txtCarType;
        EditText txtVehicleModel;
        EditText txtPlateNumber;
        Spinner vehicleColorSpinner;

        EditText txtFirstName;
        EditText txtLastName;
        EditText txtBirthYear;
        EditText txtMonthlySalary;
        EditText txtOccupationRate;
        EditText txtEmployeeID;

        Spinner employeeTypeSpinner;
        TextView textViewProperty;
        EditText txtProperty;

        bool? hasSideCar;
        double occupationRate;
        string name;
        string employeeType;
        string vehicleColor;
        string vehicleCategory;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.registration);

            txtFirstName = FindViewById<EditText>(Resource.Id.firstName);
            txtLastName = FindViewById<EditText>(Resource.Id.lastName);
            txtBirthYear = FindViewById<EditText>(Resource.Id.birth);
            txtMonthlySalary = FindViewById<EditText>(Resource.Id.salary);
            txtOccupationRate = FindViewById<EditText>(Resource.Id.ocupationr);
            txtEmployeeID = FindViewById<EditText>(Resource.Id.employeeId);
            employeeTypeSpinner = FindViewById<Spinner>(Resource.Id.spinnerType);
            textViewProperty = FindViewById<TextView>(Resource.Id.textview_flex);
            txtProperty = FindViewById<EditText>(Resource.Id.field_number);
            carRadioButton = FindViewById<RadioButton>(Resource.Id.radioCar);
            motorbikeRadioButton = FindViewById<RadioButton>(Resource.Id.radioMoto);
            yesRadioButton = FindViewById<RadioButton>(Resource.Id.radioSideCarY);
            noRadioButton = FindViewById<RadioButton>(Resource.Id.radioSideCarN);
            txtCarType = FindViewById<EditText>(Resource.Id.carType);
            txtVehicleModel = FindViewById<EditText>(Resource.Id.model);
            txtPlateNumber = FindViewById<EditText>(Resource.Id.plate);
            vehicleColorSpinner = FindViewById<Spinner>(Resource.Id.colorful_gay);

            Button registerButton = FindViewById<Button>(Resource.Id.buttonMyBalls);

            var adapterEmployeeTypes = ArrayAdapter.CreateFromResource(this, Resource.Array.items_type, Android.Resource.Layout.SimpleSpinnerItem);
            adapterEmployeeTypes.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            employeeTypeSpinner.Adapter = adapterEmployeeTypes;
            employeeTypeSpinner.ItemSelected += employeeTypeSpinner_ItemSelected;


            var adapterVehicleColor = ArrayAdapter.CreateFromResource(this, Resource.Array.items_colors, Android.Resource.Layout.SimpleSpinnerItem);
            adapterVehicleColor.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            vehicleColorSpinner.Adapter = adapterVehicleColor;
            vehicleColorSpinner.ItemSelected += VehicleColorSpinner_ItemSelected;

            carRadioButton.Click += VehicleCategoryClick;
            motorbikeRadioButton.Click += VehicleCategoryClick;
            yesRadioButton.Click += SideCarClick;
            noRadioButton.Click += SideCarClick;
            registerButton.Click += RegisterClick;


        }

        private void RegisterClick(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtFirstName.Text) &&
                !string.IsNullOrEmpty(txtLastName.Text) &&
                !string.IsNullOrEmpty(txtBirthYear.Text)
                && !string.IsNullOrEmpty(txtMonthlySalary.Text) &&
                !string.IsNullOrEmpty(txtOccupationRate.Text) &&
                !string.IsNullOrEmpty(txtEmployeeID.Text) &&
                !employeeType.Equals("Choose a type") &&
                !string.IsNullOrEmpty(txtProperty.Text)
                && !string.IsNullOrEmpty(txtVehicleModel.Text)
                && !string.IsNullOrEmpty(txtPlateNumber.Text) &&
                !vehicleColor.Equals("Choose a color"))
            {
                if (!Employee.Ids.Contains(txtEmployeeID.Text))
                {
                    name = txtFirstName.Text + " " + txtLastName.Text;

                    int birthYear = Convert.ToInt32(txtBirthYear.Text);
                    if ((birthYear < 1900) || (birthYear > DateTime.Now.Year))
                    {
                        Toast.MakeText(this, $"Error!\n Value must be greater than 1900 " +
                            $"or greater than the {DateTime.Now.Year.ToString()}", ToastLength.Long).Show();
                    }
                    else
                    {
                        int age = (DateTime.Now.Year - birthYear);

                        occupationRate = Convert.ToDouble(txtOccupationRate.Text) / 100;

                        if (occupationRate < 0.1)
                        {
                            occupationRate = 0.1;

                        }
                        else if (occupationRate > 1)
                        {
                            occupationRate = 1;
                        }

                        if (employeeType.Equals("Manager"))
                        {


                            if (vehicleCategory.Equals("Car"))
                            {
                                Car car = new Car(vehicleCategory, txtCarType.Text, txtVehicleModel.Text, txtPlateNumber.Text, vehicleColor);
                                Manager m = new Manager(name, age, txtBirthYear.Text, txtMonthlySalary.Text, occupationRate, txtEmployeeID.Text,
                                    employeeType, txtProperty.Text, car);
                                Employee.Employees.Add(m);
                            }
                            else if (vehicleCategory.Equals("Motorbike"))
                            {
                                Motorbike moto = new Motorbike(vehicleCategory, hasSideCar, txtVehicleModel.Text, txtPlateNumber.Text, vehicleColor);
                                Manager m = new Manager(name, age, txtBirthYear.Text, txtMonthlySalary.Text, occupationRate, txtEmployeeID.Text,
                                    employeeType, txtProperty.Text, moto);
                                Employee.Employees.Add(m);
                            }
                        }
                        else if (employeeType.Equals("Tester"))
                        {
                            if (vehicleCategory.Equals("Car"))
                            {
                                Car car = new Car(vehicleCategory, txtCarType.Text, txtVehicleModel.Text, txtPlateNumber.Text, vehicleColor);
                                Tester t = new Tester(name, age, txtBirthYear.Text, txtMonthlySalary.Text, occupationRate, txtEmployeeID.Text,
                                    employeeType, txtProperty.Text, car);
                                Employee.Employees.Add(t);
                            }
                            else if (vehicleCategory.Equals("Motorbike"))
                            {
                                Motorbike moto = new Motorbike(vehicleCategory, hasSideCar, txtVehicleModel.Text, txtPlateNumber.Text, vehicleColor);
                                Tester t = new Tester(name, age, txtBirthYear.Text, txtMonthlySalary.Text, occupationRate, txtEmployeeID.Text,
                                    employeeType, txtProperty.Text, moto);
                                Employee.Employees.Add(t);
                            }
                        }
                        else if (employeeType.Equals("Programmer"))
                        {

                            if (vehicleCategory.Equals("Car"))
                            {
                                Car car = new Car(vehicleCategory, txtCarType.Text, txtVehicleModel.Text, txtPlateNumber.Text, vehicleColor);
                                Programmer p = new Programmer(name, age, txtBirthYear.Text, txtMonthlySalary.Text, occupationRate,
                                    txtEmployeeID.Text, employeeType, txtProperty.Text, car);
                                Employee.Employees.Add(p);
                            }
                            else if (vehicleCategory.Equals("Motorbike"))
                            {
                                Motorbike moto = new Motorbike(vehicleCategory, hasSideCar, txtVehicleModel.Text, txtPlateNumber.Text, vehicleColor);
                                Programmer p = new Programmer(name, age, txtBirthYear.Text, txtMonthlySalary.Text, occupationRate,
                                    txtEmployeeID.Text, employeeType, txtProperty.Text, moto);
                                Employee.Employees.Add(p);
                            }
                        }

                        Employee.Ids.Add(txtEmployeeID.Text);

                        Finish();
                    }

                }
                else
                {
                    Toast.MakeText(this, "Error!\nThis employeeID is already registered", ToastLength.Long).Show();
                }

            }
            else
            {
                Toast.MakeText(this, "Error!\nFill all fields", ToastLength.Long).Show();
            }

        }


        private void SideCarClick(object sender, EventArgs e)
        {
            RadioButton rbSideCar = (RadioButton)sender;

            switch (rbSideCar.Text)
            {
                case "Yes":
                    hasSideCar = true;
                    break;
                case "No":
                    hasSideCar = false;
                    break;
                default:
                    hasSideCar = null;
                    break;

            }
        }

        private void VehicleCategoryClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string choose = (rb.Text);

            if (choose == "car")
            {
                TableRow tr = FindViewById<TableRow>(Resource.Id.row_car_type);
                tr.Visibility = Android.Views.ViewStates.Visible;
                vehicleCategory = "Car";
            }

            if (choose == "motorbike")
            {
                TableRow tr = FindViewById<TableRow>(Resource.Id.row_side);
                tr.Visibility = Android.Views.ViewStates.Visible;
                vehicleCategory = "Motorbike";
            }
        }

        private void VehicleColorSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            vehicleColor = vehicleColorSpinner.GetItemAtPosition(e.Position).ToString();
        }

        private void employeeTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            int item = (int)spinner.SelectedItemId;

            if (item == 1)
            {
                TableRow tr = FindViewById<TableRow>(Resource.Id.row_number);
                tr.Visibility = Android.Views.ViewStates.Visible;
                TextView tv = FindViewById<TextView>(Resource.Id.textview_flex);
                tv.Text = "# clients";
                employeeType = "Manager";
            }

            if (item == 2)
            {
                TableRow tr = FindViewById<TableRow>(Resource.Id.row_number);
                tr.Visibility = Android.Views.ViewStates.Visible;
                TextView tv = FindViewById<TextView>(Resource.Id.textview_flex);
                tv.Text = "# bugs";
                employeeType = "Tester";
            }

            if (item == 3)
            {
                TableRow tr = FindViewById<TableRow>(Resource.Id.row_number);
                tr.Visibility = Android.Views.ViewStates.Visible;
                TextView tv = FindViewById<TextView>(Resource.Id.textview_flex);
                tv.Text = "# projects";
                employeeType = "Programmer";
            }

        }
    }
}