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
                Forside.DisplayTop();
                //placerer alt under vores header
                Console.SetCursorPosition(5, 8);
                Console.Write("Vis Kundekartotek    1");
                Console.SetCursorPosition(5, 9);
                Console.Write("Vis Bilbase          2");
                Console.SetCursorPosition(5, 10);
                Console.Write("Vis Værkstedslog     3");
                Console.SetCursorPosition(5, 11);
                Console.Write("Administrér          4");
                Console.SetCursorPosition(5, 12);
                Console.Write("Afslut program       Q");
                Console.WriteLine();
                ConsoleKeyInfo vælger1 = Console.ReadKey(true);
                ConsoleKeyInfo vælger2;

                switch (vælger1.Key)
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
                        //Rediger databaser menu
                    case ConsoleKey.D4:
                        Console.Clear();
                        Forside.DisplayTop();
                        //placerer alt under vores header
                        Console.SetCursorPosition(5, 8);
                        Console.Write("Rediger Kundekartotek    1");
                        Console.SetCursorPosition(5, 9);
                        Console.Write("Rediger Bilbase          2");
                        Console.SetCursorPosition(5, 10);
                        Console.Write("Rediger Værkstedslog     3");
                        Console.SetCursorPosition(5, 11);
                        Console.Write("Tilbage til hovedmenu    Q");
                        Console.WriteLine();
                        vælger2 = Console.ReadKey(true);
                        switch (vælger2.Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.WriteLine("Indsæt indsæt-kode her");
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.WriteLine("Indsæt indsæt-kode her");
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.WriteLine("Indsæt indsæt-kode her");
                                break;
                            case ConsoleKey.Q:
                               
                                break;
                            default:
                                Console.WriteLine("Det var vist ikke 1, 2, 3 eller q");
                                break;
                        }

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
