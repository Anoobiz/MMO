using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
	class Forside
	{
        static void DisplayTop()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("=");
            }
        }
	}
}
