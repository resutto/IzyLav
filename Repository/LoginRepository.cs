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

        string query = $@"select a.Emp_Codigo,a.usuario,a.Cli_Codigo,a.Grup_Codigo,b.grupo_descricao as Grupo 
                          from usuario a, seg_grupo b 
                          where a.ususenhaweb=@senha and a.usuario=@user and a.grup_codigo=b.grup_codigo ";
                try
                {
                    return connection.Query<Usuario>(query, new { user = usuario.Substring(0,10).ToUpper(), senha = senha }).FirstOrDefault();
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

        public IEnumerable<UsuarioAplicacoesDTO> Aplicacoes(string usuario, int empresa)
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = $@"select c.grupo_descricao,a.apli_codigo,b.apli_descricao,b.apli_tipo,b.apli_desc_curta AS apli_descricao_curta,
                                  d.usuario,f.fun_nome as nome,f.fun_codigo as funcionario
                                from usuaplic a, aplicacoes b, seg_grupo c, usuario d, usuario_funcionario e, funcionario f
                                where a.apli_codigo=b.apli_codigo and
                                      c.grup_codigo=a.grup_codigo and
                                      d.grup_codigo=a.grup_codigo and
                                      d.usuario=@user and 
                                      e.fun_codigo=f.fun_codigo and
                                      e.emp_codigo=@emp";
                try
                {
                    return connection.Query<UsuarioAplicacoesDTO>(query, new { user = usuario.Substring(0,10).ToUpper(), emp=empresa }).ToList();
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
