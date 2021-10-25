using System;
using System.Collections.Generic;
using System.IO;

namespace SkillBox_HW_7
{
    internal class Program
    {
        private static string path; // Путь к файлу
        private static int index; // текущий элемент для добавления в employees (Счетчик записей о сотрудниках)
        private static int indexID; // последний ID работника в DB
        //private static readonly string checkYesNo = "нет ytn no да lf yes";
        //private static readonly string checkNo = "нет ytn no";
        //private static string inputYesNo;

        private static string[] titles =
        {
            "ID", "Дата и время создания", "ФИО", "Возраст", "Рост",
            "Дата рождения", "Место рождения"
        }; // Массив заголовков
        
        private static readonly List<Employee> employees = new List<Employee>(); // Коллекция

        private static void Main(string[] args)
        {
            RequestPath();

            while (true)
            {
                Menu();
            }
        }

        /// <summary>
        ///     Пользовательское меню
        /// </summary>
        private static void Menu()
        {
            Console.WriteLine(
                "\n\n1. Загрузка всех данных из файла.\n2. Добавление сотрудника.\n3. Удаление записи.\n4. Редактирование записи." +
                "\n5. Выход.");
            Console.Write("\nВыберите пункт меню: ");

            switch (Console.ReadLine())
            {
                case "1":
                    index = 0;
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
                    Environment.Exit(0);
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
        private static void RequestPath()
        {
            Console.WriteLine(
                "Введите название файла с числом N и его расширение (txt) или весь путь к данному файлу:");
            path = Console.ReadLine();
        }

        /// <summary>
        ///     Загрузка данных в память из файла
        /// </summary>
        private static void Load()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                titles = sr.ReadLine()?.Split('#');

                while (!sr.EndOfStream)
                {
                    string[] param = sr.ReadLine()?.Split('#');

                    employees.Add(new Employee(Convert.ToInt32(param[0]), Convert.ToDateTime(param[1]), param[2],
                        Convert.ToInt32(param[3]), Convert.ToInt32(param[4]), Convert.ToDateTime(param[5]),
                        param[6]));

                    index++;
                }
            }
        }

        /// <summary>
        ///     Вывод на консоль
        /// </summary>
        private static void PrintToConsole()
        {
            Console.Clear();
            Console.WriteLine(
                $"{titles[0],6} {titles[1],16} {titles[2],15} {titles[3],20} {titles[4],5} {titles[5],15} " +
                $"{titles[6],15}");

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

            indexID = employees[index - 1].Id + 1;
            index++;
            employees.Add(
                new Employee(indexID, DateTime.Now, arr[0], Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2]),
                    Convert.ToDateTime(arr[3]), arr[4]));
        }

        /// <summary>
        ///     Удаление сотрудника по ID
        /// </summary>
        private static void Del()
        {
            Console.Write("Введите Id сотрудника, запись которого нужно удалить: ");
            var delId = GetCheckId();
      
            employees.RemoveAt(employees.FindIndex(item => item.Id == delId));
            index--;
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

            indexID = employees[i].Id;
            employees.RemoveAt(i);
            employees.Insert(i, 
                new Employee(indexID, DateTime.Now, arr[0], Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2]), 
                    Convert.ToDateTime(arr[3]) , arr[4]));
        }

        /// <summary>
        ///     Проверка на наличие ID сотрудника в BD
        /// </summary>
        /// <returns></returns>
        private static int GetCheckId()
        {
            var delId = 0;
            while (true)
            {
                delId = Convert.ToInt32(Console.ReadLine());
                if (employees.Exists(x => x.Id == delId)) 
                    break;
                Console.Write("\nДанного сотрудника не существует, введите ID существующего сотрудника: ");
            }

            return delId;
        }

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
    }
}