using System;
class Program {
    static int SymbolCount(string s, char x) {
        int count = 0;
        for (int i = 0; i < s.Length - 2; i ++) {
            if (s[i] == 'a' && s[i + 1] == x && s[i + 2] == 'b')
                count++;
        }
        return count;
    }


    
    static void Main() {
        Console.Write("1) Введите строку: ");
        string? s1 = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(s1)) {
            Console.WriteLine("Строка введена неверно");
            return;
        }
        s1 = s1.ToLower();
        char[] letters = {'x', 'y', 'z'};
        (int max_length, int cur_length) = (0, 0);
        foreach (char i in s1) {
            if (i == letters[cur_length % 3]) {
                max_length = Math.Max(max_length, ++cur_length);
            } else if (i == letters[0]) {
                cur_length = 1;
            } else
                cur_length = 0;
        }
        Console.WriteLine(max_length);



        Console.Write("2) Введите строку: ");
        string? s2 = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(s2)) {
            Console.WriteLine("Строка введена неверно");
            return;
        }
        s2 = s2.ToLower();
        int count_min = int.MaxValue;
        string s_sub = "";
        for (int i = 0; i < s2.Length - 2; i++) {
            if (s2[i] == 'a' && s2[i + 2] == 'b') {
                int count = SymbolCount(s2, s2[i + 1]);
                if (count < count_min && s_sub.Contains(s2[i + 1]) == false) {
                    s_sub = Convert.ToString(s2[i + 1]);
                    count_min = count;
                }
                if (count == count_min && s_sub.Contains(s2[i + 1]) == false)
                    s_sub += s2[i + 1];
            }    
        }
        if (s_sub == "")
            Console.WriteLine("Строка введена неверно");
        foreach (char i in s_sub) {
            Console.WriteLine(i);
        }
    }
}
