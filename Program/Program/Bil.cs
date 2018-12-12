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
			int Årgang;
			int KmKørt;
			string Brændstof;
			string OpretDato;
			string RegNr;
			int KundeId;
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
			KundeId = Convert.ToInt32(Console.ReadLine());
			Console.SetCursorPosition(30, 8);
			Mærke = Console.ReadLine();
			Console.SetCursorPosition(30, 9);
			Model = Console.ReadLine();
			Console.SetCursorPosition(30, 10);
			Årgang = Convert.ToInt32(Console.ReadLine());
			Console.SetCursorPosition(30, 11);
			KmKørt = Convert.ToInt32(Console.ReadLine());
			Console.SetCursorPosition(30, 12);
			Brændstof = Console.ReadLine();
			Console.SetCursorPosition(30, 13);
			RegNr = Console.ReadLine();
			OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Bil values(" + KundeId + ",'" + Mærke + "', '" + Model + "', " + Årgang + ", " + KmKørt + ", '" + Brændstof + "', '" + RegNr + "', '" + OpretDato + "')");
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
	}
}
