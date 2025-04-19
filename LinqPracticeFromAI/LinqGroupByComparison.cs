using System.Diagnostics;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class Mark
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int StudentId { get; set; }
    public int Score { get; set; }
}
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class ReportItem
{
    public string TeacherName { get; set; }
    public string StudentName { get; set; }
    public double AverageScore { get; set; }
    public int TeacherId { get; set; }
    public string TeacherEmail { get; set; }
    public int StudentAge { get; set; }

    private string DebuggerDisplay =>
        $"Id= {TeacherId} ,TeacherName = \"{TeacherName}\", StudentName = \"{StudentName}\", AverageScore = {AverageScore}, TeacherEmail = \"{TeacherEmail}\", StudentAge = {StudentAge}";
}


class Program1
{
    static void Main1(string[] args)
    {

        var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Mr. Smith", Email = "smith@school.com" },
                new Teacher { Id = 2, Name = "Ms. Johnson", Email = "johnson@school.com" },
                new Teacher { Id = 3, Name = "Dr. Adams", Email = "adams@school.com" }
            };

        var students = new List<Student>
            {
                new Student { Id = 1, FullName = "Alice Brown", BirthDate = new DateTime(2005, 3, 15) },
                new Student { Id = 2, FullName = "Bob Green", BirthDate = new DateTime(2006, 7, 23) },
                new Student { Id = 3, FullName = "Charlie Black", BirthDate = new DateTime(2004, 11, 5) },
                new Student { Id = 4, FullName = "Diana White", BirthDate = new DateTime(2005, 1, 20) }
            };

        var marks = new List<Mark>
            {
                new Mark { Id = 1, TeacherId = 1, StudentId = 1, Score = 80 },
                new Mark { Id = 2, TeacherId = 1, StudentId = 1, Score = 90 },
                new Mark { Id = 3, TeacherId = 1, StudentId = 2, Score = 70 },
                new Mark { Id = 4, TeacherId = 2, StudentId = 2, Score = 85 },
                new Mark { Id = 5, TeacherId = 2, StudentId = 2, Score = 75 },
                new Mark { Id = 6, TeacherId = 2, StudentId = 3, Score = 88 },
                new Mark { Id = 7, TeacherId = 3, StudentId = 3, Score = 92 },
                new Mark { Id = 8, TeacherId = 3, StudentId = 4, Score = 77 },
                new Mark { Id = 9, TeacherId = 3, StudentId = 4, Score = 82 }
            };

        var reportA = (from m in marks
                       join t in teachers on m.TeacherId equals t.Id
                       join s in students on m.StudentId equals s.Id
                       group m by new { t.Id, t.Name, s.FullName, t.Email, s.BirthDate } into g
                       select new ReportItem
                       {
                           TeacherId = g.Key.Id,
                           TeacherName = g.Key.Name,
                           StudentName = g.Key.FullName,
                           AverageScore = g.Average(x => x.Score),
                           TeacherEmail = g.Key.Email,
                           StudentAge = DateTime.Now.Year - g.Key.BirthDate.Year
                       }).ToList();

        var reportB = (from m in marks
                       join t in teachers on m.TeacherId equals t.Id
                       join s in students on m.StudentId equals s.Id
                       group new { Mark = m, Teacher = t, Student = s }
                       by new { t.Name, s.FullName } into g
                       select new ReportItem
                       {
                           TeacherId = g.First().Teacher.Id,
                           TeacherName = g.Key.Name,
                           StudentName = g.Key.FullName,
                           AverageScore = g.Average(x => x.Mark.Score),
                           TeacherEmail = g.First().Teacher.Email,
                           StudentAge = DateTime.Now.Year - g.First().Student.BirthDate.Year
                       }).ToList();

        foreach (var item in reportB)
        {
            Console.WriteLine($"Teacher: {item.TeacherName} ({item.TeacherEmail})");
            Console.WriteLine($"Student: {item.StudentName} (Age: {item.StudentAge})");
            Console.WriteLine($"Average Score: {item.AverageScore}");
        }
    }
}