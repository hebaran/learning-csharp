using System;
using System.Globalization;
using System.Collections.Generic;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsAmount;
            List<object> studentsGrades = [];

            Console.Clear();

            while (true)
            {
                Console.Write("Digite quantos alunos deseja cadastrar: ");
                string userInput = Console.ReadLine() ?? "0";
                bool convertToIntSuccess = int.TryParse(userInput, out studentsAmount);

                Console.Clear();
                if (convertToIntSuccess)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor incorreto! Digite um número\n");
                }
            }

            for (int studentPosition = 1; studentPosition <= studentsAmount; studentPosition++)
            {
                List<object> actualStudent = [];
                List<float> allGrades = [];

                Console.Clear();
                Console.WriteLine($"Aluno {studentPosition}: ");
                Console.Write($"Nome: ");
                string studentName = Console.ReadLine() ?? "";

                for (int gradePosition = 1; gradePosition <= 3; gradePosition++)
                {
                    Console.Write($"Nota {gradePosition}: ");
                    string gradeInput = Console.ReadLine() ?? "";
                    gradeInput = gradeInput.Replace(",", ".");
                    bool convertToFloatSuccess = float.TryParse(gradeInput, NumberStyles.Any, CultureInfo.InvariantCulture, out float actualGrade);

                    if (convertToFloatSuccess)
                    {
                        allGrades.Add(actualGrade);
                    }
                }

                double gradeAverage = 0;

                foreach (float grade in allGrades)
                {
                    gradeAverage += grade;
                }

                gradeAverage /= allGrades.Count;
                gradeAverage = Math.Round(gradeAverage, 2);

                actualStudent.Add(studentName);
                actualStudent.Add(allGrades);
                actualStudent.Add(gradeAverage);
                studentsGrades.Add(actualStudent);
            }

            Console.Clear();
            Console.WriteLine("=== Relatório Final ===");

            foreach (var studentData in studentsGrades)
            {
                List<object> actualSudenteData = (List<object>)studentData;

                string name = (string)actualSudenteData[0];
                double average = (double)actualSudenteData[2];
                string studentStatus;

                if (average >= 7)
                {
                    studentStatus = "Aprovado";
                }
                else if (average >= 5)
                {
                    studentStatus = "Recuperação";
                }
                else
                {
                    studentStatus = "Reprovado";
                }

                string studentPrintResult = String.Format($"{name} - Média: {average} - {studentStatus}");
                Console.WriteLine(studentPrintResult);
            }
        }
    }
}
