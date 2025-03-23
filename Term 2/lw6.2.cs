using System;
class IntClass {
    public int First {get; set;}
    public int Second {get; set;}

    public IntClass(int first, int second) {
        First = first;
        Second = second;
    }

    public int Add(int first, int second) => first + second;

    public int Subtract(int first, int second) => first - second;

    public int Multiply(int first, int second) => first * second;

    public int Divide(int first, int second) {
        if (second == 0) {
            throw new DivideByZeroException("Ошибка: деление на ноль");
        }
        return first / second;
    }
}


class Program {
    delegate int Operations(int first, int second);

    static void Main() {
        IntClass obj = new IntClass(10, 11);

        Operations operations1 = null;
        Operations operations2 = null;

        operations1 += obj.Add;
        operations1 += obj.Subtract;
        operations1 += obj.Multiply;

        operations2 += obj.Multiply;
        operations2 += (first, second) => obj.Subtract(first, obj.First);
        operations2 += (first, second) => obj.Divide(first, obj.First);

        Console.WriteLine("Первая последовательность операций:");
        int result = obj.First;
        foreach (Operations op in operations1.GetInvocationList()) {
            result = op(result, obj.Second);
            Console.WriteLine($"Результат: {result}");
        }

        Console.WriteLine("Вторая последовательность операций:");
        result = obj.First;
        foreach (Operations op in operations2.GetInvocationList()) {
            result = op(result, obj.Second);
            Console.WriteLine($"Результат: {result}");
        }
    }
}