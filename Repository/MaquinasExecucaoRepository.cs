using System.Runtime.Intrinsics.Arm;
using Dapper;
using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace egourmetAPI.Repository
{
    public class MaquinasExecucaoRepository : IMaquinasExecucaoRepository
    {
        private IConfiguration _configuration;
        string conexao { get { return _configuration.GetConnectionString("firedb"); } }
        public MaquinasExecucaoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Add(MaquinasExecucao objMaqHisUso)
        {
            string query = $@"insert into MAQUINAS_EXECUCAO 
                            (EMP_CODIGO, IDCREDITO, IDANO, IDLANC, SEQUENCIAL, IDMAQUINA,
                             IDETAPA, DTINICIOEXECUCAO, STATUS) 
                            values(@emp_codigo,@idcredito,@idano,@idlanc,@sequencial,
                                   @idmaquina,@idetapa,(select CURRENT_TIMESTAMP  from rdb$database),@status)";
            
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                //falta criar o sequencial ultimo+1
                connection.Execute(query, new {
                    emp_codigo= objMaqHisUso.emp_Codigo,
                    idcredito = objMaqHisUso.idCredito,
                    idano = objMaqHisUso.idAno,
                    idlanc = objMaqHisUso.idLanc,
                    sequencial = objMaqHisUso.sequencial,
                    idmaquina = objMaqHisUso.idMaquina,
                    idetapa = objMaqHisUso.idEtapa,
                    status = objMaqHisUso.status
                     });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
                connection.Close();
            }
        }

        public IEnumerable<MaquinasExecucao> GetAll(int empresa,int idCred, string idAno, int idLanc)
        {
            string query = $@"select EMP_CODIGO, IDCREDITO, IDANO, IDLANC, SEQUENCIAL, IDMAQUINA,
                             IDETAPA, DTINICIOEXECUCAO, DTFINALEXECUCAO, STATUS 
                            from MAQUINAS_EXECUCAO 
                            where EMP_CODIGO=@emp_codigo and IDCREDITO=@idcredito and IDANO=@idano and IDLANC=@idlanc";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                //falta criar o sequencial ultimo+1
                return connection.Query<MaquinasExecucao>(query, new
                {
                    emp_codigo = empresa,
                    idcredito = idCred,
                    idano = idAno,
                    idlanc = idLanc,
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

        public MaquinasExecucao GetById(int empresa, int idCred, string idAno, int idLanc, int Sequencial)
        {
            string query = $@"select EMP_CODIGO, IDCREDITO, IDANO, IDLANC, SEQUENCIAL, IDMAQUINA,
                             IDETAPA, DTINICIOEXECUCAO, DTFINALEXECUCAO, STATUS 
                            from MAQUINAS_EXECUCAO 
                            where EMP_CODIGO=@emp_codigo and 
                                  IDCREDITO=@idcredito and 
                                  IDANO=@idano and 
                                  IDLANC=@idlanc and 
                                  SEQUENCIAL=@sequencial";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                //falta criar o sequencial ultimo+1
                return connection.Query<MaquinasExecucao>(query, new
                {
                    emp_codigo = empresa,
                    idcredito = idCred,
                    idano = idAno,
                    idlanc = idLanc,
                    sequencial=Sequencial
                }).FirstOrDefault();
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

        public void Remove(int empresa, int idCred, string idAno, int idLanc, int Sequencial)
        {
            string query = $@"delete from MAQUINAS_EXECUCAO 
                            where EMP_CODIGO=@emp_codigo and 
                                  IDCREDITO=@idcredito and 
                                  IDANO=@idano and 
                                  IDLANC=@idlanc and 
                                  SEQUENCIAL=@sequencial";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                //falta criar o sequencial ultimo+1
                connection.Execute(query, new
                {
                    emp_codigo = empresa,
                    idcredito = idCred,
                    idano = idAno,
                    idlanc = idLanc,
                    sequencial = Sequencial
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

        public void Update(MaquinasExecucao objMaqHisUso)
        {
            string query = $@"update MAQUINAS_EXECUCAO 
                            set DTFINALEXECUCAO=(select date 'NOW' from rdb$database), STATUS=@status
                            where EMP_CODIGO=@emp_codigo and IDCREDITO=@idcredito and 
                                  IDANO=@idano and IDLANC=@idlanc and SEQUENCIAL=@sequencial
                                  and IDMAQUINA=@idmaquina and IDETAPA=@idetapa";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                //falta criar o sequencial ultimo+1
                connection.Execute(query, new
                {
                    emp_codigo = objMaqHisUso.emp_Codigo,
                    idcredito = objMaqHisUso.idCredito,
                    idano = objMaqHisUso.idAno,
                    idlanc = objMaqHisUso.idLanc,
                    sequencial = objMaqHisUso.sequencial,
                    idmaquina = objMaqHisUso.idMaquina,
                    idetapa = objMaqHisUso.idEtapa,
                    status = objMaqHisUso.status
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

        public IEnumerable<MaquinasExecucao> GetAll()
        {
            throw new NotImplementedException();
        }

        public MaquinasExecucao GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
