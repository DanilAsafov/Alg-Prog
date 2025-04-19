using System;
class Point(int x, int y) {
    public int x = x;
    public int y = y;

    public void Move(int deltaX, int deltaY) {
        x += deltaX;
        y += deltaY;
        Console.WriteLine($"Новые координаты: ({x}, {y})");
    }

    public static void ExitMessage() {
        Console.WriteLine("Точка вышла за границы");
    }
}


class Monitor {
    public delegate void ExitHandler();
    public event ExitHandler OnExited;

    public void Check(Point point, int length, int width) {
        if (point.x < 0 || point.x > length || point.y < 0 || point.y > width) {
            OnExited?.Invoke();
        }
    }
}


class Program {
    static void Main() {
        int length = 100;
        int width = 50;
        Random random = new();
        
        Point point = new(random.Next(0, length + 1), random.Next(0, width + 1));
        Console.WriteLine($"Координаты точки: ({point.x}, {point.y})");

        Monitor monitor = new();
        monitor.OnExited += Point.ExitMessage;

        for (int i = 0; i < 10; i++) {
            int deltaX = random.Next(-15, 16);
            int deltaY = random.Next(-15, 16);
            
            point.Move(deltaX, deltaY);
            monitor.Check(point, length, width);
        }
    }
}