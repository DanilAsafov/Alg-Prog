using System;
using System.Collections.Generic;

public class Edge (int from, int to, int weight) {
    public int From {get; set;} = from;
    public int To {get; set;} = to;
    public int Weight {get; set;} = weight;
}


class Program {
    static void Main() {
        Console.Write("Введите количество вершин графа: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] m = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i == j) {
                    m[i, j] = 0;
                    continue;
                }

                while (true) {
                    Console.Write($"Введите вес ребра {i + 1} - {j + 1} или 0, если ребра нет: ");
                    try {
                        int val = Convert.ToInt32(Console.ReadLine());
                        m[i, j] = val;
                        break;

                    } catch (FormatException) {
                        Console.WriteLine("Неверный ввод. Введите число");
                    }
                }
            }
        }

        int a;
        while (true) {
            try {
                Console.Write("Выберите точку входа: ");
                int from = Convert.ToInt32(Console.ReadLine());
                if (from > n || from < 1) {
                    Console.WriteLine($"Ошибка: номер должен быть от 1 до {n}");
                    continue;
                }
    
                a = --from;
                break;

            } catch (FormatException) {
                Console.WriteLine("Неверный ввод. Введите число");
                continue;
            }
        }

        int[] distances = new int[n];
        int[] parents = new int[n];
        List<Edge> edges = [];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (m[i, j] != 0) {
                    edges.Add(new(i, j, m[i, j]));
                }
            }
            distances[i] = int.MaxValue;
            parents[i] = -1;
        }
        distances[a] = 0;

        for (int i = 0; i < n - 1; i++) {
            Console.WriteLine($"\nИтерация {i + 1}: ");
            foreach (var edge in edges) {
                if (distances[edge.From] != int.MaxValue &&
                    distances[edge.To] > distances[edge.From] + edge.Weight) {
                    distances[edge.To] = distances[edge.From] + edge.Weight;
                    parents[edge.To] = edge.From;
                }
            }
            for (int j = 0; j < n; j++) {
                Console.WriteLine($"До вершины {j + 1}: {(distances[j] == int.MaxValue ? "∞" : distances[j])}");
            }
        }

        bool negativeCycle = false;
        foreach (var edge in edges) {
            if (distances[edge.From] != int.MaxValue &&
                distances[edge.To] > distances[edge.From] + edge.Weight) {
                    negativeCycle = true;
                    break;
            }
        }

        if (negativeCycle) {
            Console.WriteLine("\nОбнаружен отрицательный цикл");
        } else {
            Console.WriteLine("\nРезультаты:");
            for (int i = 0; i < n; i++) {
                Console.WriteLine($"До вершины {i + 1}: {(distances[i] == int.MaxValue ? "Недостижима" : distances[i])}");
                if (distances[i] != int.MaxValue && i != a) {
                    List<int> path = [];
                    for (int current = i; current != -1; current = parents[current])
                        path.Add(current + 1);
                    path.Reverse();
                    Console.WriteLine($"Путь: {string.Join(" -> ", path)}\n");
                }
            }
        }
    }
}