using System;
class Phone {
    public string number {get; set;}
    public string telecomOperator {get; set;}
    
    public Phone(string number, string telecomOperator) {
        this.number = number;
        this.telecomOperator = telecomOperator;
    }
}


class Program {
    public static List<Phone> phone_list = [];
    public static Dictionary<string, int> operator_list = [];

    static void AddingPhone() {
        while (true) {
            try {
                Console.Write("Введите номер телефона: ");
                string? number = Console.ReadLine();
                if (string.IsNullOrEmpty(number)) {
                    throw new ArgumentException();
                }

                Console.Write("Введите имя оператора: ");
                string? telecom_operator = Console.ReadLine();
                if (string.IsNullOrEmpty(telecom_operator)) {
                    throw new ArgumentException();
                }

                phone_list.Add(new(number, telecom_operator));
                
                if (operator_list.ContainsKey(telecom_operator)) {
                    operator_list[telecom_operator]++;
                } else {
                    operator_list.Add(telecom_operator, 1);
                }

                Console.WriteLine("Телефон добавлен");
                break;

            } catch (ArgumentException) {
                Console.WriteLine("Неверный ввод");
                continue;
            }
        }
    }

    static void Output() {
        foreach (var phone in phone_list) {
            Console.WriteLine($"Номер телефона: {phone.number}\nИмя оператора: {phone.telecomOperator}\nКоличество номеров в базе у оператора: {operator_list[phone.telecomOperator]}\n");
        }
    }

    static void Main() {
        string? choice = "";
        while (choice != "3") {
            Console.WriteLine("1. Добавление телефона");
            Console.WriteLine("2. Вывод базы");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите действие: ");
            choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    AddingPhone();
                    break;
                case "2":
                    Output();
                    break;
                case "3":
                    Console.WriteLine("Выход");
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}