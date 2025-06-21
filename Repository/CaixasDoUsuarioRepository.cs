using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class CaixasDoUsuarioRepository : ICaixasDoUsuarioRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public CaixasDoUsuarioRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(CaixasDoUsuario obj)
        {
            string query = $@"insert into caixasdousuario(
                                          Emp_Codigo,
                                          Seq,
                                          Caixacodigo,
                                          Liberado,
                                          Usuario) values(@empresa,@id,@caixacodigo,@liberado,@usuario)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa=obj.Emp_Codigo,
                    id=obj.Seq,
                    caixacodigo=obj.Caixacodigo,
                    liberado=obj.Liberado,
                    usuario=obj.Usuario
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

        public IEnumerable<CaixasDoUsuario> GetAll(int empresa, string usuario)
        {
            string query = $@"select      Emp_Codigo,
                                          Seq,
                                          Caixacodigo,
                                          Liberado,
                                          Usuario 
                              from caixasdousuario
                              where Emp_Codigo=@empresa and usuario=@usuario";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<CaixasDoUsuario>(query, new
                {
                    empresa = empresa,
                    usuario = usuario
                }).ToList();
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

        public CaixasDoUsuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(int empresa, string usuario)
        {
            string query = $@"delete from caixasdousuario where
                                          Emp_Codigo=@empresa and
                                          Usuario=@usuario ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = empresa,
                    usuario = usuario
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

        public void Update(CaixasDoUsuario obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CaixasDoUsuario> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
