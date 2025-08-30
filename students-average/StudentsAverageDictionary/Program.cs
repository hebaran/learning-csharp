using System;
using System.Linq;
using System.Globalization;

namespace StudentsAverageDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Quantos alunos deseja cadastrar?\n");
            Console.Write(">> ");
            int studentsAmount = int.Parse(Console.ReadLine() ?? "0");

            Console.Clear();
            Console.WriteLine("Quantas matérias cada aluno possui?\n");
            Console.Write(">> ");
            int gradesAmount = int.Parse(Console.ReadLine() ?? "0");

            var students = new Dictionary<string, List<double>>();

            for (int studentIndex = 0; studentIndex < studentsAmount; studentIndex++)
            {
                Console.Clear();
                Console.Write($"Nome do aluno {studentIndex + 1}: ");
                string studentName = Console.ReadLine() ?? "";

                var studentGrades = new List<double>(gradesAmount);

                for (int gradeIndex = 1; gradeIndex <= gradesAmount; gradeIndex++)
                {
                    double actualGrade = ReadDouble($"Nota {gradeIndex}: ");
                    studentGrades.Add(actualGrade);
                }

                students.Add(studentName, studentGrades);
            }

            Console.Clear();
            Console.WriteLine("======== Resultados ========");

            foreach ((var student, int studentPosition) in students.Select((student, studentPosition) => (student, studentPosition + 1)))
            {
                string studentName = student.Key;
                List<double> studentGrades = student.Value;
                double studentAverage = GetAverage(studentGrades);
                string studentSituation = GetSituation(studentAverage);

                Console.WriteLine($"Aluno {studentPosition}: {studentName}");

                foreach ((double grade, int gradePosition) in studentGrades.Select((grade, gradePosition) => (grade, gradePosition + 1)))
                {
                    Console.WriteLine($"Nota {gradePosition}: {grade}");
                }

                Console.WriteLine($"Média: {studentAverage} -> {studentSituation}\n");
            }
        }

        static double ReadDouble(string message)
        {
            Console.Write(message);
            double doubleConvert = double.Parse((Console.ReadLine() ?? "0").Replace(",", "."), CultureInfo.InvariantCulture);

            return doubleConvert;
        }

        static double GetAverage(IEnumerable<double> values)
        {
            return Math.Round(values.Average(), 2);
        }

        static string GetSituation(double value)
        {
            string response;

            if (value >= 6)
            {
                response = "Aprovado";
            }
            else if (value >= 4)
            {
                response = "Recuperação";
            }
            else
            {
                response = "Reprovado";
            }

            return response;
        }
    }
}
