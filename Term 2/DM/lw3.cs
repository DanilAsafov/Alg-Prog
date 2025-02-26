using System;
using System.Collections.Generic;
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
    static void Search(int[,] m, bool[] visited, int i) {
        visited[i] = true;
        int n = m.GetLength(0);
        for (int j = 0; j < n; j++) {
            if (m[i, j] != 0 && !visited[j]) {
                Search(m, visited, j);
            }
        }
    }

    static int CountComponents(int[,] m) {
        int n = m.GetLength(0);
        bool[] visited = new bool[n];
        int components = 0;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                Search(m, visited, i);
                components++;
            }
        }
        return components;
    }

    static void Main() {
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
                    m[i, j] = val;
                    if (i != j)
                        m[j, i] = val;
                    j++;
                } catch (FormatException) {
                    Console.WriteLine("Неверный ввод. Введите число");
                }
            }
        }

        int initial_components = CountComponents(m);
        List<Edge> edges = new List<Edge>();
        bool[] visited= new bool[n];
        visited[0] = true;
        int cnt = 1;
        while (cnt < n) {
            (int min_weight, int from, int to) = (int.MaxValue, 0, 0);
            for (int i = 0; i < n; i++) {
                if (visited[i]) {
                    for (int j = 0; j < n; j++) {
                        if (!visited[j] && m[i, j] != 0 && m[i, j] < min_weight) {
                            min_weight = m[i, j];
                            from = i;
                            to = j;
                        }
                    }
                }
            }
            edges.Add(new Edge(min_weight, [from, to]));
            visited[to] = true;
            cnt++;
        }

        List<Edge> bridges = new List<Edge>();
        foreach (var edge in edges) {
            int i = edge.tops[0];
            int j = edge.tops[1];
            int edge_i_v = m[i, j];
            int edge_v_i = m[j, i];
            m[i, j] = 0;
            m[j, i] = 0;
            int current_components = CountComponents(m);
            m[i, j] = edge_i_v;
            m[j, i] = edge_v_i;
            if (current_components > initial_components)
                bridges.Add(edge);
        }
        if (bridges.Count == 0) {
            Console.WriteLine("В графе нет мостов");
            return;
        }
        Console.WriteLine("Мосты в графе:");
        foreach (var bridge in bridges) {
            Console.WriteLine($"Ребро {bridge.tops[0] + 1} - {bridge.tops[1] + 1} с весом {bridge.length}");
        }
    }
}