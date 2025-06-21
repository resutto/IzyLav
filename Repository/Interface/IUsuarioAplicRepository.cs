using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IUsuarioAplicRepository : IRepositoryBase<Usuaplic>
    {
        public void Remove(int Grupo, string Aplicacao);
        public Usuaplic GetById(int Grupo, string Aplicacao);
        public IEnumerable<Usuaplic> GetAll(int Grupo);

    }
}
