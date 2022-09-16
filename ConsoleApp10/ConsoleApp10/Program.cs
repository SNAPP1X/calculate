using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; 
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Консольный калькулятор\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.Write("Введите значене и нажмите ENTER: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Ошибка. Введите другое значение: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Введите второе значение и нажмите ENTER: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Ошибка. Введите другое значение: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Выберите операнда:");
                Console.WriteLine("\ta - Сложение");
                Console.WriteLine("\ts - Вычитание");
                Console.WriteLine("\td - Умножение");
                Console.WriteLine("\tf - Деление");
                Console.Write("Ваше? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Оператор приводит к ошибке.\n");
                    }
                    else Console.WriteLine("Ваш результат: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("При попытке вычисления, произошло математическое исключение.\n - Детали: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Нажмите 'n' и Enter чтобы закрыть, или другую кнопку и Enter чтобы продолжить: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}