using System;
class Program {
    static void Main() {
        Console.Write("Введите максимальное количество монет: ");
        long max_n = Convert.ToInt64(Console.ReadLine());
        long count = 0;
        for (int z = 1;;z++) {
            long shift_z = 1L << z;
            long number = shift_z - 1;
            if (number > max_n)
                break;
            long k = max_n / number;
            count += k;
        }
        Console.WriteLine($"Количество комбинаций: {count}");
    }
}
// Пояснение:
// z = 1: 2 * n - k = 0
// z = 2: 2 * (2 * n - k) - k = 4 * n - 3 * k = 0
// z = z: 2 ^ z * n - (2 ^ z - 1) * k = 0
// => k = (2 ^ z * n) / (2 ^ z - 1)
