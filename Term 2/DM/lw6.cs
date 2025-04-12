using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Console.Write("Введите количество вершин графа: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] distances = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i == j) {
                    distances[i, j] = 0;
                    continue;
                }

                while (true) {
                    Console.Write($"Введите вес ребра {i + 1} - {j + 1} или 0, если ребра нет: ");
                    try {
                        int val = Convert.ToInt32(Console.ReadLine());
                        distances[i, j] = val == 0 ? int.MaxValue : val;
                        break;

                    } catch (FormatException) {
                        Console.WriteLine("Неверный ввод. Введите число");
                    }
                }
            }
        }

        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (distances[i, k] != int.MaxValue && distances[k, j] != int.MaxValue) {
                        int sum = distances[i, k] + distances[k, j];
                        if (sum < distances[i, j]) {
                            distances[i, j] = sum;
                        }
                    }
                }
            }

            bool negativeCycle = false;
            for (int i = 0; i < n; i++) {
                if (distances[i, i] < 0) {
                    negativeCycle = true;
                    break;
                }
            }

            if (negativeCycle) {
                Console.WriteLine("Обнаружен цикл отрицательного веса");
                return;
            }
        }

        Console.WriteLine("\nРезультат:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (distances[i, j] == int.MaxValue) {
                    Console.Write("∞" + " ");
                } else {
                    Console.Write($"{distances[i, j]}" + " ");
                }
            }
            Console.WriteLine();
        }
    }
}