using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}
