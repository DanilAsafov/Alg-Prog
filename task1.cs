using System;

public class HelloWorld
{
    public static void Main()
    {
        int a = 20, b = 15;
        a += b;
        b = a - b;
        a -= b;
        Console.WriteLine(a + "\n" + b);
    }
}