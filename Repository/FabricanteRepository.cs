using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class FabricanteRepository : IFabricanteRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public FabricanteRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(Fabricante obj)
        {
            string query = $@"insert into fabricante(FAB_CODIGO,
                              FAB_DESCRICAO,
                              FAB_OBS) values(@codigo,@descricao,@obs)";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo=obj.Fab_Codigo, descricao=obj.Fab_Descricao, obs=obj.Fab_Obs});
            }
            catch (Exception e)
            {
                throw e;
            } finally { connection.Close(); }
            
        }

        public IEnumerable<Fabricante> GetAll()
        {
            string query = "select FAB_CODIGO,FAB_DESCRICAO,FAB_OBS from fabricante";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Fabricante>(query).ToList();
            }
            catch (Exception e)
            {
                throw e;
            } finally
            {
                connection.Close();
            }
        }

        public Fabricante GetById(int id)
        {
            string query = "select FAB_CODIGO,FAB_DESCRICAO,FAB_OBS from fabricante where fab_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Fabricante>(query, new {codigo=id}).FirstOrDefault();
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
            string query = $@"delete from fabricante where FAB_CODIGO=@codigo ";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = id });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { connection.Close(); }

        }

        public void Update(Fabricante obj)
        {
            string query = $@"update fabricante set FAB_DESCRICAO=@descricao, FAB_OBS=@obs where FAB_CODIGO=@codigo ";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = obj.Fab_Codigo, descricao = obj.Fab_Descricao, obs = obj.Fab_Obs });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { connection.Close(); }

        }
    }
}
