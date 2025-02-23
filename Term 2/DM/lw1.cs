using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
class Program {
    static void Search(int[,] m, bool[] visited, int i) {       //первый алгоритм
        visited[i] = true;
        int number = m.GetLength(0);
        for (int j = 0; j <  number; j++) {
            if (m[i, j] == 1 && !visited[j]) {
                Search(m, visited, j);
            }
        }
    }

    static int Search2 (int[,] m) {                             //второй алгоритм
        int number = m.GetLength(0);
        int[] components = new int[number];
        int count = 0;
        for (int i = 0; i < number; i++) {
            if (components[i] == 0) {
                components[i] = ++count;
                for (int j = i + 1; j < number; j++) {
                    if (m[i, j] == 1 && components[j] == 0) {
                        components[j] = count;
                    }
                }
            }
        }
        for (int i = 0; i < number; i++) {
            for (int j = i + 1; j < number; j++) {
                if (m[i, j] == 1) {
                    components[i] = Math.Min(components[i], components[j]);
                    components[j] = Math.Min(components[i], components[j]);
                }
            }
        }
        return components.Max();
    }

    static void Main() {
        Console.Write("Введите количество вершин неориентированного графа: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] m = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= i; j++) {
                while (true) {
                    Console.WriteLine($"Связаны ли {i + 1} и {j + 1} вершины (1 - да, 0 - нет)?");
                    int val = Convert.ToInt32(Console.ReadLine());
                    if (val != 0 && val != 1) {
                        Console.WriteLine("Неверный ввод");
                        continue;
                    }
                    m[i, j] = val;
                    if (i != j)
                        m[j, i] = val;
                    break;
                }
            }
        }
        bool[] visited = new bool[n];
        int result = 0;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                Search(m, visited, i);
                result++;
            }
        }
        Console.WriteLine($"Число компонент связности графа (первый алгоритм): {result}");
        int result_2 = Search2(m);
        Console.WriteLine($"Число компонент связности графа (второй алгоритм): {result_2}");
    }
}
