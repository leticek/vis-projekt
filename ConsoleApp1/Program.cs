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


            FirestoreDataMapper<CvikModel> firestoreDataMapper = new FirestoreDataMapper<CvikModel>();

            _ = firestoreDataMapper.GetByParameter("PocetOpakovani", 15);


            Console.ReadKey();
        }



        static void generateData()
        {
            List<TreninkModel> treninky = new List<TreninkModel>
            {
                new TreninkModel(1, 1, "Trenink A", new List<int> { 13, 24, 27, 29 }),
                new TreninkModel(2, 1, "Trenink B", new List<int> { 7, 10, 18, 22 }),
                new TreninkModel(3, 1, "Trenink C", new List<int> { 5, 9, 10, 25 }),
                new TreninkModel(4, 2, "Trenink A", new List<int> { 3, 4, 13, 18 }),
                new TreninkModel(5, 2, "Trenink B", new List<int> { 3, 12, 19, 28 }),
                new TreninkModel(6, 2, "Trenink C", new List<int> { 1, 2, 7, 25 }),
                new TreninkModel(7, 3, "Trenink A", new List<int> { 7, 15, 24, 28 }),
                new TreninkModel(8, 3, "Trenink B", new List<int> { 13, 15, 19, 22 }),
                new TreninkModel(9, 3, "Trenink C", new List<int> { 14, 19, 26, 28 }),
                new TreninkModel(10, 4, "Trenink A", new List<int> { 3, 12, 14, 22 }),
                new TreninkModel(11, 4, "Trenink B", new List<int> { 10, 16, 22, 29 }),
                new TreninkModel(12, 4, "Trenink C", new List<int> { 3, 6, 14, 21 }),
                new TreninkModel(13, 5, "Trenink A", new List<int> { 2, 8, 17, 23 }),
                new TreninkModel(14, 5, "Trenink B", new List<int> { 8, 15, 16, 20 }),
                new TreninkModel(15, 6, "Trenink C", new List<int> { 5, 20, 29, 30 }),

        };
            List<CvikModel> cviky = new List<CvikModel>
            {
                new CvikModel(1, "Dřep", 5, 5, "Až dolů."),
                new CvikModel(2, "Přítahy velké činky podhmatem", 8, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikModel(3, "Přítahy jednoruční činky k pasu", 8, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikModel(4, "Pullover", 10, 4, "Pauzy mezi sériemi 1min, důraz na protažení"),
                new CvikModel(5, "Bicepsový zdvih s velkou osou/ J.Č.", 10, 3, "Pauzy mezi sériemi 1,5min"),
                new CvikModel(6, "Kladivový bicepsový zdvih", 10, 3, "Pauzy mezi sériemi 1,5min"),
                new CvikModel(7, "Zvedání nohou ve visu + sklapovačky", 15, 4, "Pauzy mezi sériemi 2-3min"),
                new CvikModel(8, "Bench popř. tlaky na rovné lavici s J.Č.", 5, 3, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze "),
                new CvikModel(9, "Tlaky na nakloněné lavici s J.Č.", 8, 6, "Pyramida"),
                new CvikModel(10, "Kliky na bradlech se zátěží", 5, 4, "Pauzy mezi sériemi 1,5min, lotky do strany, větší předklon"),
                new CvikModel(11, "Rozpažování s J.Č.", 12, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikModel(12, "Kliky se zátěží", 12, 3, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikModel(13, "Francouzské tlaky", 15, 3, "Pauzy mezi sériemi 1,5min"),
                new CvikModel(14, "Kliky mezi lavičkami se zátěží na triceps", 15, 5, "Pauzy mezi sériemi 1,5min"),
                new CvikModel(15, "Stahování lana", 10, 5, "Až dolů."),
                new CvikModel(16, "Plank klasický + do strany", 5, 5, "Klasický plank -> plank 1 strana -> plank 2 strana (ihned bez pauzy)"),
                new CvikModel(17, "Tlaky s J.Č. popř. tlaky s velkou osou za hlavou", 10, 5, "Pauzy mezi sériemi 2-2,5min, nedávat důraz na negativní fáze"),
                new CvikModel(18, "Přítahy velké činky popř. J.Č. k bradě", 8, 4, "Pauzy mezi sériemi 2min, nedávat důraz na negativní fáze"),
                new CvikModel(19, "Rozpažování s J.Č.", 10, 4, "Pauzy mezi sériemi 2min, vytáčet malíčky nahoru, bez negativní fáze"),
                new CvikModel(20, "Upažování na zadní delty", 12, 4, "Pauzy mezi sériemi 2min, nedávat důraz na negativní fáze"),
                new CvikModel(21, "Předpažování", 12, 3, "Pauzy mezi sériemi 2min"),
                new CvikModel(22, "Krčení ramen s velkou osou", 8, 3, "Pauzy mezi sériemi 2min"),
                new CvikModel(23, "Krčení ramen s J.Č.", 12, 3, "Pauzy mezi sériemi 2min"),
                new CvikModel(24, "Zvedání nohou ve visu + sklapovačky", 20, 4, "Pauzy mezi sériemi 1min"),
                new CvikModel(25, "Legpress", 5, 3, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikModel(26, "Čelní dřep", 5, 5, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikModel(27, "Výpady", 15, 4, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikModel(28, "Mrtvý tah s nataženými nohy", 5, 5, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikModel(29, "Zakopávání", 10, 3, "Pauzy mezi sériemi 2min, bez negativní fáze"),
        };

            FirestoreDataMapper<TreninkModel> treninkMapper = new FirestoreDataMapper<TreninkModel>();
            FirestoreDataMapper<CvikModel> cvikMapper = new FirestoreDataMapper<CvikModel>();

            foreach (TreninkModel t in treninky)
            {
                _ = treninkMapper.Insert(t);
            }

            foreach (CvikModel c in cviky)
            {
                _ = cvikMapper.Insert(c);
            }



        }
    }
}
