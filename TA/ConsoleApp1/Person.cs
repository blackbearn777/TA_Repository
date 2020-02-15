using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Person : IComparable
    {
        private int value;
        private double salary;
        private int hours;
        private string surname;
        private string name;
        private int index;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Hours { get => hours; set => hours = value; }
        public double Salary { get => salary; set => salary = value; }
        public int Index
        {
            get => index;
            set
            {
                if (Hours >= 144)
                {
                    index = value * 2;
                }
                else
                {
                    index = value;
                }
            }
        }
        public Person()
        {

        }

        public Person(string name, string surname, int hours, int index)
        {
            Name = name;
            Surname = surname;
            Hours = hours;
            Index = index;
            Salary = Hours * Index * 0.22;
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public int CompareTo(object obj)
        {
            return Salary.CompareTo(((Person)obj).Salary);
        }
    }
}
