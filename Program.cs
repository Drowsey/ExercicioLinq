using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using ExercicioLinq.Entities;

namespace ExercicioLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            List<Employee> list = new List<Employee>();

            Console.WriteLine("Enter the file path: ");
                string path = Console.ReadLine();
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] data = sr.ReadLine().Split(',');
                        string name = data[0];
                        string email = data[1];
                        double salary = double.Parse(data[2], CultureInfo.InvariantCulture);

                        list.Add(new Employee(name, email, salary));
                    }
                    Console.Write("Enter salary: ");
                    double minSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    var emails = list.Where(e => e.Salary >= minSalary).OrderBy(e => e.Email).Select(e => e.Email);
                    foreach(string email in emails)
                    {
                        Console.WriteLine(email);
                    }

                    Console.Write("Sum of salary of people whose name starts with 'M': $ ");
                    var salSum = list.Where(e => e.Name[0] == 'M').Select(e => e.Salary).Sum();
                    Console.WriteLine(salSum.ToString("F2", CultureInfo.InvariantCulture));



                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
