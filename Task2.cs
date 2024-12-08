using System;

// Абстрактний клас, що описує стандартний калькулятор
public abstract class AbstractCalc
{
    protected string model;

    public AbstractCalc(string model)
    {
        this.model = model;
    }

    public string GetModel()
    {
        return model;
    }

    // Абстрактні методи для арифметичних операцій
    public abstract double Add(double a, double b);
    public abstract double Subtract(double a, double b);
    public abstract double Multiply(double a, double b);
    public abstract double Divide(double a, double b);
}

// Клас для стандартного калькулятора
public class OrdinaryCalc : AbstractCalc
{
    public OrdinaryCalc(string model) : base(model) { }

    public override double Add(double a, double b) => a + b;
    public override double Subtract(double a, double b) => a - b;
    public override double Multiply(double a, double b) => a * b;
    public override double Divide(double a, double b) => a / b;
}

// Інтерфейс для інженерних операцій
public interface IAdvanced
{
    double Sine(double angle);  // Обчислення синуса
    double Cosine(double angle); // Обчислення косинуса
}

// Клас для інженерного калькулятора
public class AdvancedCalc : OrdinaryCalc, IAdvanced
{
    public AdvancedCalc(string model) : base(model) { }

    public double Sine(double angle) => Math.Sin(angle);
    public double Cosine(double angle) => Math.Cos(angle);
}

// Головний клас програми
public class MainClass ///*
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Виберіть тип калькулятора:");
        Console.WriteLine("1. Стандартний калькулятор");
        Console.WriteLine("2. Інженерний калькулятор");
        int choice = int.Parse(Console.ReadLine());

        AbstractCalc calc = null;

        if (choice == 1)
        {
            calc = new OrdinaryCalc("Стандартний калькулятор");
        }
        else if (choice == 2)
        {
            calc = new AdvancedCalc("Інженерний калькулятор");
        }

        Console.WriteLine($"Обрано калькулятор: {calc.GetModel()}");
        
        // Вибір операції
        Console.WriteLine("Виберіть операцію:");
        Console.WriteLine("1. Додавання");
        Console.WriteLine("2. Віднімання");
        Console.WriteLine("3. Множення");
        Console.WriteLine("4. Ділення");
        Console.WriteLine("5. Синус (тільки для інженерного калькулятора)");
        Console.WriteLine("6. Косинус (тільки для інженерного калькулятора)");

        int operation = int.Parse(Console.ReadLine());

        double result = 0;
        double a, b;

        if (operation >= 1 && operation <= 4)
        {
            Console.WriteLine("Введіть перше число:");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть друге число:");
            b = double.Parse(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    result = calc.Add(a, b);
                    break;
                case 2:
                    result = calc.Subtract(a, b);
                    break;
                case 3:
                    result = calc.Multiply(a, b);
                    break;
                case 4:
                    result = calc.Divide(a, b);
                    break;
            }
        }
        else if (operation == 5 || operation == 6)
        {
            Console.WriteLine("Введіть кут в радіанах:");
            a = double.Parse(Console.ReadLine());

            if (operation == 5)
                result = ((IAdvanced)calc).Sine(a);
            else if (operation == 6)
                result = ((IAdvanced)calc).Cosine(a);
        }

        Console.WriteLine($"Результат: {result}");
    }
}
