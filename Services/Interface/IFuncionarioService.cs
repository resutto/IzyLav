using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IFuncionarioService:IServiceBase<Funcionario>
    {
        public Funcionario GetById(int funCodigo, int empresa);
        public IEnumerable<Funcionario> GetAllAsync(int empresa);
        public void Remove(int id, int empresa);
    }
}
