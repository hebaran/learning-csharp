using System;
using System.Linq;
using System.Globalization;

namespace StudentsAveragList
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
            
            var allNames = new List<string>(studentsAmount);
            var allGrades = new List<List<double>>(studentsAmount);

            for (int studentIndex = 0; studentIndex < studentsAmount; studentIndex++)
            {
                Console.Clear();
                Console.Write($"Nome do aluno {studentIndex + 1}: ");
                string studentName = Console.ReadLine() ?? "";
                
                allNames.Add(studentName);

                var studentGrades = new List<double>(gradesAmount);

                for (int gradeIndex = 1; gradeIndex <= gradesAmount; gradeIndex++)
                {
                    double actualGrade = ReadDouble($"Nota {gradeIndex}: ");
                    studentGrades.Add(actualGrade);
                }

                allGrades.Add(studentGrades);
            }

            Console.Clear();
            Console.WriteLine("======== Resultados ========");
            
            for (int studentIndex = 0; studentIndex < studentsAmount; studentIndex++)
            {
                List<double> actualGrades = allGrades[studentIndex];
                double studentAverage = GetAverage(actualGrades);
                string studentSituation = GetSituation(studentAverage);
                string studentName = allNames[studentIndex]; 
                
                Console.WriteLine($"Aluno {studentIndex + 1}: {studentName}");

                foreach ((double grade, int position) in actualGrades.Select((grade, position) => (grade, position + 1)))
                {
                    Console.WriteLine($"Nota {position}: {grade}");
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
