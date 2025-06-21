using System.Data.Common;
using System.Transactions;
using Dapper;
using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;
using FirebirdSql.Data.FirebirdClient;

namespace egourmetAPI.Repository
{
    public class CreditosRepository : ICreditosRepository
    {
        private IConfiguration _configuration; 
        string conexao {  get{ return _configuration.GetConnectionString("firedb"); } }
        
        public CreditosRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //os creditos estao sendo lancados via banco de dados por isso ainda não estou usando essas rotinas de INCLUIR
        //ainda não foram testadas
        public void Add(Creditos obj)
        {
            string query = $@"insert into creditos(emp_codigo,idcredito,idano,dataoperacao,horaoperacao,idcredito_anterior,idano_anterior,valor,cli_codigo,idlanc,logframe)
                              values(@empresa,@idcredito,@idano,@dataOperacao,@horaOperacao,@idCreditoAnt,@idCreditoAnoAnt,@valor, @cliente,@idlanc,@logframe)";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new{
                    empresa=obj.Emp_Codigo,
                    idcredito=obj.IdCredito,
                    idano=obj.IdAno,
                    dataOperacao=obj.DataOperacao,
                    horaOperacao=obj.HoraOperacao,
                    idCreditoAnt=obj.Idcredito_Anterior,
                    idCreditoAnoAnt=obj.Idano_Anterior,
                    valor=obj.Valor,
                    cliente=obj.Cli_Codigo,
                    idlanc=obj.IdLanc,
                    logframe=obj.LogFrame
                });
            }
            catch (Exception e)
            {
                throw e;
            } finally
            {
                connection.Close();
            }
            
        }


        public IEnumerable<Creditos> GetTicketsCompradosLivres(int empCodigo)
        {
            string query = $@"select  EMP_CODIGO,IDCREDITO,IDANO,DATAOPERACAO,HORAOPERACAO,VALOR
                            from creditos where emp_codigo=@empresa 
                            and idlanc is null and cli_codigo is null and dtimpressao is null and dtenviosms is null";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                return connection.Query<Creditos>(query, new { empresa = empCodigo }).ToList();
            } catch (Exception e) {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }
        public IEnumerable<Creditos> GetAll(int empCodigo)
        {
            string query = $@"select  EMP_CODIGO,IDCREDITO,IDANO,DATAOPERACAO,HORAOPERACAO,IDCREDITO_ANTERIOR,IDANO_ANTERIOR,
                            VALOR,CONDIC_CODIGO,CLI_CODIGO,IDLANC,LOGFRAME 
                            from creditos where emp_codigo=@empresa";
            
            var connection = new FbConnection(conexao);

            try
            {
                connection.Open();
                return connection.Query<Creditos>(query, new { empresa = empCodigo }).ToList();
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

        public Creditos GetById(int id, int empCodigo, string ano)
        {
            string query = $@"select  EMP_CODIGO,IDCREDITO,IDANO,DATAOPERACAO,HORAOPERACAO,IDCREDITO_ANTERIOR,IDANO_ANTERIOR,
                            VALOR,CONDIC_CODIGO,CLI_CODIGO,IDLANC,LOGFRAME 
                            from creditos where emp_codigo=@empresa and idcredito=@idcredito and idano=@idano";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();

                return connection.Query<Creditos>(query, new { empresa = empCodigo, idcredito = id, idano = ano }).FirstOrDefault();
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
        /*
         Validações a serem incluidas:
        1) Se a maquina esta disponivel?
        2) Se o credito ainda não foi utilizado em outra maquina
         */
        public void ConsumirCreditoMaquina(int empCodigo, int idCredito, string idAno, string idMaquina)
        {
            string query1 = $@"insert into MAQUINAS_CREDITOS(EMP_CODIGO,IDLANC,IDMAQUINA,
                                                            IDCREDITO,IDANO,DATAUTILIZACAO,HORAUTILIZACAO) values(@empresa, @idlanc, @idmaquina, 
                                                                                   @idcredito, @idano,
                                                            (select date 'NOW' from rdb$database),
                                                            (select substring(time 'now' from 1 for 8) from rdb$database) )";
            string query2 = $@"update creditos set idlanc=@lancamento 
                               where EMP_CODIGO=@empresa and IDCREDITO=@idcredito and IDANO=@idano";
            
            var connection = new FbConnection(conexao);
            connection.Open();
            IdLanc que1 = GerarIdLanc(empCodigo, connection);
            FbTransaction transaction = connection.BeginTransaction();
            FbCommand command = new FbCommand();
            try
                {

                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = query1;
                command.Parameters.AddWithValue("@empresa", empCodigo);
                command.Parameters.AddWithValue("@idlanc", que1.idLanc);
                command.Parameters.AddWithValue("@idmaquina", idMaquina);
                command.Parameters.AddWithValue("@idcredito", idCredito);
                command.Parameters.AddWithValue("@idano", idAno);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = query2;
                command.Parameters.AddWithValue("@empresa", empCodigo);
                command.Parameters.AddWithValue("@lancamento", que1.idLanc);
                command.Parameters.AddWithValue("@idcredito", idCredito);
                command.Parameters.AddWithValue("@idano", idAno);
                command.ExecuteNonQuery();

                transaction.Commit();
                }
            catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            finally
                {
                    connection.Close();
                }

           

        }

        public IdLanc GerarIdLanc(int empCodigo, FbConnection con1)
        {
            string query = $@"select max(idlanc)+1 as idlanc from MAQUINAS_CREDITOS where emp_Codigo=@empresa";
            try
            {
                IdLanc id;
                id = con1.Query<IdLanc>(query, new { empresa = empCodigo }).FirstOrDefault();
                if (id.idLanc == 0 ){
                    id.idLanc = 1;
                }
                return id;
            }
            catch (Exception ex) {
                throw ex;
            }
                
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Creditos obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Creditos> GetAll()
        {
            throw new NotImplementedException();
        }

        public Creditos GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
