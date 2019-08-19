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
    class Manager : Employee
    {
        private string qtyClients;

        public string NbClients { get => qtyClients; set => qtyClients = value; }


        public Manager(string name, int age, string birthYear, string monthlySalary, double occupationRate, string employeeID,
            string employeeType, string nbClients, Vehicle employeeVehicle)
        {
            this.Name = name;
            this.Age = age;
            this.BirthYear = birthYear;
            this.MonthlySalary = monthlySalary;
            this.OccupationRate = occupationRate;
            this.EmployeeID = employeeID;
            this.EmployeeType = employeeType;
            this.NbClients = nbClients;
            this.EmployeeVehicle = employeeVehicle;
            this.List = true;
        }

        public override string ToString()
        {
            string message = null;

            if (List)
            {
                message = "Name: " + Name + "\n Id: " + EmployeeID;
            }
            else
            {
                string annualIncome = Employee.AnnualIncome(Convert.ToDouble(MonthlySalary), EmployeeType, Convert.ToInt32(NbClients)).ToString();

                string vehicleProfile = EmployeeVehicle.ToString();
                message = "Name: " + Name + ", a " +
                    EmployeeType +
                    "\nAge: " + Age + "\n" + EmployeeVehicle.ToString() +
                "\n Occupation Rate: " +
                Convert.ToInt32(OccupationRate * 100).ToString() + "% \n Annual Income: $" +
                annualIncome + "\nHe/She has brought " +
                NbClients + " new clients";
            }


            return message;
        }

    }
}