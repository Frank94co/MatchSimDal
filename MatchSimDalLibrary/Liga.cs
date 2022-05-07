using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchSimDalLibrary
{
    public static class Liga
    {
		public static string Partido(short nivelLocal, short nivelVisitante, bool esNeutral)
		{
			byte resLocal = 0;
			byte resVisitante = 0;
			short modiLocal = 0;
			short modiVisitante = 0;
            if (esNeutral)
            {
                if (nivelLocal == nivelVisitante)
                {
					resLocal = Neutral(0);
					resVisitante = Neutral(0);
                }
                else
                {
                    switch (nivelLocal)
                    {
						case 0:
							modiLocal = Modificador.Alto();
							break;
						case 1:
							modiLocal = Modificador.Medio();
							break;
						case 2:
							modiLocal = Modificador.Bajo();
							break;
						default:
							throw new Exception("Categoría incorrecta");
					}
                    switch (nivelVisitante)
                    {
						case 0:
							modiVisitante = Modificador.Alto();
							break;
						case 1:
							modiVisitante = Modificador.Medio();
							break;
						case 2:
							modiVisitante = Modificador.Bajo();
							break;
						default:
							throw new Exception("Categoría incorrecta");
					}
					if(nivelLocal==0 && nivelVisitante == 1)
                    {
                        if (modiVisitante > 0)
                        {
							if (modiLocal < modiVisitante)
								modiLocal = 0;
							else
								modiLocal -= modiVisitante;

							modiVisitante = 0;
						}
                    }
                    else if(nivelLocal == 1 && nivelVisitante == 0)
                    {
						if (modiLocal > 0)
						{
							if (modiVisitante < modiLocal)
								modiVisitante = 0;
							else
								modiVisitante -= modiLocal;

							modiLocal = 0;
						}
					}
					else if(nivelLocal==1 && nivelVisitante == 2)
                    {
						if (modiLocal < 0)
							modiLocal = 0;
                    }
					else if (nivelLocal == 2 && nivelVisitante == 1)
					{
						if (modiVisitante < 0)
							modiVisitante = 0;
					}
					resLocal = Neutral(modiLocal);
					resVisitante = Neutral(modiVisitante);
				}
            }
            else
            {
				if (nivelLocal == nivelVisitante)
				{
					resLocal = Local(0);
					resVisitante = Visitante(0);
                }
                else
                {
					switch (nivelLocal)
					{
						case 0:
							modiLocal = Modificador.Alto();
							break;
						case 1:
							modiLocal = Modificador.Medio();
							break;
						case 2:
							modiLocal = Modificador.Bajo();
							break;
						default:
							throw new Exception("Categoría incorrecta");
					}
					switch (nivelVisitante)
					{
						case 0:
							modiVisitante = Modificador.Alto();
							break;
						case 1:
							modiVisitante = Modificador.Medio();
							break;
						case 2:
							modiVisitante = Modificador.Bajo();
							break;
						default:
							throw new Exception("Categoría incorrecta");
					}
					if (nivelLocal == 0 && nivelVisitante == 1)
					{
						if (modiVisitante > 0)
						{
							modiVisitante = 0;
							if (modiLocal < modiVisitante)
								modiLocal = 0;
							else
								modiLocal -= modiVisitante;
						}
					}
					else if (nivelLocal == 1 && nivelVisitante == 0)
					{
						if (modiLocal > 0)
						{
							modiLocal = 0;
							if (modiVisitante < modiLocal)
								modiVisitante = 0;
							else
								modiVisitante -= modiLocal;
						}
					}
					else if (nivelLocal == 1 && nivelVisitante == 2)
					{
						if (modiLocal < 0)
							modiLocal = 0;
					}
					else if (nivelLocal == 2 && nivelVisitante == 1)
					{
						if (modiVisitante < 0)
							modiVisitante = 0;
					}
					resLocal = Local(modiLocal);
					resVisitante = Visitante(modiVisitante);
				}
			}
			return resLocal + "-" + resVisitante;
		}
		private static byte Local(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

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
						dado1 = (byte)(rand.Next(100) + 1);
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

		private static byte Visitante(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 35)
			{
				equipo1 += 0;
			}
			else if (dado1 < 71)
			{
				equipo1 += 1;
			}
			else if (dado1 < 90)
			{
				equipo1 += 2;
			}
			else if (dado1 < 97)
			{
				equipo1 += 3;
			}
			else if (dado1 < 100)
			{
				equipo1 += 4;
			}
			else // Caso cuando el dado es 100
			{
				equipo1 = 5;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 66)
				{
					equipo1 += 0;
				}
				else if (dado1 < 88)
				{
					equipo1 += 1;
				}
				else if (dado1 < 95)
				{
					equipo1 += 2;
				}
				else if (dado1 < 100)
				{
					equipo1 += 3;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 4;
					bool haceFalta;
					do // en este punto lanza tantos dados como haga falta
					{
						Random rand = new Random();
						dado1 = (byte)(rand.Next(100) + 1);
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

		private static byte Neutral(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 27)
			{
				equipo1 += 0;
			}
			else if (dado1 < 59)
			{
				equipo1 += 1;
			}
			else if (dado1 < 81)
			{
				equipo1 += 2;
			}
			else if (dado1 < 93)
			{
				equipo1 += 3;
			}
			else if (dado1 < 99)
			{
				equipo1 += 4;
			}
			else if (dado1 < 100)
			{
				equipo1 += 5;
			}
			else // Caso cuando el dado es 100
			{
				equipo1 = 6;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 66)
				{
					equipo1 += 0;
				}
				else if (dado1 < 88)
				{
					equipo1 += 1;
				}
				else if (dado1 < 95)
				{
					equipo1 += 2;
				}
				else if (dado1 < 100)
				{
					equipo1 += 3;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 4;
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
	}
}
