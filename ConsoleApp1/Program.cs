using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Trenink t = new Trenink(15, 5, "test", new List<int> { 1, 7, 15, 13 });

            TreninkDataMapper treninkDataMapper = new TreninkDataMapper();

            _ = treninkDataMapper.Insert(t);

            Console.ReadKey();
        }
    }
}
