using ConsoleProjectAnar.Interfaces;
using ConsoleProjectAnar.Models;
using ConsoleProjectAnar.Services;
using System;


namespace ConsoleProjectAnar
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager managerService = new HumanResourceManager();
            string x;
            while (true)
            {
                Console.WriteLine("1.1 Departamentlerin siyahisi");
                Console.WriteLine("1.2 Departament elave et");
                Console.WriteLine("1.3 Departament redakte et");
                Console.WriteLine("2.1 Employeelarin hamsini goster");
                Console.WriteLine("2.2 Employee department uzre goster");
                Console.WriteLine("2.3 Employee elave et");
                Console.WriteLine("2.4 Employee redakte et");
                Console.WriteLine("2.5 Employee sil");
                Console.WriteLine("0. Exit");


                x = Console.ReadLine();

                if (x=="0")
                {
                    break;
                }
                else if (x=="1.1")
                {
                    GetDepartment(managerService);
                }
                else if (x == "1.2")
                {
                    AddDepartment(managerService);
                }
                else if (x == "1.3")
                {
                    EditDepartment(managerService);
                }
                else if (x == "2.1")
                {
                    ShowAllEmployee(managerService);
                }
                else if (x == "2.2")
                {
                    ShowEmployeeFromDepartment(managerService);
                }
                else if (x == "2.3")
                {
                    AddEmployee(managerService);
                }
                else if (x == "2.4")
                {
                    EditEmployee(managerService);
                }
                else if (x == "2.5")
                {
                    DelEmployee(managerService);
                }

            }
        }

        //departamentin adini,icindeki isci sayini ve maas ortalamasini cixarir
        public static void GetDepartment(IHumanResourceManager manager)
        {
            foreach (var item in manager.GetDepartments())
            {
                Console.WriteLine($"{item.Name} {item.employees.Length} {item.CalcSalaryAverage()}");
            }
        }
        //departament elave edir(adini,isci sayinin limitini ve maas limitini consoldan daxil edirik)
        public static void AddDepartment(IHumanResourceManager manager)
        {
            string name;
            int workLimit;
            int salaryLimit;



            Console.Write("Adi: ");
            while (true)
            {
                name = Console.ReadLine();
                if (name.Length > 1) break;
                else Console.Write("Adi dogru daxil edin: ");
            }

            Console.Write("Isci sayi: ");
            while (true)
            {
                workLimit = int.Parse(Console.ReadLine());
                if (workLimit > 0) break;
                else Console.Write("Isci sayi dogru daxil edin: ");
            }

            Console.Write("Maas limiti: ");
            while (true)
            {
                salaryLimit = int.Parse(Console.ReadLine());
                if (salaryLimit > 250) break;
                else Console.Write("Maas limitini dogru daxil edin: ");
            }

            manager.AddDepartment(new Department(name, workLimit, salaryLimit));

        }
        //Department uzerinde deyisiklik edir(yalniz adini deyisir)
        public static void EditDepartment(IHumanResourceManager manager)
        {
            string name;
            Console.Write("Adi: ");
            name = Console.ReadLine();

            foreach (var item in manager.GetDepartments())
            {
                if(item.Name == name)
                {
                    string newName;
                    Console.Write("Adi: ");
                    while (true)
                    {
                        newName = Console.ReadLine();
                        if (newName.Length > 1) break;
                        else Console.Write("Adi dogru daxil edin: ");
                    }
                    manager.EditDepartaments(name, newName);
                    return;
                }
            }
            Console.WriteLine("Bu adda department yoxdu.");
        }
        // butun iscilerin isci nomresi,ad soyadi,department adi,maasi ve pozisyasi gosterir
        public static void ShowAllEmployee(IHumanResourceManager manager)
        {
            foreach (var item in manager.GetDepartments())
            {
                foreach (var emp in item.employees)
                {
                    Console.WriteLine($"{emp.No} {emp.Fullname} {emp.DepartmentName} {emp.Salary} {emp.Position}");
                }
            }
        }
        //Departament uzre isci siyahisi(iscinin nomresi,ad soyadi,departament adi,maasi ve pozisyasi)
        public static void ShowEmployeeFromDepartment(IHumanResourceManager manager)
        {
            string name;
            Console.Write("Adi: ");
            name = Console.ReadLine();

            foreach (var item in manager.GetDepartments())
            {
                if (item.Name == name)
                {
                    foreach (var emp in item.employees)
                    {
                        Console.WriteLine($"{emp.No} {emp.Fullname} {emp.DepartmentName} {emp.Salary} {emp.Position}");
                    }
                    return;
                }
            }
            Console.WriteLine("Bu adda department yoxdu.");
        }
        //isci elave edir
        public static void AddEmployee(IHumanResourceManager manager)
        {
            string name;
            string depName;
            int salary;
            string position;

            
          

            Console.Write("Adi: ");
            while (true)
            {
                name = Console.ReadLine();
                if (name.Length > 1) break;
                else Console.Write("Adi dogru daxil edin: ");
            }

            Console.Write("Department adi: ");
            while (true)
            {
                depName = Console.ReadLine();
                if (depName.Length > 1) break;
                else Console.Write("Department adini dogru daxil edin: ");
            }

            Console.Write("Maas: ");
            while (true)
            {
                salary = int.Parse(Console.ReadLine());
                if (salary > 250) break;
                else Console.Write("Maasi dogru daxil edin: ");
            }

            Console.Write("Position: ");
            while (true)
            {
                position = Console.ReadLine();
                if (position.Length > 1) break;
                else Console.Write("Positioni dogru daxil edin: ");
            }

            foreach (var item in manager.GetDepartments())
            {
                if (item.Name == depName)
                {
                    manager.AddEmployee(new Employee(name, depName, position, salary), depName);
                    return;
                }
            }
            Console.WriteLine("Bu adda department yoxdu.");

        }
         //Isci uzerinde deyisiklik edir
        public static void EditEmployee(IHumanResourceManager manager)
        {
            string No;
            Console.Write("No: ");
            No = Console.ReadLine();

            foreach (var item in manager.GetDepartments())
            {
                foreach (var emp in item.employees)
                {
                    if(emp.No == No)
                    {
                        Console.WriteLine($"{emp.No} {emp.Fullname} {emp.DepartmentName} {emp.Salary} {emp.Position}");
                        int newSalary;
                        string newPosition;

                        Console.Write("Yeni maas: ");
                        while (true)
                        {
                            newSalary = int.Parse(Console.ReadLine());
                            if (newSalary > 250) break;
                            else Console.Write("Maasi dogru daxil edin: ");
                        }

                        Console.Write("Yeni postion: ");
                        while (true)
                        {
                            newPosition = Console.ReadLine();
                            if (newPosition.Length > 1) break;
                            else Console.Write("positioni dogru daxil edin: ");
                        }
                        manager.EditEmploye(No, newSalary, newPosition);
                        return;
                    }
                }
            }
            Console.WriteLine("Emplpyee tapilmadi.");
        }
        //iscini silir
        public static void DelEmployee(IHumanResourceManager manager)
        {
            string depName;
            string No;

            Console.Write("Department adi: ");
            depName = Console.ReadLine();

            Console.Write("Employee No: ");
            No = Console.ReadLine();

            foreach (var item in manager.GetDepartments())
            {
                if(item.Name == depName)
                {
                    foreach (var emp in item.employees)
                    {
                        if (emp.No == No)
                        {
                            manager.RemoveEmployee(No, depName);
                            break;
                        }
                    }
                    return;
                }
                
            }
            Console.WriteLine("Employee tapilmadi.");
        }

    }
}

        
