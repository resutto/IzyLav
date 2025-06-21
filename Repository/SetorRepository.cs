using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class SetorRepository : ISetorRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }
        
        public SetorRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public IEnumerable<Setor> GetAll()
        {
            string query = $@"select Set_Codigo,Set_Descricao from setor";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Setor>(query).ToList();
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

        public Setor GetById(int id)
        {
            string query = $@"select Set_Codigo,Set_Descricao from setor where set_codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Setor>(query, new
                {
                    codigo = id
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

        public void Add(Setor obj)
        {
            string query = $@"insert into setor(Set_Codigo,Set_Descricao) values(@codigo,@descricao)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Set_Codigo,
                    descricao = obj.Set_Descricao
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

        public void Update(Setor obj)
        {
            string query = $@"update setor set Set_Descricao = @descricao where Set_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Set_Codigo,
                    descricao = obj.Set_Descricao
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

        public void Remove(int id)
        {
            string query = $@"delete from setor where Set_Codigo=@codigo";

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
    }
}
