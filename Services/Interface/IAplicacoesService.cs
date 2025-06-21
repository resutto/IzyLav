using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IAplicacoesService:IServiceBase<Aplicacoes>
    {
        public Aplicacoes GetById(string id);
        public void Remove(string id);
    }
}
