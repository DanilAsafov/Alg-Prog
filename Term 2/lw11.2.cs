using System;
public class Item(string id, string name) {
    public string ID = id;
    public string Name = name;
}


public class Supplier(string id, string name) {
    public string ID = id;
    public string Name = name;
}


public class Motion(string itemID, string supplierID, string operationType, 
int itemCount, double cost, string date) {
    public string ItemID = itemID;
    public string SupplierID = supplierID;
    public string OperationType = operationType;
    public int ItemCount = itemCount;
    public double Cost = cost;
    public string Date = date;
}


class Program {
    static Dictionary<Item, Motion> DataBase = [];

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

    static void AddingItem() {
        string itemName = Validation("Введите имя товара: ");
        string itemID = Validation("Введите ID товара: ");
        string operationType = Validation("Введите тип операции (поставка/продажа): ");

        string supplierName = null, supplierID = null;
        if (operationType != "продажа") {
            supplierName = Validation("Введите имя поставщика: ");
            supplierID = Validation("Введите ID поставщика: ");
        }

        int itemCount; double cost;
        while (true) {
            itemCount = int.TryParse(Validation("Введите количество товара: "), out var result1) ? result1 : -1;
            cost = double.TryParse(Validation("Введите цену товара: "), out var result2) ? result2 : -1;
            if (itemCount < 0 || cost < 0) {
                Console.WriteLine("Ошибка: неверный ввод");            
            } else {
                break;
            }
        }

        string date = Validation("Введите дату: ");
        
        var supplier = new Supplier(supplierID, supplierName);
        DataBase.Add(new(itemID, itemName), new(itemID, supplier.ID, operationType, itemCount, cost, date));
    }

    static void ShowRemainingItems() {
        var items = DataBase.Keys;
        Console.WriteLine("Остатки товаров:");
        foreach (var item in items) {
            var inCount = DataBase.Values
                .Where(m => m.ItemID == item.ID && m.OperationType == "поставка")
                .Sum(m => m.ItemCount);
                
            var outCount = DataBase.Values
                .Where(m => m.ItemID == item.ID && m.OperationType == "продажа")
                .Sum(m => m.ItemCount);
                
            int remaining = inCount - outCount;
            Console.WriteLine($"{item.ID} {item.Name} - {remaining} шт.");
        }
    }

    static void SearchBySuppliesGrouping() {
        var suppliers = new Dictionary<string, List<Motion>>();
        foreach (var pair in DataBase) {
            var motion = pair.Value;
            if (motion.OperationType == "поставка") {
                if (!suppliers.ContainsKey(motion.SupplierID))
                    suppliers[motion.SupplierID] = [];
                suppliers[motion.SupplierID].Add(motion);
            }
        }

        Console.WriteLine("Поставки товаров, сгруппированные по поставщику:");
        foreach (var supplier in suppliers) {
            Console.WriteLine($"Поставщик {supplier.Key}:");
            foreach (var motion in supplier.Value) {
                var item = DataBase.Keys.First(i => i.ID == motion.ItemID);
                Console.WriteLine($"{item.Name} - {motion.ItemCount} шт.");
            }
        }
    }

    static void ShowSalesGroupedByDate() {
        var salesByDate = new Dictionary<string, List<Motion>>();
        foreach (var pair in DataBase) {
            var motion = pair.Value;
            if (motion.OperationType == "продажа") {
                if (!salesByDate.ContainsKey(motion.Date))
                    salesByDate[motion.Date] = [];
                salesByDate[motion.Date].Add(motion);
            }
        }

        Console.WriteLine("Продажи товаров, сгруппированные по дате:");
        foreach (var dateGroup in salesByDate) {
            Console.WriteLine($"Дата {dateGroup.Key}:");
            foreach (var motion in dateGroup.Value) {
                var item = DataBase.Keys.First(i => i.ID == motion.ItemID);
                Console.WriteLine($"{item.Name} - {motion.ItemCount} шт.");
            }
        }
    }

    static void ShowTotalRevenue() {
        double total = 0;
        foreach (var pair in DataBase) {
            var motion = pair.Value;
            if (motion.OperationType == "продажа")
                total += motion.ItemCount * motion.Cost;
        }
        Console.WriteLine($"Общая выручка от продаж: {total}");
    }

    static void ShowTopSupplier() {
        var supplierTotals = new Dictionary<string, int>();
        foreach (var pair in DataBase) {
            var motion = pair.Value;
            if (motion.OperationType == "поставка") {
                if (!supplierTotals.ContainsKey(motion.SupplierID))
                    supplierTotals[motion.SupplierID] = 0;
                supplierTotals[motion.SupplierID] += motion.ItemCount;
            }
        }

        string topSupplier = "";
        int maxCount = 0;
        foreach (var pair in supplierTotals) {
            if (pair.Value > maxCount) {
                maxCount = pair.Value;
                topSupplier = pair.Key;
            }
        }

        Console.WriteLine($"Поставщик с максимальными поставками: {topSupplier}");
        Console.WriteLine($"Общее количество поставленного товара: {maxCount}");
    }

    static void Main() {
        string? input = "";
        while (input != "7") {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Выдать отстатки товаров");
            Console.WriteLine("3. Выдать поставки товаров, сгруппированные по поставщику");
            Console.WriteLine("4. Выдать продажи товаров, сгруппированных по дате");
            Console.WriteLine("5. Выдать выручку от продаж");
            Console.WriteLine("6. Выдать поставщика, который поставил максимальное количество товара");
            Console.WriteLine("7. Выход");
            Console.Write("Введите номер действия: ");
            input = Console.ReadLine();

            switch (input) {
                case "1":
                    AddingItem();
                    break;
                 case "2":
                    ShowRemainingItems();
                    break;
                case "3":
                    SearchBySuppliesGrouping();
                    break;
                case "4":
                    ShowSalesGroupedByDate();
                    break;
                case "5":
                    ShowTotalRevenue();
                    break;
                case "6":
                    ShowTopSupplier();
                    break;
                case "7":
                    Console.WriteLine("Выход");
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}