using System;

namespace HW2
{
    // Định nghĩa lớp Person
    class Person
    {
        private string name;
        private string address;
        private double salary;

        // Constructor mặc định
        public Person() { }

        // Constructor có tham số
        public Person(string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        // Getter và Setter
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        // Hàm nhập và kiểm tra thông tin Person
        public static Person inputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrEmpty(sSalary))
            {
                throw new Exception("You must input Salary.");
            }

            double salaryVal;
            // Kiểm tra xem sSalary có phải là số hợp lệ không
            bool isNumber = double.TryParse(sSalary, out salaryVal);
            if (!isNumber)
            {
                throw new Exception("You must input digit.");
            }

            // Kiểm tra lương phải lớn hơn 0
            if (salaryVal <= 0)
            {
                throw new Exception("Salary is greater than zero");
            }

            return new Person(name, address, salaryVal);
        }

        // Hàm hiển thị thông tin một Person
        public static void displayPersonInfo(Person person)
        {
            Console.WriteLine("Information of Person you have entered:");
            Console.WriteLine("Name:" + person.Name);
            Console.WriteLine("Address:" + person.Address);
            Console.WriteLine("Salary:" + person.Salary);
        }

        // Hàm sắp xếp danh sách Person theo lương tăng dần bằng thuật toán Bubble Sort
        public static Person[] sortBySalary(Person[] personArray)
        {
            try
            {
                int n = personArray.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (personArray[j].Salary > personArray[j + 1].Salary)
                        {
                            // Hoổi chỗ 2 Person
                            Person temp = personArray[j];
                            personArray[j] = personArray[j + 1];
                            personArray[j + 1] = temp;
                        }
                    }
                }
                return personArray;
            }
            catch (Exception)
            {
                throw new Exception("Can't Sort Person");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3];

            // Function 1: Input Data cho 3 người
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("=====Management Person programer=====");
                Console.WriteLine("Input Information of Person");

                Console.Write("Please input name:");
                string name = Console.ReadLine();

                Console.Write("Please input address:");
                string address = Console.ReadLine();

                Person p = null;
                while (p == null)
                {
                    Console.Write("Please input salary:");
                    string sSalary = Console.ReadLine();
                    try
                    {
                        p = Person.inputPersonInfo(name, address, sSalary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                persons[i] = p;
            }

            // Function 2 & 3: Sắp xếp theo lương tăng dần và hiển thị
            try
            {
                Person.sortBySalary(persons);

                foreach (Person p in persons)
                {
                    Person.displayPersonInfo(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}