using System;
namespace Project {
    class Program {
        static void Main() {
            int n, input, max = 0, lmax = 0, smax = 0, past = 0, spast = 0, end5 = 0;
            bool odd = true;
            Console.WriteLine("Введите значение n: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Введите {i + 1} число: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (odd && Math.Abs(input) % 2 == 0)
                    odd = false;
                if (i == 0) {
                        max = input;
                        spast = input;
                } else {
                    if (i == 1)
                        past = input;
                    if (Math.Abs(input) % 10 == 5) {
                        end5++;
                    }
                    if (input >= max) {
                        smax = max;
                        max = input;
                    } else if (input > smax) {
                        smax = input;
                    }
                    if (i > 1) {
                        if (spast <= past && past >= input) {
                            lmax++;
                        }
                
                        spast = past;
                        past = input;
                    }
                }               
            }
            Console.WriteLine($"Локальный максимум: {lmax}\nВсе нечетные: {odd}\nВторой максимум: {smax}\nОкончание на 5: {end5}");
        }
    }
}
