using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchSimDalLibrary
{
    public static class Modificador
    {
        public static short Alto()
        {
            Random random = new Random();
            byte dado = (byte)(random.Next(10) + 1);
            switch (dado)
            {
                case 1:
                    return 0;
                case 2:
                    return 1;
                case 3:
                    return 2;
                case 4:
                    return 3;
                case 5:
                    return 4;
                case 6:
                    return 5;
                case 7:
                    return 6;
                case 8:
                    return 7;
                case 9:
                    return 8;
                default:
                    return 9;
            }
        }

        public static short Medio()
        {
            Random random = new Random();
            byte dado = (byte)(random.Next(10) + 1);
            switch (dado)
            {
                case 1:
                    return -4;
                case 2:
                    return -3;
                case 3:
                    return -2;
                case 4:
                    return -1;
                case 5:
                case 6:
                    return 0;
                case 7:
                    return 1;
                case 8:
                    return 2;
                case 9:
                    return 3;
                default:
                    return 4;
            }
        }
        public static short Bajo()
        {
            Random random = new Random();
            byte dado = (byte)(random.Next(10) + 1);
            switch (dado)
            {
                case 1:
                    return -9;
                case 2:
                    return -8;
                case 3:
                    return -7;
                case 4:
                    return -6;
                case 5:
                    return -5;
                case 6:
                    return -4;
                case 7:
                    return -3;
                case 8:
                    return -2;
                case 9:
                    return -1;
                default:
                    return 0;
            }
        }

    }
}
