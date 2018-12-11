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
        public static void DisplayTop(int LogoLeftStart)
        {
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
    }
}
