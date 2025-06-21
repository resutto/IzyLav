using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IFormaQdeDiasRepository: IRepositoryBase<FormaQdeDias>
    {
        public IEnumerable<FormaQdeDias> GetAll(int forma);
        public void Remove(int id, int forma);

    }
}
