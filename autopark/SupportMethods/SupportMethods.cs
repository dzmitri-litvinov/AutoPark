using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public static class SupportMethods
    {
        public static void PrintScreenLine(int scrWidth)
        {
            Console.WriteLine(new string('*', scrWidth) + '\n');
        }

        public static void PrintNewLevel(int levelNumber)
        {
            Console.WriteLine($"////////////\n" +
                              $"//Level 0{levelNumber}//\n" +
                              $"////////////");
        }
    }
}
