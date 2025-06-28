using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IDepositoService:IServiceBase<Deposito>
    {
        public IEnumerable<Deposito> GetAllAsync(int empresa);
        public Deposito GetById(int id, int empresa);
        public void Remove(int id, int empresa);
    }
}
