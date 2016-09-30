using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Equation
{
    class Program
    {
        static void Main(string[] args)
        {
            GetParams getParams = new GetParams();
            Console.WriteLine(getParams.GetResult());
            Console.WriteLine($"Лог файл сохранен в {Environment.CurrentDirectory}\\log.txt");
            //GetParams.DumpLog();
            Console.ReadKey();
        }

        
        
    }
}
