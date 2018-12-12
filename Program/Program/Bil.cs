using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
	class Bil
	{
		public string Mærke { get; set; }
		public string Model { get; set; }
		public int Årgang { get; set; }
		public int KmKørt { get; set; }
		public string Brændstof { get; set; }
		public string OpretDato { get; set; }
		public int RegNr { get; set; }
		public void opretBil()
		{
			Console.Clear();
			Forside.DisplayTop();
			Console.WriteLine("Indtast Mærke: ");
			Console.WriteLine("Indtast Model: ");
			Console.WriteLine("Indtast Årgang: ");
			Console.WriteLine("Indtast KmKørt: ");
			Console.WriteLine("Indtast Brændstof: ");
			Console.WriteLine("Indtast Registreringsnummer: ");
			Console.SetCursorPosition(30, 7);
			Mærke = Console.ReadLine();
			Console.SetCursorPosition(30, 8);
			Model = Console.ReadLine();
			Console.SetCursorPosition(30, 9);
			Årgang = Convert.ToInt32(Console.ReadLine());
			Console.SetCursorPosition(30, 10);
			KmKørt = Convert.ToInt32(Console.ReadLine());
			Console.SetCursorPosition(30, 11);
			Brændstof = Console.ReadLine();
			Console.SetCursorPosition(30, );
			RegNr = Convert.ToInt32(Console.ReadLine());
			OpretDato = DateTime.Now.ToString("d");
			SQL.Change("insert into Bil values('" + Mærke + "', '" + Model + "', '" + Årgang + "', " + KmKørt + ", " + Brændstof + ", '" + RegNr + "', '" + OpretDato + "')");
		}
	}
}
