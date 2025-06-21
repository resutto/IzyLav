using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public GrupoRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;

        }
        public void Add(Grupo obj)
        {
            string query = $@"insert into grupo(grup_codigo,grup_descricao,estoque) values(@codigo,@descricao,@estoque)";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new {codigo = obj.Grup_Codigo, descricao=obj.Grup_Descricao, estoque=obj.Estoque });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
            
        }

        public IEnumerable<Grupo> GetAll()
        {
            string query = $@"select grup_codigo,grup_descricao,estoque from grupo";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Grupo>(query).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }

        public Grupo GetById(int id)
        {
            string query = $@"select grup_codigo,grup_descricao,estoque from grupo where grup_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Grupo>(query, new {codigo=id}).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }

        public void Remove(int id)
        {
            string query = $@"delete from grupo where grup_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }

        public void Update(Grupo obj)
        {
            string query = $@" update grupo set grup_descricao=@descricao, estoque=@estoque where grup_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = obj.Grup_Codigo, descricao = obj.Grup_Descricao, estoque = obj.Estoque });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }
    }
}
