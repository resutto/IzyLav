using System.Collections.Generic;

namespace egourmetAPI.Repository.Interface
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(int id);
    }
}
