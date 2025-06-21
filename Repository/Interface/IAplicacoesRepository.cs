using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IAplicacoesRepository:IRepositoryBase<Aplicacoes>
    {
        public void Remove(string codigo);
        public Aplicacoes GetById(string id);
    }
}
