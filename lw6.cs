using System;
namespace Project {
    class Program {
        static void Main() {
            int n, cnt = 0, past = 0, d = 0, present, t, mx = int.MinValue, max_i = 0, mn = int.MaxValue, min_i = 0;
            bool s = false;  
            Console.Write("Введите длину массива: ");
            n = Convert.ToInt16(Console.ReadLine());
            int[] m = new int[n]; 
            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Введите {i + 1} элемент массива");
                m[i] = Convert.ToInt32(Console.ReadLine());
                present = m[i];
                if (present > mx) {
                    mx = present;
                    max_i = i;
                }
                if (present < mn) {
                    mn = present;
                    min_i = i;
                }
                if (Math.Abs(present) % 10 == 3)
                    cnt++;
                if (i == 0)
                    past = present;
                else {
                    if (i == 1)
                        d = (present - past); 
                    if (((present - past) == d) && (d > 0))
                        s = true;
                    else
                        s = false;     
                }
                past = present;
            }
            t = m[max_i];
            m[max_i] = m[min_i];
            m[min_i] = t;
            var str = string.Join(" ", m);
            Console.WriteLine($"Количество элемнтов, оканчивающихся на 3: {cnt}");
            if (s == true)
                Console.WriteLine("Элементы массива являются равномерно возрастающей последовательностью");
            else
                Console.WriteLine("Элементы массива не являются равномерно возрастающей последовательностью");
            Console.WriteLine($"Измененный массив: {str}");
                
        } 
    }
}