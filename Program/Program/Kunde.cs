using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
	class Kunde
	{
		public string Navn { get; set; }
		public string Efternavn { get; set; }
		public string Adr { get; set; }
		public int Postnr { get; set; }
		public int Tlf { get; set; }
		public string OpretDato { get; set; }
		public string Email { get; set; }

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
		public void sletKunde()
		{
			Console.WriteLine("Kundeliste:\n");
			SQL.SelectFewKunde("select * from Kunder");
			Console.WriteLine();
			Console.Write("Indtast ID på kunden der skal slettes: ");
			int idValg = Convert.ToInt32(Console.ReadLine());
			SQL.Change("delete from Kunder where KundeId = " + idValg + "");
			SQL.SelectFewKunde("select * from Kunder");

		}
		public void opretKunde()
		{
			Console.Clear();
			Console.WriteLine("Indtast Navn: ");		
			Console.WriteLine("Indtast Efternavn: ");
			Console.WriteLine("Indtast Adresse: ");
			Console.WriteLine("Indtast Postnummer: ");
			Console.WriteLine("Indtast Telefonnummer: ");
			Console.WriteLine("Indtast E-Mail adresse: ");
			Navn = Console.ReadLine();
			Efternavn = Console.ReadLine();			
			Adr = Console.ReadLine();
			Postnr = Convert.ToInt32(Console.ReadLine());
			Tlf = Convert.ToInt32(Console.ReadLine());
			Email = Console.ReadLine();
			OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Kunder values('" + Navn + "', '" + Efternavn + "', '" + Adr + "', " + Postnr + ", " + Tlf + ", '" + Email + "', '" + OpretDato + "')"); 

			
		}
		//public Kunde(string navn, string efternavn, string adresse, int postnr, int tlf, string email, DateTime opretDato)
		//{
		//	Navn = navn;
		//	Efternavn = efternavn;
		//	Adr = adresse;
		//	Postnr = postnr;
		//	Tlf = tlf;
		//	Email = email;
		//	OpretDato = opretDato;
		//}
	}
}
