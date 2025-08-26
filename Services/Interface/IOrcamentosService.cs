using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IOrcamentosService:IServiceBase<Orcamentos>
    {
        public IEnumerable<Orcamentos> GetAllAsync(int empresa);
        public Orcamentos GetById(int empresa, int orcamentoid, string ano);
        public void Remove(int emp_Codigo, int orc_Codigo, string ano);
        public String Add(Orcamentos obj);

    }
}
