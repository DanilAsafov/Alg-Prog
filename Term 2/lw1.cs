using System;
using System.Dynamic;
class Phone {
    public string telecom_operator {get; set;}
    public string number {get; set;}
    public string date_of_conclusion {get; set;}
    
    public Phone(string telecom_operator, string number, string date_of_conclusion) {
        this.telecom_operator = telecom_operator;
        this.number = number;
        this.date_of_conclusion = date_of_conclusion;
    }
}


class User {
    public string full_name {get; set;}
    public string city_of_residence {get; set;}

    public User(string full_name, string city_of_residence) {
        this.full_name = full_name;
        this.city_of_residence = city_of_residence;
    }
}


class Program {
    static List<User> user_list = new List<User>();
    static List<Phone> phone_list = new List<Phone>();

    static void AddingPhone() {
        while (true) {
            Console.Write("Введите имя оператора: ");
            string? name = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string? number = Console.ReadLine();
            Console.Write("Введите дату заключения договора (число.месяц.год): ");
            string? date = Console.ReadLine();
            if ((name == "") || (number == "") || (date == "")) {
                Console.WriteLine("Неверный ввод");
                continue;
            }
            phone_list.Add(new Phone(name, number, date));
            Console.WriteLine("Телефон добавлен");
            break;
        }
    }

    static void AddingUser() {
        while (true) {
            Console.Write("Введите ФИО: ");
            string? full_name = Console.ReadLine();
            Console.Write("Введите город проживания: ");
            string? city_of_residence = Console.ReadLine();
            if ((full_name == "") || (city_of_residence == "")) {
                Console.WriteLine("Неверный ввод");
                continue;
            }
            user_list.Add(new User(full_name, city_of_residence));
            Console.WriteLine("Пользователь добавлен");
            break;
        }
    }

    static void SearchByDateOfConclusion() {
        Console.Write("Введите дату заключения договора (число.месяц.год): ");
        string? date = Console.ReadLine();
        var result = phone_list.Where(i => i.date_of_conclusion == date).ToList();
        if (result.Count > 0) {
            Console.WriteLine("Результаты поиска: ");
            for (int i = 0; i < result.Count; i++) {
                int index = phone_list.IndexOf(result[i]);
                Console.WriteLine($"ФИО: {user_list[index].full_name}. Город проживания: {user_list[index].city_of_residence}. Оператор: {result[i].telecom_operator}. Номер: {result[i].number}. Дата заключения договора: {result[i].date_of_conclusion}");
            }
        } else {
            Console.WriteLine("Нет результатов с указанной датой");
        }
    }

    static void SearchByOperator() {
        Console.Write("Введите имя оператора: ");
        string? name = Console.ReadLine();
        var result = phone_list.Where(i => i.telecom_operator == name).ToList();
        if (result.Count > 0) {
            Console.WriteLine("Результаты поиска: ");
            for (int i = 0; i < result.Count; i++) {
                int index = phone_list.IndexOf(result[i]);
                Console.WriteLine($"ФИО: {user_list[index].full_name}. Город проживания: {user_list[index].city_of_residence}. Оператор: {result[i].telecom_operator}. Номер: {result[i].number}. Дата заключения договора: {result[i].date_of_conclusion}");
            }
        } else {
            Console.WriteLine("Нет результатов с указанным оператором");
        }
    }

    static void SearchByNumber() {
        Console.Write("Введите номер телефона: ");
        string? number = Console.ReadLine();
        var result = phone_list.Where(i => i.number == number).ToList();
        if (result.Count > 0) {
            Console.WriteLine("Результаты поиска: ");
            for (int i = 0; i < result.Count; i++) {
                int index = phone_list.IndexOf(result[i]);
                Console.WriteLine($"ФИО: {user_list[index].full_name}. Город проживания: {user_list[index].city_of_residence}. Оператор: {result[i].telecom_operator}. Номер: {result[i].number}. Дата заключения договора: {result[i].date_of_conclusion}");
            }
        } else {
            Console.WriteLine("Нет результатов с указанным номером");
        }
    }

    static void Main() {
        string? choice = "";
        while (choice != "6") {
            Console.WriteLine("Заполнение базы:");
            Console.WriteLine("1. Добавить телефон");
            Console.WriteLine("2. Добавить пользователя");
            Console.WriteLine("3. Выборка по дате заключения договора");
            Console.WriteLine("4. Выборка по оператору связи");
            Console.WriteLine("5. Выборка по номеру телефона");
            Console.WriteLine("6. Выход");
            Console.Write("Введите номер действия: ");
            choice = Console.ReadLine();
    
            switch (choice) {
                case "1":
                    AddingPhone();
                    break;
                case "2":
                    AddingUser();
                    break;
                case "3":
                    SearchByDateOfConclusion();
                    break;
                case "4":     
                    SearchByOperator();
                    break;
                case "5":
                    SearchByNumber();
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