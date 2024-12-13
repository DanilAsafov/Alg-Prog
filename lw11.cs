using System;
class First {
    public int field1;
    public int field2;

    public First() {
        field1 = 0;
        field2 = 0;
    }

    public First(int x) {
        field1 = x;
        field2 = 0;
    }

    public First(int x, int y) {
        field1 = x;
        field2 = y;
    }

    
    public int Addition() {
        return field1 + field2;
    }

    
    public int Subtraction() {
        return field1 - field2;
    }

    
    public int Multiplication() {
        return field1 * field2;
    }

    
    public double Division() {
        if (field2 == 0) {
            throw new DivideByZeroException();
        }
        return field1 / field2;
    }
}



class Program {
    static void Main() {
        First object1 = new First();
    
        Console.WriteLine("Введите параметр второго объекта (одно число): ");
        int n = Convert.ToInt32(Console.ReadLine());
        First object2 = new First(n);

        Console.WriteLine("Введите параметр третьего объекта (два числа, разделенные пробелом): ");
        string s = Console.ReadLine();
        string[] parameters = s.Split(' ');
        First object3 = new First(Convert.ToInt32(parameters[0]), Convert.ToInt32(parameters[1]));

        Console.WriteLine("\nОбъект 1:");
        Console.WriteLine($"Сложение: {object1.Addition()}");
        Console.WriteLine($"Разность: {object1.Subtraction()}");
        Console.WriteLine($"Произведение: {object1.Multiplication()}");
        try {
            Console.WriteLine($"Деление: {object1.Division()}");
        } catch (DivideByZeroException) {
            Console.WriteLine("Ошибка: деление на ноль");
        }

        Console.WriteLine("\nОбъект 2:");
        Console.WriteLine($"Сложение: {object2.Addition()}");
        Console.WriteLine($"Разность: {object2.Subtraction()}");
        Console.WriteLine($"Произведение: {object2.Multiplication()}");
        try {
            Console.WriteLine($"Деление: {object2.Division()}");
        } catch (DivideByZeroException) {
            Console.WriteLine("Ошибка: деление на ноль");
        }

        Console.WriteLine("\nОбъект 3:");
        Console.WriteLine($"Сложение: {object3.Addition()}");
        Console.WriteLine($"Разность: {object3.Subtraction()}");
        Console.WriteLine($"Произведение: {object3.Multiplication()}");
        try {
            Console.WriteLine($"Деление: {object1.Division()}");
        } catch (DivideByZeroException) {
            Console.WriteLine("Ошибка: деление на ноль");
        }
    }
}
