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
            Employee employee1 = new Employee(1, DateTime.Now, "Батршин Денис Фанилевич", 29, 165,
                new DateTime(1992, 03, 29), "Город Нягань");

            employee1.Print();

            Console.ReadKey();

        }
            
    }
}
