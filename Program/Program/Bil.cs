using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
	class Bil
	{
		public static void opretBil()
		{
			string Mærke;
			string Model;
			int Årgang = 0;
			int KmKørt = 0;
			string Brændstof = "";
			string OpretDato;
			string RegNr;
			int KundeId = 0;
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Indtast KundeID: ");
			Console.WriteLine("Indtast Mærke: ");
			Console.WriteLine("Indtast Model: ");
			Console.WriteLine("Indtast Årgang: ");
			Console.WriteLine("Indtast KmKørt: ");
			Console.WriteLine("Indtast Brændstof: ");
			Console.WriteLine("Indtast RegistreringsNr: ");
			Console.SetCursorPosition(30, 7);
            while (KundeId == 0)
            {
                try
                {

                    KundeId = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Id skal være et tal");
                    Console.SetCursorPosition(30, 7);
                    Console.ReadKey(true);
                }
                catch (OverflowException)
                {
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Tallet er for stort");
                    Console.SetCursorPosition(30, 7);
                    Console.ReadKey(true);
                }
            }
			Console.SetCursorPosition(30, 8);
			Mærke = Console.ReadLine();
			Console.SetCursorPosition(30, 9);
			Model = Console.ReadLine();
			Console.SetCursorPosition(30, 10);
            while (Årgang == 0)
            {
                try
                {
                    Årgang = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("Indtast kun tal");
                    Console.SetCursorPosition(30, 10);
                    Console.ReadKey(true);
                }
            }
            while (Årgang < 1900 || Årgang > 2019)
            {
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Indtast et gyldigt årstal.");
                Console.SetCursorPosition(30, 10);
                Årgang = Convert.ToInt32(Console.ReadLine());
            }
			Console.SetCursorPosition(30, 11);
            while (KmKørt == 0)
            {
                try
                {
                    KmKørt = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("Indtast tal");
                    Console.SetCursorPosition(30, 11);
                    Console.ReadKey(true);
                }
            }
            
            Console.SetCursorPosition(30, 12);
            Brændstof = Console.ReadLine();
            while (Brændstof.ToLower() != "benzin"&& Brændstof.ToLower() != "diesel")
            {

                Console.SetCursorPosition(0, 12);
                Console.WriteLine("benzin eller diesel?");
                Console.SetCursorPosition(30, 12);
                Brændstof = Console.ReadLine();
            }
			Console.SetCursorPosition(30, 13);
			RegNr = Console.ReadLine();
			OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Bil values(" + KundeId + ",'" + Mærke + "', '" + Model + "', " + Årgang + ", " + KmKørt + ", '" + Brændstof + "', '" + RegNr + "', '" + OpretDato + "')");
		}
		public static void opdaterBil()
		{
			Console.WriteLine("Bil liste:\n");
			SQL.SelectFewBil("select * from Bil");
			Console.Write("\nIndtast ID på bilen du vil redigere: ");
			int idValg = Convert.ToInt32(Console.ReadLine());
			SQL.SelectAllDataKunde("select * from Bil where BilId = " + idValg + "");
			Console.WriteLine("Indtast nummeret på den information du vil opdatere:");
			Console.WriteLine("1. Mærke");
			Console.WriteLine("2. Model");
			Console.WriteLine("3. Årgang");
			Console.WriteLine("4. Km Kørt");
			Console.WriteLine("5. Brændstof");
			Console.WriteLine("6. Registrerings Nr");
			Console.WriteLine("7. Kunde ID\n");
			var info = "";
			ConsoleKeyInfo nummer = Console.ReadKey(true);
			switch (nummer.Key)
			{
				case ConsoleKey.D1:
					Console.Write("Indtast et nyt mærke: ");
					info = Console.ReadLine();
					SQL.Change("update Bil set Mærke = '" + info + "' where BilId = " + idValg + "");
					break;
				case ConsoleKey.D2:
					Console.Write("Indtast en ny model: ");
					info = Console.ReadLine();
					SQL.Change("update Bil set Model = '" + info + "' where BilId = " + idValg + "");
					break;
				case ConsoleKey.D3:
					Console.Write("Indtast en ny årgang: ");
					info = Console.ReadLine();
					SQL.Change("update Bil set Årgang = '" + info + "' where BilId = " + idValg + "");
					break;
				case ConsoleKey.D4:
					Console.Write("Indtast et antal Km kørt: ");
					info = Console.ReadLine();
					SQL.Change("update Bil set KmKørt = " + info + " where BilId = " + idValg + "");
					break;
				case ConsoleKey.D5:
					Console.Write("Indtast en ny slags brændstof: ");
					info = Console.ReadLine();
					SQL.Change("update Bil set Brændstof = " + info + " where BilId = " + idValg + "");
					break;
				case ConsoleKey.D6:
					Console.Write("Indtast et nyt registrerings nr: ");
					info = Console.ReadLine();
					SQL.Change("update Bil set RegNr = '" + info + "' where BilId = " + idValg + "");
					break;
				case ConsoleKey.D7:
					Console.Write("Indtast et nyt kunde ID: ");
					info = Console.ReadLine();
					SQL.Change("update Bil set KundeId = '" + info + "' where BilId = " + idValg + "");
					break;
				default:
					Console.WriteLine("Du må kun vælge et nummer fra listen.");
					break;
			}
		}
		public static void sletBil()
		{
			Console.WriteLine("Bil liste:\n");
			SQL.SelectFewBil("select * from Bil");
			Console.WriteLine();
			Console.Write("Indtast ID på bilen der skal slettes: ");
			int idValg = Convert.ToInt32(Console.ReadLine());
			SQL.Change("delete from Bil where BilId = " + idValg + "");
			SQL.SelectFewBil("select * from Bil");
		}
		public static void visBil()
		{
			int idValg = 0;
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Bilkartotek:\n");
			SQL.SelectFewBil("select * from Bil");
			Console.Write("\nIndtast ID på den bil du vil se: ");
			try
			{
				idValg = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.WriteLine("Du må kun indtaste tal. Tryk på en tast.");
			}
			SQL.SelectAllDataBil("select * from Bil where BilId = " + idValg + "");
			SQL.SelectBesøg("select * from Besøg where BilId = " + idValg + "");
			Console.ReadKey();
		}
	}
}
