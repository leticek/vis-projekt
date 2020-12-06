using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Cvik cvik = new Cvik(3, "Dřep", 5, 5, "Až dolů");
            CvikDataMapper cd = new CvikDataMapper();
            _ = cd.Insert(cvik);
            Console.ReadKey();
        }
    }
}
