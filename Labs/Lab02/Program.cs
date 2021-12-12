using System;
using Lab01;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[] { new Student("Vadim Chugunov", DateTime.Parse("01-11-2001"),
                                                    DateTime.Parse("10-05-2019"), "a", "CIT", "Engineering", 70.4),
                                          new Student("Oleksandr Ivanchenko", DateTime.Parse("18-11-2002"), DateTime.Parse("15-1-2019"),
                                            "b", "CIT", "Engineering", 90.5)};

            var firstStudent = new Student("Vadim Chugunov", DateTime.Parse("01-11-2001"), DateTime.Parse("10-05-2019"), "a", "CIT", "Engineering", 70.4);
            var secondStudent = new Student("Sergey Dremen", DateTime.Parse("02-01-2002"), DateTime.Parse("10-02-2019"), "a", "CIT", "Engineering", 89.4);
            var thirdStudent = new Student("Oleksandr Ivanchenko", DateTime.Parse("10-11-2002"), DateTime.Parse("15-1-2019"), "b", "CIT", "Engineering", 90.5);

            var studentsArray = new Student[] { firstStudent, secondStudent };
            var list = new Container(studentsArray);

            Console.WriteLine("==========================List==========================");
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem.ToString());
            }
            list.Add(thirdStudent);

            Console.WriteLine("==========================List after added element==========================");
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem.ToString());
            }
        }
    }
}
