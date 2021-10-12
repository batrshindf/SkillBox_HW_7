using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox_HW_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository rep = new Repository();

            rep.Load();
            rep.PrintToConsole();
            Console.WriteLine($"\n\nОбщее количество сотрудников: {rep.GetCountEmployee}");
            

            Console.ReadKey();

        }

        /// <summary>
        ///     Путь к файлу. Запрашиваем путь к файлу с данными
        /// </summary>
        //private static string RequestPath()
        //{
        //    Console.WriteLine(
        //        "Введите название файла с числом N и его расширение (txt) или весь путь к данному файлу:");
        //    return Console.ReadLine();
        //}
        
    }
}
