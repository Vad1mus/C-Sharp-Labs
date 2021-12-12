using System;
using System.Text;
using Lab01;
namespace Lab07
{
    public class ShowStudents
    {
        public static void showStudentInfo(Student student,FixedConteiner list)
        {
            int pos = -1;

            if(list.Find(student) != null)
            {
                pos = 1;
            }

            if (pos != -1)
            {
                var builder = new StringBuilder();
                Console.WriteLine("\n===========Data -> (Course, Group&Semester, Age)===========\n");

                Console.WriteLine("Course&Semester info:");
                builder.AppendFormat("Course: {0}\nSemester: {1}\n", (DateTime.Now.Year - student.DateOfReceipt.Year) + 1,
                         Math.Ceiling((double)((12 * (DateTime.Now.Year - student.DateOfReceipt.Year) + DateTime.Now.Month - student.DateOfReceipt.Month)
                        - 2 * (DateTime.Now.Year - student.DateOfReceipt.Year))) / 5);
                Console.WriteLine(builder.ToString());
                builder.Clear();

                Console.WriteLine("\nGroup info:");
                builder.AppendFormat("Faculty: {0}\nSpecialty: {1}\nDate of admission: {2}\nGroup index: {3}", student.Faculty,
                student.Specialization, student.DateOfReceipt.Year, student.IndexGroup);
                Console.WriteLine(builder.ToString());
                builder.Clear();

                Console.WriteLine("\nAge info:");
                builder.AppendFormat("Years: {0}\nMonth: {1}\nDays: {2}\n", DateTime.Now.Year - student.DateOfBirth.Year,
                        (Math.Abs(DateTime.Now.Month - student.DateOfBirth.Month)) - 1, DateTime.Now.Day);
                Console.WriteLine(builder.ToString());
                builder.Clear();
            }
            else
            {
                Console.WriteLine("No student in List!\n");
            }
        }
       
        public static void showAllStudents(FixedConteiner list)
        {
            foreach(var student in list)
            {
                Console.WriteLine(student.ToString());
            }
        }
       
    }
}
