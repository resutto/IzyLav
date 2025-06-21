using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using Model;

namespace EgourmetAPI.Repository
{
    public class UsuarioFuncionarioRepository : IUsuarioFuncionarioRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public UsuarioFuncionarioRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(UsuarioFuncionario obj)
        {
            string query = $@"insert into usuario_funcionario(
                                        Id,
                                        Fun_Codigo,
                                        Usuario,
                                        Emp_Codigo)
                                        values(@id,@funcionario,@usuario,@empresa)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    id=obj.Id,
                    funcionario=obj.Fun_Codigo,
                    usuario=obj.Usuario,
                    empresa=obj.Emp_Codigo
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

        public IEnumerable<UsuarioFuncionario> GetAll(int empresa,string usuario)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    string query = $@"select Id,Fun_Codigo, usuario,emp_codigo from usuario_funcionario where Usuario=@usuario and Emp_Codigo=@empresa";
                    connection.Open();
                    return connection.Query<UsuarioFuncionario>(query, new { usuario = usuario, empresa = empresa }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public UsuarioFuncionario GetById(int empresa, string usuario, int id)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    string query = $@"select Id,Fun_Codigo, usuario,emp_codigo from usuario_funcionario where Usuario=@usuario and Emp_Codigo=@empresa and Id=@id";
                    connection.Open();
                    return connection.Query<UsuarioFuncionario>(query, new { usuario = usuario, empresa = empresa, id=id }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Remove(int empresa, string usuario, int id)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    string query = $@"delete from usuario_funcionario where Usuario=@usuario and Emp_Codigo=@empresa and Id=@id";
                    connection.Open();
                    connection.Execute(query, new { usuario = usuario, empresa = empresa, id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(UsuarioFuncionario obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioFuncionario> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioFuncionario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
