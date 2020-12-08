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

            //generateData();


            FirestoreDataMapper<TreninkovyPlan> firestoreDataMapper = new FirestoreDataMapper<TreninkovyPlan>();
            TreninkovyPlan treninkovyPlan = new TreninkovyPlan(1, 1,
                                            "Pro Růženu", DateTime.Now.ToUniversalTime(), ObtiznostTreninkovehoPlanu.EXPERT,
                                            CilPlanu.ZVYSENI_SILY, "Nasypeme to Růžo", new List<int> { 1, 2, 3 });

            _ = firestoreDataMapper.Insert(treninkovyPlan);

            Console.ReadKey();
        }



        static void generateData()
        {
            List<Trenink> treninky = new List<Trenink>
            {
                new Trenink(1, 1, "Trenink A", new List<int> { 13, 24, 27, 29 }),
                new Trenink(2, 1, "Trenink B", new List<int> { 7, 10, 18, 22 }),
                new Trenink(3, 1, "Trenink C", new List<int> { 5, 9, 10, 25 }),
                new Trenink(4, 2, "Trenink A", new List<int> { 3, 4, 13, 18 }),
                new Trenink(5, 2, "Trenink B", new List<int> { 3, 12, 19, 28 }),
                new Trenink(6, 2, "Trenink C", new List<int> { 1, 2, 7, 25 }),
                new Trenink(7, 3, "Trenink A", new List<int> { 7, 15, 24, 28 }),
                new Trenink(8, 3, "Trenink B", new List<int> { 13, 15, 19, 22 }),
                new Trenink(9, 3, "Trenink C", new List<int> { 14, 19, 26, 28 }),
                new Trenink(10, 4, "Trenink A", new List<int> { 3, 12, 14, 22 }),
                new Trenink(11, 4, "Trenink B", new List<int> { 10, 16, 22, 29 }),
                new Trenink(12, 4, "Trenink C", new List<int> { 3, 6, 14, 21 }),
                new Trenink(13, 5, "Trenink A", new List<int> { 2, 8, 17, 23 }),
                new Trenink(14, 5, "Trenink B", new List<int> { 8, 15, 16, 20 }),
                new Trenink(15, 6, "Trenink C", new List<int> { 5, 20, 29, 30 }),

        };
            List<Cvik> cviky = new List<Cvik>
            {
                new Cvik(1, "Dřep", 5, 5, "Až dolů."),
                new Cvik(2, "Přítahy velké činky podhmatem", 8, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new Cvik(3, "Přítahy jednoruční činky k pasu", 8, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new Cvik(4, "Pullover", 10, 4, "Pauzy mezi sériemi 1min, důraz na protažení"),
                new Cvik(5, "Bicepsový zdvih s velkou osou/ J.Č.", 10, 3, "Pauzy mezi sériemi 1,5min"),
                new Cvik(6, "Kladivový bicepsový zdvih", 10, 3, "Pauzy mezi sériemi 1,5min"),
                new Cvik(7, "Zvedání nohou ve visu + sklapovačky", 15, 4, "Pauzy mezi sériemi 2-3min"),
                new Cvik(8, "Bench popř. tlaky na rovné lavici s J.Č.", 5, 3, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze "),
                new Cvik(9, "Tlaky na nakloněné lavici s J.Č.", 8, 6, "Pyramida"),
                new Cvik(10, "Kliky na bradlech se zátěží", 5, 4, "Pauzy mezi sériemi 1,5min, lotky do strany, větší předklon"),
                new Cvik(11, "Rozpažování s J.Č.", 12, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new Cvik(12, "Kliky se zátěží", 12, 3, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new Cvik(13, "Francouzské tlaky", 15, 3, "Pauzy mezi sériemi 1,5min"),
                new Cvik(14, "Kliky mezi lavičkami se zátěží na triceps", 15, 5, "Pauzy mezi sériemi 1,5min"),
                new Cvik(15, "Stahování lana", 10, 5, "Až dolů."),
                new Cvik(16, "Plank klasický + do strany", 5, 5, "Klasický plank -> plank 1 strana -> plank 2 strana (ihned bez pauzy)"),
                new Cvik(17, "Tlaky s J.Č. popř. tlaky s velkou osou za hlavou", 10, 5, "Pauzy mezi sériemi 2-2,5min, nedávat důraz na negativní fáze"),
                new Cvik(18, "Přítahy velké činky popř. J.Č. k bradě", 8, 4, "Pauzy mezi sériemi 2min, nedávat důraz na negativní fáze"),
                new Cvik(19, "Rozpažování s J.Č.", 10, 4, "Pauzy mezi sériemi 2min, vytáčet malíčky nahoru, bez negativní fáze"),
                new Cvik(20, "Upažování na zadní delty", 12, 4, "Pauzy mezi sériemi 2min, nedávat důraz na negativní fáze"),
                new Cvik(21, "Předpažování", 12, 3, "Pauzy mezi sériemi 2min"),
                new Cvik(22, "Krčení ramen s velkou osou", 8, 3, "Pauzy mezi sériemi 2min"),
                new Cvik(23, "Krčení ramen s J.Č.", 12, 3, "Pauzy mezi sériemi 2min"),
                new Cvik(24, "Zvedání nohou ve visu + sklapovačky", 20, 4, "Pauzy mezi sériemi 1min"),
                new Cvik(25, "Legpress", 5, 3, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new Cvik(26, "Čelní dřep", 5, 5, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new Cvik(27, "Výpady", 15, 4, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new Cvik(28, "Mrtvý tah s nataženými nohy", 5, 5, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new Cvik(29, "Zakopávání", 10, 3, "Pauzy mezi sériemi 2min, bez negativní fáze"),
        };

            FirestoreDataMapper<Trenink> treninkMapper = new FirestoreDataMapper<Trenink>();
            FirestoreDataMapper<Cvik> cvikMapper = new FirestoreDataMapper<Cvik>();

            foreach (Trenink t in treninky)
            {
                _ = treninkMapper.Insert(t);
            }

            foreach (Cvik c in cviky)
            {
                _ = cvikMapper.Insert(c);
            }



        }
    }
}
