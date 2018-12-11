using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
	class Program
	{
		static void Main(string[] args)
		{
            
            bool kører = true;
          

            while (kører)
            {
                Console.Clear();
                Forside.DisplayTop(4);
                //placerer alt under vores header
                Console.SetCursorPosition(5, 8);
                Console.Write("Kundekartotek    1");
                Console.SetCursorPosition(5, 9);
                Console.Write("Bilbase          2");
                Console.SetCursorPosition(5, 10);
                Console.Write("Værkstedsbesøg   3");
                Console.SetCursorPosition(5, 11);
                Console.Write("Afslut program   Q");
                Console.WriteLine();
                ConsoleKeyInfo vælger = Console.ReadKey(true);

                switch (vælger.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("1 er valgt");
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("2 valgt");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Værkstedsbesøg");
                        break;
                    case ConsoleKey.Q:
                        kører = false;
                        break;
                    default:
                        Console.WriteLine("Det var vist ikke 1, 2, 3 eller q");
                        break;
                }
            }
            Environment.Exit(0);
            Console.ReadKey();
		}
	}
}
