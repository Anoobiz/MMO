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
		public void opretKunde()
		{
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Indtast Navn: ");
			Console.WriteLine("Indtast Efternavn: ");
			Console.WriteLine("Indtast Adresse: ");
			Console.WriteLine("Indtast Postnummer: ");
			Console.WriteLine("Indtast Telefonnummer: ");
			Console.WriteLine("Indtast E-Mail adresse: ");
			Console.SetCursorPosition(50, 7);
			Navn = Console.ReadLine();
			erDerTal = Navn.Any(c => char.IsDigit(c));
			while (erDerTal)
			{
				Console.SetCursorPosition(0, 7);
				Console.Write("                                                                                            ");
				Console.SetCursorPosition(0, 7);
				Console.WriteLine("Navn må ikke indeholde tal, prøv igen:");
				Console.SetCursorPosition(50, 7);
				Navn = Console.ReadLine();
				erDerTal = Navn.Any(c => char.IsDigit(c));
			}
			Console.SetCursorPosition(0, 7);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 7);
			Console.WriteLine("Navn:");
			Console.SetCursorPosition(50, 7);
			Console.WriteLine(Navn);
			Console.SetCursorPosition(50, 8);
			Efternavn = Console.ReadLine();
			erDerTal = Efternavn.Any(c => char.IsDigit(c));
			while (erDerTal)
			{
				Console.SetCursorPosition(0, 8);
				Console.Write("                                                                                            ");
				Console.SetCursorPosition(0, 8);
				Console.WriteLine("Efternavn må ikke indeholde tal, prøv igen:");
				Console.SetCursorPosition(50, 8);
				Efternavn = Console.ReadLine();
				erDerTal = Efternavn.Any(c => char.IsDigit(c));
			}
			Console.SetCursorPosition(0, 8);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 8);
			Console.WriteLine("Efternavn:");
			Console.SetCursorPosition(50, 8);
			Console.WriteLine(Efternavn);
			Console.SetCursorPosition(50, 9);
			Adr = Console.ReadLine();
			Console.SetCursorPosition(0, 9);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 9);
			Console.WriteLine("Adresse:");
			Console.SetCursorPosition(50, 9);
			Console.WriteLine(Adr);
			Console.SetCursorPosition(50, 10);
			bool PostNrLoop = true;
			while (PostNrLoop)
			{
				try
				{
					Postnr = Convert.ToInt32(Console.ReadLine());
					if (Postnr.ToString().Length != 4)
					{
						Console.SetCursorPosition(0, 10);
						Console.Write("                                                                                            ");
						Console.SetCursorPosition(0, 10);
						Console.WriteLine("Et postnummer er altid 4 cifre, prøv igen:");
						Console.SetCursorPosition(50, 10);
					}
					else
					{
						PostNrLoop = false;
					}
				}
				catch (Exception)
				{
					Console.SetCursorPosition(0, 10);
					Console.Write("                                                                                            ");
					Console.SetCursorPosition(0, 10);
					Console.WriteLine("Et postnummer er altid et tal med 4 cifre, prøv igen:");
					Console.SetCursorPosition(50, 10);
				}
			}
			Console.SetCursorPosition(0, 10);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 10);
			Console.WriteLine("Postnummer:");
			Console.SetCursorPosition(50, 10);
			Console.WriteLine(Postnr);
			Console.SetCursorPosition(50, 11);
			bool TlfLoop = true;
			while (TlfLoop)
			{
				try
				{
					Tlf = Convert.ToInt32(Console.ReadLine());
					if (Tlf.ToString().Length != 8)
					{
						Console.SetCursorPosition(0, 11);
						Console.Write("                                                                                            ");
						Console.SetCursorPosition(0, 11);
						Console.WriteLine("Et telefonnummer er altid 8 cifre:");
						Console.SetCursorPosition(50, 11);
					}
					else
					{
						TlfLoop = false;
					}
				}
				catch (Exception)
				{
					Console.SetCursorPosition(0, 11);
					Console.Write("                                                                                            ");
					Console.SetCursorPosition(0, 11);
					Console.WriteLine("Et telefonnummer er altid tal med 8 cifre:");
					Console.SetCursorPosition(50, 11);
				}
			}
			Console.SetCursorPosition(0, 11);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 11);
			Console.WriteLine("Telefonnummer:");
			Console.SetCursorPosition(50, 11);
			Console.WriteLine(Tlf);
			Console.SetCursorPosition(50, 12);
			Email = Console.ReadLine();
			while (!IsValidEmail(Email))
			{
				Console.SetCursorPosition(0, 12);
				Console.Write("                                                                                            ");
				Console.SetCursorPosition(0, 12);
				Console.WriteLine("Ugyldig indtastning, prøv igen:");
				Console.SetCursorPosition(50, 12);
				Email = Console.ReadLine();
			}
			Console.SetCursorPosition(0, 12);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 12);
			Console.WriteLine("Email adresse:");
			Console.SetCursorPosition(50, 12);
			Console.WriteLine(Email);
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
			int idValg = 0;
			try
			{
				idValg = Convert.ToInt32(Console.ReadLine());
				SQL.SelectAllDataKunde("select * from Kunder where KundeId = " + idValg + "");
				Console.WriteLine("Indtast nummeret på den information du vil opdatere:");
				Console.WriteLine("1. Navn");
				Console.WriteLine("2. Efternavn");
				Console.WriteLine("3. Adresse");
				Console.WriteLine("4. Postnummer");
				Console.WriteLine("5. Telefonnummer");
				Console.WriteLine("6. E-Mail adresse\n");
				var info = "";
				bool erDerTal;
				ConsoleKeyInfo nummer = Console.ReadKey(true);
				switch (nummer.Key)
				{
					case ConsoleKey.D1:
						Console.Write("Indtast et nyt navn: ");
						info = Console.ReadLine();
						erDerTal = info.Any(c => char.IsDigit(c));						
						while (erDerTal)
						{
							Console.WriteLine("Navn kan ikke indeholde tal, prøv igen");
							Console.Write("Indtast et nyt navn: ");
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
							Console.WriteLine("Navn kan ikke indeholde tal, prøv igen");
							Console.Write("Indtast et nyt navn: ");
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
						bool PostNrLoop = true;
						while (PostNrLoop)
						{
							try
							{
								info = Console.ReadLine();
								if (info.ToString().Length != 4)
								{
									Console.WriteLine("Et postnummer er altid 4 cifre, prøv igen:");
									Console.Write("Indtast et nyt postnummer: ");
								}
								else
								{
									PostNrLoop = false;
								}
							}
							catch (Exception)
							{
								Console.WriteLine("Et postnummer er altid et tal med 4 cifre, prøv igen:");
								Console.Write("Indtast et nyt postnummer: ");
							}
						}
						SQL.Change("update Kunder set PostNr = " + info + " where KundeId = " + idValg + "");
						break;
					case ConsoleKey.D5:
						Console.Write("Indtast et nyt telefonnummer: ");
						bool TlfLoop = true;
						while (TlfLoop)
						{
							try
							{
								info = Console.ReadLine();
								if (info.ToString().Length != 8)
								{
									Console.WriteLine("Et telefonnummer er altid 8 cifre:");
									Console.Write("Indtast et nyt telefonnummer: ");
								}
								else
								{
									TlfLoop = false;
								}
							}
							catch (Exception)
							{
								Console.WriteLine("Et telefonnummer er altid tal med 8 cifre:");
								Console.Write("Indtast et nyt telefonnummer: ");
							}
						}
						SQL.Change("update Kunder set Tlf = " + info + " where KundeId = " + idValg + "");
						break;
					case ConsoleKey.D6:
						Console.Write("Indtast en ny E-Mail adresse: ");
						info = Console.ReadLine();
						while (!IsValidEmail(info))
						{
							Console.WriteLine("Ugyldig indtastning, prøv igen:");
							Console.Write("Indtast en ny E-Mail adresse: ");
							info = Console.ReadLine();
						}
						SQL.Change("update Kunder set Email = '" + info + "' where KundeId = " + idValg + "");
						break;
					default:
						Console.WriteLine("Du må kun vælge et nummer fra listen.");
						break;
				}
			}
			catch (Exception)
			{
				
			}

		}
		public static void sletKunde()
		{
			Console.WriteLine("Kundeliste:\n");
			SQL.SelectFewKunde("select * from Kunder");
			Console.WriteLine();
			Console.Write("Indtast ID på kunden der skal slettes: ");
			int idValg = 0;
			try
			{
				idValg = Convert.ToInt32(Console.ReadLine());
			}
			catch (Exception)
			{

			}
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
		static bool IsValidEmail(string email)
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
