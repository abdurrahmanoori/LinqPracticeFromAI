//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LinqPracticeFromAI
//{
//    public class Program
//    {
//        const decimal AbsentPenalty = 50m;
//        const decimal LatePenalty = 10m;
//        const decimal EarlyLeavePenalty = 15m;

//        public static void Main(string[] args)
//        {
//            var employees = new List<Employee>
//            {
//                new Employee { Id = 1, FullName = "Alice Johnson" },
//                new Employee { Id = 2, FullName = "Bob Smith" },
//                new Employee { Id = 3, FullName = "Charlie Brown" }
//            };

//            var attendanceRecords = new List<AttendanceRecord>
//            {
//                new AttendanceRecord { EmployeeId = 1, Date = new DateTime(2025, 3, 1), IsPresent = false, IsLate = false, LeftEarly = false },
//                new AttendanceRecord { EmployeeId = 1, Date = new DateTime(2025, 3, 2), IsPresent = true, IsLate = true, LeftEarly = true },
//                new AttendanceRecord { EmployeeId = 1, Date = new DateTime(2025, 3, 3), IsPresent = true, IsLate = true, LeftEarly = true },
//                new AttendanceRecord { EmployeeId = 1, Date = new DateTime(2025, 3, 4), IsPresent = true, IsLate = true, LeftEarly = true },
//                new AttendanceRecord { EmployeeId = 2, Date = new DateTime(2025, 3, 1), IsPresent = true, IsLate = false, LeftEarly = false },
//                new AttendanceRecord { EmployeeId = 2, Date = new DateTime(2025, 3, 2), IsPresent = false, IsLate = false, LeftEarly = false },
//                new AttendanceRecord { EmployeeId = 2, Date = new DateTime(2025, 3, 3), IsPresent = true, IsLate = true, LeftEarly = false },
//                new AttendanceRecord { EmployeeId = 3, Date = new DateTime(2025, 3, 1), IsPresent = true, IsLate = false, LeftEarly = true },
//                new AttendanceRecord { EmployeeId = 3, Date = new DateTime(2025, 3, 2), IsPresent = true, IsLate = false, LeftEarly = true },
//                new AttendanceRecord { EmployeeId = 3, Date = new DateTime(2025, 3, 3), IsPresent = false, IsLate = false, LeftEarly = false }
//            };

//            var month = new DateTime(2025, 3, 1);

//            var report = from record in attendanceRecords
//                         where record.Date.Year == month.Year && record.Date.Month == month.Month
//                         join emp in employees on record.EmployeeId equals emp.Id
//                         group new { record, emp } by emp.Id into empGroup
//                         let employee = empGroup.First().emp
//                         let absents = empGroup.Count(x => !x.record.IsPresent)
//                         let lates = empGroup.Count(x => x.record.IsLate)
//                         let earlyLeaves = empGroup.Count(x => x.record.LeftEarly)
//                         let extraLates = lates > 3 ? lates - 3 : 0
//                         let extraEarlyLeaves = earlyLeaves > 2 ? earlyLeaves - 2 : 0
//                         let penalty = (absents * AbsentPenalty) + (extraLates * LatePenalty) + (extraEarlyLeaves * EarlyLeavePenalty)
//                         select new EmployeePenaltySummaryDto
//                         {
//                             EmployeeName = employee.FullName,
//                             TotalAbsentDays = absents,
//                             TotalLateDays = lates,
//                             TotalEarlyLeaves = earlyLeaves,
//                             PenaltyAmount = penalty
//                         };

//            foreach (var r in report)
//            {
//                Console.WriteLine($"Name: {r.EmployeeName}, Absent: {r.TotalAbsentDays}, Late: {r.TotalLateDays}, Early Leaves: {r.TotalEarlyLeaves}, Penalty: ${r.PenaltyAmount}");
//            }
//        }
//    }

//    public class Employee
//    {
//        public int Id { get; set; }
//        public string FullName { get; set; }
//    }

//    public class AttendanceRecord
//    {
//        public int EmployeeId { get; set; }
//        public DateTime Date { get; set; }
//        public bool IsPresent { get; set; }
//        public bool IsLate { get; set; }
//        public bool LeftEarly { get; set; }
//    }

//    public class EmployeePenaltySummaryDto
//    {
//        public string EmployeeName { get; set; }
//        public int TotalAbsentDays { get; set; }
//        public int TotalLateDays { get; set; }
//        public int TotalEarlyLeaves { get; set; }
//        public decimal PenaltyAmount { get; set; }
//    }
//}
