using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;

namespace EgourmetAPI.Repository
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public UnidadeRepository(IConfiguration configuration)
        {
            _configuracoes = configuration;
        }

        public void Add(Unidade obj)
        {
            string query = $@"insert into unidade(unid_codigo,unid_descricao,unid_Conver_Pc,Unid_Mask) values(@codigo,@descricao,@pecas,@mask)";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = obj.Unid_Codigo, descricao = obj.Unid_Descricao, pecas = obj.Unid_Conver_Pc, mask = obj.Unid_Mask });

            }
            catch (Exception ex)
            {
                throw ex;

            } finally { connection.Close(); }
        }

        public IEnumerable<Unidade> GetAll()
        {
            string query = $@"select  unid_codigo,unid_descricao,unid_Conver_Pc,Unid_Mask from unidade";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Unidade>(query).ToList();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { connection.Close(); }
        }

        public Unidade GetById(int id)
        {
            string query = $@"select  unid_codigo,unid_descricao,unid_Conver_Pc,Unid_Mask from unidade where unid_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Unidade>(query, new { codigo = id }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { connection.Close(); }
        }

        public void Remove(int id)
        {
            string query = $@"delete from unidade where unid_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = id});

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { connection.Close(); }
        }

        public void Update(Unidade obj)
        {
            string query = $@"update unidade set unid_descricao=@descricao , unid_Conver_Pc=@pecas,Unid_Mask=@mask where unid_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = obj.Unid_Codigo, descricao = obj.Unid_Descricao, pecas = obj.Unid_Conver_Pc, mask = obj.Unid_Mask });

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { connection.Close(); }
        }
    }
}
