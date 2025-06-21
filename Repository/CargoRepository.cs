using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class CargoRepository : ICargoRepository
    {

        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public CargoRepository(IConfiguration configuracao) {
            _configuracoes = configuracao;
        }
        public void Add(Cargo obj)
        {
            string query = $@"insert into cargo(Cargo_Codigo,Cargo_Descricao,Eh_Vendedor) values(@Codigo,@Descricao,@EhVendedor)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                { Codigo=obj.Cargo_Codigo, Descricao=obj.Cargo_Descricao, EhVendedor = obj.Eh_Vendedor
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

        public IEnumerable<Cargo> GetAll()
        {
            string query = $@"select Cargo_Codigo,Cargo_Descricao,Eh_Vendedor from cargo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cargo>(query).ToList();
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

        public Cargo GetById(int id)
        {
            string query = $@"select Cargo_Codigo,Cargo_Descricao,Eh_Vendedor from cargo where cargo_codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cargo>(query, new { codigo = id }).FirstOrDefault();

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
            string query = $@"delete from cargo where Cargo_Codigo=@Codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    Codigo = id
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

        public void Update(Cargo obj)
        {
            string query = $@"update cargo set Cargo_Descricao=@Descricao, Eh_Vendedor=@EhVendedor where Cargo_Codigo=@Codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    Descricao = obj.Cargo_Descricao,
                    EhVendedor = obj.Eh_Vendedor,
                    Codigo = obj.Cargo_Codigo
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
