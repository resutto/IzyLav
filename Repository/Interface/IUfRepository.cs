using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IUfRepository:IRepositoryBase<Uf>
    {
        public void RemoveUf(string codigoid);
        public Uf GetByUf(string id);


    }
}
