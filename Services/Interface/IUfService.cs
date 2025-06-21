using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IUfService:IServiceBase<Uf>
    {
        public Uf GetById(string id);
        public void Remove(string id);
    }
}
