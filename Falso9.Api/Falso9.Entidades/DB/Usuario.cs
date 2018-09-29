using System;
using System.Collections.Generic;

namespace Falso9.Entidades.DB
{
    public partial class Usuario
    {
        public Usuario()
        {
            Apuesta = new HashSet<Apuesta>();
            Mensaje = new HashSet<Mensaje>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Apuesta> Apuesta { get; set; }
        public ICollection<Mensaje> Mensaje { get; set; }
    }
}
