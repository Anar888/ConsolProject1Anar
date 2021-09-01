using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProjectAnar
{
    class Employee
    {
        private static  int Count = 1000;
        public string No;
        public string Fullname;
        private string _position;
        //positiona min 2 limit verilib yeni 2den az olduqda bildiris gedir
        public string Position
        {
            get { return _position; }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("Position minumum 2 herfden ibaret ola biler");
                }
                else
                {
                    _position = value;
                }
            }
        }

        private int _salary;
        //Salary 250den asagi olduqda bildiris gedir
        public int Salary {
            get { return _salary; }
            set
            {
                if (value < 250)
                    Console.WriteLine("Işçinin maaşı 250man-dan aşağı ola bilməz");
                else
                    _salary = value;
            }
            }
        public string DepartmentName;
        public Employee(string fullname, string depname,string position, int salary)
        {
            Position = position;     
            Fullname = fullname;
            DepartmentName = depname;
            Salary = salary;
            Count++;
            
            No = depname.Substring(0, 2).ToUpper() + Count;
        }
    }
}