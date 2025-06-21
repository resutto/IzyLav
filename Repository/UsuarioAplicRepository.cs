using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class UsuarioAplicRepository : IUsuarioAplicRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public UsuarioAplicRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public void Add(Usuaplic obj)
        {
            string query = $@"insert into USUAPLIC(Grup_Codigo,Apli_Codigo) values(@grupocodigo,@aplicodigo)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                   grupocodigo=obj.Grup_Codigo,
                   aplicodigo=obj.Apli_Codigo
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

        public IEnumerable<Usuaplic> GetAll(int Grupo)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    connection.Open();
                    string query = $@"select Grup_Codigo,Apli_Codigo from USUAPLIC where Grup_Codigo=@grupocodigo";
                    return connection.Query<Usuaplic>(query, new { grupocodigo = Grupo}).ToList();
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

        public Usuaplic GetById(int Grupo, string Aplicacao) {
            using (var connection = new FbConnection(conexao) ) {
                try {
                    connection.Open();
                    string query = $@"select Grup_Codigo,Apli_Codigo from USUAPLIC
                                        where Grup_Codigo=@grupocodigo and Apli_Codigo=@aplicodigo";
                    return connection.Query<Usuaplic>(query, new { grupocodigo = Grupo, aplicodigo = Aplicacao }).FirstOrDefault();
                }catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public Usuaplic GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int Grupo, string Aplicacao)
        {
            string query = $@"delete from USUAPLIC where Grup_Codigo=@grupo and Apli_Codigo=@aplicodigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    grupo = Grupo,
                    aplicodigo = Aplicacao
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

        public void Update(Usuaplic obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuaplic> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
