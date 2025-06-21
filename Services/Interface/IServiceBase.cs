using System.Collections.Generic;

namespace egourmetAPI.Service.Interface
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllAsync();

        TEntity GetById(int id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(int id);
    }
}
