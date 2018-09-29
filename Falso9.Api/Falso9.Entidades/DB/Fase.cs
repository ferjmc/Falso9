using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Fase
    {
        public Fase()
        {
            Partido = new HashSet<Partido>();
        }

        public int FaseId { get; set; }
        public int TorneoId { get; set; }
        public string Nombre { get; set; }
        public string IdApi { get; set; }

        public Torneo Torneo { get; set; }
        public ICollection<Partido> Partido { get; set; }
    }
}
