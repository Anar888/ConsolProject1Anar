using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProjectAnar.Models
{
    class Department
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2)
                    Console.WriteLine("Departament adi minimum 2 herfden ibaret olmalidir");
                else
                    _name = value;
            }
            }
        
        private  int _worklimit;
        public int Workerlimit
        {
            get { return _worklimit; }
            set
            {
                if (value < 1)
                    Console.WriteLine("isci sayi 1-den az ola bilmez");
                else
                    _worklimit = value;
            }
        }
        private int _salarylimit;
        public int Salarylimit
        {
            get { return _salarylimit; }
            set
            {
                if (value < 250)
                    Console.WriteLine("Maas 250den asagi ola bilmez");
                else
                    _salarylimit = value;
            }
        }
        
       
        private Employee[] _employees = new Employee[0];
        public Employee[] employees => _employees;
        //{
        //    get
        //    {
        //        return _employees;
        //    }
        //}
        public int CalcSalaryAverage() 
        {
            int salaryaverage = 0;
            int result = 0;
            foreach (Employee item in employees)
            {
                result += item.Salary;
            }
            salaryaverage = result / Workerlimit;
            return salaryaverage;
        }
        public void AddEmploye(Employee employee)
        {
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[_employees.Length - 1] = employee;

        }
        public void RemoveEmploye(string empno)
        {
            _employees = Array.FindAll(_employees, x => x.No != empno);
        }
        public Department(string name,int worklimit,int salarylimit)
        {
            Name = name;
            Workerlimit = worklimit;
            Salarylimit = salarylimit;
        }

       
    }
}
