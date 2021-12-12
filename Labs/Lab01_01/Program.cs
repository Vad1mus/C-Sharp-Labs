using System;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[] { new Student("Vadim Chugunov", DateTime.Parse("01-11-2001"),
                                                    DateTime.Parse("10-05-2019"), "a", "CIT", "Engineering", 12.4),
                                          new Student("Oleksandr Ivanchenko", DateTime.Parse("18-11-2002"), DateTime.Parse("15-1-2019"),
                                            "b", "CIT", "Engineering", 90.5)};

            // Printing out students' data
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
            Console.ReadLine();
        }
    }
}