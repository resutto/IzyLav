using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EgourmetAPI.Repository.Interface
{
    public interface IOrcamentosRepository : IRepositoryBase<Orcamentos>
    {
        public IEnumerable<Orcamentos> GetAll(int empresa);
        public Orcamentos GetById(int empresa, int orcamentoid, string ano);
        public void Remove(int empresa, int orcamentoid, string ano);
        public String Add(Orcamentos obj);
        public IEnumerable<Orcamentos> GetAllFromClient(int empresa, int clienteCodigo);
    }
}
