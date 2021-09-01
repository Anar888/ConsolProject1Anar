using ConsoleProjectAnar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProjectAnar.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }

        public void AddDepartment(Department department);

        public Department[] GetDepartments();
        public void EditDepartaments(string currentname, string newnam);
        public void AddEmployee(Employee employee,String departmentname);

        public void RemoveEmployee(string empno, string dpname);
        public void EditEmploye(string empno,int salary,string position );
       

    }
}
