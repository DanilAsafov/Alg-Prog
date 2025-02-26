using System;
using System.ComponentModel;
public class Edge : IComparable<Edge> {
    public int length {get; set;}
    public int[] tops {get; set;}
    public Edge(int length, int[] tops) {
        this.length = length;
        this.tops = tops;
    }
    public int CompareTo(Edge other) => length.CompareTo(other.length);
}


class Program {
    static void Main() {
        List<Edge> edges = [];
        Console.Write("Введите количество вершин неориентированного графа: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] m = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i;) {
                if (i == j) {
                    j++;
                    continue;
                }
                Console.Write($"Введите вес ребра {i + 1} - {j + 1} или 0, если ребра нет: ");
                try {
                    int val = Convert.ToInt32(Console.ReadLine());
                    edges.Add(new Edge(val, [i, j]));
                    m[i, j] = val;
                    if (i != j)
                        m[j, i] = val;
                    j++;
                } catch (FormatException) {
                    Console.WriteLine("Неверный ввод. Введите число");
                }
            }
        }

        bool[] visited = new bool[n];                                    //первый алгоритм
        visited[0] = true;
        (int cnt, int result, int top) = (1, 0, 0);
        int way;
        while (cnt != n) {
            way = int.MaxValue;
            for (int i = 0; i < n; i++) {
                if (!visited[i])
                    continue;
                for (int j = 0; j < n; j++) {
                    if (visited[j])
                        continue;
                    if (m[i, j] != 0 && m[i, j] < way) {
                        way = m[i, j];
                        top = j;
                    }
                }
            }
            result += way;
            visited[top] = true;
            cnt++;
        }
        Console.WriteLine($"Результат (первый алгоритм): {result}");

        edges.Sort();                                                   //второй алгоритм
        visited = new bool[n];
        (cnt, result) = (0, 0);
        foreach (var edge in edges) {
            int[] tops = edge.tops;
            if (visited[tops[0]] && visited[tops[1]] || m[tops[0], tops[1]] == 0)
                continue;
            result += edge.length;
            for (int i = 0; i < tops.Length; i++) {
                if (!visited[tops[i]]) {
                    cnt += 1;
                    visited[tops[i]] = true;
                }
            }
            if (cnt == n)
                break;
        }
        Console.WriteLine($"Результат (второй алгоритм): {result}");
    }
}