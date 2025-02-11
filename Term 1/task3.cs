using System;
namespace forpractice
{
    class Program
    {
        static void Main()
        {
            int l = 3, m = 3, p = 5, n = 10; //результаты при подстановке различных n совпадают
            Console.WriteLine(n * (2 * (p + m) + (l * (n + 1)))); 
        }
    }
}
