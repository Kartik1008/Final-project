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
    class Programmer : Employee
    {
        private string qtyProjects;

        public string NbProjects { get => qtyProjects; set => qtyProjects = value; }

        public Programmer(string name, int age, string birthYear, string monthlySalary, double occupationRate, string employeeID,
            string employeeType, string nbProjects, Vehicle employeeVehicle)
        {
            this.Name = name;
            this.Age = age;
            this.BirthYear = birthYear;
            this.MonthlySalary = monthlySalary;
            this.OccupationRate = occupationRate;
            this.EmployeeID = employeeID;
            this.EmployeeType = employeeType;
            this.NbProjects = nbProjects;
            this.EmployeeVehicle = employeeVehicle;
            this.List = true;
        }

        public override string ToString()
        {
            string message = null;

            if (List)
            {
                message = "Name: " + Name + "\nId: " + EmployeeID;
            }
            else
            {
                string annualIncome = Employee.AnnualIncome(Convert.ToDouble(MonthlySalary), EmployeeType, Convert.ToInt32(NbProjects)).ToString();

                string vehicleProfile = EmployeeVehicle.ToString();
                message = "Name: " + Name + ", a " + EmployeeType + "\nAge: "
                    + Age + "\n" +
                    EmployeeVehicle.ToString() +
                "\nOccupation Rate: " +
                Convert.ToInt32(OccupationRate * 100).ToString()
                + "%\nAnnual Income: $" +
                annualIncome + "\nHe/She has completed "
                + NbProjects + " project(s)";
            }


            return message;
        }
    }
}