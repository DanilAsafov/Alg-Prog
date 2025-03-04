using System;
using System.Collections.Generic;
class Program {
    public static void Calculation(string input) {
        Stack<int> stack = new Stack<int>();
        string[] array = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (array.Length == 0) {
            Console.WriteLine("Неверный ввод");
            return;
        }
        foreach (var i in array) {
            if (int.TryParse(i, out int number)) {
                stack.Push(number);
            } else {
                if (stack.Count < 2) {
                    Console.WriteLine("Неверный ввод");
                    return;
                }
                int s1 = stack.Pop();
                int s2 = stack.Pop();

                switch (i) {
                    case "+":
                        stack.Push(s2 + s1);
                        break;
                    case "-":
                        stack.Push(s2 - s1);
                        break;
                    case "*":
                        stack.Push(s2 * s1);
                        break;
                    case "/":
                        if (s1 == 0) {
                            Console.WriteLine("Ошибка: деление на ноль");
                            return;
                        }
                        stack.Push(s2 / s1);
                        break;
                    default:
                        Console.WriteLine($"Неизвестная операция: {i}");
                        return;
                }
            }
        }
        
        if(stack.Count == 1) {
            int result = stack.Pop();
            Console.WriteLine($"Результат: {result}");
        } else {
            Console.WriteLine("Неверный ввод");
        }
    }

    static void Main() {
        Console.WriteLine("Введите выражение в польской записи (допустимые операции: '+', '-', '*', '/'): ");
        string? input = Console.ReadLine();
        Calculation(input);
    }
}
