using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Temporada
    {
        public Temporada()
        {
            Torneo = new HashSet<Torneo>();
        }

        public int TemporadaId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string IdApi { get; set; }

        public ICollection<Torneo> Torneo { get; set; }
    }
}
