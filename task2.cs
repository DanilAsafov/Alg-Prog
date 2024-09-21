using System;

public class HelloWorld
{
    public static void Main()
    {
        int a = 25, b = 35;
        Console.WriteLine ((a + b + Math.Abs(a-b)) / 2);
        Console.WriteLine ((a + b - Math.Abs(a-b)) / 2);
    }
}