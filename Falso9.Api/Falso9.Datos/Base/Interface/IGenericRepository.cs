using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Falso9.Datos.Base.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class//, <span class="pl-en">IEntity</span>
    {
        Task<List<TEntity>> GetAllAsync();

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}
