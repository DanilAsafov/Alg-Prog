using System;
using System.Collections.Generic;
using System.Linq;

public class Edge(int weight, int from, int to) {
    public int Weight = weight;
    public int From = from;
    public int To = to;
}


class Program {
    public static Dictionary<int, List<Edge>> ways = [];
    
    static Tuple<int, int>? GraphAnalysis(int[][] matrix) {
        int n = matrix.GetLength(0);
        List<int> source = [];
        List<int> drain = [];
        for (int i = 0; i < n; i++) {
            bool isSource = true, isDrain = true;
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] != 0)
                    isDrain = false;
                if (matrix[j][i] != 0)
                    isSource = false;
            }
            if (isSource)
                source.Add(i);
            if (isDrain)
                drain.Add(i);
        }
        if (source.Count == 0 || drain.Count == 0) {
            Console.WriteLine("Граф не является сетью");
            return null;
        } else if (source.Count > 1 || drain.Count > 1) {
            Console.WriteLine("Граф несвязный");
            return null;
        }
        return new Tuple<int, int>(source[0], drain[0]);
    }


    static bool Search(int source, int drain, out Dictionary<int, (int, Edge)> parent) {
        parent = [];
        var queue = new Queue<int>();
        var visited = new HashSet<int>();

        queue.Enqueue(source);
        visited.Add(source);

        while (queue.Count > 0) {
            int u = queue.Dequeue();
            if (ways.ContainsKey(u)) {
                foreach (var edge in ways[u]) {
                    int v = edge.To;
                    if (!visited.Contains(v) && edge.Weight > 0) {
                        parent[v] = (u, edge);
                        visited.Add(v);
                        queue.Enqueue(v);
                        if (v == drain)
                            return true;
                    }
                }
            }
        }
        return false;
    }

    static void Main() {
        Console.Write("Введите число вершин сети: ");
        int n = Convert.ToInt16(Console.ReadLine());
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++) {
            Console.Write($"Введите {i + 1} строку матрицы через пробел (нет ребра - 0): ");
            matrix[i] = [.. Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];
        }

        var result = GraphAnalysis(matrix);
        if (result == null)
            return;
        (int source, int drain) = result;
        
        ways = [];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int capacity = matrix[i][j];
                if (capacity > 0) {
                    if (!ways.ContainsKey(i))
                        ways[i] = [];
                    ways[i].Add(new Edge(capacity, i, j));
                    if (!ways.ContainsKey(j))
                        ways[j] = [];
                    ways[j].Add(new Edge(0, j, i));
                }
            }
        }

        int maxFlow = 0;

        while (Search(source, drain, out var parent)) {
            var path = new List<Edge>();
            int current = drain;
            while (parent.ContainsKey(current)) {
                var edge = parent[current].Item2;
                path.Add(edge);
                current = parent[current].Item1;
            }
            path.Reverse();

            int minResidual = path.Min(e => e.Weight);
            maxFlow += minResidual;

            foreach (var edge in path) {
                edge.Weight -= minResidual;
                var reverseEdge = ways[edge.To].First(e => e.From == edge.To && e.To == edge.From);
                reverseEdge.Weight += minResidual;
            }
        }
        Console.WriteLine($"Максимальный поток: {maxFlow}");
    }
}