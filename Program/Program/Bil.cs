using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Program
{
	class Bil
	{
		public string Mærke { get; set; }
		public string Model { get; set; }
		public int Årgang { get; set; }
		public int KmKørt { get; set; }
		public string  Brændstof { get; set; }
		public string OpretDato { get; set; }
		public string RegNr { get; set; }
		public int KundeId { get; set; }
		List<Bil> biler = new List<Bil>();
		public void opretBil()
		{
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Indtast KundeID: ");
			Console.WriteLine("Indtast Mærke: ");
			Console.WriteLine("Indtast Model: ");
			Console.WriteLine("Indtast Årgang: ");
			Console.WriteLine("Indtast KmKørt: ");
			Console.WriteLine("Indtast Brændstof: ");
			Console.WriteLine("Indtast RegistreringsNr: ");
			Console.SetCursorPosition(50, 7);
			bool loop = true;
			int idFindes = 0;
            while (loop)
            {
                try
                {
                    KundeId = Convert.ToInt32(Console.ReadLine());
					foreach (DataRow item in SQL.Liste("Select KundeId from Kunder").Rows)
					{
						if (KundeId == Convert.ToInt32(item["KundeId"]))
						{
							idFindes = Convert.ToInt32(item["KundeId"]);							
						}
					}
					if (KundeId == idFindes)
					{
						loop = false;						
					}
					else
					{
						Console.SetCursorPosition(0, 7);
						Console.Write("                                                                                            ");
						Console.SetCursorPosition(0, 7);
						Console.WriteLine("Ugyldigt kundeId, prøv igen:");
						Console.SetCursorPosition(50, 7);
					}
				}
                catch (FormatException)
                {
                    Console.SetCursorPosition(0, 7);
					Console.Write("                                                                                            ");
					Console.SetCursorPosition(0, 7);
					Console.WriteLine("KundeId skal være et tal:");
                    Console.SetCursorPosition(50, 7);                    
                }
                catch (OverflowException)
                {					
                    Console.SetCursorPosition(0, 7);
					Console.Write("                                                                                            ");
					Console.SetCursorPosition(0, 7);
					Console.WriteLine("Tallet er for stort, prøv igen:");					
                    Console.SetCursorPosition(50, 7);                   
                }
            }
			Console.SetCursorPosition(0, 7);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 7);
			Console.WriteLine("KundeId:");
			Console.SetCursorPosition(50, 7);
			Console.WriteLine(KundeId);
			Console.SetCursorPosition(50, 8);
			Mærke = Console.ReadLine();
			Console.SetCursorPosition(0, 8);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 8);
			Console.WriteLine("Mærke:");
			Console.SetCursorPosition(50, 8);
			Console.WriteLine(Mærke);
			Console.SetCursorPosition(50, 9);
			Model = Console.ReadLine();
			Console.SetCursorPosition(0, 9);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 9);
			Console.WriteLine("Model:");
			Console.SetCursorPosition(50, 9);
			Console.WriteLine(Model);
			Console.SetCursorPosition(50, 10);
            while (Årgang == 0)
            {
                try
                {
                    Årgang = Convert.ToInt32(Console.ReadLine());
					if (Årgang < 1900 || Årgang > 2019)
					{
						Console.SetCursorPosition(0, 10);
						Console.Write("                                                                                            ");
						Console.SetCursorPosition(0, 10);
						Console.WriteLine("Indtast en gyldig årgang:");
						Console.SetCursorPosition(50, 10);
						Årgang = 0;
					}
				}
                catch (FormatException)
                {
                    Console.SetCursorPosition(0, 10);
					Console.Write("                                                                                            ");
					Console.SetCursorPosition(0, 10);
					Console.WriteLine("En årgang indeholder kun tal, prøv igen:");
                    Console.SetCursorPosition(50, 10);
                    Console.ReadKey(true);
                }
            }
			Console.SetCursorPosition(0, 10);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 10);
			Console.WriteLine("Årgang:");
			Console.SetCursorPosition(50, 10);
			Console.WriteLine(Årgang);
			Console.SetCursorPosition(50, 11);
            while (KmKørt == 0)
            {
                try
                {
                    KmKørt = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(0, 11);
					Console.Write("                                                                                            ");
					Console.SetCursorPosition(0, 11);
					Console.WriteLine("Km kørt skal være et tal, prøv igen:");
                    Console.SetCursorPosition(50, 11);                    
                }
            }
			Console.SetCursorPosition(0, 11);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 11);
			Console.WriteLine("Kilometer kørt:");
			Console.SetCursorPosition(50, 11);
			Console.WriteLine(KmKørt);
			Console.SetCursorPosition(50, 12);
            Brændstof = Console.ReadLine();
            while (Brændstof.ToLower() != "benzin"&& Brændstof.ToLower() != "diesel")
            {
                Console.SetCursorPosition(0, 12);
				Console.Write("                                                                                            ");
				Console.SetCursorPosition(0, 12);
                Console.WriteLine("Benzin eller diesel:");
                Console.SetCursorPosition(50, 12);
                Brændstof = Console.ReadLine();
            }
			Console.SetCursorPosition(0, 12);
			Console.Write("                                                                                            ");
			Console.SetCursorPosition(0, 12);
			Console.WriteLine("Brændstof:");
			Console.SetCursorPosition(50, 12);
			Console.WriteLine(Brændstof);
			Console.SetCursorPosition(50, 13);
			RegNr = Console.ReadLine();
			OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Bil values(" + KundeId + ",'" + Mærke + "', '" + Model + "', " + Årgang + ", " + KmKørt + ", '" + Brændstof + "', '" + RegNr + "', '" + OpretDato + "')");
			biler.Add(new Bil(Mærke, Model, Årgang, KmKørt, Brændstof, OpretDato, RegNr, KundeId));
		}
		public static void opdaterBil()
		{
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Bil liste:\n");
			SQL.SelectFewBil("select * from Bil");
			Console.Write("\nIndtast ID på bilen du vil redigere: ");
			int idValg = 0;
			try
			{
				idValg = Convert.ToInt32(Console.ReadLine());
				SQL.SelectAllDataBil("select * from Bil where BilId = " + idValg + "");
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
			catch (Exception)
			{
				
			}
		}
		public static void sletBil()
		{
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Bil liste:\n");
			SQL.SelectFewBil("select * from Bil");
			Console.WriteLine();
			Console.Write("Indtast ID på bilen der skal slettes: ");
			int idValg = 0;
			try
			{
				idValg = Convert.ToInt32(Console.ReadLine());
			}
			catch (Exception)
			{
				
			}			
			SQL.Change("delete from Bil where BilId = " + idValg + "");			
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
		public Bil(string mærke, string model, int årgang, int kmKørt, string brændstof, string opretDato, string regNR, int kundeId)
		{
			Mærke = mærke;
			Model = model;
			Årgang = årgang;
			Brændstof = brændstof;
			OpretDato = opretDato;
			RegNr = regNR;
			KundeId = kundeId;
		}
		public Bil()
		{

		}
	}
}
