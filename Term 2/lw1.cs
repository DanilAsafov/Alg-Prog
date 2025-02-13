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
    public List<Phone> phone_list {get; set;}

    public User(string full_name, string city_of_residence, List<Phone> phone_list) {
        this.full_name = full_name;
        this.city_of_residence = city_of_residence;
        this.phone_list = phone_list;
    }
}


class Program {
    static List<User> user_list = new List<User>();

    static void AddingPhone(User new_user) {
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
            new_user.phone_list.Add(new Phone(name, number, date));
            break;
        }
    }

    static void AddingUser() {
        while (true) {
            Console.Write("Введите ФИО: ");
            string? full_name = Console.ReadLine();
            Console.Write("Введите город проживания: ");
            string? city_of_residence = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(full_name) || string.IsNullOrWhiteSpace(city_of_residence)) {
                Console.WriteLine("Неверный ввод");
                continue;
            }
            User new_user = new User(full_name, city_of_residence, new List<Phone>());
            Console.Write("Введите количество номеров телефона пользователя: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                AddingPhone(new_user);
            }
            user_list.Add(new_user);
            Console.WriteLine("Пользователь добавлен");
            break;
        }
    }

    static void SearchByDateOfConclusion() {
        Console.Write("Введите дату заключения договора (число.месяц.год): ");
        string? date = Console.ReadLine();
        int cnt = 0;
        Console.WriteLine("Результаты поиска: ");
        foreach (User user in user_list) {
            var result = user.phone_list.Where(i => i.date_of_conclusion == date).ToList();
            if (result.Count == 0) {
                continue;
            } else {
                cnt++;
                Console.WriteLine($"ФИО: {user.full_name}. Город проживания: {user.city_of_residence}");
                foreach (Phone phone in user.phone_list) {
                    Console.WriteLine($"Имя оператора: {phone.telecom_operator}. Номер телефона: {phone.number}. Дата заключения договора: {phone.date_of_conclusion}");
                }
            }
        }
        if (cnt == 0)
            Console.WriteLine("Нет результатов с указанной датой");
    }

    static void SearchByOperator() {
        Console.Write("Введите имя оператора: ");
        string? name = Console.ReadLine();
        int cnt = 0;
        Console.WriteLine("Результаты поиска: ");
        foreach (User user in user_list) {
            var result = user.phone_list.Where(i => i.telecom_operator == name).ToList();
            if (result.Count == 0) {
                continue;
            } else {
                cnt++;
                Console.WriteLine($"ФИО: {user.full_name}. Город проживания: {user.city_of_residence}");
                foreach (Phone phone in user.phone_list) {
                    Console.WriteLine($"Имя оператора: {phone.telecom_operator}. Номер телефона: {phone.number}. Дата заключения договора: {phone.date_of_conclusion}");
                }
            }
        }
        if (cnt == 0)
            Console.WriteLine("Нет результатов с указанным именем оператора");
    }

    static void SearchByNumber() {
        Console.Write("Введите номер телефона: ");
        string? number = Console.ReadLine();
        int cnt = 0;
        Console.WriteLine("Результаты поиска: ");
        foreach (User user in user_list) {
            var result = user.phone_list.Where(i => i.number == number).ToList();
            if (result.Count == 0) {
                continue;
            } else {
                cnt++;
                Console.WriteLine($"ФИО: {user.full_name}. Город проживания: {user.city_of_residence}");
                foreach (Phone phone in user.phone_list) {
                    Console.WriteLine($"Имя оператора: {phone.telecom_operator}. Номер телефона: {phone.number}. Дата заключения договора: {phone.date_of_conclusion}");
                }
            }
        }
        if (cnt == 0)
            Console.WriteLine("Нет результатов с указанным номером телефона");
    }

    static void Main() {
        string? choice = "";
        while (choice != "5") {
            Console.WriteLine("Заполнение базы:");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Выборка по дате заключения договора");
            Console.WriteLine("3. Выборка по оператору связи");
            Console.WriteLine("4. Выборка по номеру телефона");
            Console.WriteLine("5. Выход");
            Console.Write("Введите номер действия: ");
            choice = Console.ReadLine();
    
            switch (choice) {
                case "1":
                    AddingUser();
                    break;
                case "2":
                    SearchByDateOfConclusion();
                    break;
                case "3":     
                    SearchByOperator();
                    break;
                case "4":
                    SearchByNumber();
                    break;
                case "5":
                    Console.WriteLine("Выход");
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}