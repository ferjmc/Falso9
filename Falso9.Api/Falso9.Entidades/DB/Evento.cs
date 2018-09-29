using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Evento
    {
        public long EventoId { get; set; }
        public int PartidoId { get; set; }
        public int EventoTipoId { get; set; }
        public int? JugadorId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public EventoTipo EventoTipo { get; set; }
        public Jugador Jugador { get; set; }
        public Partido Partido { get; set; }
    }
}
