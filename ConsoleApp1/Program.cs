using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using DTO.DTOs;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //generateData();
            FirestoreDataMapper<PlanovanyTreninkDTO> firestoreDataMapper = new FirestoreDataMapper<PlanovanyTreninkDTO>();
            List<PlanovanyTreninkDTO> planovanyTreninkDTOs = new List<PlanovanyTreninkDTO>
            {
                new PlanovanyTreninkDTO(1, 1, 13, "HDP Gym", false,"Nezapomenout peníze", DateTime.Now.AddDays(13)),
                new PlanovanyTreninkDTO(2, 1, 13, "Fitness Ring", true,"Dáme do těla", DateTime.Now.AddDays(5)),
                new PlanovanyTreninkDTO(3, 1, 13, "Top Fitness", false,"Dneska jen odpočinek", DateTime.Now.AddDays(20)),
                new PlanovanyTreninkDTO(4, 1, 13, "ARENA", true,"Zaměříme se na dřepy", DateTime.Now.AddDays(17)),
                new PlanovanyTreninkDTO(5, 1, 13, "Extrifit GYM", false,"Důraz na mobilitu", DateTime.Now.AddDays(15)),
            };

            foreach (PlanovanyTreninkDTO t in planovanyTreninkDTOs)
            {
                _ = firestoreDataMapper.Insert(t);
            }

            Console.ReadKey();
        }



        static void generateData()
        {
            List<ZadostDTO> zadosti = new List<ZadostDTO>
            {
                new ZadostDTO(1, 4, DTO.Enums.TypZadosti.PRODLOUZENI, DateTime.Now.AddDays(5)),
                new ZadostDTO(2, 13, DTO.Enums.TypZadosti.PRODLOUZENI, DateTime.Now.AddDays(5)),
                new ZadostDTO(3, 14, DTO.Enums.TypZadosti.ZRUSENI, DateTime.Now.AddDays(-15)),
                new ZadostDTO(4, 19, DTO.Enums.TypZadosti.PRODLOUZENI, DateTime.Now.AddDays(7)),
                new ZadostDTO(5, 20, DTO.Enums.TypZadosti.ZRUSENI, DateTime.Now),
                new ZadostDTO(6, 25, DTO.Enums.TypZadosti.ZRUSENI, DateTime.Now.AddDays(-4)),
                new ZadostDTO(7, 26, DTO.Enums.TypZadosti.PRODLOUZENI, DateTime.Now.AddDays(-15)),
                new ZadostDTO(8, 28, DTO.Enums.TypZadosti.ZRUSENI, DateTime.Now.AddDays(10)),
            };



            List<TreninkDTO> treninky = new List<TreninkDTO>
            {
                new TreninkDTO(1, 1, "Trenink A", new List<int> { 13, 24, 27, 29 }),
                new TreninkDTO(2, 1, "Trenink B", new List<int> { 7, 10, 18, 22 }),
                new TreninkDTO(3, 1, "Trenink C", new List<int> { 5, 9, 10, 25 }),
                new TreninkDTO(4, 2, "Trenink A", new List<int> { 3, 4, 13, 18 }),
                new TreninkDTO(5, 2, "Trenink B", new List<int> { 3, 12, 19, 28 }),
                new TreninkDTO(6, 2, "Trenink C", new List<int> { 1, 2, 7, 25 }),
                new TreninkDTO(7, 3, "Trenink A", new List<int> { 7, 15, 24, 28 }),
                new TreninkDTO(8, 3, "Trenink B", new List<int> { 13, 15, 19, 22 }),
                new TreninkDTO(9, 3, "Trenink C", new List<int> { 14, 19, 26, 28 }),
                new TreninkDTO(10, 4, "Trenink A", new List<int> { 3, 12, 14, 22 }),
                new TreninkDTO(11, 4, "Trenink B", new List<int> { 10, 16, 22, 29 }),
                new TreninkDTO(12, 4, "Trenink C", new List<int> { 3, 6, 14, 21 }),
                new TreninkDTO(13, 5, "Trenink A", new List<int> { 2, 8, 17, 23 }),
                new TreninkDTO(14, 5, "Trenink B", new List<int> { 8, 15, 16, 20 }),
                new TreninkDTO(15, 6, "Trenink C", new List<int> { 5, 20, 29, 30 }),

        };
            List<CvikDTO> cviky = new List<CvikDTO>
            {
                new CvikDTO(1, "Dřep", 5, 5, "Až dolů."),
                new CvikDTO(2, "Přítahy velké činky podhmatem", 8, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikDTO(3, "Přítahy jednoruční činky k pasu", 8, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikDTO(4, "Pullover", 10, 4, "Pauzy mezi sériemi 1min, důraz na protažení"),
                new CvikDTO(5, "Bicepsový zdvih s velkou osou/ J.Č.", 10, 3, "Pauzy mezi sériemi 1,5min"),
                new CvikDTO(6, "Kladivový bicepsový zdvih", 10, 3, "Pauzy mezi sériemi 1,5min"),
                new CvikDTO(7, "Zvedání nohou ve visu + sklapovačky", 15, 4, "Pauzy mezi sériemi 2-3min"),
                new CvikDTO(8, "Bench popř. tlaky na rovné lavici s J.Č.", 5, 3, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze "),
                new CvikDTO(9, "Tlaky na nakloněné lavici s J.Č.", 8, 6, "Pyramida"),
                new CvikDTO(10, "Kliky na bradlech se zátěží", 5, 4, "Pauzy mezi sériemi 1,5min, lotky do strany, větší předklon"),
                new CvikDTO(11, "Rozpažování s J.Č.", 12, 4, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikDTO(12, "Kliky se zátěží", 12, 3, "Pauzy mezi sériemi 1,5min, nedávat důraz na negativní fáze"),
                new CvikDTO(13, "Francouzské tlaky", 15, 3, "Pauzy mezi sériemi 1,5min"),
                new CvikDTO(14, "Kliky mezi lavičkami se zátěží na triceps", 15, 5, "Pauzy mezi sériemi 1,5min"),
                new CvikDTO(15, "Stahování lana", 10, 5, "Až dolů."),
                new CvikDTO(16, "Plank klasický + do strany", 5, 5, "Klasický plank -> plank 1 strana -> plank 2 strana (ihned bez pauzy)"),
                new CvikDTO(17, "Tlaky s J.Č. popř. tlaky s velkou osou za hlavou", 10, 5, "Pauzy mezi sériemi 2-2,5min, nedávat důraz na negativní fáze"),
                new CvikDTO(18, "Přítahy velké činky popř. J.Č. k bradě", 8, 4, "Pauzy mezi sériemi 2min, nedávat důraz na negativní fáze"),
                new CvikDTO(19, "Rozpažování s J.Č.", 10, 4, "Pauzy mezi sériemi 2min, vytáčet malíčky nahoru, bez negativní fáze"),
                new CvikDTO(20, "Upažování na zadní delty", 12, 4, "Pauzy mezi sériemi 2min, nedávat důraz na negativní fáze"),
                new CvikDTO(21, "Předpažování", 12, 3, "Pauzy mezi sériemi 2min"),
                new CvikDTO(22, "Krčení ramen s velkou osou", 8, 3, "Pauzy mezi sériemi 2min"),
                new CvikDTO(23, "Krčení ramen s J.Č.", 12, 3, "Pauzy mezi sériemi 2min"),
                new CvikDTO(24, "Zvedání nohou ve visu + sklapovačky", 20, 4, "Pauzy mezi sériemi 1min"),
                new CvikDTO(25, "Legpress", 5, 3, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikDTO(26, "Čelní dřep", 5, 5, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikDTO(27, "Výpady", 15, 4, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikDTO(28, "Mrtvý tah s nataženými nohy", 5, 5, "Pauzy mezi sériemi 2min, bez negativní fáze"),
                new CvikDTO(29, "Zakopávání", 10, 3, "Pauzy mezi sériemi 2min, bez negativní fáze"),
        };

            FirestoreDataMapper<TreninkDTO> treninkMapper = new FirestoreDataMapper<TreninkDTO>();
            FirestoreDataMapper<CvikDTO> cvikMapper = new FirestoreDataMapper<CvikDTO>();
            FirestoreDataMapper<ZadostDTO> zadostMapper = new FirestoreDataMapper<ZadostDTO>();


            foreach (TreninkDTO t in treninky)
            {
                _ = treninkMapper.Insert(t);
            }

            foreach (CvikDTO c in cviky)
            {
                _ = cvikMapper.Insert(c);
            }

            foreach (ZadostDTO z in zadosti)
            {
                _ = zadostMapper.Insert(z);
            }



        }
    }
}
