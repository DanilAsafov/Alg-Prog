using System;
using System.Collections.Generic;
class Program {
    static bool Equal(int[,] m, int c1, int c2, int n) {
        HashSet<int> c1_elements = new HashSet<int>();
        for (int i = 0; i < n; i++) {
            c1_elements.Add(m[i, c1]);
        }
        for (int i = 0; i < n; i++) {
            if (!c1_elements.Contains(m[i, c2])) {
                return false;
            }
        }
        return true;
    }



    static int Count(int[,] m, int s) {
        int cnt = 0;
        for (int j = 0; j < m.GetLength(1); j++) {
            if (m[s, j] == 0)
                cnt++;
        }
        return cnt;
    }



    static void Sort(int[,] m, int n) {
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - i - 1; j++) {
                if (Count(m, j) < Count(m, j + 1)) {
                    for (int k = 0; k < n; k++) {
                        int t = m[j, k];
                        m[j, k] = m[j + 1, k];
                        m[j + 1, k] = t;
                    }
                }
            }
        }
    }



    static void Change(int[,] m, int n) {
        int min = int.MaxValue;
        int max = int.MinValue;
        (int min_r, int min_c) = (-1, -1);
        (int max_r, int max_c) = (-1, -1);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (m[i, j] < min) {
                    min = m[i, j];
                    min_r = i;
                    min_c = j;
                }
                if (m[i, j] > max) {
                    max = m[i, j];
                    max_r = i;
                    max_c = j;
                }
            }
        }
        if (min_r != -1 && max_r != -1) {
            m[min_r, min_c] = max;
            m[max_r, max_c] = min;
        }
    }



    static void Main() {
        Console.Write("Введите размерность массива n: ");
        int n = Convert.ToInt16(Console.ReadLine());
        int[,] m = new int[n, n];
        bool found = false;
        for (int i = 0; i < n; i++) {
            Console.WriteLine($"Введите элементы {i + 1}-го ряда: ");
            for (int j = 0; j < n; j++) {
                m[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        for (int c1 = 0; c1 < n; c1++) {
            for (int c2 = c1 + 1; c2 < n; c2++) {
                if (Equal(m, c1, c2, n)) {
                    Console.WriteLine($"Столбцы {c1 + 1} и {c2 + 1} содержат одинаковые элементы");
                    found = true;
                }
            }
        }
        if (!found) {
            Console.WriteLine("Нет столбцов с одинаковыми элементами");
        }
        Sort(m, n);
        Console.WriteLine("Отсортированный массив: ");
        for (int i = 0; i < n; i ++) {
            for (int j = 0; j < n; j++) {
                Console.Write(m[i, j] + " ");
            }
            Console.WriteLine();
        }
        Change(m, n);
        Console.WriteLine("Массив после замены максимального и минимального элемента:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write(m[i, j] + " ");
            }
            Console.WriteLine();
        }
    }   
}

