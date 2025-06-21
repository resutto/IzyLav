using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Repository.Interface
{
    public interface IUsuarioRepository:IRepositoryBase<Usuario>
    {
        public IEnumerable<Usuario> GetAll(int emp_Codigo);
        public Usuario GetById(string id, int emp_Codigo);
        public void Remove(string usuario, int emp_Codigo);


    }
}
