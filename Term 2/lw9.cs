using System;

public class MyArray<T> {
    private T[] Items;
    public int Count {get; set;}
    
    public MyArray() {
        Items = [];
    }

    public void Add(T item) {
        T[] newArray = new T[Count + 1];
        
        for (int i = 0; i < Count; i++) {
            newArray[i] = Items[i];
        }
        
        newArray[Count] = item;
        Items = newArray;
        Count++;
    }

    public void RemoveAt(int index) {
        CheckIndex(index);
        
        T[] newArray = new T[Count - 1];
        
        for (int i = 0; i < index; i++) {
            newArray[i] = Items[i];
        }
        
        for (int i = index + 1; i < Count; i++) {
            newArray[i - 1] = Items[i];
        }
        
        Items = newArray;
        Count--;
    }

    public T Get(int index) {
        CheckIndex(index);
        return Items[index];
    }

    private void CheckIndex(int index) {
        if (index < 0 || index >= Count) {
            throw new IndexOutOfRangeException("Неверный индекс");
        }
    }
}


class Program {
    static void Main() {
        MyArray<int> numbers = new();
        
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        
        Console.WriteLine("После добавления:");
        for (int i = 0; i < numbers.Count; i++) {
            Console.WriteLine($"Индекс {i}: {numbers.Get(i)}");
        }
  
        numbers.RemoveAt(1);
        
        Console.WriteLine("\nПосле удаления индекса 1:");
        for (int i = 0; i < numbers.Count; i++) {
            Console.WriteLine($"Индекс {i}: {numbers.Get(i)}");
        }
    
        MyArray<string> words = new MyArray<string>();
        words.Add("Hello");
        words.Add("World");
        
        Console.WriteLine("\nСтроковый массив:");
        Console.WriteLine(words.Get(0) + " " + words.Get(1));
    }
}