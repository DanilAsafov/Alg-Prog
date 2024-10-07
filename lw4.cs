using System;
namespace Project {
    class Program {
        static void Main() {
            int n, input, cnt1 = 0, cnt2 = 0, cnt3 = 0, past = 0, h = 0, min = int.MaxValue, max = int.MinValue, max_sum = int.MinValue;
            Console.WriteLine("Введите значение n: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Введите {i + 1} число: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (i == 0)                                        //подпоследовательность из равных четных элементов (№2)
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
                

                
                if (Math.Abs(input) % 2 == 0) {                   //сумма подпоследовательности из четных элеиентов (№3)
                    cnt3 += input;
                    h = cnt3;
                } else {
                    max_sum = Math.Max(max_sum, cnt3);
                    cnt3 = 0;
                }
                
                
                    
                if (input == 1)                                   //подпоследовательность из единиц (№1)
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
            if (max == int.MinValue)
                max = 0;
            if (cnt2 > max)
                max = cnt2;
            if (h > max_sum)
                max_sum = h;    
            Console.WriteLine($"Минимальный размер подпоследовательности из единиц: {min}");
            Console.WriteLine($"Максимальный размер подпоследовательности из одинаковых четных элкментов: {max}");
            Console.WriteLine($"Максимальная сумма подпоследовательности из четных элементов: {max_sum}");
        } 
    }
}