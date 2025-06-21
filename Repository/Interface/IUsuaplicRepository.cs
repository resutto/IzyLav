using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IUsuaplicRepository:IRepositoryBase<Usuaplic>
    {
        public void Remove(int empresa, string aplicacao);

    }
}
