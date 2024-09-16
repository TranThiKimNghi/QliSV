using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    internal class Student
    {
        //1. Field
        private string studentID;
        private string fullName;
        private int age;
        //2. Property
        public string StudentID
        {
            get => studentID; set => studentID = value;
        }
        public string FullName { get => fullName; set => fullName = value; }
        public int Age { get => age; set => age = value; }

        //3.Constructor
        public Student() { }
        public Student(string studentID, string fullName, int age)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.age = age;
        }
        //4. Methods
        public void Input()
        {
            Console.Write("Nhập MSSV:");
            StudentID = Console.ReadLine();
            Console.Write("Nhập Họ tên Sinh viên:");
            FullName = Console.ReadLine();
            Console.Write("Nhập Tuổi:");
            Age = int.Parse(Console.ReadLine());
        }
        public void Show()
        {
            Console.WriteLine("MSSV:{0} Họ Tên:{1} Tuổi:{2}",
            this.StudentID, this.fullName, this.Age);
        }
    }
    class program
    {
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách toàn bộ  thông tin sinh viên ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }

        static void DisplayStudentsByAgeRange(List<Student> studentList, int minAge, int maxAge)
        {
            Console.WriteLine("=== Danh sách sinh viên có tuổi từ 15 đến 18===", minAge, maxAge);
            var students = studentList.Where(s => s.Age >= minAge && s.Age <= maxAge);
            foreach (var student in students)
            {
                student.Show();
            }
        }

        static void DisplayStudentsByNameStartingWithA(List<Student> studentList)
        {
            const string StartLetter = "A";

            Console.WriteLine("=== Danh sách sinh viên có tên bắt đầu bằng chữ A ===");

            var students = studentList.Where(s => {
                var nameParts = s.FullName.Split(' ');
                string lastName = nameParts[nameParts.Length - 1];
                return lastName.StartsWith(StartLetter, StringComparison.OrdinalIgnoreCase);
            }).ToList();

            foreach (var student in students)
            {
                student.Show();
            }
        }

        static void CalculateTotalAge(List<Student> studentList)
        {
            int totalAge = studentList.Sum(s => s.Age);
            Console.WriteLine($"Tổng tuổi của tất cả sinh viên: {totalAge}");
        }

        static void FindOldestStudent(List<Student> studentList)
        {

            int maxAge = studentList.Max(s => s.Age);
            var oldestStudent = studentList.FirstOrDefault(s => s.Age == maxAge);
            Console.WriteLine("=== Sinh viên có tuổi lớn nhất ===");
            oldestStudent.Show();  // Hiển thị sinh viên lớn tuổi nhất


        }

        static void SortStudentsByAgeAscending(List<Student> studentList)
        {
            var sortedStudents = studentList.OrderBy(s => s.Age).ToList();
            Console.WriteLine("=== Danh sách sinh viên sắp xếp theo tuổi tăng dần ===");
            foreach (var student in sortedStudents)
            {
                student.Show();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            List<Student> studentList = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Hiển thị sinh viên từ 15 đến 18 tuổi");
                Console.WriteLine("4. Hiển thị sinh viên có tên bắt đầu bằng chữ A");
                Console.WriteLine("5. Tính tổng tuổi của tất cả sinh viên");
                Console.WriteLine("6. Tìm sinh viên có tuổi lớn nhất");
                Console.WriteLine("7. Sắp xếp sinh viên theo tuổi tăng dần");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chuc nang (0-7): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);

                        break;
                    case "2":
                        DisplayStudentList(studentList);

                        break;
                    case "3":
                        DisplayStudentsByAgeRange(studentList, 15, 18);
                        break;
                    case "4":
                        DisplayStudentsByNameStartingWithA(studentList);
                        break;
                    case "5":
                        CalculateTotalAge(studentList);
                        break;
                    case "6":
                        FindOldestStudent(studentList);
                        break;
                    case "7":
                        SortStudentsByAgeAscending(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");

                        break;
                }
                Console.WriteLine();
            }
        }
    }
}