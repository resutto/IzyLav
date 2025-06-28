using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IFormaQdeDiasService:IServiceBase<FormaQdeDias>
    {
        public IEnumerable<FormaQdeDias> GetAllAsync(int forma);
        public FormaQdeDias GetById(int id, int forma);
        public void Remove(int id, int forma);
    }
}
