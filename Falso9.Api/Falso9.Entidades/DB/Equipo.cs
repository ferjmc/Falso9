using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Equipo
    {
        public Equipo()
        {
            Jugador = new HashSet<Jugador>();
            PartidoEquipoIdLocalNavigation = new HashSet<Partido>();
            PartidoEquipoIdVisitanteNavigation = new HashSet<Partido>();
        }

        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string IdApi { get; set; }

        public EquipoInfo EquipoInfo { get; set; }
        public ICollection<Jugador> Jugador { get; set; }
        public ICollection<Partido> PartidoEquipoIdLocalNavigation { get; set; }
        public ICollection<Partido> PartidoEquipoIdVisitanteNavigation { get; set; }
    }
}
