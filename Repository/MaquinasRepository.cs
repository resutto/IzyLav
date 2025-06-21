using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Dapper;
using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.Model;

namespace IzyLav.Repository
{
    public class MaquinasRepository : IMaquinasRepository
    {
        private IConfiguration _configuration;
        string conexao { get { return _configuration.GetConnectionString("firedb"); } }
        public MaquinasRepository(IConfiguration config)
        {
            _configuration = config;
        }
        public void Add(Maquinas objMaquina)
        {
            string query = $@"insert into MAQUINAS( 
                              EMP_CODIGO,
                              IDMAQUINA,
                              NOMEMAQUINA,
                              TIPOMAQUINA,
                              FUNCAOLAVAR,
                              FUNCAOSECAR,
                              TRABALHANDO,
                              BLOQUEADA) values 
                             (@emp_codigo,
                              @idmaquina,
                              @nomemaquina,
                              @tipomaquina,
                              @funcaolavar,
                              @funcaosecar,
                              @trabalhando,
                              @bloqueada)";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new {
                    emp_codigo  = objMaquina.Emp_Codigo,
                    idmaquina   = objMaquina.IdMaquina,
                    nomemaquina = objMaquina.NomeMaquina,
                    tipomaquina = objMaquina.TipoMaquina,
                    funcaolavar = objMaquina.FuncaoLavar,
                    funcaosecar = objMaquina.FuncaoSecar,
                    trabalhando = objMaquina.Trabalhando,
                    bloqueada   = objMaquina.Bloqueada
                });
            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public IEnumerable<Maquinas> GetAll(int empCodigo)
        {
            string query=$@"select 
                              EMP_CODIGO,
                              IDMAQUINA,
                              NOMEMAQUINA,
                              TIPOMAQUINA,
                              FUNCAOLAVAR,
                              FUNCAOSECAR,
                              TRABALHANDO,
                              BLOQUEADA
                            from MAQUINAS where emp_codigo=@emp_codigo";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Maquinas>(query, new {emp_codigo=empCodigo}).ToList();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public Maquinas GetById(string id, int empCodigo)
        {
            string query = $@" select 
                                  EMP_CODIGO,
                                  IDMAQUINA,
                                  NOMEMAQUINA,
                                  TIPOMAQUINA,
                                  FUNCAOLAVAR,
                                  FUNCAOSECAR,
                                  TRABALHANDO,
                                  BLOQUEADA
                                from MAQUINAS where emp_codigo=@emp_codigo and
                                  idmaquina=@idmaquina";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                return connection.Query<Maquinas>(query, new { emp_codigo=empCodigo, idmaquina=id}).FirstOrDefault();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void Remove(string id, int empCodigo)
        {
            string query = $@"delete from MAQUINAS where EMP_CODIGO=@emp_codigo and IDMAQUINA=@idmaquina ";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                connection.Execute(query, new { emp_codigo = empCodigo, idmaquina = id });
            }
            catch (Exception ex) { throw ex; }
            finally { 
                connection.Close(); 
            }
        }

        public void UpdateStatus(int empCodigo, string id)
        {
            string query = $@"update MAQUINAS set trabalhando = @trabalhando where EMP_CODIGO = @emp_codigo and IDMAQUINA = @idmaquina";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                connection.Execute(query, new { emp_codigo = empCodigo, idmaquina=id});
            } catch (Exception ex) {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public IEnumerable<Maquinas> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maquinas GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Maquinas objMaquina)
        {
            string query = $@"update MAQUINAS set  NOMEMAQUINA=@nomemaquina, TIPOMAQUINA=@tipomaquina,
                                                   FUNCAOLAVAR=@funcaolavar, FUNCAOSECAR=@funcaosecar,
                                                   BLOQUEADA  =@bloqueada 
                                                   where
                                                      EMP_CODIGO=@emp_codigo and
                                                      IDMAQUINA=@idmaquina";
            var connection = new FbConnection(conexao);
            try { 
                connection.Open();
                connection.Execute(query, new
                {

                    nomemaquina = objMaquina.NomeMaquina,
                    tipomaquina = objMaquina.TipoMaquina,
                    funcaolavar = objMaquina.FuncaoLavar,
                    funcaosecar = objMaquina.FuncaoSecar,
                    bloqueada = objMaquina.Bloqueada,
                    emp_codigo = objMaquina.Emp_Codigo,
                    idmaquina = objMaquina.IdMaquina
                });
            } catch (Exception ex) { throw ex; } finally { connection.Close(); }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(MaquinasEtapas objMaquinasEtapas)
        {
            throw new NotImplementedException();
        }
    }
}
