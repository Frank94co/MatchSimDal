namespace MatchSimDalLibrary.Competencia
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public short Nivel { get; set; }
        public byte Categoria { get; set; }
        public byte GolesMarcados { get; set; }
        public byte GolesRecibidos { get; set; }
        public int Puntos { get; set; }
        public int Victorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int Jugados { get; set; }

        public Equipo(string nombre, short nivel, byte categoria, byte golesMarcados, byte golesRecibidos)
        {
            Nombre = nombre;
            Nivel = nivel;
            Categoria = categoria;
            GolesMarcados = golesMarcados;
            GolesRecibidos = golesRecibidos;
        }

        public Equipo(string nombre, short nivel)
        {
            Nombre = nombre;
            Nivel = nivel;
        }

        public Equipo(string nombre, byte categoria)
        {
            Nombre = nombre;
            Categoria = categoria;
        }

        public Equipo(string nombre, byte categoria, short nivel)
        {
            Nombre = nombre;
            Categoria = categoria;
            Nivel = nivel;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}