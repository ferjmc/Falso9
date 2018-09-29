using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Jugador
    {
        public Jugador()
        {
            Evento = new HashSet<Evento>();
        }

        public int JugadorId { get; set; }
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public DateTime? Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Posicion { get; set; }
        public string IdApi { get; set; }

        public Equipo Equipo { get; set; }
        public ICollection<Evento> Evento { get; set; }
    }
}
