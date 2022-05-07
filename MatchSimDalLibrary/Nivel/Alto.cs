using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchSimDalLibrary.Nivel
{
    public static class Alto
    {
		public static byte Local()
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			if (dado1 < 19)
			{
				equipo1 += 0;
			}
			else if (dado1 < 47)
			{
				equipo1 += 1;
			}
			else if (dado1 < 70)
			{
				equipo1 += 2;
			}
			else if (dado1 < 86)
			{
				equipo1 += 3;
			}
			else if (dado1 < 94)
			{
				equipo1 += 4;
			}
			else if (dado1 < 98)
			{
				equipo1 += 5;
			}
			else if (dado1 < 99)
            {
				equipo1 += 6;
            }
			else // Caso cuando el dado es 100
			{
				equipo1 = 7;
				dado1 = (byte)(random.Next(100) + 1);
                if (dado1 < 56)
                {
					equipo1 += 0;
                }
				else if (dado1 < 83)
                {
					equipo1 += 1;
                }
				else if (dado1 < 93)
				{
					equipo1 += 2;
				}
				else if (dado1 < 98)
				{
					equipo1 += 3;
				}
				else if (dado1 < 99)
                {
					equipo1 += 4;
                }
                else // segundo dado otra vez de 100
                {
					equipo1 += 5;
					bool haceFalta;
					do // en este punto lanza tantos dados como haga falta
					{
						Random rand = new Random();
						dado1 = (byte)(random.Next(100) + 1);
						if (dado1 < 90)
                        {
							haceFalta = false;
                        }
                        else if (dado1 < 100)
                        {
							haceFalta = false;
							equipo1 += 1;
                        }
                        else
                        {
							haceFalta = true;
							equipo1 += 1;
                        }
					} while (haceFalta);
                }
			}
			return equipo1;
		}

		public static byte Visitante()
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			if (dado1 < 33)
			{
				equipo1 += 0;
			}
			else if (dado1 < 69)
			{
				equipo1 += 1;
			}
			else if (dado1 < 88)
			{
				equipo1 += 2;
			}
			else if (dado1 < 95)
			{
				equipo1 += 3;
			}
			else if (dado1 < 99)
			{
				equipo1 += 4;
			}
			else
			{
				byte bonus = (byte)(random.Next(4) + 1);
				equipo1 += (byte)(4 + bonus);
			}
			return equipo1;
		}

		public static byte Neutral()
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			if (dado1 < 33)
			{
				equipo1 += 0;
			}
			else if (dado1 < 69)
			{
				equipo1 += 1;
			}
			else if (dado1 < 88)
			{
				equipo1 += 2;
			}
			else if (dado1 < 95)
			{
				equipo1 += 3;
			}
			else if (dado1 < 99)
			{
				equipo1 += 4;
			}
			else
			{
				byte bonus = (byte)(random.Next(4) + 1);
				equipo1 += (byte)(4 + bonus);
			}
			return equipo1;
		}
	}
}
