using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SkillBox_HW_7
{
    internal class Repository
    {
        private static string _path; // Путь к файлу
        private static int _index; // текущий элемент для добавления в employees (Счетчик записей о сотрудниках)
        private static int _indexId; // последний ID работника в DB

        private static readonly string[] _titles =
        {
            "ID", "Дата и время создания", "ФИО", "Возраст", "Рост", "Дата рождения", "Место рождения"
        }; // Массив заголовков

        public List<Employee> employees = new List<Employee>(); // Коллекция

        public string Path
        {
            get => _path;
            set => _path = value;
        }

        public int Index
        {
            get => _index;
            set => _index = value;
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
        public void Load()
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
        public void PrintToConsole()
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
        public void AddFromTheConsole(string[] arr)
        {
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
        public void Del(int delId)
        {
            employees.RemoveAt(employees.FindIndex(item => item.Id == delId));
            _index--;
        }

        /// <summary>
        ///     Редактирование записи о сотруднике
        /// </summary>
        public void Edit(int id, string[] arr)
        {
            var i = employees.FindIndex(x => x.Id == id);

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
        public void Save()
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
        ///     Логика. Загрузка данных из файла в диапазоне дат.
        /// </summary>
        /// <param name="with">Начальная дата</param>
        /// <param name="by">Конечная дата</param>
        public void GetUploadByDate(DateTime with, DateTime by)
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    string[] param = sr.ReadLine()?.Split('#');

                    if (param != null)
                        if (Convert.ToDateTime(param[1]) > with && Convert.ToDateTime(param[1]) < by)
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
        public void SortUp()
        {
            employees = employees.OrderBy(x => x.DataTimeRecordAdd).ToList();
        }

        /// <summary>
        ///     Сортировка по убыванию, по свойству Дата Создания записи
        /// </summary>
        public void SortDn()
        {
            employees = employees.OrderByDescending(x => x.DataTimeRecordAdd).ToList();
        }

        /// <summary>
        ///     Проверка на наличие ID сотрудника в BD
        /// </summary>
        /// <returns></returns>
        public int GetCheckId()
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
        ///     Провека на наличе и расширение файла.
        /// </summary>
        private static bool CheckTxtRequestPath(bool o)
        {
            if (_path.Length <= 3)
                Console.WriteLine("Введите верное расширение файла (Имя файла.txt).");
            else if (_path[_path.Length - 1] != 't' && _path[_path.Length - 2] != 'x' && _path[_path.Length - 3] != 't')
                Console.WriteLine("Введите верное расширение файла (Имя файла.txt).");
            else o = false;

            return o;
        }
    }
}