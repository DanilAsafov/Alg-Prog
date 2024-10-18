using System;
namespace Project {
    class Program {
        static void Main() {    
            int even_reverse = 0;
            bool odd = true;
            while(true) {
                Console.WriteLine("Введите число: ");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input <= 0) {
                    break;
                }
                while(input > 0) {
                    int r_number = input % 10;
                    if (r_number % 2 == 0) {
                        odd = false;
                        even_reverse = even_reverse * 10 + r_number;
                    }
                    input /= 10;
                }
            }
            if (odd)
                Console.WriteLine("Четных цифр в числе нет");
            else
                Console.WriteLine($"Результат: {even_reverse}");     
        } 
    }
}