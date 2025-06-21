using Autofac.Features.Metadata;
using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using System.Drawing;

namespace EgourmetAPI.Repository
{
    public class ContasReceberRepository : IContasReceberRepository
    {

        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public ContasReceberRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(ContasReceber obj)
        {
            string query = $@"insert into contas_receber(
                                  Contrec_Codigo,
                                  Emp_Codigo,
                                  Contrec_Parcela,
                                  Anuencia_Cartorio,
                                  Contrec_Conta,
                                  Condic_Codigo,
                                  Port_Codigo,
                                  Tpcob_Codigo,
                                  Contrec_Documento,
                                  Contrec_Descricao,
                                  Cli_Codigo,
                                  Contrec_Data_Conta,
                                  Contrec_Data_Vencimento,
                                  Contrec_Valor,
                                  Contrec_Desconto,
                                  Contrec_Juros,
                                  Contrec_Multa,
                                  Contrec_Total,
                                  Contrec_Observacoes,
                                  Contrec_Cancelado,
                                  Contrec_Numparcelas,
                                  Orc_Codigo,
                                  Contrec_Nossonumero,
                                  Contrec_Dtbaicaauto,
                                  Contrec_Recibo,
                                  Contrec_Quitacao,
                                  Contrec_Vlrpago,
                                  Contrec_Nf,
                                  Dtmovimentacao,
                                  Anuencia_Data,
                                  Anuencia_Protocolo,
                                  Anuencia_Data_Baixa,
                                  Contrec_Controle,
                                  Contrec_Autorizacao,
                                  Orc_Ano,
                                  Avulso,
                                  Dt_Lib_Envio_Cob,
                                  Usu_Lib_Envio_Cob,
                                  Contrec_Desp_Cartorio,
                                  Contrec_Desp_Banco,
                                  Contrec_Desp_Outras,
                                  Podepagar_Usuario,
                                  Conta_Codigo)
                                values(
                                  @contreccodigo,
                                  @empresa,
                                  @parcela,
                                  @cartorio,
                                  @contrecconta,
                                  @condicao,
                                  @portador,
                                  @tipocobranca,
                                  @cliente,
                                  @documento,
                                  @descricao,
                                  current_date,
                                  @datavencimento,
                                  @valor,
                                  @desconto,
                                  @juros,
                                  @multa,
                                  @total,
                                  @observacoes,
                                  null,
                                  @totalparcelas,
                                  @orcamento,
                                  @orcamentoano,
                                  @nossonumero,
                                  null,
                                  null,
                                  null,
                                  0,
                                  @notafiscal,
                                  null,
                                  @anuenciadata,
                                  @anuenciaprotocolo,
                                  @anuenciadatabaixa,
                                  0,
                                  null
                                  null,
                                  null,
                                  null,
                                  0,
                                  0,
                                  null,
                                  @contacodigo)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    contreccodigo=obj.Contrec_Codigo,
                    empresa = obj.Emp_Codigo,
                    parcela = obj.Contrec_Parcela,
                    cartorio = obj.Anuencia_Cartorio,
                    contrecconta = obj.Contrec_Conta,
                    condicao = obj.Condic_Codigo,
                    portador = obj.Port_Codigo,
                    tipocobranca = obj.Tpcob_Codigo,
                    cliente = obj.Cli_Codigo,
                    documento = obj.Contrec_Documento,
                    descricao = obj.Contrec_Descricao,
                    datavencimento = obj.Contrec_Data_Vencimento,
                    valor = obj.Contrec_Valor,
                    desconto = obj.Contrec_Desconto,
                    juros = obj.Contrec_Juros,
                    multa = obj.Contrec_Multa,
                    total = obj.Contrec_Total,
                    observacoes = obj.Contrec_Observacoes,
                    totalparcelas = obj.Contrec_Numparcelas,
                    orcamento = obj.Orc_Codigo,
                    orcamentoano = obj.Orc_Ano,
                    nossonumero = obj.Contrec_Nossonumero,
                    notafiscal = obj.Contrec_Nf,
                    anuenciadata = obj.Anuencia_Data,
                    anuenciaprotocolo = obj.Anuencia_Protocolo,
                    anuenciadatabaixa = obj.Anuencia_Data_Baixa,
                    contacodig = obj.Conta_Codigo
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

        public IEnumerable<ContasReceber> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ContasReceber> GetAll(int empresa)
        {
            string query = $@"    select 
                                  Contrec_Codigo,
                                  Emp_Codigo,
                                  Contrec_Parcela,
                                  Anuencia_Cartorio,
                                  Contrec_Conta,
                                  Condic_Codigo,
                                  Port_Codigo,
                                  Tpcob_Codigo,
                                  Contrec_Documento,
                                  Contrec_Descricao,
                                  Cli_Codigo,
                                  Contrec_Data_Conta,
                                  Contrec_Data_Vencimento,
                                  Contrec_Valor,
                                  Contrec_Desconto,
                                  Contrec_Juros,
                                  Contrec_Multa,
                                  Contrec_Total,
                                  Contrec_Observacoes,
                                  Contrec_Cancelado,
                                  Contrec_Numparcelas,
                                  Orc_Codigo,
                                  Contrec_Nossonumero,
                                  Contrec_Dtbaicaauto,
                                  Contrec_Recibo,
                                  Contrec_Quitacao,
                                  Contrec_Vlrpago,
                                  Contrec_Nf,
                                  Dtmovimentacao,
                                  Anuencia_Data,
                                  Anuencia_Protocolo,
                                  Anuencia_Data_Baixa,
                                  Contrec_Controle,
                                  Contrec_Autorizacao,
                                  Orc_Ano,
                                  Avulso,
                                  Dt_Lib_Envio_Cob,
                                  Usu_Lib_Envio_Cob,
                                  Contrec_Desp_Cartorio,
                                  Contrec_Desp_Banco,
                                  Contrec_Desp_Outras,
                                  Podepagar_Usuario,
                                  Conta_Codigo
                            from contas_receber
                            where emp_codigo=@empresa";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<ContasReceber>(query, new
                {
                    empresa = empresa}).ToList();
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


        public ContasReceber GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ContasReceber GetById(int empresa , int contreccodigo)
        {
            string query = $@"    select 
                                  Contrec_Codigo,
                                  Emp_Codigo,
                                  Contrec_Parcela,
                                  Anuencia_Cartorio,
                                  Contrec_Conta,
                                  Condic_Codigo,
                                  Port_Codigo,
                                  Tpcob_Codigo,
                                  Contrec_Documento,
                                  Contrec_Descricao,
                                  Cli_Codigo,
                                  Contrec_Data_Conta,
                                  Contrec_Data_Vencimento,
                                  Contrec_Valor,
                                  Contrec_Desconto,
                                  Contrec_Juros,
                                  Contrec_Multa,
                                  Contrec_Total,
                                  Contrec_Observacoes,
                                  Contrec_Cancelado,
                                  Contrec_Numparcelas,
                                  Orc_Codigo,
                                  Contrec_Nossonumero,
                                  Contrec_Dtbaicaauto,
                                  Contrec_Recibo,
                                  Contrec_Quitacao,
                                  Contrec_Vlrpago,
                                  Contrec_Nf,
                                  Dtmovimentacao,
                                  Anuencia_Data,
                                  Anuencia_Protocolo,
                                  Anuencia_Data_Baixa,
                                  Contrec_Controle,
                                  Contrec_Autorizacao,
                                  Orc_Ano,
                                  Avulso,
                                  Dt_Lib_Envio_Cob,
                                  Usu_Lib_Envio_Cob,
                                  Contrec_Desp_Cartorio,
                                  Contrec_Desp_Banco,
                                  Contrec_Desp_Outras,
                                  Podepagar_Usuario,
                                  Conta_Codigo
                            from contas_receber
                            where emp_codigo=@empresa and contrec_codigo=@contreccodigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<ContasReceber>(query, new
                {
                    empresa = empresa,
                    contreccodigo = contreccodigo
                }).FirstOrDefault();
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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(int empresa, int contreccodigo)
        {
            string query = $@" delete from contas_receber 
                        where                                   
                          Contrec_Codigo=@contreccodigo and 
                          Emp_Codigo=@empresa ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    contreccodigo = contreccodigo,
                    empresa = empresa,
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

        public void Update(ContasReceber obj)
        {
            string query = $@" update contas_receber set
                                  Anuencia_Cartorio=@cartorio,
                                  Contrec_Conta=@contrecconta,
                                  Condic_Codigo=@condicao,
                                  Port_Codigo=@portador,
                                  Tpcob_Codigo=@tipocobranca,
                                  Contrec_Documento=@documento,
                                  Contrec_Descricao=@descricao,
                                  Cli_Codigo=@cliente,
                                  Contrec_Data_Vencimento=@datavencimento,
                                  Contrec_Valor=@valor,
                                  Contrec_Desp_Cartorio=@despcartorio,
                                  Contrec_Desp_Banco=@despbanco,
                                  Contrec_Desp_Outras=@despoutra,
                                  Contrec_Desconto=@desconto,
                                  Contrec_Juros=@juros,
                                  Contrec_Multa=@multa,
                                  Contrec_Total=@total,
                                  Contrec_Observacoes=@observacoes,
                                  Contrec_Numparcelas=@totalparcelas,
                                  Orc_Codigo=@orcamento,
                                  Orc_Ano=@orcamentoano,
                                  Contrec_Nossonumero=@nossonumero,
                                  Contrec_Quitacao=@dataquitacao,
                                  Contrec_Vlrpago=@valorpago,
                                  Contrec_Nf=@notafiscal,
                                  Anuencia_Data=@anuenciadata,
                                  Anuencia_Protocolo=@anuenciaprotocolo,
                                  Anuencia_Data_Baixa=@anuenciadatabaixa,
                                  Conta_Codigo=@contacodigo
                        where                                   
                          Contrec_Codigo=@contreccodigo and 
                          Emp_Codigo=@empresa ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    contreccodigo = obj.Contrec_Codigo,
                    empresa = obj.Emp_Codigo,
                    parcela = obj.Contrec_Parcela,
                    cartorio = obj.Anuencia_Cartorio,
                    contrecconta = obj.Contrec_Conta,
                    condicao = obj.Condic_Codigo,
                    portador = obj.Port_Codigo,
                    tipocobranca = obj.Tpcob_Codigo,
                    cliente = obj.Cli_Codigo,
                    documento = obj.Contrec_Documento,
                    descricao = obj.Contrec_Descricao,
                    datavencimento = obj.Contrec_Data_Vencimento,
                    valor = obj.Contrec_Valor,
                    despcartorio = obj.Contrec_Desp_Cartorio,
                    despoutra = obj.Contrec_Desp_Outras,
                    despbanco = obj.Contrec_Desp_Banco,
                    desconto = obj.Contrec_Desconto,
                    juros = obj.Contrec_Juros,
                    multa = obj.Contrec_Multa,
                    total = obj.Contrec_Total,
                    valorpago = obj.Contrec_Vlrpago,
                    observacoes = obj.Contrec_Observacoes,
                    totalparcelas = obj.Contrec_Numparcelas,
                    orcamento = obj.Orc_Codigo,
                    orcamentoano = obj.Orc_Ano,
                    nossonumero = obj.Contrec_Nossonumero,
                    notafiscal = obj.Contrec_Nf,
                    anuenciadata = obj.Anuencia_Data,
                    anuenciaprotocolo = obj.Anuencia_Protocolo,
                    anuenciadatabaixa = obj.Anuencia_Data_Baixa,
                    contacodigo = obj.Conta_Codigo,
                    dataquitacao = obj.Contrec_Quitacao,
                }); ;
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
    }
}
