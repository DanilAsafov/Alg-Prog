using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
class Program {
    static void Main() {
        try {
            Console.WriteLine("Введите список элементов целочисленного типа: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Ошибка: пустая стркоа");

            string[] array = input.Split([' ']);
            List<int> numbers = [];
            foreach (var element in array) {
                numbers.Add(Convert.ToInt32(element));
            }

            HashSet<int> unique_elements = [.. numbers];
            Console.WriteLine("Уникальные элементы:");
            foreach (var element in unique_elements) {
                Console.WriteLine(element);
            }
            
            Dictionary<int, int> frequency = [];
            foreach (var number in numbers) {
                if (frequency.ContainsKey(number)) {
                    frequency[number]++;
                } else {
                    frequency[number] = 1;
                }
            }
            int max_frequency = frequency.Values.Max();
            Console.WriteLine("Элементы с максимальной частотой:");
            foreach (var element in frequency) {
                if (element.Value == max_frequency) {
                    Console.WriteLine(element.Key);
                }
            }

        } catch (ArgumentException ex) {
          Console.WriteLine(ex.Message);
        }
    }
}
