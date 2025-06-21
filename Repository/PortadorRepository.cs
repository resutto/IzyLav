using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class PortadorRepository : IPortadorRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public PortadorRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(Portador obj)
        {
            string query = $@"insert into portador(Port_Codigo,Port_Descricao,Port_Cnpjcpf) values(@codigo,@descricao,@cpf)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Cart_Codigo,
                    descricao = obj.Port_Descricao,
                    cpf = obj.Port_Cnpjcpf
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

        public IEnumerable<Portador> GetAll()
        {
            string query = $@" select Port_Codigo,Port_Descricao,Port_Cnpjcpf from  portador";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Portador>(query).ToList();
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

        public Portador GetById(int id)
        {
            string query = $@" select Port_Codigo,Port_Descricao,Port_Cnpjcpf from  portador where port_codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Portador>(query, new {codigo=id}).FirstOrDefault();
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
            string query = $@"delete from portador
                               where port_Codigo=@codigo";

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

        public void Update(Portador obj)
        {
            string query = $@"update portador Port_Descricao=@descricao ,Port_Cnpjcpf=@cpf where Port_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    descricao = obj.Port_Descricao,
                    cpf = obj.Port_Cnpjcpf,
                    codigo = obj.Cart_Codigo

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
