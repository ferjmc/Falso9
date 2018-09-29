using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Torneo
    {
        public Torneo()
        {
            Fase = new HashSet<Fase>();
            Mensaje = new HashSet<Mensaje>();
        }

        public int TorneoId { get; set; }
        public int TemporadaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string IdApi { get; set; }

        public Temporada Temporada { get; set; }
        public ICollection<Fase> Fase { get; set; }
        public ICollection<Mensaje> Mensaje { get; set; }
    }
}
