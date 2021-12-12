using System;
using Lab01;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstStudent = new Student("Vadim Chugunov", DateTime.Parse("01-11-2001"), DateTime.Parse("10-05-2019"), "a", "CIT", "CompScience", 70.4);
            var secondStudent = new Student("Sergey Dremen", DateTime.Parse("02-01-2002"), DateTime.Parse("10-02-2019"), "a", "CIT", "Engineering", 89.4);
            var thirdStudent = new Student("Oleksandr Ivanchenko", DateTime.Parse("10-11-2002"), DateTime.Parse("15-1-2019"), "b", "CIT", "Engineering", 90.5);
            var fourth = new Student("Ivan Champ", DateTime.Parse("01-05-2002"), DateTime.Parse("10-05-2018"), "b", "CIT", "CompScience", 90.9);
            var fith = new Student("Vadim Chugunov", DateTime.Parse("06-06-2003"), DateTime.Parse("05-11-2020"), "c", "CIT", "CompScience", 95.9);
            var studentsArray = new Student[] { firstStudent, secondStudent, thirdStudent, fourth, fith };
            var list = new FixedConteiner(studentsArray);

            ShowStudents.showAllStudents(list);
            ShowStudents.showStudentInfo(firstStudent, list);
            list.Remove(firstStudent);
            SerializeData.WriteToFile(list);
            SerializeData.ReadFromFile(list);

            ShowStudents.showAllStudents(list);
            Console.WriteLine(Avarage.CountAvg(list));
            list.CountOfStudentsWithNameVadim();
        }
    }
}
