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
    class Employee
    {

        private Vehicle employeeVehicle;
        private static List<Employee> employees = new List<Employee>();
        private static List<string> ids = new List<string>();
        public Vehicle EmployeeVehicle { get => employeeVehicle; set => employeeVehicle = value; }
        public static List<Employee> Employees { get => employees; set => employees = value; }

        private bool list;
        private string name;
        private int age;
        private string birthYear;
        private string monthlySalary;
        private double occupationRate;
        private string employeeID;
        private string employeeType;
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string BirthYear { get => birthYear; set => birthYear = value; }
        public string MonthlySalary { get => monthlySalary; set => monthlySalary = value; }
        public double OccupationRate { get => occupationRate; set => occupationRate = value; }
        public string EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeType { get => employeeType; set => employeeType = value; }

        public bool List { get => list; set => list = value; }
        public static List<string> Ids { get => ids; set => ids = value; }
        public const double bonus_new_clients = 500;
        public const double bonus_bugs = 10;
        public const double bonus_projects = 200;

        public static double AnnualIncome(double monthlySalary, string employeeType, int myField)
        {
            double annualIncome = 0; double bonus = 0;

            if (employeeType.Equals("Manager"))
            {
                bonus = bonus_new_clients * myField;
            }
            else if (employeeType.Equals("Tester"))
            {
                bonus = bonus_bugs * myField;
            }
            else if (employeeType.Equals("Programmer"))
            {
                bonus = bonus_projects * myField;
            }

            annualIncome = 12 * monthlySalary + bonus;

            return annualIncome;
        }
    }
}