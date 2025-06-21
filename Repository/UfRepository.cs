using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class UfRepository : IUfRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public UfRepository( IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(Uf obj)
        {
            string query = $@"insert into uf(COD_UF,UF_SIGLA) values(@codigo,@descricao)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.COD_UF,
                    descricao = obj.UF_SIGLA
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

        public IEnumerable<Uf> GetAll()
        {
            string query = $@"select COD_UF,UF_SIGLA from uf";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Uf>(query).ToList();
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

        public Uf GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Uf GetByUf(string id)
        {
            string query = $@"select COD_UF,UF_SIGLA from uf where cod_uf=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Uf>(query, new { codigo = id }).FirstOrDefault();
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


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUf(string codigoid)
        {
            string query = $@"delete from uf set where cod_uf=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = codigoid
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

        public void Update(Uf obj)
        {
            string query = $@"update uf set uf_sigla=@descricao where cod_uf=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.COD_UF,
                    descricao = obj.UF_SIGLA
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
    }
}
