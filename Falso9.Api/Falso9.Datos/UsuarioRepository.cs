using Falso9.Datos.Base;
using Falso9.Datos.Interface;
using Falso9.Entidades.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Falso9.Datos
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ProDeExtContext dbContext) : base(dbContext)
        {

        }
        
        public async Task<Usuario> GetById(int usuarioId)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(e => e.UsuarioId == usuarioId);
        }

    }
}
