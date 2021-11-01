using System;

namespace SkillBox_HW_7
{
    internal class Interface
    {
        private readonly Repository repository = new Repository();
        private string _path;

        public string Path
        {
            get => _path;
            set => _path = value;
        }

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
                    repository.Index = 0;
                    repository.Load();
                    repository.PrintToConsole();
                    break;
                case "2":
                    repository.AddFromTheConsole(GetDataEmployee());
                    repository.PrintToConsole();
                    break;
                case "3":
                    repository.Del(GetDelId());
                    repository.PrintToConsole();
                    break;
                case "4":
                    repository.Edit(GetEditId(), GetDataEmployee());
                    repository.PrintToConsole();
                    break;
                case "5":
                    Console.Clear();
                    repository.Save();
                    repository.PrintToConsole();
                    Console.WriteLine($"\n\nДанные успешно сохранены в файл: {Path}");
                    break;
                case "6":
                    UploadByDate();
                    repository.PrintToConsole();
                    break;
                case "7":
                    Console.Clear();
                    repository.SortUp();
                    repository.PrintToConsole();
                    break;
                case "8":
                    Console.Clear();
                    repository.SortDn();
                    repository.PrintToConsole();
                    break;
                case "9":
                    Console.Clear();
                    repository.employees.Clear();
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
                    repository.PrintToConsole();
                    break;
            }
        }

        /// <summary>
        ///     Загрузка данных из файла в диапазоне дат.
        /// </summary>
        private void UploadByDate()
        {
            Console.WriteLine("Введите диапазон дат, которые надо загрузить.");
            Console.Write("C ");
            var with = Convert.ToDateTime(Console.ReadLine());
            Console.Write(" по ");
            var by = Convert.ToDateTime(Console.ReadLine());

            repository.GetUploadByDate(with, by);
        }

        /// <summary>
        ///     ввод данных о работнике с консоли
        /// </summary>
        /// <returns>Массив данных</returns>
        private string[] GetDataEmployee()
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

        private int GetDelId()
        {
            Console.Write("\nВведите Id сотрудника, запись которого нужно удалить: ");

            return repository.GetCheckId();
        }

        private int GetEditId()
        {
            Console.Write("\nВведите Id сотрудника, запись которого нужно отредактировать: ");

            return repository.GetCheckId();
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
                Path = Console.ReadLine();

                o = repository.CheckTxtRequestPath(o);
            }
        }
    }
}