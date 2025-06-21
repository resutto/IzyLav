using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;
using Microsoft.Extensions.Primitives;

namespace EgourmetAPI.Repository.Interface
{
    public interface ICidadeRepository : IRepositoryBase<Cidade>
    {
        public void RemoveCidade(string ufid, string municipioid);
        public Cidade GetByUfMunicipio(StringTokenizer ufid, string municipioid);


    }
}
