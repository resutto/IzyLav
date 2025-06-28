using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface ICfopRepository:IRepositoryBase<Cfop>
    {
        public void Remove(string id);
        public Cfop GetById(string id);
    }
}
