using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public static class PrintVehicle
    {
        public static string ToString(Vehicle[] obj)
        {
            int n = obj.Length;
            string[] strArray = new string[n];

            for (int i = 0; i < n; i++)
                strArray[i] = obj[i].ToString();

            string str = string.Join("\n", strArray);

            return str;
        }
    }
}
