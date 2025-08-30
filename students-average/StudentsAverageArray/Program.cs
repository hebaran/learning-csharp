using System;
using System.Globalization;

namespace StudentsAverageArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int studentsAmount = ReadInt("Quantos alunos irá conferir? ");
            const int gradesAmount = 3;

            string[] studentNames = new string[studentsAmount];
            double[] studentGrades = new double[studentsAmount * gradesAmount];
            double[] studentAverage = new double[studentsAmount];

            for (int studentPosition = 0; studentPosition < studentsAmount; studentPosition++)
            {
                Console.Clear();
                Console.Write($"Nome do Aluno: ");
                studentNames[studentPosition] = Console.ReadLine() ?? "";

                for (int gradePosition = 0; gradePosition < gradesAmount; gradePosition++)
                {
                    double actualGrade = ReadDouble($"Nota {gradePosition + 1}: ");

                    int index = studentPosition * gradesAmount + gradePosition;
                    studentGrades[index] = actualGrade;
                }
            }

            for (int gradeIndex = 0; gradeIndex < studentsAmount; gradeIndex++)
            {
                int startGradeList = gradeIndex * gradesAmount;
                studentAverage[gradeIndex] = GetAverage(studentGrades, gradesAmount, startGradeList);
            }

            Console.Clear();
            Console.Write("===== Resultados =====");

            for (int gradeIndex = 0; gradeIndex < studentGrades.Length; gradeIndex++)
            {
                int correctGradeIndex = gradeIndex % gradesAmount + 1;
                int studentIndex = gradeIndex / gradesAmount;
                string actualStudent = studentNames[studentIndex];
                double actualGrade = studentGrades[gradeIndex];

                if (gradeIndex % gradesAmount == 0)
                {
                    Console.WriteLine($"\nAluno {studentIndex + 1}:");
                    Console.WriteLine(actualStudent);
                }

                Console.WriteLine($"Nota {correctGradeIndex}: {actualGrade}");

                if ((gradeIndex + 1) % gradesAmount == 0)
                {
                    double actualAverage = studentAverage[studentIndex];
                    string studentStatus = GetAverageStatus(actualAverage);

                    Console.WriteLine($"Média: {actualAverage} -> {studentStatus}");
                }
            }
        }

        static double GetAverage(double[] allValues, int divisor, int start)
        {
            double average = 0;

            for (int valueOffset = 0; valueOffset < divisor; valueOffset++)
            {
                average += allValues[start + valueOffset];
            }

            average /= divisor;
            average = Math.Round(average, 2);

            return average;
        }

        static string GetAverageStatus(double value)
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

        static int ReadInt(string data)
        {
            Console.Write(data);
            int intConvert = int.Parse(Console.ReadLine() ?? "0");

            return intConvert;
        }

        static double ReadDouble(string data)
        {
            Console.Write(data);
            double doubleConvert = double.Parse((Console.ReadLine() ?? "0").Replace(",", "."), CultureInfo.InvariantCulture);

            return doubleConvert;
        }
    }
}
