using MatchSimDalLibrary;
using MatchSimDalLibrary.Competencia;
using MatchSimDalWindows.Helpers;

namespace MatchSimDalWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCampoNeutral_Click(object sender, EventArgs e)
        {
            MatchStandardForm matchStandardForm= new MatchStandardForm(true);
            matchStandardForm.Show();
        }

        private void btnLocVisi_Click(object sender, EventArgs e)
        {
            MatchStandardForm matchStandardForm = new MatchStandardForm(false);
            matchStandardForm.Show();
        }

        private void btnCopa_Click(object sender, EventArgs e)
        {
            MatchCupForm matchCupForm = new MatchCupForm();
            matchCupForm.Show();
        }

        private void btnCopaEntera_Click(object sender, EventArgs e)
        {
            try
            {
                //Borrar el archivo donde se guarda la Copa si ya existe.

                if (seleccionarArchivo.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCopaCompleta_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                Thread hilo = new Thread((ThreadStart)(() => {
                    if (seleccionarArchivoCopa.ShowDialog() == DialogResult.OK)
                    {
                        path = seleccionarArchivoCopa.FileName;
                    }

                }));
                hilo.SetApartmentState(ApartmentState.STA);
                hilo.Start();
                hilo.Join();


                List<Equipo> equipos = new List<Equipo>();
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] infoEquipos = line.Split('|');
                        Equipo equipo = new Equipo(infoEquipos[0], Convert.ToByte(infoEquipos[1]), Convert.ToByte(infoEquipos[2]));
                        equipos.Add(equipo);
                    }
                }
                var respuesta = MessageBox.Show($"Se han cargado {equipos.Count} equipos, ¿deseas continuar?",
                    "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (respuesta == DialogResult.Yes)
                {
                    CopaEntera(equipos, 1, "");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMultijornada_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionarArchivo.ShowDialog() == DialogResult.OK)
                {
                    if (seleccionarArchivo.CheckFileExists)
                    {
                        using(var sr= new StreamReader(seleccionarArchivo.FileName))
                        {
                            string mensaje = "";
                            string line;
                            List<Equipo> equipos = new List<Equipo>();

                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.StartsWith("#"))
                                {
                                    mensaje += $"{line.Split("$")[1]} {line.Split("$")[2]}: \n";
                                }
                                else
                                {
                                    if (line.Contains("-"))
                                    {
                                        string[] partido = line.Split('-');
                                        string l = partido[0];
                                        string v = partido[1];
                                        Equipo? local = equipos.Find(e => e.Nombre == l.Split("|")[1] && e.Nivel == Convert.ToByte(l.Split("|")[0]));
                                        Equipo? visitante = equipos.Find(e => e.Nombre == v.Split("|")[1] && e.Nivel == Convert.ToByte(v.Split("|")[0]));
                                        if (local != null && visitante != null)
                                        {
                                            byte gLocal = 0, gVisitante = 0;
                                            string resultado= Liga.Partido(local.Nivel, visitante.Nivel, false);
                                            gLocal = Convert.ToByte(resultado.Split("-")[0]);
                                            gVisitante = Convert.ToByte(resultado.Split("-")[1]);

                                            local.GolesMarcados += gLocal;
                                            visitante.GolesMarcados += gVisitante;
                                            local.GolesRecibidos += gVisitante;
                                            visitante.GolesRecibidos += gLocal;
                                            local.Jugados += 1;
                                            visitante.Jugados += 1;
                                            if (gLocal == gVisitante)
                                            {
                                                local.Puntos += 1;
                                                visitante.Puntos += 1;
                                                local.Empates += 1;
                                                visitante.Empates += 1;
                                            }
                                            else
                                            {
                                                if (gLocal > gVisitante)
                                                {
                                                    local.Puntos += 3;
                                                    local.Victorias += 1;
                                                    visitante.Derrotas += 1;
                                                }
                                                else
                                                {
                                                    visitante.Puntos += 3;
                                                    visitante.Victorias += 1;
                                                    local.Derrotas += 1;
                                                }
                                            }

                                            mensaje += $"\t {local} {resultado} {visitante} \n";
                                        }
                                    }
                                    else
                                    {
                                        Equipo competidor = new Equipo(line.Split("|")[1], nivel: Convert.ToByte(line.Split("|")[0]));
                                        mensaje += $"{competidor}, de nivel ";
                                        switch (competidor.Nivel)
                                        {
                                            case 0:
                                                mensaje += $"alto\n";
                                                break;
                                            case 1:
                                                mensaje += $"medio\n";
                                                break;
                                            case 2:
                                                mensaje += $"bajo\n";
                                                break;
                                        }
                                        equipos.Add(competidor);
                                    }
                                }
                            }

                            var listaOrdenada = (from eq in equipos
                                                 orderby eq.Puntos descending, eq.GolesMarcados - eq.GolesRecibidos descending, eq.GolesMarcados descending
                                                 select eq).ToList();

                            var listaStrings = (from eq in equipos
                                                select eq.Nombre).ToList();

                            var stringLargo = listaStrings.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;


                            mensaje += "==================================================\n";
                            mensaje += "Equipo\t| PJ | PG | PE | PP | GF | GC | DG | Pt\n";

                            for (int i = 0; i < listaOrdenada.Count; i++)
                            {
                                string pos = (i + 1).ToString().PadLeft(2)+".";
                                string jug = listaOrdenada[i].Jugados.ToString().PadLeft(2);
                                string vic = listaOrdenada[i].Victorias.ToString().PadLeft(2);
                                string emp = listaOrdenada[i].Empates.ToString().PadLeft(2);
                                string der = listaOrdenada[i].Derrotas.ToString().PadLeft(2);
                                string gf = listaOrdenada[i].GolesMarcados.ToString().PadLeft(3);
                                string gc = listaOrdenada[i].GolesRecibidos.ToString().PadLeft(3);
                                string pt = listaOrdenada[i].Puntos.ToString().PadLeft(3);
                                int diferencia = listaOrdenada[i].GolesMarcados - listaOrdenada[i].GolesRecibidos;
                                string dg = diferencia.ToString().PadLeft(3);
                                mensaje += $"{pos} {listaOrdenada[i].Nombre.PadRight(stringLargo)}| {jug} | {vic} | {emp} | {der} | {gf} | {gc} | {dg} | {pt}\n";
                            }

                            File.WriteAllText("informe_completo_multi.txt", mensaje);
                            MessageBox.Show("Se ha emitido un informe completo de los partidos ingresados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLiga_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionarArchivo.ShowDialog() == DialogResult.OK)
                {
                    if (seleccionarArchivo.CheckFileExists)
                    {
                        using (var sr = new StreamReader(seleccionarArchivo.FileName))
                        {
                            string mensaje = "";
                            string line;
                            List<Equipo> equipos = new List<Equipo>();
                            List<string> nombres = new List<string>();
                            
                            while ((line = sr.ReadLine()!) != null)
                            {
                                
                                if (line.StartsWith("#"))
                                {
                                    mensaje += $"{line.Split("$")[1]} {line.Split("$")[2]}: \n";
                                    nombres.Add(line.Split("$")[2].Replace("de ", ""));
                                }
                                else
                                {
                                    Equipo competidor = new Equipo(nombre: line.Split("|")[3],  
                                                                   categoria: Convert.ToByte(line.Split("|")[0]), 
                                                                   grupo: Convert.ToByte(line.Split("|")[1]), 
                                                                   nivel: Convert.ToByte(line.Split("|")[2]));
                                    mensaje += $"{competidor}, de nivel ";
                                    switch (competidor.Nivel)
                                    {
                                        case 0:
                                            mensaje += $"alto\n";
                                            break;
                                        case 1:
                                            mensaje += $"medio\n";
                                            break;
                                        case 2:
                                            mensaje += $"bajo\n";
                                            break;
                                    }
                                    equipos.Add(competidor);
                                }
                            }

                            var divisiones = (from eq in equipos
                                              group eq by new { eq.Categoria, eq.Grupo } into gr
                                              select gr.ToList()).ToList();

                            for (int n = 0; n < divisiones.Count; n++)
                            {
                                mensaje += $"{nombres[n]} cargada: \n";
                                var participantes = divisiones[n];
                                participantes.Shuffle();
                                var listaPartidos = ListMatches(participantes).ToList();
                                var jornadas = listaPartidos.Select(p => p.Day).Distinct().OrderBy(d => d);

                                foreach (var jornada in jornadas)
                                {
                                    mensaje += $"Jornada {jornada + 1}\n";
                                    listaPartidos.ForEach(lp =>
                                    {
                                        if (lp.Day == jornada)
                                        {
                                            Equipo? local = participantes.Find(e => e.Nombre == lp.First.Nombre && e.Nivel == lp.First.Nivel);
                                            Equipo? visitante = participantes.Find(e => e.Nombre == lp.Second.Nombre && e.Nivel == lp.Second.Nivel);
                                            if (local != null && visitante != null)
                                            {
                                                byte gLocal = 0, gVisitante = 0;
                                                string resultado = Liga.Partido(local.Nivel, visitante.Nivel, false);
                                                gLocal = Convert.ToByte(resultado.Split("-")[0]);
                                                gVisitante = Convert.ToByte(resultado.Split("-")[1]);

                                                local.GolesMarcados += gLocal;
                                                visitante.GolesMarcados += gVisitante;
                                                local.GolesRecibidos += gVisitante;
                                                visitante.GolesRecibidos += gLocal;
                                                local.Jugados += 1;
                                                visitante.Jugados += 1;
                                                if (gLocal == gVisitante)
                                                {
                                                    local.Puntos += 1;
                                                    visitante.Puntos += 1;
                                                    local.Empates += 1;
                                                    visitante.Empates += 1;
                                                }
                                                else
                                                {
                                                    if (gLocal > gVisitante)
                                                    {
                                                        local.Puntos += 3;
                                                        local.Victorias += 1;
                                                        visitante.Derrotas += 1;
                                                    }
                                                    else
                                                    {
                                                        visitante.Puntos += 3;
                                                        visitante.Victorias += 1;
                                                        local.Derrotas += 1;
                                                    }
                                                }

                                                mensaje += $"\t {local} {resultado} {visitante} \n";
                                            }
                                        }
                                    });

                                    var listaOrdenada = (from eq in participantes
                                                         orderby eq.Puntos descending, eq.GolesMarcados - eq.GolesRecibidos descending, eq.GolesMarcados descending
                                                         select eq).ToList();

                                    var listaStrings = (from eq in participantes
                                                        select eq.Nombre).ToList();

                                    var stringLargo = listaStrings.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;


                                    mensaje += "".PadRight(stringLargo+47, '=')+"\n";
                                    mensaje += "Equipo".PadRight(stringLargo + 4) + "| PJ | PG | PE | PP | GF  | GC  | DG  | Pt\n";

                                    for (int i = 0; i < listaOrdenada.Count; i++)
                                    {
                                        string pos = (i + 1).ToString().PadLeft(2) + ".";
                                        string jug = listaOrdenada[i].Jugados.ToString().PadLeft(2);
                                        string vic = listaOrdenada[i].Victorias.ToString().PadLeft(2);
                                        string emp = listaOrdenada[i].Empates.ToString().PadLeft(2);
                                        string der = listaOrdenada[i].Derrotas.ToString().PadLeft(2);
                                        string gf = listaOrdenada[i].GolesMarcados.ToString().PadLeft(3);
                                        string gc = listaOrdenada[i].GolesRecibidos.ToString().PadLeft(3);
                                        string pt = listaOrdenada[i].Puntos.ToString().PadLeft(3);
                                        int diferencia = listaOrdenada[i].GolesMarcados - listaOrdenada[i].GolesRecibidos;
                                        string dg = diferencia.ToString().PadLeft(3);
                                        mensaje += $"{pos} {listaOrdenada[i].Nombre.PadRight(stringLargo)}| {jug} | {vic} | {emp} | {der} | {gf} | {gc} | {dg} | {pt}\n";
                                    }
                                    mensaje += "\n";
                                }
                            }
                            
                            File.WriteAllText("informe_completo_ligas.txt", mensaje);
                            MessageBox.Show("Se ha emitido un informe completo de los partidos ingresados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReportBug_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si encontraste algún bug, por favor avisa a @Frank9412_co en twitter. Envía pantallazo con lo que pasó y se intentará arreglar lo antes posible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopaEntera(List<Equipo> participantes, int ronda, string resultado)
        {
            List<Equipo> ganadores = new List<Equipo>();
            if (participantes.Count == 1)
            {
                resultado += $"El ganador del torneo es: {participantes[0]}.";
                File.WriteAllText("informe_completo_copa.txt", resultado);
                MessageBox.Show($"El ganador del torneo es {participantes[0]} y se ha realizado un informe recapitulando la copa",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                //Calcula la potencia de 2 menor a la cantidad de participantes
                int potencia = (int)Math.Ceiling(Math.Log2(participantes.Count));
                int exentos = (int)(Math.Pow(2, potencia) - participantes.Count);
                if (exentos >= 0)
                {
                    for (int i = 1; i <= exentos; i++)
                    {
                        participantes.Add(new Equipo("Bye", categoria: 5));
                    }
                }

                short iteraciones = (short)(participantes.Count / 2);
                Random random = new Random();
                Equipo local, visitante;
                short aux;

                resultado += $"Ronda {ronda}: \n";
                for (short i = 0; i < iteraciones; i++)
                {
                    //programa los equipos exentos
                    if (participantes.Find(e => e.Nombre == "Bye") != null)
                    {
                        aux = (short)random.Next(participantes.Count - exentos);
                        int indiceBye = participantes.FindLastIndex(e => e.Nombre == "Bye");
                        if (aux % 2 == 0)
                        {
                            local = participantes[aux];
                            visitante = participantes[indiceBye];
                        }
                        else
                        {
                            visitante = participantes[aux];
                            local = participantes[indiceBye];
                        }
                    }
                    else
                    {
                        //de este bucle no se sale sino hasta que encuentre dos equipos que se llamen distinto
                        do
                        {
                            aux = (short)random.Next(participantes.Count);
                            local = participantes[aux];
                            aux = (short)random.Next(participantes.Count);
                            visitante = participantes[aux];
                        } while (local.Nombre == visitante.Nombre);
                    }
                    participantes.Remove(local);
                    participantes.Remove(visitante);

                    if (local.Nombre == "Bye")
                    {
                        ganadores.Add(visitante);
                        resultado += $"{visitante.Nombre} descansa. \n";
                    }
                    else if (visitante.Nombre == "Bye")
                    {
                        ganadores.Add(local);
                        resultado += $"{local.Nombre} descansa. \n";
                    }

                    else
                    {
                        bool eLocal;
                        string resultadoParcial = Copa.PartidoEquipos(local, visitante, out eLocal);
                        if (eLocal)
                        {
                            ganadores.Add(local);
                        }
                        else
                        {
                            ganadores.Add(visitante);
                        }
                        resultado += resultadoParcial + "\n";
                    }
                }
                resultado += "======================================================\n";

                var respuesta = MessageBox.Show($"Ronda {ronda} terminada. ¿Desea continuar la copa?", $"Ronda {ronda} terminada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (respuesta == DialogResult.Yes)
                {
                    ronda = ronda + 1;
                    CopaEntera(ganadores, ronda, resultado);
                }
                else if (respuesta == DialogResult.No)
                {
                    File.WriteAllText("informe_parcial_copa.txt", resultado);
                    MessageBox.Show("Se emitió un informe parcial de la copa al haberse detenido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static IEnumerable<(int Day, T First, T Second)> ListMatches<T>(IList<T> teams)
        {
            var matches = new List<(int, T, T)>();
            if (teams == null || teams.Count < 2)
            {
                return matches;
            }

            var restTeams = new List<T>(teams.Skip(1));
            var teamsCount = teams.Count;
            if (teams.Count % 2 != 0)
            {
                restTeams.Add(default);
                teamsCount++;
            }

            for (var day = 0; day < teamsCount - 1; day++)
            {
                if (restTeams[day % restTeams.Count]?.Equals(default) == false)
                {
                    matches.Add((day, teams[0], restTeams[day % restTeams.Count]));
                }

                for (var index = 1; index < teamsCount / 2; index++)
                {
                    var firstTeam = restTeams[(day + index) % restTeams.Count];
                    var secondTeam = restTeams[(day + restTeams.Count - index) % restTeams.Count];
                    if (firstTeam?.Equals(default) == false && secondTeam?.Equals(default) == false)
                    {
                        matches.Add((day, firstTeam, secondTeam));
                    }
                }
            }


            for (int i = 0; i < teamsCount - 1; i++)
            {
                var partidosJornada = matches.FindAll(m => m.Item1 == i);
                for (int j = 0; j < partidosJornada.Count(); j++)
                {
                    var partido = partidosJornada[j];

                    int jornada = partido.Item1 + (teamsCount - 1);
                    T firstTeam = partido.Item3;
                    T secondTeam = partido.Item2;

                    matches.Add((jornada, firstTeam, secondTeam));
                }
            }

            return matches;
        }
    }
}