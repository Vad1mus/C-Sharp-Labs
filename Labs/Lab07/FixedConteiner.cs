using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Lab01;
using System.Linq;

namespace Lab07
{
    public class FixedConteiner : IEnumerable
    {
        private Student[] _students;

        delegate double task(Student[] student);

        public Student[] Students
        {
            get
            {
                return _students;
            }
        }
        public FixedConteiner(Student[] pArray)
        {
            _students = new Student[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _students[i] = pArray[i];
            }
        }
        /* Add,remove,find methods*/
        public void Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student is null");
            }

            var newArr = new Student[_students.Length + 1];

            for (int i = 0; i < _students.Length; i++)
            {
                newArr[i] = _students[i];
            }

            newArr[newArr.Length - 1] = student;
            _students = newArr;
        }
        public bool Remove(Student student)
        {
            if (student == null)
            {
                return false;
            }

            int pos = -1;

            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                return false;
            }

            var newArr = new Student[_students.Length - 1];

            for (int i = 0; i < pos; i++)
            {
                newArr[i] = _students[i];
            }
            for (int i = pos + 1; i < _students.Length; i++)
            {
                newArr[i - 1] = _students[i];
            }

            _students = newArr;
            return true;
        }
        public Student Find(Student student)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    return _students[i];
                }
            }
            return null;
        }
        public void EditData(Student student)
        {
            int index = -1;

            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Equals(student))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                Console.WriteLine("Remember, you can edit only {Fullname, DateOfReceipt, Faculty}  fields!\n");
                try
                {
                    Console.WriteLine("Enter new Full Name: ");
                    _students[index].Name = Console.ReadLine();
                    Console.WriteLine("\nEnter new Date Of Receipt: ");
                    _students[index].DateOfReceipt = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("\nEnter new name of Faculty: ");
                    _students[index].Faculty = Console.ReadLine();
                    Console.WriteLine("\nStudent data is modified successfuly!\n ");

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("There is no student in list\n");
            }
        }
 
        public void CountOfStudentsWithNameVadim()
        {

            var students = _students.Where(s => s.Name.Equals("Vadim Chugunov"));
            Console.WriteLine("\n" + students.Count());
        }

        public bool RemoveForOption()
        {
            var builder = new StringBuilder();
            builder.Append("Enter option of the deleting:\n")
                .Append("1 - Group index\n").Append("2 - Specialty\n").Append("3 - Faculty\n\n");
            Console.WriteLine(builder);

            var temp = Console.ReadLine();
            Student[] students = null;
            switch (temp)
            {
                case "1":
                    Console.WriteLine("Write name of group index:");
                    temp = Console.ReadLine();
                    students = _students.Where(s => s.IndexGroup.Equals(temp)).ToArray();
                    break;
                case "2":
                    Console.WriteLine("Write name of specialty:");
                    temp = Console.ReadLine();
                    students = _students.Where(s => s.Specialization.Equals(temp)).ToArray();
                    break;
                case "3":
                    Console.WriteLine("Write name of faculty:");
                    temp = Console.ReadLine();
                    students = _students.Where(s => s.Faculty.Equals(temp)).ToArray();
                    break;
                default:
                    temp = "";
                    Console.WriteLine("Error!\n");
                    break;
            }


            if (!string.IsNullOrEmpty(temp))
            {
                var prevSize = _students.Length;
                for (int i = 0; i < _students.Length; i++)
                {
                    for (int j = 0; j < students.Length; j++)
                    {
                        if (_students[i].Equals(students[j]))
                        {
                            Remove(_students[i]);
                        }
                    }
                }
                if (prevSize != _students.Length)
                {
                    return true;
                }
            }

            return false;
        }
        public IEnumerator GetEnumerator()
        {
            return new ContainerEnum(_students);
        }
    }
    public sealed class ContainerEnum : IEnumerator
    {

        private Student[] _students;
        private int _position = -1;


        public ContainerEnum(Student[] students)
        {
            _students = students;
        }


        public object Current
        {
            get
            {
                try
                {
                    return _students[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _students.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
