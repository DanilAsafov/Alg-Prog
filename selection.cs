using System;
class Program {
    static int Groups(int n) {
        if (n < 3)
            return 0;
        if (n == 3)
            return 1;
        else {
            int even_count = n / 2;
            int odd_count = n - even_count;
            return Groups(even_count) + Groups(odd_count);
        }
    }   
    
    
    static void Main() {
        string s = File.ReadAllText(@"C:\Users\MV\OneDrive\Рабочий стол\Алгоритмизация и программирование\ргр\input_s1_10.txt");
        int n = Convert.ToInt32(s);
        int count = Groups(n);
        Console.WriteLine($"Количество групп по 3 человека: {count}");
    }
}