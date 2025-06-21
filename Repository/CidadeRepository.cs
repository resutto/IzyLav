using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Primitives;

namespace EgourmetAPI.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }
        public CidadeRepository(IConfiguration configuracao) {
            _configuracoes = configuracao;
        }
        public void Add(Cidade obj)
        {
            string query = $@"insert into cidade(Uf,Municipio,Municipio_Nome) values(@uf,@municipio,@nome)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    uf = obj.Uf,
                    municipio = obj.Municipio,
                    nome = obj.Municipio_Nome
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public IEnumerable<Cidade> GetAll()
        {
            string query = $@"select Uf,Municipio,Municipio_Nome from cidade";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cidade>(query).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public Cidade GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cidade GetByUfMunicipio(StringTokenizer ufid, string municipioid)
        {
            string query = $@"select Uf,Municipio,Municipio_Nome from cidade where Uf=@uf and Municipio=@municipio";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cidade>(query, new
                {
                    uf = ufid,
                    municipio = municipioid
                }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public void RemoveCidade(string ufid, string municipioid)
        {
            string query = $@"delete from cidade where Uf=@uf and Municipio=@municipio";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    uf = ufid,
                    municipio = municipioid
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }


        public void Update(Cidade obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
