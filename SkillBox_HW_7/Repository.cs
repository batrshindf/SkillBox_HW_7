using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox_HW_7
{
    struct Repository
    {
        private Employee[] employees; // Основной массив для хранения данных
        private string path; // Путь к файлу
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
            this.titles = new string[0];
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
        ///     Загрузка данных в память
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split('#');

                while (!sr.EndOfStream)
                {
                    string[] param = sr.ReadLine().Split('#');
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
        public void Save(string outputPath)
        {
            string outputText = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                this.titles[0],
                this.titles[1],
                this.titles[2],
                this.titles[3],
                this.titles[4],
                this.titles[5],
                this.titles[6]);

            File.AppendAllText(outputPath, $"{outputText}\n");

            for (int i = 0; i < this.index; i++)
            {
                outputText = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                    this.employees[0].Id,
                    this.employees[1].DataTimeRecordAdd,
                    this.employees[2].FullName,
                    this.employees[3].Age,
                    this.employees[4].Height,
                    this.employees[5].DateOfBirth,
                    this.employees[6].PlaceOfBirth);

                File.AppendAllText(outputPath, $"{outputText}\n");
            }

        }

        /// <summary>
        ///     Вывод на консоль
        /// </summary>
        public void PrintToConsole()
        {
            Console.Clear();
            Console.WriteLine($"{this.titles[0], 6} {this.titles[1], 16} {this.titles[2], 15} {this.titles[3], 20} " +
                              $"{this.titles[4], 5} {this.titles[5], 15} {this.titles[6], 15}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.employees[i].Print());
            }
        }
        
        /// <summary>
        ///     Подсчет кол-ва сотрудников
        /// </summary>
        public int GetCountEmployee { get { return this.index; } }

        /// <summary>
        ///     Путь к файлу. Запрашиваем путь к файлу с данными
        /// </summary>
        /// <returns></returns>
        private string GetRequestPath
        {
            get
            {
                Console.WriteLine(
                    "Введите название файла с числом N и его расширение (txt) или весь путь к данному файлу:");
                return Console.ReadLine();
            }
        }
       
    }
}
