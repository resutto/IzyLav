using Dapper;
using EgourmetAPI.Model;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.Data;
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

        public IEnumerable<UsuarioAplicacoesDTO> Aplicacoes(string usuario)
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = $@"select c.grupo_descricao,a.apli_codigo,b.apli_descricao,b.apli_tipo,b.apli_desc_curta AS apli_descricao_curta,d.usuario
                                from usuaplic a, aplicacoes b, seg_grupo c, usuario d
                                where a.apli_codigo=b.apli_codigo and
                                c.grup_codigo=a.grup_codigo and
                                d.grup_codigo=a.grup_codigo and
                                d.usuario=@user";
                try
                {
                    return connection.Query<UsuarioAplicacoesDTO>(query, new { user = usuario.Substring(0,10).ToUpper() }).ToList();
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

    }
}
