using Falso9.Entidades.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Falso9.Negocio.Interface
{
    public interface IUsuarioNegocio
    {
        Task<Usuario> Autenticar(string login, string password);
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario user, string password);
        void Update(Usuario user, string password = null);
        void Delete(int id);
    }
}
