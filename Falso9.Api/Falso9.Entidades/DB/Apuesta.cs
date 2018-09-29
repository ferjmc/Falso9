using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Apuesta
    {
        public int ApuestaId { get; set; }
        public int PartidoId { get; set; }
        public int GolesEquipoLocal { get; set; }
        public int GolesEquipoVisitante { get; set; }
        public int UsuarioId { get; set; }

        public Partido Partido { get; set; }
        public Usuario Usuario { get; set; }
    }
}
