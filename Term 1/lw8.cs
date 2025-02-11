using System;
class Program {
    static void Filling(int[] array) {
        Console.WriteLine("Введите элементы массива: ");
        for (int i = 0; i < array.Length; i++) {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    static int SearchMax(int[] array) {
        int max = array[0];
        for (int i = 1; i < array.Length; i++) {
            if (array[i] > max) {
                max = array[i];
            }
        }
        return max;
    }

    static int SearchMin(int[] array) {
        int min = array[0];
        for (int i = 1; i < array.Length; i++) {
            if (array[i] < min) {
                min = array[i];
            }
        }
        return min;
    }



    static void Main() {
        Console.Write("Введите размерность зубчатого массива: ");
        int n = Convert.ToInt32(Console.ReadLine()); 
        int[][] m = new int[n][];
        for (int i = 0; i < n; i++) {
            Console.Write($"Введите размерность массива {i + 1}: ");
            int size = Convert.ToInt32(Console.ReadLine());
            m[i] = new int[size];
            Filling(m[i]);
        }
        for (int i = 0; i < m.Length; i++) {
            int max = SearchMax(m[i]);
            int min = SearchMin(m[i]);
            Console.WriteLine($"Массив {i + 1}: Максимум - {max}, Минимум - {min}");
        }
    }
}
