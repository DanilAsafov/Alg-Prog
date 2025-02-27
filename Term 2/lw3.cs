using System;
using System.Collections.Generic;
class Program {
    public static bool Check(string input) {
        Stack<char> stack = new Stack<char>();
        foreach (char i in input) {
            if (i == '(' || i == '[' || i == '{') {
                stack.Push(i);
            } else if (i == ')' || i == ']' || i == '}') {
                if (stack.Count == 0)
                    return false;
                char top = stack.Pop();
                if ((i == ')' && top != '(') || (i == ']' && top != '[') || (i == '}' && top != '{'))
                    return false;  
            }
        }
        return stack.Count == 0;
    }

    static void Main() {
        Console.WriteLine("Введите подпоследовательность символов: ");
        string? input = Console.ReadLine();
        Console.WriteLine(Check(input) ? "Условие выполняется" : "Условие не выполняется");
    }
}