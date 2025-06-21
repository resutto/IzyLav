using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IUsuarioFuncionarioService: IServiceBase<UsuarioFuncionario>
    {
        public IEnumerable<UsuarioFuncionario> GetAll(int empresa, string usuario);
    }
}
