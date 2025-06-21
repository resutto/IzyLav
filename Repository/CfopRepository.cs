using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class CfopRepository : ICfopRepository
    {

        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public CfopRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public void Add(Cfop obj)
        {
            string query = $@"insert into cfop(Cfop_Codigo,Cfop_Descricao,Cfop_Obs) values(@codigo,@descricao,@obs)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Cfop_Codigo,
                    descricao = obj.Cfop_Descricao,
                    obs = obj.Cfop_Obs
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

        public IEnumerable<Cfop> GetAll()
        {
            string query = $@"select Cfop_Codigo,Cfop_Descricao,Cfop_Obs from cfop";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cfop>(query).ToList();
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

        public Cfop GetById(int id)
        {
            string query = $@"select Cfop_Codigo,Cfop_Descricao,Cfop_Obs from cfop where cfop_codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cfop>(query, new {codigo=id}).FirstOrDefault();
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
            string query = $@"delete from cfop where Cfop_Codigo=@codigo";

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

        public void Update(Cfop obj)
        {
            string query = $@"update cfop set Cfop_Descricao=@descricao ,Cfop_Obs=@obs where Cfop_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Cfop_Codigo,
                    descricao = obj.Cfop_Descricao,
                    obs = obj.Cfop_Obs
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
