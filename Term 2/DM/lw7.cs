using System;
using System.Collections.Generic;

public class WavePathfinder {
    public bool[,] map;
    public int[,] wave;
    public int width;
    public int height;
    
    public List<(int x, int y)> FindPath(bool[,] grid, (int x, int y) start, (int x, int y) end) {
        map = grid;
        width = map.GetLength(0);
        height = map.GetLength(1);
        wave = new int[width, height];
        
        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                wave[x, y] = -1;
            }
        }
        
        if (!map[start.x, start.y] || !map[end.x, end.y])
            return null;

        Queue<(int x, int y)> queue = new();
        wave[start.x, start.y] = 0;
        queue.Enqueue(start);
        
        int[] dx = [0, 0, -1, 1];
        int[] dy = [-1, 1, 0, 0];
        
        bool pathFound = false;
        while (queue.Count > 0 && !pathFound) {
            var (x, y) = queue.Dequeue();
            for (int i = 0; i < 4; i++) {
                int nx = x + dx[i];
                int ny = y + dy[i];
                
                if (nx >= 0 && ny >= 0 && nx < width && ny < height) {
                    if (wave[nx, ny] == -1 && map[nx, ny]) {
                        wave[nx, ny] = wave[x, y] + 1;
                        queue.Enqueue((nx, ny));
                        if (nx == end.x && ny == end.y) {
                            pathFound = true;
                            break;
                        }
                    }
                }
            }
        }
        return ReconstructPath(start, end);
    }
    
    public List<(int x, int y)> ReconstructPath((int x, int y) start, (int x, int y) end) {
        if (wave[end.x, end.y] == -1) 
            return null;
        
        List<(int x, int y)> path = [];
        int[] dx = [0, 0, -1, 1];
        int[] dy = [-1, 1, 0, 0];
        
        var current = end;
        path.Add(current);
        
        while (current.x != start.x || current.y != start.y) {
            for (int i = 0; i < 4; i++) {
                int px = current.x + dx[i];
                int py = current.y + dy[i];
                
                if (px >= 0 && py >= 0 && px < width && py < height) {
                    if (wave[px, py] == wave[current.x, current.y] - 1) {
                        current = (px, py);
                        path.Add(current);
                        break;
                    }
                }
            }
        }
        path.Reverse();
        return path;
    }
}


class Program {
    static void Main() {
        bool[,] grid = {
            {true,  true,  true,  false, true},
            {false, false, true,  true, true}
        };
        
        var pathfinder = new WavePathfinder();
        var path = pathfinder.FindPath(grid, (0, 0), (1, 4));
        
        if (path != null) {
            Console.WriteLine("Путь:");
            foreach (var (x, y) in path) {
                Console.WriteLine($"[{x}, {y}]");
            }
        } else {
            Console.WriteLine("Путь не найден");
        }
    }
}