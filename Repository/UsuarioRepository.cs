using Dapper;
using EgourmetAPI.Model;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.Repository.Interface;

namespace IzyLav.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;
        string conexao { get { return _configuration.GetConnectionString("firedb"); } }

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Add(Usuario objUsuario)
        {
                using (var connection = new FbConnection(conexao)){
                try
                {
                    string query = $@"insert into USUARIO(USUARIO,GRUP_CODIGO,USUSENHA,EMP_CODIGO,USULOGON,
                                                  USUSENHAWEB,USUARIOWEB,CLI_CODIGO,USUSENHARAPIDA,fun_codigo)
                              values(@usuario,@grup_codigo,@ususenha,@emp_codigo,@usulogon,
                                     @ususenhaweb,@usuarioweb,@cli_codigo,@ususenharapida,0)";
                    connection.Open();
                    connection.Execute(query, new {
                        usuario= objUsuario.usuario,
                        grup_codigo = objUsuario.Grup_Codigo,
                        ususenha = objUsuario.Ususenha,
                        emp_codigo = objUsuario.Emp_Codigo,
                        usulogon = objUsuario.Usulogon,
                        ususenhaweb = objUsuario.Ususenhaweb,
                        usuarioweb = objUsuario.Ususenha,
                        cli_codigo = objUsuario.Cli_Codigo,
                        ususenharapida = objUsuario.Ususenharapida
                    });
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

        public IEnumerable<Usuario> GetAll(int emp_Codigo)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    string query = $@"select USUARIO,GRUP_CODIGO,USUSENHA,EMP_CODIGO,USULOGON,USUSENHAWEB,
                                             USUARIOWEB,CLI_CODIGO,USUSENHARAPIDA 
                                     from USUARIO where emp_codigo=@empresa";
                    connection.Open();
                    return connection.Query<Usuario>(query, new
                    {
                        empresa = emp_Codigo
                    }).ToList();
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
        public Usuario GetById(string id, int emp_Codigo)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    string query = $@"select USUARIO,GRUP_CODIGO,USUSENHA,EMP_CODIGO,USULOGON,USUSENHAWEB,
                                             USUARIOWEB,CLI_CODIGO,USUSENHARAPIDA 
                                     from USUARIO where emp_codigo=@empresa and usuario=@usuario";
                    connection.Open();
                    return connection.Query<Usuario>(query, new {usuario=id,emp_codigo = emp_Codigo}).FirstOrDefault();
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

        public void Remove(string usuario,int emp_Codigo)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    string query = $@"  delete from USUARIO where USUARIO=@usuario and emp_codigo=@emp_codigo";

                    connection.Open();
                    connection.Execute(query, new
                    {
                        usuario = usuario,
                        emp_codigo = emp_Codigo,

                    });
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

        public void Update(Usuario objUsuario)
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    string query = $@"update USUARIO set GRUP_CODIGO=@grup_codigo,USUSENHA=@ususenha,USULOGON=@usulogon,
                                USUSENHAWEB=@ususenhaweb,USUARIOWEB=@usuarioweb,USUSENHARAPIDA=@ususenharapida
                                where USUARIO=@usuario and emp_codigo=@emp_codigo";

                    connection.Open();
                    connection.Execute(query, new
                    {
                        grup_codigo = objUsuario.Grup_Codigo,
                        ususenha = objUsuario.Ususenha,
                        usulogon = objUsuario.Usulogon,
                        ususenhaweb = objUsuario.Ususenhaweb,
                        usuarioweb = objUsuario.Ususenha,
                        ususenharapida = objUsuario.Ususenharapida,
                        usuario = objUsuario.usuario,
                        emp_codigo = objUsuario.Emp_Codigo,

                    });
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

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
