using System;
class Program {
    static void Main() {
        char[] m = {'a', 'e', 'i', 'o', 'u', 'y'};
        Console.WriteLine("Введите строку: ");
        string? s = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(s)) {
            Console.WriteLine("Строка введена неверно");
            return;
        }
        s = s.ToLower();
        string result = "";
        string[] s_array = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        (int count1, int count2, int count3, int count4) = (0, 0, 0, 0); 
        foreach (string p in s_array) {
            result = result + p + " ";
            for (int i = 0; i < p.Length; i++) {
                if ((i % 2 != 0) && (m.Contains(p[i])))
                    count1++;
                if (p[i] == 'a')
                    count4++;
            }
            if (count1 >= 1)
                count2 ++;
            count1 = 0;
            if (p.Length % 2 != 0 && p[0] == p[^1])
                count3++;
            if (count4 >= 1)
                Console.WriteLine(p); 
        }
        Console.WriteLine(result.Trim());
        Console.WriteLine($"Количество слов, в которых на четных местах стоят гласные буквы: {count2}");
        Console.WriteLine($"Количество слов, длина которых нечетная, а первый и последний символ совпадают: {count3}");
    } 
}
