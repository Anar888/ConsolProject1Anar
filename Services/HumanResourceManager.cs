using ConsoleProjectAnar.Interfaces;
using ConsoleProjectAnar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProjectAnar.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments = new Department[0];

        public Department[] Departments => _departments;
        //{
        //    get
        //    {
        //        return _departments;
        //    }
        //}

        //departament elave edir
        public void AddDepartment(Department department)
        {
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }
        //Isci elave edir
        public void AddEmployee(Employee employee, string departmentname)
        {
            foreach (var item in Departments)
            {
                if (item.Name== departmentname)
                {
                    item.AddEmploye(employee);
                    break;
                }
            }
        }
        //Departamentler uzerinde deyisiklik edir
        public void EditDepartaments(string currentname,string newname)
        {
            foreach (var item in Departments)
            {
                if (item.Name==currentname)
                {
                    item.Name = newname;
                    break;
                }
            }
        }
        //Isci uzerinde deyisiklik edir
        public void EditEmploye(string empno, int salary, string position)
        {
            foreach (Department item in Departments)
            {
                foreach (Employee item2 in item.employees)
                {
                    if (item2.No == empno)
                    {
                        item2.Position = position;
                        item2.Salary = salary;
                    }
                    else
                    {
                        Console.WriteLine("Yanlis daxil etmisiniz");
                    }
                }
            }

        }

      //Departmentlerin siyahisin gosterir
        public Department[] GetDepartments()
        {
            return Departments;            
        }
        //Employe No-suna gore silir
        public void RemoveEmployee(string empno, string dpname)
        {
            foreach (var item in Departments)
            {
                if (item.Name==dpname)
                {
                    item.RemoveEmploye(empno);
                    break;
                }
            }
        }
    }
}
