using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Mensaje
    {
        public int MensajeId { get; set; }
        public int UsuarioId { get; set; }
        public int TorneoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje1 { get; set; }

        public Torneo Torneo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
