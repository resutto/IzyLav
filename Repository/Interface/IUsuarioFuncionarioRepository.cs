using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IUsuarioFuncionarioRepository:IRepositoryBase<UsuarioFuncionario>
    {
        public void Remove(int empresa, int id);
    }
}
