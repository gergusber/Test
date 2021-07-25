using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelPort.Domain.Service
{
    public interface IService<TEntity>
    {
        Task<TEntity> Add(TEntity obj);

        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Update(TEntity obj);

        Task Remove(int id);
    }
}