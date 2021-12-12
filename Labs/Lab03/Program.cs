using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Lab01;
using Lab02;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstStudent = new Student("Vadim Chugunov", DateTime.Parse("01-11-2001"), DateTime.Parse("10-05-2019"), "a", "CIT", "Engineering", 70.4);
            var secondStudent = new Student("Sergey Dremen", DateTime.Parse("02-01-2002"), DateTime.Parse("10-02-2019"), "a", "CIT", "Engineering", 89.4);
            var thirdStudent = new Student("Oleksandr Ivanchenko", DateTime.Parse("10-11-2002"), DateTime.Parse("15-1-2019"), "b", "CIT", "Engineering", 90.5);

            var studentsArray = new Student[] { firstStudent, secondStudent, thirdStudent };
            var list = new Container(studentsArray);

            foreach (var listItem in list)
            {
                Console.WriteLine(listItem.ToString());
            }

            list.Remove(firstStudent);

            list.WriteToFile();
            list.ReadFromFile();

            Console.WriteLine("List data read from file:");
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem.ToString());
            }

            list.EditData(thirdStudent);
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem.ToString());
            }
            
        }
    }
}
