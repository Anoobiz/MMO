using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
	class Kunde
	{
		public static void opretKunde()
		{
			string Navn;
			string Efternavn;
			string Adr;
			int Postnr;
			int Tlf;
			string OpretDato;
			string Email;
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Indtast Navn: ");
			Console.WriteLine("Indtast Efternavn: ");
			Console.WriteLine("Indtast Adresse: ");
			Console.WriteLine("Indtast Postnummer: ");
			Console.WriteLine("Indtast Telefonnummer: ");
			Console.WriteLine("Indtast E-Mail adresse: ");
			Console.SetCursorPosition(30, 7);
			Navn = Console.ReadLine();
			Console.SetCursorPosition(30, 8);
			Efternavn = Console.ReadLine();
			Console.SetCursorPosition(30, 9);
			Adr = Console.ReadLine();
			Console.SetCursorPosition(30, 10);
			Postnr = Convert.ToInt32(Console.ReadLine());
			Console.SetCursorPosition(30, 11);
			Tlf = Convert.ToInt32(Console.ReadLine());
			Console.SetCursorPosition(30, 12);
			Email = Console.ReadLine();
			OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Kunder values('" + Navn + "', '" + Efternavn + "', '" + Adr + "', " + Postnr + ", " + Tlf + ", '" + Email + "', '" + OpretDato + "')");
		}
		public void opdaterKunde()
		{
			Console.WriteLine("Kundeliste:\n");
			SQL.SelectFewKunde("select * from Kunder");
			Console.WriteLine();
			Console.Write("Indtast ID på kunden du vil redigere: ");
			int idValg = Convert.ToInt32(Console.ReadLine());
			SQL.SelectAllDataKunde("select * from Kunder where KundeId = "+ idValg +"");
			Console.WriteLine("Indtast nummeret på den information du vil opdatere:");
			Console.WriteLine("1. Navn");
			Console.WriteLine("2. Efternavn");
			Console.WriteLine("3. Adresse");
			Console.WriteLine("4. Postnummer");
			Console.WriteLine("5. Telefonnummer");
			Console.WriteLine("6. E-Mail adresse\n");
			var info = "";
			ConsoleKeyInfo nummer = Console.ReadKey(true);
			switch (nummer.Key)
			{
				case ConsoleKey.D1:
					Console.Write("Indtast et nyt navn: ");
					info = Console.ReadLine();
					SQL.Change("update Kunder set Navn = '" + info + "' where KundeId = "+ idValg + "");
					break;
				case ConsoleKey.D2:
					Console.Write("Indtast et nyt efternavn: ");
					info = Console.ReadLine();
					SQL.Change("update Kunder set Efternavn = '" + info + "' where KundeId = " + idValg + "");
					break;
				case ConsoleKey.D3:
					Console.Write("Indtast en ny adresse: ");
					info = Console.ReadLine();
					SQL.Change("update Kunder set Adresse = '" + info + "' where KundeId = " + idValg + "");
					break;
				case ConsoleKey.D4:
					Console.Write("Indtast et nyt postnummer: ");
					info = Console.ReadLine();
					SQL.Change("update Kunder set PostNr = " + info + " where KundeId = " + idValg + "");
					break;
				case ConsoleKey.D5:
					Console.Write("Indtast et nyt telefonnummer: ");
					info = Console.ReadLine();
					SQL.Change("update Kunder set Tlf = " + info + " where KundeId = " + idValg + "");
					break;
				case ConsoleKey.D6:
					Console.Write("Indtast en ny E-Mail adresse: ");
					info = Console.ReadLine();
					SQL.Change("update Kunder set Adresse = '" + info + "' where KundeId = " + idValg + "");
					break;
				default:
					Console.WriteLine("Du må kun vælge et nummer fra listen.");
					break;
			}
		}
		public static void sletKunde()
		{
			Console.WriteLine("Kundeliste:\n");
			SQL.SelectFewKunde("select * from Kunder");
			Console.WriteLine();
			Console.Write("Indtast ID på kunden der skal slettes: ");
			int idValg = Convert.ToInt32(Console.ReadLine());
			SQL.Change("delete from Kunder where KundeId = " + idValg + "");
			SQL.SelectFewKunde("select * from Kunder");
		}
	}
}
