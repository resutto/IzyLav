using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        public IEnumerable<Usuario> GetAllAsync(int emp_Codigo);
        public Usuario GetById(string userId, int emp_Codigo);
        public void Remove(string userId, int emp_Codigo);
    }
}
