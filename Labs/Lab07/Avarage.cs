using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab01;

namespace Lab07
{
    class Avarage
    {
        delegate double task(Student[] student);

        public static double CountAvg(FixedConteiner list)
        {
            task functionD = null;
            Student[] array = list.Students;
            Console.WriteLine("\n\nCount of avarage Age or University Performance:");
            Console.WriteLine("1 - University Performance");
            Console.WriteLine("2 - Age");
            Console.WriteLine("Write 1 or 2 ");
            var temp = Console.ReadLine();
            if (temp == "1")
            {
                functionD = CountAvgUniversityPer;
            }
            else if (temp == "2")
            {
                functionD = CountAvgAge;
            }
            else
            {
                Console.WriteLine("Error!Try again!");
                return -1;
            }

            var builder = new StringBuilder();
            builder.Append("Enter option of the count:\n")
                .Append("1 - Group\n").Append("2 - Specialty\n").Append("3 - Faculty\n\n");
            Console.WriteLine(builder);
            temp = Console.ReadLine();
            Student[] students = null;
            switch (temp)
            {
                case "1":
                    Console.WriteLine("Write name of group:");
                    temp = Console.ReadLine();
                    students = array.Where(s => s.IndexGroup.Equals(temp)).ToArray();
                    break;
                case "2":
                    Console.WriteLine("Write name of specialty:");
                    temp = Console.ReadLine();
                    students = array.Where(s => s.Specialization.Equals(temp)).ToArray();
                    break;
                case "3":
                    Console.WriteLine("Write name of faculty:");
                    temp = Console.ReadLine();
                    students = array.Where(s => s.Faculty.Equals(temp)).ToArray();
                    break;
                default:
                    temp = "";
                    Console.WriteLine("Error!\n");
                    break;
            }
            return functionD(students);
        }

        private static double CountAvgAge(Student[] list)
        {
            double temp = 0;

            foreach (var listItem in list)
            {
                temp += DateTime.Now.Year - listItem.DateOfBirth.Year;
            }

            return temp / list.Length;
        }

        private static double CountAvgUniversityPer(Student[] list)
        {
            double temp = 0;

            foreach (var listItem in list)
            {
                temp += listItem.UniversityPerfomance;
            }

            return temp / list.Length;
        }

    }
}
