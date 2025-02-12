using System;
using System.ComponentModel;
using System.Data;
class Program {
    static void Search(int[,] m, bool[] visited, int i, int n) {
        visited[i] = true;
        for (int j = 0; j < n; j++) {
            if (m[i, j] == 1 && !visited[j]) {
                Search(m, visited, j, n);
            }
        }
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
                    if ((val != 0) && (val != 1)) {
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
                Search(m, visited, i, n);
                result++;
            }
        }
        Console.WriteLine($"Число компонент связности графа: {result}");
    }
}
