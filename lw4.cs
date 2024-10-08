using System;
namespace Project {
    class lw4 {
        static void Main() {
            int n, input, cnt1 = 0, cnt2 = 0, past = 0, present = 0, min = int.MaxValue, max = 0, max_sum = int.MinValue;
            Console.WriteLine("Введите значение n: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Введите {i + 1} число: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (i == 0)                                        // подпоследовательность из равных четных элементов (№2)
                    past = input;
                if (input == past && Math.Abs(input) % 2 == 0)
                    cnt2++;
                else {
                    if (cnt2 > max)
                        max = cnt2;
                    cnt2 = 0;
                    if (Math.Abs(input) % 2 == 0)
                        cnt2++;
                }
                past = input; 
                if (cnt2 == n)
                    max = cnt2;
                

                
                if (input % 2 == 0) {                             // сумма подпоследовательности из четных элементов (№3)
                    present += input;
                    if (present < input)
                        present = Math.Max(present, input);
                    max_sum = Math.Max(max_sum, present);
                } else 
                    present = 0;
                

                    
                if (input == 1)                                   // подпоследовательность из единиц (№1)
                    cnt1++;
                else {     
                    if (cnt1 < min && cnt1 > 0)
                        min = cnt1;  
                    cnt1 = 0;
                }
                if (cnt1 == n)
                    min = cnt1;



            }
            if (cnt1 < min && cnt1 > 0)
                min = cnt1;
            if (min == int.MaxValue)
                min = 0;
            if (cnt2 > max)
                max = cnt2;
            if (max_sum == int.MinValue)
                max_sum = 0;
            Console.WriteLine($"Минимальный размер подпоследовательности из единиц: {min}");
            Console.WriteLine($"Максимальный размер подпоследовательности из одинаковых четных элкментов: {max}");
            Console.WriteLine($"Максимальная сумма подпоследовательности из четных элементов: {max_sum}");
        } 
    }
}