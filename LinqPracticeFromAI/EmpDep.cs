//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LinqPracticeFromAI
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var departments = new List<Department>
//                {
//                    new Department { Id = 1, Name = "HR" },
//                    new Department { Id = 2, Name = "IT" },
//                    new Department { Id = 3, Name = "Finance" }
//                };

//            var employees = new List<Employee>
//                {
//                    new Employee { Id = 1, FullName = "Alice Johnson", HireDate = new DateTime(2015, 5, 10), DepartmentId = 1 },
//                    new Employee { Id = 2, FullName = "Bob Smith", HireDate = new DateTime(2018, 3, 21), DepartmentId = 2 },
//                    new Employee { Id = 3, FullName = "Cathy Brown", HireDate = new DateTime(2020, 11, 12), DepartmentId = 2 },
//                    new Employee { Id = 4, FullName = "David Wilson", HireDate = new DateTime(2016, 1, 30), DepartmentId = 3 }
//                };

//            var reviews = new List<Review>
//                {
//                    new Review { Id = 1, DepartmentId = 1, EmployeeId = 1, Score = 88 },
//                    new Review { Id = 2, DepartmentId = 1, EmployeeId = 1, Score = 92 },
//                    new Review { Id = 3, DepartmentId = 2, EmployeeId = 2, Score = 75 },
//                    new Review { Id = 4, DepartmentId = 2, EmployeeId = 2, Score = 80 },
//                    new Review { Id = 5, DepartmentId = 2, EmployeeId = 3, Score = 84 },
//                    new Review { Id = 6, DepartmentId = 3, EmployeeId = 4, Score = 90 }
//                };

//            var report = from d in departments
//                         join e in employees on d.Id equals e.DepartmentId
//                         group e by d into g
//                         select new
//                         {
//                             DepartmentId = g.Key?.Id,
//                             DepartmentName = g.Key?.Name,
//                             DepEmpCountr = g.Count()
//                             //EmployeeName = g.Key.FullName,
//                             //AverageScore = g.Average(x => x.Score),
//                             //YearsWorked = DateTime.Now.Year - g.Key.HireDate.Year
//                         };

//            var repor2t = (from e in employees
//                           join d in departments on e.DepartmentId equals d.Id
//                           group e by d into g
//                           select new
//                           { 
//                               DepartmentId = g.Key?.Id,
//                               DepartmentName = g.Key?.Name,
//                               DepEmpCountr = g.Count()
//                               //EmployeeName = g.Key.FullName,
//                               //AverageScore = g.Average(x => x.Score),
//                               //YearsWorked = DateTime.Now.Year - g.Key.HireDate.Year
//                           }).ToList();

//            //foreach (var item in report)
//            //{
//            //    Console.WriteLine($"Department: {item.DepartmentName}");
//            //    Console.WriteLine($"Employee: {item.EmployeeName} (Years Worked: {item.YearsWorked})");
//            //    Console.WriteLine($"Average Review Score: {item.AverageScore}\n");
//            //}
//        }
//    }
//    public class Department
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }

//        public ICollection<Employee> Employees { get; set; }
//    }

//    public class Employee
//    {
//        public int Id { get; set; }
//        public string FullName { get; set; }
//        public DateTime HireDate { get; set; }
//        public int DepartmentId { get; set; }
//        public Department Department { get; set; }
//        //public ICollection<Review> Reviews { get; set; }
//    }

//    public class Review
//    {
//        public int Id { get; set; }
//        public int DepartmentId { get; set; }
//        public int EmployeeId { get; set; }
//        public int Score { get; set; }
//    }

//    [DebuggerDisplay("{DebuggerDisplay,nq}")]
//    public class EmployeeReportItem
//    {
//        public string DepartmentName { get; set; }
//        public string EmployeeName { get; set; }
//        public double AverageScore { get; set; }
//        public int DepartmentId { get; set; }
//        public int YearsWorked { get; set; }

//        private string DebuggerDisplay =>
//            $"DepartmentId={DepartmentId}, DepartmentName=\"{DepartmentName}\", EmployeeName=\"{EmployeeName}\", AvgScore={AverageScore}, YearsWorked={YearsWorked}";
//    }
//}
