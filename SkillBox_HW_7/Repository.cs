using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SkillBox_HW_7
{
    class Repository
    {
        private static string _path; // Путь к файлу
        private static int _index; // текущий элемент для добавления в employees (Счетчик записей о сотрудниках)
        private static int _indexId; // последний ID работника в DB
        private static readonly string[] _titles =
        {
            "ID", "Дата и время создания", "ФИО", "Возраст", "Рост", "Дата рождения", "Место рождения"
        }; // Массив заголовков

        private static List<Employee> employees = new List<Employee>(); // Коллекция


        /// <summary>
        ///     Пользовательское меню
        /// </summary>
        public void Menu()
        {
            Console.WriteLine(
                "\n\n1. Загрузка всех данных из файла.\n2. Добавление сотрудника.\n3. Удаление записи." +
                "\n4. Редактирование записи.\n5. Сохранить в файл.\n6. Загрузка данных в диапозоне дат." +
                "\n7. Сортировка по возрастанию даты создания записи.\n8. Сортировка по убыванию даты создания записи. " +
                "\n9. Очистить память.\n10. Выход.\n11. Изменение пути к файлу.");
            Console.Write("\nВыберите пункт меню: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _index = 0;
                    Load();
                    PrintToConsole();
                    break;
                case "2":
                    AddFromTheConsole();
                    PrintToConsole();
                    break;
                case "3":
                    Del();
                    PrintToConsole();
                    break;
                case "4":
                    Edit();
                    PrintToConsole();
                    break;
                case "5":
                    Console.Clear();
                    Save();
                    PrintToConsole();
                    Console.WriteLine($"\n\nДанные успешно сохранены в файл: {_path}");
                    break;
                case "6":
                    UploadByDate();
                    PrintToConsole();
                    break;
                case "7":
                    Console.Clear();
                    SortUp();
                    PrintToConsole();
                    break;
                case "8":
                    Console.Clear();
                    SortDn();
                    PrintToConsole();
                    break;
                case "9":
                    Console.Clear();
                    employees.Clear();
                    Console.WriteLine("\n\nПамять успешно очищена.");
                    break;
                case "10":
                    Environment.Exit(0);
                    break;
                case "11":
                    RequestPath();
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Вы не выбрали ни один пункт меню.\n");
                    PrintToConsole();
                    break;
            }
        }

        /// <summary>
        ///     Путь к файлу. Запрашиваем путь к файлу с данными
        /// </summary>
        public void RequestPath()
        {
            var o = true;

            while (o)
            {
                Console.WriteLine(
                    "Введите название файла и его расширение (txt) или весь путь к данному файлу:");
                _path = Console.ReadLine();

                o = CheckTxtRequestPath(o);
            }

        }

        /// <summary>
        ///     Загрузка данных в память из файла
        /// </summary>
        private static void Load()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    string[] param = sr.ReadLine()?.Split('#');

                    if (param != null)
                        employees.Add(
                            new Employee(
                                Convert.ToInt32(param[0]),
                                Convert.ToDateTime(param[1]),
                                param[2],
                                Convert.ToInt32(param[3]),
                                Convert.ToInt32(param[4]),
                                Convert.ToDateTime(param[5]),
                                param[6]));

                    _index++;
                }
            }
        }

        /// <summary>
        ///     Вывод на консоль
        /// </summary>
        private static void PrintToConsole()
        {
            Console.Clear();
            Console.WriteLine($"{_titles[0],6} {_titles[1],16} {_titles[2],15} {_titles[3],20} {_titles[4],5} " +
                              $"{_titles[5],15} {_titles[6],15}");

            foreach (var item in employees)
            {
                Console.WriteLine(item.Print());
            }
        }

        /// <summary>
        ///     Добавление сотрудника пользователем через консоль
        /// </summary>
        private static void AddFromTheConsole()
        {
            var arr = GetDataEmployee();

            if (_indexId == 0)
                _indexId++;
            else
                _indexId = employees[_index - 1].Id + 1;

            _index++;
            employees.Add(
                new Employee(_indexId,
                    DateTime.Now,
                    arr[0],
                    Convert.ToInt32(arr[1]),
                    Convert.ToInt32(arr[2]),
                    Convert.ToDateTime(arr[3]),
                    arr[4]));
        }

        /// <summary>
        ///     Удаление сотрудника по ID
        /// </summary>
        private static void Del()
        {
            Console.Write("Введите Id сотрудника, запись которого нужно удалить: ");
            var delId = GetCheckId();

            employees.RemoveAt(employees.FindIndex(item => item.Id == delId));
            _index--;
        }

        /// <summary>
        ///     Редактирование записи о сотруднике
        /// </summary>
        private static void Edit()
        {
            Console.Write("Введите Id сотрудника, запись которого нужно отредактировать: ");
            var id = GetCheckId();
            var i = employees.FindIndex(x => x.Id == id);
            var arr = GetDataEmployee();

            _indexId = employees[i].Id;
            employees.RemoveAt(i);
            employees.Insert(i, new Employee(_indexId,
                                    DateTime.Now,
                                    arr[0],
                                    Convert.ToInt32(arr[1]),
                                    Convert.ToInt32(arr[2]),
                                    Convert.ToDateTime(arr[3]),
                                    arr[4]));
        }

        /// <summary>
        ///     Сохранение БД Сотрудников в файл.
        /// </summary>
        private static void Save()
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                foreach (var x in employees)
                {
                    sw.WriteLine(x.PrintToFile());
                }
            }
        }

        /// <summary>
        ///     Загрузка данных из файла в диапазоне дат.
        /// </summary>
        private static void UploadByDate()
        {
            Console.WriteLine("Введите диапазон дат, которые надо загрузить.");
            Console.Write("C ");
            var with = Convert.ToDateTime(Console.ReadLine());
            Console.Write(" по ");
            var by = Convert.ToDateTime(Console.ReadLine());

            GetUploadByDate(with, @by);
        }

        /// <summary>
        ///     Логика. Загрузка данных из файла в диапазоне дат.
        /// </summary>
        /// <param name="with">Начальная дата</param>
        /// <param name="by">Конечная дата</param>
        private static void GetUploadByDate(DateTime with, DateTime @by)
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    string[] param = sr.ReadLine()?.Split('#');

                    if (param != null)
                        if (Convert.ToDateTime(param[1]) > with && Convert.ToDateTime(param[1]) < @by)
                        {
                            employees.Add(
                                new Employee(
                                    Convert.ToInt32(param[0]),
                                    Convert.ToDateTime(param[1]),
                                    param[2],
                                    Convert.ToInt32(param[3]),
                                    Convert.ToInt32(param[4]),
                                    Convert.ToDateTime(param[5]),
                                    param[6]));
                        }

                    _index++;
                }
            }
        }

        /// <summary>
        ///     Сортировка по возрастанию, по свойству Дата Создания записи
        /// </summary>
        private static void SortUp()
        {
            employees = employees.OrderBy(x => x.DataTimeRecordAdd).ToList();
        }

        /// <summary>
        ///     Сортировка по убыванию, по свойству Дата Создания записи
        /// </summary>
        private static void SortDn()
        {
            employees = employees.OrderByDescending(x => x.DataTimeRecordAdd).ToList();
        }
        /// <summary>
        ///     Проверка на наличие ID сотрудника в BD
        /// </summary>
        /// <returns></returns>
        private static int GetCheckId()
        {
            int delId;
            while (true)
            {
                delId = Convert.ToInt32(Console.ReadLine());
                if (employees.Exists(x => x.Id == delId))
                    break;
                Console.Write("\nДанного сотрудника не существует, введите ID существующего сотрудника: ");
            }

            return delId;
        }

        /// <summary>
        ///    Загрузка данных 
        /// </summary>
        /// <returns>Массив данных</returns>
        private static string[] GetDataEmployee()
        {
            string[] arr = new string[5];
            Console.Clear();

            Console.Write("\nВведите Ф.И.О. сотрудника: ");
            arr[0] = Console.ReadLine();

            Console.Write("Введите возраст сотрудника: ");
            arr[1] = Console.ReadLine();

            Console.Write("Введите рост сотрудника: ");
            arr[2] = Console.ReadLine();

            Console.Write("Введите дату рождения сотрудника: ");
            arr[3] = Console.ReadLine();

            Console.Write("Введите место рождения сотрудника: ");
            arr[4] = Console.ReadLine();

            return arr;
        }

        /// <summary>
        ///     Провека на наличе и расширение файла.
        /// </summary>
        private static bool CheckTxtRequestPath(bool o)
        {
            if (_path.Length <= 3)
                Console.WriteLine("Введите верное расширение файла (Имя файла.txt).");
            else
                if (_path[_path.Length - 1] != 't' && _path[_path.Length - 2] != 'x' && _path[_path.Length - 3] != 't')
                Console.WriteLine("Введите верное расширение файла (Имя файла.txt).");
            else o = false;

            return o;
        }
    }
}
