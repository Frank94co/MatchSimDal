using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchSimDalLibrary.Competencia
{
    public class Competencia
    {
        public short Participantes { get; set; }
        public List<Equipo> Equipos { get; set; }

        public Competencia(short participantes, List<Equipo> equipos)
        {
            Participantes = participantes;
            Equipos = equipos;
        }

        public void Eliminar(Equipo eliminado)
        {
            this.Equipos.Remove(eliminado);
        }
    }
}
