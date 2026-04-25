using System;
using System.Reflection.PortableExecutable;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Menu();

            var options = new string[4] { "1", "2", "3", "4"};
            double result = 0;
            char symbol = '\0';

            Console.Write(">> ");
            string userOption = Console.ReadLine() ?? "";

            if (Array.Exists(options, validOption => validOption == userOption))
            {
                Console.Write("Primeiro Número: ");
                double firstNumber = double.Parse(Console.ReadLine() ?? "0");
            
                Console.Write("Segundo Número: ");
                double secondNumber = double.Parse(Console.ReadLine() ?? "0");

                switch (userOption)
                {
                    case "1":
                        result = firstNumber + secondNumber;
                        symbol = '+';
                        break;
                    case "2":
                        result = firstNumber - secondNumber;
                        symbol = '-';
                        break;
                    case "3":
                        result = firstNumber * secondNumber;
                        symbol = '*';
                        break;
                    case "4":
                        if (secondNumber == 0)
                        {
                            Console.WriteLine("É impossível dividir qualquer número por 0!");
                            return;    
                        }

                        result = firstNumber / secondNumber;
                        symbol = '/';
                        break;
                }

                Console.Clear();
                Console.WriteLine($"{firstNumber} {symbol} {secondNumber} = {result}");
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }

        static void Menu()
        {
            Console.WriteLine("[1] - Soma");
            Console.WriteLine("[2] - Subtração");
            Console.WriteLine("[3] - Multiplicação");
            Console.WriteLine("[4] - Divisão");
        }
    }
}
