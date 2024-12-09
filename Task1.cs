// Comment
//Second comment
using System;

namespace SimpleCalculator
{
    // Основний калькулятор, що реалізує арифметичні операції
    public class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Помилка: Ділення на нуль!");
                return double.NaN;  // Повертає NaN (Not a Number) для помилки
            }
            return a / b;
        }
    }

    // Клас для інтерфейсу користувача
    public class UserInterface
    {
        private Calculator calculator = new Calculator();

        public void Start()
        {
            bool continueCalculating = true;

            while (continueCalculating)
            {
                Console.Clear();
                Console.WriteLine("Привіт! Це простий калькулятор.");
                Console.WriteLine("Оберіть операцію:");
                Console.WriteLine("1. Додавання");
                Console.WriteLine("2. Віднімання");
                Console.WriteLine("3. Множення");
                Console.WriteLine("4. Ділення");
                Console.WriteLine("5. Вийти");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    continueCalculating = false;
                    Console.WriteLine("До побачення!");
                    continue;
                }

                double num1, num2;
                Console.Write("Введіть перше число: ");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.Write("Будь ласка, введіть правильне число: ");
                }

                Console.Write("Введіть друге число: ");
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.Write("Будь ласка, введіть правильне число: ");
                }

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Результат: {num1} + {num2} = {calculator.Add(num1, num2)}");
                        break;
                    case "2":
                        Console.WriteLine($"Результат: {num1} - {num2} = {calculator.Subtract(num1, num2)}");
                        break;
                    case "3":
                        Console.WriteLine($"Результат: {num1} * {num2} = {calculator.Multiply(num1, num2)}");
                        break;
                    case "4":
                        double result = calculator.Divide(num1, num2);
                        if (!double.IsNaN(result))
                        {
                            Console.WriteLine($"Результат: {num1} / {num2} = {result}");
                        }
                        break;
                    default:
                        Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.Start();
        }
    }
}
