using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class TipoCobrancaRepository : ITipoCobrancaRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }
        public TipoCobrancaRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(TipoCobranca obj)
        {
            string query = $@"insert tipo_cobranca(Tpcob_Codigo,Tpcob_Descricao,Tpcob_Padrao)
                                            values(@codigo,@descricao,@padrao)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Tpcob_Codigo,
                    descricao = obj.Tpcob_Descricao,
                    padrao=obj.Tpcob_Padrao
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

        public IEnumerable<TipoCobranca> GetAll()
        {
            string query = $@"select  Tpcob_Codigo,Tpcob_Descricao,Tpcob_Padrao from tipo_cobranca";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<TipoCobranca>(query).ToList();
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

        public TipoCobranca GetById(int id)
        {
            string query = $@"select  Tpcob_Codigo,Tpcob_Descricao,Tpcob_Padrao from tipo_cobranca where Tpcob_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<TipoCobranca>(query, new { codigo = id }).FirstOrDefault();
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
            string query = $@"delete from tipo_cobranca
                               where Tpcob_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = id
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

        public void Update(TipoCobranca obj)
        {
            string query = $@"update tipo_cobranca set Tpcob_Descricao=@descricao,Tpcob_Padrao=@padrao
                               where Tpcob_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    descricao = obj.Tpcob_Descricao,
                    padrao = obj.Tpcob_Padrao,
                    codigo = obj.Tpcob_Codigo
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
