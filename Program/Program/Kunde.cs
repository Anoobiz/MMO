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
		List<Kunde> kunder = new List<Kunde>();

        bool erDerTal;
        bool erDerBogstaver;
		public void opretKunde()
		{
			//string Navn;
			//string Efternavn;
			//string Adr;
			//int Postnr;
			//int Tlf;
			//string OpretDato;
			//string Email;
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
            erDerTal = Navn.Any(c => char.IsDigit(c));
            while (erDerTal)
            {
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Navn må ikke indeholde tal");
                Console.SetCursorPosition(50, 7);
                Navn = Console.ReadLine();
                erDerTal = Navn.Any(c => char.IsDigit(c));
            }
			Console.SetCursorPosition(50, 8);
			Efternavn = Console.ReadLine();
            erDerTal = Efternavn.Any(c => char.IsDigit(c));
            while (erDerTal)
            {
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Efternavn må ikke indeholde tal");
                Console.SetCursorPosition(50, 8);
                Efternavn = Console.ReadLine();
                erDerTal = Navn.Any(c => char.IsDigit(c));
            }
            Console.SetCursorPosition(50, 9);
			Adr = Console.ReadLine();
			Console.SetCursorPosition(50, 10);
			string temp = Console.ReadLine();
            erDerBogstaver = temp.Any(c => char.IsLetter(c));
            if (temp.Length == 4 && !erDerBogstaver)
            {
                Postnr = Convert.ToInt32(temp);
            }else
            {
                while (temp.Length != 4 && erDerBogstaver)
                {
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("Post nr er fire cifre!");
                    Console.SetCursorPosition(50, 10);
                    erDerBogstaver = temp.Any(c => char.IsLetter(c));
                    temp = Console.ReadLine();
                    Postnr = Convert.ToInt32(temp);
                }
            }
            

            Console.SetCursorPosition(50, 11);
            temp = Console.ReadLine();
            erDerBogstaver = temp.Any(c => char.IsLetter(c));
            while (erDerBogstaver)
            {
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Tlf indeholder kun tal");
                Console.SetCursorPosition(50, 11);
                temp = Console.ReadLine();
                erDerTal = temp.Any(c => char.IsDigit(c));
            }
            Tlf = Convert.ToInt32(temp);
            Console.SetCursorPosition(30, 12);
			temp = Console.ReadLine();
            //Ville prøve denne her funktion til tjek af email- se nederst. Ville det være smart med en test-klasse???
            if (IsValidEmail(temp))
            {
                Email = temp;
            }
            else
            {
                while(!IsValidEmail(temp))
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("Indtast gyldig email");
                    Console.SetCursorPosition(50, 12);
                    temp = Console.ReadLine();

                }
            }
            OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Kunder values('" + Navn + "', '" + Efternavn + "', '" + Adr + "', " + Postnr + ", " + Tlf + ", '" + Email + "', '" + OpretDato + "')");			
			kunder.Add(new Kunde(Navn, Efternavn, Adr, Postnr, Tlf, Email, OpretDato));			
		}
		public void KundeListe()
		{
			
		}

		public static void opdaterKunde()
		{
            Console.Clear();
            Forside.DisplayTop();
            Console.WriteLine("Kundeliste:\n");
			SQL.SelectFewKunde("select * from Kunder");
			Console.Write("\nIndtast ID på kunden du vil redigere: ");
           int idValg = Convert.ToInt32(Console.ReadLine()); //exception handling?
			SQL.SelectAllDataKunde("select * from Kunder where KundeId = " + idValg + "");
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
                    bool erDerTal = true;
                    Console.Write("Indtast et nyt navn: ");
                    while (erDerTal)
                    {
                        Console.WriteLine("Navn kan ikke indeholde tal");
                        info = Console.ReadLine();
                        erDerTal = info.Any(c => char.IsDigit(c));

                    }

                    SQL.Change("update Kunder set Navn = '" + info + "' where KundeId = " + idValg + "");
					break;
				case ConsoleKey.D2:
					Console.Write("Indtast et nyt efternavn: ");
					info = Console.ReadLine();
                    erDerTal = info.Any(c => char.IsDigit(c));
                    while (erDerTal)
                    {
                        Console.WriteLine("Navn kan ikke indeholde tal");
                        info = Console.ReadLine();
                        erDerTal = info.Any(c => char.IsDigit(c));
                    }
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
                    string temp = Console.ReadLine();
                    //Try catch og kun fire cifre
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
			SQL.Change("delete from Bil where KundeId = " + idValg + "");
		}
		public static void visKunde()
		{
			int idValg = 0;
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Kundekartotek:\n");
			SQL.SelectFewKunde("select * from Kunder order by Efternavn");
			Console.Write("\nIndtast ID på den kunde du vil se: ");
			try
			{
				idValg = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.WriteLine("Du må kun indtaste tal. Tryk på en tast.");
			}
			SQL.SelectAllDataKunde("select * from Kunder where KundeId = " + idValg + "");
			SQL.SelectFewBil("select * from Bil where KundeId = " + idValg + "");
			Console.ReadKey();

		}
		public Kunde(string navn, string efternavn, string adr, int postnr, int tlf, string opretDato, string email)
		{
			Navn = navn;
			Efternavn = efternavn;
			Adr = adr;
			Postnr = postnr;
			Tlf = tlf;
			OpretDato = opretDato;
			Email = email;

		}
		public Kunde()
		{

		}
        bool IsValidEmail(string email)
        {
            
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
