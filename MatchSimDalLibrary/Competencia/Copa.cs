using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchSimDalLibrary.Competencia
{
    public static class Copa
    {

		public static string PartidoEquipos(Equipo local, Equipo visitante, out bool ganadorLocal)
        {
			string resultado = "";
			byte resLocal = 0;
			byte resVisitante = 0;
			short modiLocal = 0;
			short modiVisitante = 0;

			short categoriaLocal = local.Categoria;
			short nivelLocal = local.Nivel;
			short categoriaVisitante = visitante.Categoria;
			short nivelVisitante = visitante.Nivel;

			if (categoriaLocal < 1)
			{
				throw new ArgumentException("Se envió una categoría local incorrecta");
			}

			if (categoriaVisitante < 1)
			{
				throw new ArgumentException("Se envió una categoría visitante incorrecta");
			}

			if (nivelLocal > 2 || nivelLocal < 0)
			{
				throw new ArgumentException("Se envió un nivel local incorrecto");
			}

			if (nivelVisitante > 2 || nivelVisitante < 0)
			{
				throw new ArgumentException("Se envió un nivel visitante incorrecto");
			}

			List<short> superiores = new List<short> { 0, 1 };
			List<short> inferiores = new List<short> { 1, 2 };

			if (categoriaLocal == categoriaVisitante && nivelLocal == nivelVisitante)
			{
				resLocal = PrimeraLocal(modiLocal);
				resVisitante = PrimeraVisitante(modiVisitante);
			}
			else
			{
				short diferencia = (short)(categoriaLocal - categoriaVisitante);
				if (diferencia > 0)
				{
					if (inferiores.Contains(nivelLocal))
					{
						switch (nivelLocal)
						{
							case 1:
								short aux = Modificador.Medio();
								modiLocal = aux > 0 ? (short)0 : aux;
								break;
							case 2:
								modiLocal = Modificador.Bajo();
								break;
						}
					}

					if (superiores.Contains(nivelVisitante))
					{
						switch (nivelVisitante)
						{
							case 0:
								modiVisitante = Modificador.Alto();
								break;
							case 1:
								short aux = Modificador.Medio();
								modiVisitante = aux < 0 ? (short)0 : aux;
								break;
						}
					}
					resVisitante = PrimeraVisitante(modiVisitante);
					switch (diferencia)
					{
						case 1:
							resLocal = SegundaLocal(modiLocal);
							break;
						case 2:
							resLocal = TerceraLocal(modiLocal);
							break;
						case 3:
							resLocal = CuartaLocal(modiLocal);
							break;
						default:
							resLocal = QuintaLocal(modiLocal);
							break;
					}
				}
				else
				{
					if (inferiores.Contains(nivelVisitante))
					{
						switch (nivelVisitante)
						{
							case 1:
								short aux = Modificador.Medio();
								modiVisitante = aux > 0 ? (short)0 : aux;
								break;
							case 2:
								modiVisitante = Modificador.Bajo();
								break;
						}
					}

					if (superiores.Contains(nivelLocal))
					{
						switch (nivelLocal)
						{
							case 0:
								modiLocal = Modificador.Alto();
								break;
							case 1:
								short aux = Modificador.Medio();
								modiLocal = aux < 0 ? (short)0 : aux;
								break;
						}
					}
					resLocal = PrimeraLocal(modiLocal);
					switch (diferencia)
					{
						case -1:
							resVisitante = SegundaVisitante(modiVisitante);
							break;
						case -2:
							resVisitante = TerceraVisitante(modiVisitante);
							break;
						case -3:
							resVisitante = CuartaVisitante(modiVisitante);
							break;
						default:
							resVisitante = QuintaVisitante(modiVisitante);
							break;
					}
				}
			}

			resultado = $"{local} {resLocal}-{resVisitante} {visitante}. ";
            if (resLocal > resVisitante)
            {
				ganadorLocal = true;
            }
			else if (resLocal < resVisitante)
            {
				ganadorLocal = false;
            }
			else
			{
				var tanda = EjecutarTandaPenaltis();
				resultado += $"En la tanda quedaron {tanda.Item1}-{tanda.Item2}, después de {tanda.Item3} penaltis lanzados.";
                if (tanda.Item1 > tanda.Item2)
                {
					ganadorLocal = true;
                }
                else 
                {
					ganadorLocal= false;
                }
			}
			return resultado.Trim();
		}
		public static string Partido(short categoriaLocal, short nivelLocal, short categoriaVisitante,
									 short nivelVisitante)
        {
			string resultado = "";
			byte resLocal = 0;
			byte resVisitante = 0;
			short modiLocal = 0;
			short modiVisitante = 0;

            if (categoriaLocal < 1)
            {
				throw new ArgumentException("Se envió una categoría local incorrecta");
			}

			if (categoriaVisitante < 1)
			{
				throw new ArgumentException("Se envió una categoría visitante incorrecta");
			}

			if (nivelLocal > 2 || nivelLocal < 0)
            {
				throw new ArgumentException("Se envió un nivel local incorrecto");
            }

			if (nivelVisitante > 2 || nivelVisitante < 0)
			{
				throw new ArgumentException("Se envió un nivel visitante incorrecto");
			}

			List<short> superiores = new List<short> { 0, 1 };
			List<short> inferiores = new List<short> { 1, 2 };

			if(categoriaLocal==categoriaVisitante && nivelLocal == nivelVisitante)
            {
				resLocal = PrimeraLocal(modiLocal);
				resVisitante = PrimeraVisitante(modiVisitante);
            }
            else
            {
				short diferencia = (short)(categoriaLocal - categoriaVisitante);
				if(diferencia > 0)
                {
                    if (inferiores.Contains(nivelLocal))
                    {
                        switch (nivelLocal)
                        {
							case 1:
								short aux = Modificador.Medio();
								modiLocal = aux > 0 ? (short)0 : aux;
								break;
							case 2:
								modiLocal = Modificador.Bajo();
								break;
						}
                    }

					if (superiores.Contains(nivelVisitante))
					{
						switch (nivelVisitante)
						{
							case 0:
								modiVisitante = Modificador.Alto();
								break;
							case 1:
								short aux = Modificador.Medio();
								modiVisitante = aux < 0 ? (short)0 : aux;
								break;
						}
					}
					resVisitante = PrimeraVisitante(modiVisitante);
					switch (diferencia)
                    {
						case 1:
							resLocal = SegundaLocal(modiLocal);
							break;
						case 2:
							resLocal = TerceraLocal(modiLocal);
							break;
						case 3:
							resLocal = CuartaLocal(modiLocal);
							break;
						default:
							resLocal = QuintaLocal(modiLocal);
							break;
					}
				}
                else
                {
					if (inferiores.Contains(nivelVisitante))
					{
						switch (nivelVisitante)
						{
							case 1:
								short aux = Modificador.Medio();
								modiVisitante = aux > 0 ? (short)0 : aux;
								break;
							case 2:
								modiVisitante = Modificador.Bajo();
								break;
						}
					}

					if (superiores.Contains(nivelLocal))
					{
						switch (nivelLocal)
						{
							case 0:
								modiLocal = Modificador.Alto();
								break;
							case 1:
								short aux = Modificador.Medio();
								modiLocal = aux < 0 ? (short)0 : aux;
								break;
						}
					}
					resLocal = PrimeraLocal(modiLocal);
					switch (diferencia)
					{
						case -1:
							resVisitante = SegundaVisitante(modiVisitante);
							break;
						case -2:
							resVisitante = TerceraVisitante(modiVisitante);
							break;
						case -3:
							resVisitante = CuartaVisitante(modiVisitante);
							break;
						default:
							resVisitante = QuintaVisitante(modiVisitante);
							break;
					}
				}
            }

			resultado = $"El partido quedó {resLocal}-{resVisitante}. ";
            if (resLocal == resVisitante)
            {
				var tanda = EjecutarTandaPenaltis();
				resultado += $"En la tanda quedaron {tanda.Item1}-{tanda.Item2}, después de {tanda.Item3} penaltis lanzados.";
            }

			return resultado.Trim();
        }
		private static byte PrimeraLocal(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 16)
			{
				equipo1 += 0;
			}
			else if (dado1 < 40)
			{
				equipo1 += 1;
			}
			else if (dado1 < 60)
			{
				equipo1 += 2;
			}
			else if (dado1 < 80)
			{
				equipo1 += 3;
			}
			else if (dado1 < 91)
			{
				equipo1 += 4;
			}
			else if (dado1 < 96)
			{
				equipo1 += 5;
			}
			else if (dado1 < 100)
			{
				equipo1 += 6;
			}
			else
			{
				equipo1 = 7;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 51)
				{
					equipo1 += 0;
				}
				else if (dado1 < 80)
				{
					equipo1 += 1;
				}
				else if (dado1 < 92)
				{
					equipo1 += 2;
				}
				else if (dado1 < 98)
				{
					equipo1 += 3;
				}
				else if (dado1 < 100)
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

		private static byte PrimeraVisitante(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 26)
			{
				equipo1 += 0;
			}
			else if (dado1 < 50)
			{
				equipo1 += 1;
			}
			else if (dado1 < 75)
			{
				equipo1 += 2;
			}
			else if (dado1 < 90)
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
			else
			{
				equipo1 = 6;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 76)
				{
					equipo1 += 0;
				}
				else if (dado1 < 92)
				{
					equipo1 += 1;
				}
				else if (dado1 < 100)
				{
					equipo1 += 2;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 3;
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

		private static byte SegundaLocal(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 30)
			{
				equipo1 += 0;
			}
			else if (dado1 < 65)
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
			else
			{
				equipo1 = 4;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 76)
				{
					equipo1 += 0;
				}
				else if (dado1 < 100)
				{
					equipo1 += 1;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 2;
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

		private static byte SegundaVisitante(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 40)
			{
				equipo1 += 0;
			}
			else if (dado1 < 90)
			{
				equipo1 += 1;
			}
			else if (dado1 < 100)
			{
				equipo1 += 2;
			}
			else
			{
				equipo1 = 3;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 76)
				{
					equipo1 += 0;
				}
				else if (dado1 < 100)
				{
					equipo1 += 1;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 2;
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

		private static byte TerceraLocal(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 36)
			{
				equipo1 += 0;
			}
			else if (dado1 < 90)
			{
				equipo1 += 1;
			}
			else if (dado1 < 100)
			{
				equipo1 += 2;
			}
			else
			{
				equipo1 = 3;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 76)
				{
					equipo1 += 0;
				}
				else if (dado1 < 100)
				{
					equipo1 += 1;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 2;
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

		private static byte TerceraVisitante(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 50)
			{
				equipo1 += 0;
			}
			else if (dado1 < 94)
			{
				equipo1 += 1;
			}
			else if (dado1 < 100)
			{
				equipo1 += 2;
			}
			else
			{
				equipo1 = 3;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 100)
				{
					equipo1 += 0;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 1;
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

		private static byte CuartaLocal(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 46)
			{
				equipo1 += 0;
			}
			else if (dado1 < 95)
			{
				equipo1 += 1;
			}
			else if (dado1 < 100)
			{
				equipo1 += 2;
			}
			else
			{
				equipo1 = 3;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 100)
				{
					equipo1 += 0;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 1;
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

		private static byte CuartaVisitante(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 56)
			{
				equipo1 += 0;
			}
			else if (dado1 < 100)
			{
				equipo1 += 1;
			}
			else
			{
				equipo1 = 2;
				dado1 = (byte)(random.Next(100) + 1);
                if (dado1 < 76)
                {
					equipo1 += 0;
				}
				if (dado1 < 100)
				{
					equipo1 += 1;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 2;
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

		private static byte QuintaLocal(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 50)
			{
				equipo1 += 0;
			}
			else if (dado1 < 100)
			{
				equipo1 += 1;
			}
			else
			{
				equipo1 = 2;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 76)
				{
					equipo1 += 0;
				}
				else if (dado1 < 100)
				{
					equipo1 += 1;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 2;
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

		private static byte QuintaVisitante(short modificador)
		{
			Random random = new Random();
			byte equipo1 = 0;
			byte dado1 = (byte)(random.Next(100) + 1);

			dado1 = (dado1 + modificador < 0) ? (byte)1 : (byte)(dado1 + modificador);

			if (dado1 < 60)
			{
				equipo1 += 0;
			}
			else if (dado1 < 100)
			{
				equipo1 += 1;
			}
			else
			{
				equipo1 = 2;
				dado1 = (byte)(random.Next(100) + 1);
				if (dado1 < 100)
				{
					equipo1 += 0;
				}
				else // segundo dado otra vez de 100
				{
					equipo1 += 1;
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

		private static Tuple<int, int, int> EjecutarTandaPenaltis()
		{
			int pLocal = 0, pVisitante = 0, diferenciaInt = 0, iaux = 0;
			for (int i = 1; i <= 5; i++)
			{
				iaux = i;
				Random random = new Random();
				int dadoLocal = random.Next(1000) + 1;
				int dadoVisitante = random.Next(1000) + 1;
				switch (i)
				{
					case 1:
						if (dadoLocal >= 206)
							pLocal++;
						if (dadoVisitante >= 206)
							pVisitante++;
						break;
					case 2:
						if (dadoLocal >= 206)
							pLocal++;
						if (dadoVisitante >= 206)
							pVisitante++;
						break;
					case 3:
						if (dadoLocal >= 274)
							pLocal++;
						if (dadoVisitante >= 274)
							pVisitante++;
						break;
					case 4:
						if (dadoLocal >= 236)
							pLocal++;
						if (dadoVisitante >= 236)
							pVisitante++;
						break;
					case 5:
						if (dadoLocal >= 160)
							pLocal++;
						if (dadoVisitante >= 160)
							pVisitante++;
						break;
				}
				diferenciaInt = Math.Abs(pLocal - pVisitante);
				if (diferenciaInt >= 3 && i >= 3)
					break;
				if (diferenciaInt >= 2 && i >= 4)
					break;
			}
			if (diferenciaInt > 0)
			{
				return new Tuple<int, int, int>(pLocal, pVisitante, iaux);
			}
			else
			{
				int penalLanzado = 6;
				while (diferenciaInt == 0)
				{
					Random random = new Random();
					int dadoLocal = random.Next(1000) + 1;
					int dadoVisitante = random.Next(1000) + 1;
					if (dadoLocal >= 327)
						pLocal++;
					if (dadoVisitante >= 327)
						pVisitante++;
					diferenciaInt = Math.Abs(pLocal - pVisitante);
					if (diferenciaInt > 0)
						break;
					else
						penalLanzado++;
				}
				return new Tuple<int, int, int>(pLocal, pVisitante, penalLanzado);
			}
		}
	}
}
