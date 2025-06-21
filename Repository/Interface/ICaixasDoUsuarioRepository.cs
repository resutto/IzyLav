using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface ICaixasDoUsuarioRepository:IRepositoryBase<CaixasDoUsuario>
    {
        public void Remove(int empresa, string usuario);
    }
}
