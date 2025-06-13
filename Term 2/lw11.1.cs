using System;
public class Phone(string number, string owner, string releaseYear, string telecomOperator) {
    public string Number = number;
    public string Owner = owner;
    public string ReleaseYear = releaseYear;
    public string TelecomOperator = telecomOperator;
}


class Program {
    static List<Phone> DataBase = [];

    static void Print(IEnumerable<Phone> collection) {
        foreach (var obj in collection) {
            Console.WriteLine($"Номер: {obj.Number}\nВладелец: {obj.Owner}\nГод выпуска: {obj.ReleaseYear}\nОператор: {obj.TelecomOperator}");
        }
    }

    static string Validation(string s) {
        while (true) {
            Console.Write(s);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Ошибка: пустая строка");
            } else {
                return input;
            }
        }
    }

    static void AddingPhone() {
        string number = Validation("Введите номер телефона: ");
        string owner = Validation("Введите имя владельца: ");
        string releaseYear = Validation("Введите год выпуска: ");
        string telecomOperator = Validation("Введите имя оператора: ");

        DataBase.Add(new(number, owner, releaseYear, telecomOperator));
    }

    static void SearchByTelecomOperator() {
        string input = Validation("Введите оператора связи: ");
        var selected = DataBase.Where(p => p.TelecomOperator.Equals(input, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Номера телефонов указанного оператора связи:");
        Print(selected);
    }

    static void SearchByReleaseYear() {
        string input = Validation("Введите год выпуска: ");
        var selected = DataBase.Where(p => p.ReleaseYear.Equals(input, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Данные за заданный год:");
        Print(selected);        
    }

    static void SearchByTelecomOperatorGrouping() {
        var selected = DataBase.GroupBy(p => p.TelecomOperator);
        Console.WriteLine("Группировка по оператору связи:");
        foreach (var obj in selected) {
            Print(obj);
        }
    }

    static void SearchByReleaseYearGrouping() {
        var selected = DataBase.GroupBy(p => p.ReleaseYear);
        Console.WriteLine("Группировка по году выпуска:");
        foreach (var obj in selected) {
            Print(obj);
        }
    }

    static void Main() {
        string? input = "";
        while (input != "6") {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить телефон");
            Console.WriteLine("2. Выдать все телефоны по заданному оператору связи");
            Console.WriteLine("3. Выдать все телефоны за заданный год");
            Console.WriteLine("4. Выдать все данные, сгруппированные по оператору связи");
            Console.WriteLine("5. Выдать все данные, сгруппированные по году выпуска");
            Console.WriteLine("6. Выход");
            Console.Write("Введите номер действия: ");
            input = Console.ReadLine();

            switch (input) {
                case "1":
                    AddingPhone();
                    break;
                case "2":
                    SearchByTelecomOperator();
                    break;
                case "3":
                    SearchByReleaseYear();
                    break;
                case "4":
                    SearchByTelecomOperatorGrouping();
                    break;
                case "5":
                    SearchByReleaseYearGrouping();
                    break;
                case "6":
                    Console.WriteLine("Выход");
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}