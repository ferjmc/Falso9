using Falso9.Datos.Base.Interface;
using Falso9.Entidades.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Falso9.Datos.Interface
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetById(int usuarioId);
    }
}
