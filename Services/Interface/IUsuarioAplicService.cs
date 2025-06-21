using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IUsuarioAplicService: IServiceBase<Usuaplic>
    {
        public IEnumerable<Usuaplic> GetAllAsync(int Grupo);
        public Usuaplic GetById(int Grupo, string Aplicacao);
        public void Remove(int Grupo, string Aplicacao);
    }
}
