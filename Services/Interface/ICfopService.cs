using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface ICfopService:IServiceBase<Cfop>
    {
        public Cfop GetById(string id);
        public void Remove(string id);
    }
}
