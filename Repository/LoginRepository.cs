using Dapper;
using EgourmetAPI.Model;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.Repository.Interface;

namespace IzyLav.Repository
{
    public class LoginRepository:ILoginRepository
    {

        private readonly IConfiguration _configuration;
        public LoginRepository(IConfiguration config)
        {
            _configuration = config;
        }
        string conexao { get { return _configuration.GetConnectionString("firedb"); } }
        public void EsqueceuSenha()
        {
            Console.WriteLine("Solicitar Troca de Senha");
        }

        public Usuario Login(string usuario, string senha)
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = $@"select * from usuario where ususenhaweb=@senha and usuario=@user ";
                try
                {
                    return connection.Query<Usuario>(query, new { user = usuario, senha = senha }).FirstOrDefault();
                }
                catch (Exception ex) {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
