using System;
public struct Book(string AuthorFullName, string Name, string ReleaseYear, string Publishing, string ID) {
    public string AuthorFullName = AuthorFullName;
    public string Name = Name;
    public string ReleaseYear = ReleaseYear;
    public string Publishing = Publishing;
    public string ID = ID;
}


public class Formular(Book Book) {
    public Book Book = Book;
    public List<Accounting> BorrowHistory = [];
}


public class Accounting(string BorrowDate, string ReturnDate) {
    public string BorrowDate = BorrowDate;
    public string ReturnDate = ReturnDate;
}


class Program {
    static Dictionary<Book, Formular> LibraryDatabase = [];

    static void AddingBook() {
        while (true) {
            try {
                Console.Write("Введите ФИО автора книги: ");
                string? author_full_name = Console.ReadLine();

                Console.Write("Введите название книги: ");
                string? name = Console.ReadLine();

                Console.Write("Введите год выпуска книги: ");
                string? release_year = Console.ReadLine();

                Console.Write("Введите название издательства: ");
                string? publishing = Console.ReadLine();

                Console.Write("Введите ID книги: ");
                string? id = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(author_full_name) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(release_year) ||
                string.IsNullOrWhiteSpace(publishing) || string.IsNullOrWhiteSpace(id)) {
                    throw new Exception("Ошикба ввода: пустая строка");
                }

                Book book = new(author_full_name, name, release_year, publishing, id);
                LibraryDatabase.Add(book, new(book));
                Console.WriteLine("Книга добавлена\n");
                break;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }

    static void FillingBorrowHistory() {
        while (true) {
            try {
                Console.Write("Введите ID книги: ");
                string? id = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(id)) {
                    throw new Exception("Ошибка: пустая строка");
                }
                foreach (var book in LibraryDatabase) {
                    if (book.Key.ID == id) {
                        Console.Write("Введите число сессий в истории книги: ");
                        int sessions = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < sessions; i++) {
                            Console.WriteLine("Введите дату выдачи или 0, если книга не выдавалась: ");
                            string? borrow_date = Console.ReadLine();
                            Console.WriteLine("Введите дату выдачи или 0, если книга не сдавалась: ");
                            string? return_date = Console.ReadLine();

                            book.Value.BorrowHistory.Add(new(borrow_date, return_date));
                        }
                    }
                }
                Console.WriteLine("История заполнена\n");
                break;

            } catch (FormatException) {
                Console.WriteLine("Ошибка ввода");
                continue;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }

    static void SearchByNotBorrowing() {
        Console.WriteLine("Результаты:\n");
        foreach (var book in LibraryDatabase) {
            foreach (var session in book.Value.BorrowHistory) {
                if (session.BorrowDate == "0") {
                    Console.WriteLine($"ФИО автора: {book.Key.AuthorFullName}\nНазвание: {book.Key.Name}\nГод выпуска: {book.Key.ReleaseYear}\nИздательство: {book.Key.Publishing}\nID: {book.Key.ID}\n");
                }
            }
        }
    }   

    static void SearchByNotReturned() {
        Console.WriteLine("Результаты:\n");
        foreach (var book in LibraryDatabase) {
            foreach (var session in book.Value.BorrowHistory) {
                if (session.ReturnDate == "0") {
                    Console.WriteLine($"ФИО автора: {book.Key.AuthorFullName}\nНазвание: {book.Key.Name}\nГод выпуска: {book.Key.ReleaseYear}\nИздательство: {book.Key.Publishing}\nID: {book.Key.ID}\n");
                }
            }
        }
    }
    
    static void Main() {
        string? choice = "";
        while (choice != "5") {
            Console.WriteLine("Заполнение базы:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Заполнить историю выдачи книги");
            Console.WriteLine("3. Вывести сведения о книгах, которые ни разу не выдавались");
            Console.WriteLine("4. Вывести сведения о книгах, которые еще не сданы");
            Console.WriteLine("5. Выход");
            Console.Write("Введите номер действия: ");
            choice = Console.ReadLine();
    
            switch (choice) {
                case "1":
                    AddingBook();
                    break;
                case "2":
                    FillingBorrowHistory();
                    break;
                case "3": 
                    SearchByNotBorrowing();    
                    break;
                case "4":     
                    SearchByNotReturned();
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