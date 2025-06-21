using egourmetAPI.Model;
using egourmetAPI.Service.Interface;

namespace IzyLav.Services.Interface
{
    public interface IMaquinasService:IServiceBase<Maquinas>
    {
        public IEnumerable<Maquinas> GetAll(int empCodigo);
        public Maquinas GetById(string id, int empCodigo);
        public void Remove(string id, int empCodigo);
    }
}
