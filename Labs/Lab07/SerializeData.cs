using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using Lab01;

namespace Lab07
{
    public class SerializeData
    {
        public static void WriteToFile(FixedConteiner list)
        {
            Student[] students = list.Students;
            var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

            try
            {
                using (var file = new FileStream("students_list_fixed.json", FileMode.Create))
                {
                    try
                    {
                        jsonFormatter.WriteObject(file, students);
                        Console.WriteLine("Successfully written to file\n");
                    }
                    catch (System.Runtime.Serialization.SerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ReadFromFile(FixedConteiner list)
        {
            Student[] students = list.Students;
            if (students != null)
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

                try
                {
                    using (var file = new FileStream("students_list_fixed.json", FileMode.Open))
                    {
                        try
                        {
                            students = jsonFormatter.ReadObject(file) as Student[];
                            Console.WriteLine("Successfully read from file\n");
                        }
                        catch (System.Runtime.Serialization.SerializationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("There are no students in container\n");
            }
        }
    }
}
