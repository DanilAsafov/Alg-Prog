using System;
public class Head {
    public string name {get; set;}
    public Head(string name) {
        this.name = name;
    }
}


public interface IValues {
    double Area();
    double Perimeter();
}


public class Circle : Head, IValues {
    public double radius {get; set;}

    public Circle(string name, double radius) : base(name) {
        this.radius = radius;
    }

    public double Area() {
        return Math.PI * radius * radius;
    }

    public double Perimeter() {
        return 2 * Math.PI * radius;
    }
}


public class Square : Head, IValues {
    public double side_length {get; set;}

    public Square(string name, double side_length) : base(name) {
        this.side_length = side_length;
    }

    public double Area() {
        return side_length * side_length;
    }

    public double Perimeter() {
        return 4 * side_length;
    }
}


public class EquilateralTriangle : Head, IValues{
    public double side_length {get; set;}

    public EquilateralTriangle(string name, double side_length) : base(name) {
        this.side_length = side_length;
    }

    public double Area() {
        return (Math.Sqrt(3) / 4) * side_length * side_length;
    }

    public double Perimeter() {
        return 3 * side_length;
    }
}


class Program {
    static void Main() {
        Circle circle = new Circle("Окружность", 5);
        Square square = new Square("Квадрат", 10);
        EquilateralTriangle triangle = new EquilateralTriangle("Равносторонний треугольник", 12);

        IValues[] shapes = {circle, square, triangle};

        foreach (var shape in shapes) {
            Console.WriteLine($"Фигура: {((Head) shape).name}");
            Console.WriteLine($"Площадь: {shape.Area()}");
            Console.WriteLine($"Периметр: {shape.Perimeter()}");
            Console.WriteLine();
        }
    }
}
