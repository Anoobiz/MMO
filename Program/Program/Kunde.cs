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

		private static void opdaterKunde()
		{

		}
		public void sletKunde()
		{
			Console.WriteLine("Kundeliste:\n");
			SQL.SelectFewKunde("select KundeId, Navn, Efternavn from Kunder");
			Console.WriteLine();
			Console.Write("Indtast ID på kunden der skal slettes: ");
			int idValg = Convert.ToInt32(Console.ReadLine());
			SQL.Change("delete from Kunder where KundeId = " + idValg + "");
			SQL.SelectFewKunde("select KundeId, Navn, Efternavn from Kunder");

		}
		public void opretKunde()
		{
			Console.Clear();
			Console.WriteLine("Indtast Navn: ");		
			Console.WriteLine("Indtast Efternavn: ");
			Console.WriteLine("Indtast adresse: ");
			Console.WriteLine("Indtast Postnummer: ");
			Console.WriteLine("Intast telefonnummer: ");
			Console.WriteLine("Indtast E-Mail adresse: ");
			Navn = Console.ReadLine();
			Efternavn = Console.ReadLine();			
			Adr = Console.ReadLine();
			Postnr = Convert.ToInt32(Console.ReadLine());
			Tlf = Convert.ToInt32(Console.ReadLine());
			Email = Console.ReadLine();
			OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Kunder values('" + Navn + "', '" + Efternavn + "', '" + Adr + "', " + Postnr + ", " + Tlf + ",'" + OpretDato + "', '" + Email + "')"); 

			
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
