using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StudentsPOO
{
    class Program
    {
        public const int gradesAmount = 3;

        public static void Main(string[] args)
        {
            var gradeArray = new double[] { 1, 2, 3 };
            var gradeList = new List<double>(gradesAmount) { 1, 2, 3 };

            Student pedro = new Student("Pedro");
            Student maria = new Student("Maria", gradeArray);
            Student marcos = new Student("Marcos", gradeList);

            var students = new List<Student>(3) { pedro, maria, marcos };

            Console.Clear();

            foreach (var student in students)
            {
                Console.WriteLine("=============");
                Console.WriteLine(student.Name);
                student.ShowGrades();
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public double[] Grades { get; set; }

        public Student(string name = "Desconhecido", IEnumerable<double>? grades = null)
        {
            Name = name;
            Grades = new double[Program.gradesAmount];

            if (grades != null)
            {
                Grades = grades.ToArray();
            }
        }

        public void ShowGrades()
        {
            foreach (double grade in Grades)
            {
                Console.WriteLine(grade.ToString("F2", new CultureInfo("pt-BR")));
            }
        }
    }
}
