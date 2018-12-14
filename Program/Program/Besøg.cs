using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Besøg
    {
        public int BilId { get; set; }
        public DateTime Dato { get; set; }
        public string Udført { get; set; }

        public void opretBesøg()
        {
            Console.Clear();
            Forside.DisplayTop();
            Console.WriteLine("Indtast Bil ID: ");
            Console.WriteLine("Indtast udført arbejde: ");
            Console.SetCursorPosition(30, 7);
            //LOGIK til at finde biler og sørge for at kun biler der findes kan indtastes
            BilId = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(30, 8);
            Udført = Console.ReadLine();
            Dato = DateTime.Now;
            SQL.Change("insert into Besøg values(" + BilId + ", '" + Udført + "', '" + Dato + "')");
        }
        public static void opdaterBesøg()
        {
            Console.WriteLine("Værksteds ophold:\n");
            SQL.SelectBesøg("select * from Besøg");
            Console.Write("\nIndtast ID på opholdet du vil redigere: ");
            int idValg = Convert.ToInt32(Console.ReadLine());
            SQL.SelectBesøg("select * from Kunder where FakturaNr = " + idValg + "");
            Console.WriteLine("Indtast nummeret på den information du vil opdatere:");
            Console.WriteLine("1. BilId");
            Console.WriteLine("2. Udført\n");
            var info = "";
            ConsoleKeyInfo nummer = Console.ReadKey(true);
            switch (nummer.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Indtast et nyt bil ID: ");
                    //LOGIK til at finde biler og sørge for at kun biler der findes kan indtastes
                    info = Console.ReadLine();
                    SQL.Change("update Besøg set BildId = '" + info + "' where FakturaNr = " + idValg + "");
                    break;
                case ConsoleKey.D2:
                    Console.Write("Indtast nyt udført arbejde: ");
                    info = Console.ReadLine();
                    SQL.Change("update Besøg set Udført = '" + info + "' where FakturaNr = " + idValg + "");
                    break;
                default:
                    Console.WriteLine("Du må kun vælge et nummer fra listen.");
                    break;
            }
        }
        public static void sletBesøg()
        {
            Console.WriteLine("Værkstedlog:\n");
            SQL.SelectBesøg("select * from Besøg");
            Console.WriteLine();
            Console.Write("Indtast ID på værksteds opholdet der skal slettes: ");
            int idValg = Convert.ToInt32(Console.ReadLine());
            SQL.Change("delete from Besøg where FakturaNr = " + idValg + "");
        }
        public static void visBesøg()
        {
            Console.Clear();
            Forside.DisplayTop();
            Console.WriteLine("Værkstedslog:\n");
            SQL.SelectBesøg("select * from Besøg");
            Console.ReadKey();
        }
    }
}
