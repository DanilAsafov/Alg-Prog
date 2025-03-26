using System;
using System.Collections.Generic;

class Program {
    public static void Dijkstra(int[,] graph, int from) {
        int nodes = graph.GetLength(0);
        int[] distances = new int[nodes];
        bool[] visited = new bool[nodes];

        for (int i = 0; i < nodes; i++) {
            distances[i] = int.MaxValue;
        }
        distances[from] = 0;

        for (int count = 0; count < nodes - 1; count++) {
            int min = int.MaxValue;
            int current = -1;

            for (int i = 0; i < nodes; i++) {
                if (!visited[i] && distances[i] <= min) {
                    min = distances[i];
                    current = i;
                }
            }

            if (current == -1)
                break;

            visited[current] = true;

            for (int neighbor = 0; neighbor < nodes; neighbor++) {
                if (graph[current, neighbor] != 0 && !visited[neighbor]) {
                    int newDistance = distances[current] + graph[current, neighbor];
                    if (newDistance < distances[neighbor]) {
                        distances[neighbor] = newDistance;
                    }
                }
            }
        }

        Console.WriteLine("Вершина\tРасстояние от старта");
        for (int i = 0; i < nodes; i++) {
            Console.WriteLine($"{i + 1}\t{(distances[i] == int.MaxValue ? "∞" : distances[i])}");
        }
    }
    

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
    
                a = from;
                break;

            } catch (FormatException) {
                Console.WriteLine("Неверный ввод. Введите число");
                continue;
            }
        }
        Dijkstra(m, --a);
    }
}