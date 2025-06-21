using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

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

        public void Remove(int empresa, int id)
        {
            string query = $@"delete from usuario_funcionario where
                                        Id=@id and 
                                        Emp_Codigo=@empresa";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    id = id,
                    empresa = empresa
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

        public void Update(UsuarioFuncionario obj)
        {
            throw new NotImplementedException();
        }
    }
}
