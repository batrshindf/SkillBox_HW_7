using System;
using System.IO;

namespace SkillBox_HW_7
{
    struct Repository
    {
        private Employee[] employees; // Основной массив для хранения данных
        private readonly string path; // Путь к файлу
        private int index; // текущий элемент для добавления в employees
        private string[] titles; // Массив заголовков

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="path">Путь к файлу с данными</param>
        public Repository(string path)
        {
            this.path = path;
            this.index = 0;
            this.titles = Array.Empty<string>();
            this.employees = new Employee[1];
        }

        /// <summary>
        ///     Увеличение текущего хранилища
        /// </summary>
        /// <param name="flag">Условие увеличения</param>
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this.employees, this.employees.Length * 2);
            }
        }

        /// <summary>
        ///     Метод удаления записи о сотруднике
        /// </summary>
        public void Del()
        {
            Console.Write("Введите Id сотрудника, который нужно удалить: ");
            var elementArr = int.Parse(Console.ReadLine());
            for (int i = 0; i < index; i++)
            {
                if (Equals(elementArr,employees[i].Id))
                {
                    for (int j = i; j <= index; j++)
                    {
                        employees[j] = employees[j + 1];
                        employees[j].Id--;
                    }

                    index--;
                    break;
                }
            }
        }
        
        /// <summary>
        ///     Редактрование записи о сотруднике
        /// </summary>
        public void Edit()
        {
            Console.Write("Введите Id сотрудника, запись которого надо отредактировать: ");
            var elementArr = int.Parse(Console.ReadLine());

            for (int i = 0; i < index; i++)
            {
                if (Equals(elementArr, employees[i].Id))
                {
                    Console.Write("Введите Ф.И.О. сотрудника: ");
                    employees[i].FullName = Console.ReadLine();

                    Console.Write("Введите возраст сотрудника: ");
                    employees[i].Age = Convert.ToByte(Console.ReadLine());

                    Console.Write("Введите рост сотрудника: ");
                    employees[i].Height = Convert.ToByte(Console.ReadLine());

                    Console.Write("Введите дату рождения сотрудника: ");
                    employees[i].DateOfBirth = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Введите место рождения сотрудника: ");
                    employees[i].PlaceOfBirth = Console.ReadLine();
                }
            }
        }
        
        /// <summary>
        ///     Добавление сотрудника
        /// </summary>
        /// <param name="specificEmployee">Сотрудник</param>
        public void Add(Employee specificEmployee)
        {
            this.Resize(index >= this.employees.Length);
            this.employees[index] = specificEmployee;
            this.index++;
        }

        /// <summary>
        ///     Добавление сотрудника поьзователем в консоле.
        /// </summary>
        public void AddFromTheConsole()
        {
            Console.Clear();
            bool a = true;

            while (a)
            {
                Console.Write("Введите Ф.И.О. сотрудника: ");
                string fullName = Console.ReadLine();

                Console.Write("Введите возраст сотрудника: ");
                byte age = Convert.ToByte(Console.ReadLine());

                Console.Write("Введите рост сотрудника: ");
                byte height = Convert.ToByte(Console.ReadLine());

                Console.Write("Введите дату рождения сотрудника: ");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Введите место рождения сотрудника: ");
                string placeOfBirth = Console.ReadLine();


                Add(new Employee(this.index + 1, DateTime.Now, fullName, age, height, dateOfBirth, placeOfBirth));

                Console.Write("Хотите добавить ещё одного сотрудника? (да/нет): ");
                if (Equals(Console.ReadLine()?.ToLower(), "нет")) { a = false; }
            }
        }

        /// <summary>
        ///     Загрузка данных в память
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine()?.Split('#');

                while (!sr.EndOfStream)
                {
                    string[] param = sr.ReadLine()?.Split('#');
                    Add(new Employee(Convert.ToInt32(param[0]), Convert.ToDateTime(param[1]), param[2],
                        Convert.ToByte(param[3]), Convert.ToByte(param[4]), Convert.ToDateTime(param[5]),
                        param[6]));
                }
            }
        }

        /// <summary>
        ///     Сохранение
        /// </summary>
        /// <param name="outputPath">Путь файла для записи</param>
        public void Save()
        {
            string outputText = 
                $"{this.titles[0]}#{this.titles[1]}#{this.titles[2]}#{this.titles[3]}#{this.titles[4]}#{this.titles[5]}#{this.titles[6]}";

            File.WriteAllText(path, $"{outputText}\n");

            for (int i = 0; i < this.index; i++)
            {
                outputText = $"{this.employees[i].Id}#{this.employees[i].DataTimeRecordAdd:dd.MM.yyyy hh:mm}#{this.employees[i].FullName}#" +
                             $"{this.employees[i].Age}#{this.employees[i].Height}#{this.employees[i].DateOfBirth:dd.MM.yyyy}#" +
                             $"{this.employees[i].PlaceOfBirth}";

                File.AppendAllText(this.path, $"{outputText}\n");
            }

        }

        /// <summary>
        ///     Вывод на консоль
        /// </summary>
        public void PrintToConsole()
        {
            Console.Clear();
            Console.WriteLine($"{this.titles[0],6} {this.titles[1],16} {this.titles[2],15} {this.titles[3],20} {this.titles[4],5} " +
                              $"{this.titles[5],15} {this.titles[6],15}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.employees[i].Print());
            }
        }

        /// <summary>
        ///     Подсчет кол-ва сотрудников
        /// </summary>
        public int GetCountEmployee { get { return this.index; } }
    }
}
