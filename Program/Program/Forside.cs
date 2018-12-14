using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Forside
    {		
		public static void DisplayTop()
        {
            int LogoLeftStart = Console.WindowWidth / 2 - 14;
            int TopBarTop = 0;
            int TopBarBund = 6;
            int Windowwidth = Console.WindowWidth;
            string LogoText = "MONSTER MOSTERS ORIGINALE VÆRKSTED";


            //Top og bund bar
            for (int i = 0; i < Windowwidth; i++)
            {
                Console.SetCursorPosition(i, TopBarTop);
                Console.WriteLine("=");

                Console.SetCursorPosition(i, TopBarBund);
                Console.WriteLine("=");
            }

            // LOGO
            // 1. M
            for (int i = TopBarTop; i < TopBarBund - 1; i++)
            {
                Console.SetCursorPosition(LogoLeftStart, i + 1);
                Console.WriteLine("M");

                Console.SetCursorPosition(LogoLeftStart + 8, i + 1);
                Console.WriteLine("M");
            }
            Console.SetCursorPosition(LogoLeftStart+2,TopBarTop+2);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 3, TopBarTop + 3);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 4, TopBarTop + 4);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 5, TopBarTop + 3);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 6, TopBarTop + 2);
            Console.WriteLine("M");

            //2. M
            for (int i = TopBarTop; i < TopBarBund - 1; i++)
            {
                Console.SetCursorPosition(LogoLeftStart+10, i + 1);
                Console.WriteLine("M");

                Console.SetCursorPosition(LogoLeftStart+ 18, i + 1);
                Console.WriteLine("M");
            }
            Console.SetCursorPosition(LogoLeftStart + 12, TopBarTop + 2);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 13, TopBarTop + 3);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 14, TopBarTop + 4);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 15, TopBarTop + 3);
            Console.WriteLine("M");
            Console.SetCursorPosition(LogoLeftStart + 16, TopBarTop + 2);
            Console.WriteLine("M");

            // O
            for (int i = LogoLeftStart + 20+1; i < LogoLeftStart + 20+8; i++)
            {
                Console.SetCursorPosition(i,TopBarTop+1);
                Console.WriteLine("O");
                Console.SetCursorPosition(i, TopBarBund - 1);
                Console.WriteLine("O");
            }
            for (int i = TopBarTop+2; i < 5; i++)
            {
                Console.SetCursorPosition(LogoLeftStart + 20, i);
                Console.WriteLine("O");
                Console.SetCursorPosition(LogoLeftStart + 28, i);
                Console.WriteLine("O");
            }

            Console.SetCursorPosition((Windowwidth/2)-(LogoText.Length/2),TopBarBund);
            Console.WriteLine(LogoText);
        }

        public static void Menu()
        {
            bool kører = true;
			Kunde Kunder = new Kunde();
			

            while (kører)
            {
                Console.Clear();
                DisplayTop();
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
                //Vælgere til switches
                ConsoleKeyInfo vælger1 = Console.ReadKey(true);
                ConsoleKeyInfo vælger2;
                ConsoleKeyInfo vælger3;	
				//Hovedmenu
				switch (vælger1.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
						Kunde.visKunde();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
						Bil.visBil();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
						Besøg.visBesøg();

                        break;
                    //Rediger menu
                    case ConsoleKey.D4:
                        Console.Clear();
                        DisplayTop();
                        //Redigermenu
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
                            //Rediger kunde
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.SetCursorPosition(5, 8);
                                Console.Write("Opret Kunde              1");
                                Console.SetCursorPosition(5, 9);
                                Console.Write("Rediger Kunde            2");
                                Console.SetCursorPosition(5, 10);
                                Console.Write("Slet Kunde               3");
                                Console.SetCursorPosition(5, 11);
                                Console.Write("Tilbage til hovedmenu    Q");
                                Console.WriteLine();
                                vælger3 = Console.ReadKey(true);
                                switch (vælger3.Key)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
                                        Kunder.opretKunde();
										
                                        break;
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
										Kunde.opdaterKunde();
                                        break;
                                    case ConsoleKey.D3:
                                    case ConsoleKey.NumPad3:
                                        Kunde.sletKunde();
                                        break;
                                    default:
                                        Console.WriteLine("Det var ikke én af valgmulighederne");
                                         break;
                                }
                                break;
                        //Rediger bil
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.SetCursorPosition(5, 8);
                                Console.Write("Opret Bil                1");
                                Console.SetCursorPosition(5, 9);
                                Console.Write("Rediger Bil              2");
                                Console.SetCursorPosition(5, 10);
                                Console.Write("Slet Bil                 3");
                                Console.SetCursorPosition(5, 11);
                                Console.Write("Tilbage til hovedmenu    Q");
                                Console.WriteLine();
                                vælger3 = Console.ReadKey(true);
                                switch (vælger3.Key)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
										Bil.opretBil();
                                        break;
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
										Bil.opdaterBil();
                                        break;
                                    case ConsoleKey.D3:
                                    case ConsoleKey.NumPad3:
										Bil.sletBil();
                                        break;
                                    case ConsoleKey.Q:
                                        break;
                                    default:
                                        Console.WriteLine("Det var ikke én af valgmulighederne");
                                        break;
                                }
                                break;
                        //Rediger værkstedsbesøg
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.SetCursorPosition(5, 8);
                                Console.Write("Opret ny Service         1");
                                Console.SetCursorPosition(5, 9);
                                Console.Write("Rediger Faktura          2");
                                Console.SetCursorPosition(5, 10);
                                Console.Write("Slet faktura             3");
                                Console.SetCursorPosition(5, 11);
                                Console.Write("Tilbage til hovedmenu    Q");
                                Console.WriteLine();
                                vælger3 = Console.ReadKey(true);
                                switch (vælger3.Key)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
										Besøg.opretBesøg();
                                        break;
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
										Besøg.opdaterBesøg();
                                        break;
                                    case ConsoleKey.D3:
                                    case ConsoleKey.NumPad3:
										Besøg.sletBesøg();
                                        break;
                                    default:
                                        Console.WriteLine("Det var ikke én af valgmulighederne");
                                        break;
                                }
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
