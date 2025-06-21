using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IUsuarioFuncionarioRepository:IRepositoryBase<UsuarioFuncionario>
    {
        public void Remove(int empresa, string usuario, int id);
        public IEnumerable<UsuarioFuncionario> GetAll(int empresa, string usuario);
        public UsuarioFuncionario GetById(int empresa, string usuario, int id);
    }
}
