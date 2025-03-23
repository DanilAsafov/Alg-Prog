using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
class Car {
    public string mark {get; set;}
    public string full_name {get; set;}
    public string release {get; set;}
    public bool washed {get; set;}

    public Car(string mark, string full_name, string release, bool washed) {
        this.mark = mark;
        this.full_name = full_name;
        this.release = release;
        this.washed = washed;
    }
}


class Garage {
    public List<Car> car_list {get; set;} = [];
}


class CarWash {
    public void Washing(Car car) {
        if (car.washed) {
            Console.WriteLine($"Машина {car.mark} уже была помыта");
        } else {
            car.washed = true;
            Console.WriteLine($"Машина {car.mark} теперь помыта");
        }
    }
}


class Program {
    static void AddingCar() {
        while (true) {
            try {
                Console.Write("Введите марку машины: ");
                string? mark = Console.ReadLine();
                if (string.IsNullOrEmpty(mark)) {
                    throw new ArgumentException();
                }

                Console.Write("Введите ФИО владельца: ");
                string? full_name = Console.ReadLine();
                if (string.IsNullOrEmpty(full_name)) {
                    throw new ArgumentException();
                }

                Console.Write("Введите год выпуска машины: ");
                string? release = Console.ReadLine();
                if (string.IsNullOrEmpty(release)) {
                    throw new ArgumentException();
                }

                Console.Write("Машина помыта (true или false)? ");
                string? isWashed = Console.ReadLine();
                if (string.IsNullOrEmpty(isWashed)) {
                    throw new ArgumentException();
                }

                bool washed = Convert.ToBoolean(isWashed);
                garage.car_list.Add(new Car(mark, full_name, release, washed));
                Console.WriteLine("Машина добавлена");
                break;

            } catch (ArgumentException) {
                Console.WriteLine("Неверный ввод");
                continue;
            }
        }
    }

    static void Wash() {
        WashCarDelegate car_wash_delegate;
        CarWash car_wash = new();
        car_wash_delegate = car_wash.Washing;
        foreach (var car in garage.car_list) {
            car_wash_delegate(car);
        }
        Console.WriteLine("Все машины помыты");
    }

    static void Output() {
        foreach (var car in garage.car_list) {
            Console.WriteLine($"Марка: {car.mark}\nВладелец: {car.full_name}\nГод выпуска: {car.release}\nПомыта: {car.washed}\n");
        }
    }

    public delegate void WashCarDelegate(Car car);

    public static Garage garage = new();

    static void Main() {
        string? choice = "";
        while (choice != "4") {
            Console.WriteLine("1. Добавить автомобиль");
            Console.WriteLine("2. Помыть все автомобили");
            Console.WriteLine("3. Вывод базы");
            Console.WriteLine("4. Выход");
            Console.Write("Введите номер действия: ");
            choice = Console.ReadLine();
    
            switch (choice) {
                case "1":
                    AddingCar();
                    break;
                case "2":
                    Wash();
                    break;
                case "3":
                    Output();
                    break;
                case "4":
                    Console.WriteLine("Выход");
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}