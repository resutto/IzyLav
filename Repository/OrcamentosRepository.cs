using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;

namespace EgourmetAPI.Repository
{
    public class OrcamentosRepository : IOrcamentosRepository
    {

        private IConfiguration _configuration;
        string conexao { get { return _configuration.GetConnectionString("firedb"); } }

        public OrcamentosRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Add(Orcamentos obj)
        {

            string query = $@"insert into orcamentos(  
                                      Emp_Codigo,
                                      Orc_Codigo,
                                      Orc_Ano,
                                      Conta_Codigo,
                                      Condic_Codigo,
                                      Trans_Codigo,
                                      Orc_Data,
                                      Fun_Codigo,
                                      Cli_Codigo,
                                      Orc_Data_Confirmacao,
                                      Orc_Subtotal,
                                      Orc_Observacoes,
                                      Orc_Total,
                                      Orc_Desconto,
                                      Orc_Totitems,
                                      Orc_Qdeparcelas,
                                      Orc_Notafical,
                                      Orc_Imposto,
                                      Cfop,
                                      Cancelado,
                                      Formpgto_Codigo,
                                      Mov_Codigo,
                                      Preorc_Codigo,
                                      Orc_Dt_Cancela,
                                      Orc_Data_Emissao,
                                      Orc_Data_Saida,
                                      Orc_Vlriss,
                                      Orc_Vlrpis,
                                      Orc_Vlrcofins,
                                      Orc_VlrIrrf,
                                      Orc_Vlrinss,
                                      Orc_Vlrcsll,
                                      Entreg_Endereco,
                                      Entreg_Numero,
                                      Entreg_Bairro,
                                      Entreg_Cidade,
                                      Entreg_Uf,
                                      Entreg_Fone1,
                                      Entreg_Fone2,
                                      Entreg_Cep,
                                      Entreg_Contato,
                                      Entreg_Local,
                                      Entreg_Compl,
                                      Entreg_Referencia,
                                      Condic_Obs,
                                      Liberado,
                                      Dtentrega,
                                      Dtcancelado,
                                      Hrcancelado,
                                      Orc_Notafiscal,
                                      Orc_Nfserie,
                                      Nfse,
                                      File_Xml_Nfe,
                                      Dt_Envio_Xml,
                                      File_Xml_Cancelado,
                                      Dt_Cancelamento_Nfe,
                                      Hora_Abertura,
                                      Orc_Data_Hora,
                                      Orc_Fim_Hora,
                                      Seq,
                                      Perc_Comissao,
                                      Vlr_Comissao,
                                      Vlr_Acrescimo,
                                      Perc_Desconto,
                                      Mesa,
                                      Orc_Hrultimo_Atendimento,
                                      Numero_Nfce,
                                      Serie_Nfce,
                                      Orc_Notafiscal_Serie,
                                      Totaproxtributo,
                                      inscricaoestadual,
                                      emissorinscricaoestadual,
                                      Pc_Criou,
                                      Via,
                                      Pc_Encerrou,
                                      Nfe_Tp_Doc,
                                      Nfe_Doc)

                                    values(
                                      @empresa,
                                      @orccodigo,
                                      (select substring(date 'NOW'  from 1 for 4 ) from rdb$database),
                                      @contacodigo,
                                      @condicaopgto,
                                      @transportador,
                                      CURRENT_DATE,
                                      @funcodigo,
                                      @clicodigo,
                                      null,
                                      @subtotal,
                                      @observacoes,
                                      @total,
                                      @desconto,
                                      @totalitens,
                                      @qdeparcelas,
                                      @notafical,
                                      @valorimposto,
                                      @cfop,
                                      @cancelado,
                                      @formpgtoCodigo,
                                      null,
                                      0,
                                      null,
                                      null,
                                      null,
                                      0,
                                      0,
                                      0,
                                      0,
                                      0,
                                      0,
                                      @endereco,
                                      @numero,
                                      @bairro,
                                      @cidade,
                                      @uf,
                                      @fone1,
                                      @fone2,
                                      @cep,
                                      @contato,
                                      @local,
                                      @compl,
                                      @referencia,
                                      @condicobs,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      0,
                                      0,
                                      0,
                                      0,
                                      0,
                                      null,
                                      null,
                                      null,
                                      null,
                                      null,
                                      0,
                                      @inscricaoestadual,
                                      @emissorinscricaoestadual,
                                      @pccriou,
                                      0,
                                      null,
                                      null,
                                      null
                                    )";

            var connection = new FbConnection(conexao);
            IdLanc que1 = Datpai.GerarIdLanc(obj.Emp_Codigo, connection,
                                 $@"select max(orc_codigo)+1 as idlanc from orcamentos where emp_Codigo=@empresa and orc_ano= (select substring(date 'NOW'  from 1 for 4 ) from rdb$database) ");

            try
            {
                connection.Execute(query, new
                {
                    empresa=obj.Emp_Codigo,
                    orccodigo=que1.idLanc,
                    contacodigo=obj.Conta_Codigo,
                    condicaopgto=obj.Condic_Codigo,
                    transportador=obj.Trans_Codigo,
                    funcodigo=obj.Fun_Codigo,
                    clicodigo=obj.Cli_Codigo,
                    inscricaoestadual = obj.inscricaoestadual,
                    emissorinscricaoestadual = obj.emissorinscricaoestadual,
                    subtotal = obj.Orc_Subtotal,
                    observacoes=obj.Orc_Observacoes,
                    total=obj.Orc_Total,
                    desconto=obj.Orc_Desconto,
                    totalitens=obj.Orc_Totitems,
                    qdeparcelas=obj.Orc_Qdeparcelas,
                    notafical=obj.Orc_Notafical,
                    valorimposto=obj.Orc_Imposto,
                    cfop=obj.Cfop,
                    cancelado=obj.Cancelado,
                    formpgtoCodigo=obj.Formpgto_Codigo,
                    endereco=obj.Entreg_Endereco,
                    numero=obj.Entreg_Numero,
                    bairro=obj.Entreg_Bairro,
                    cidade=obj.Entreg_Cidade,
                    uf=obj.Entreg_Uf,
                    fone1=obj.Entreg_Fone1,
                    fone2=obj.Entreg_Fone2,
                    cep=obj.ENTREG_Cep,
                    contato=obj.Entreg_Contato,
                    local=obj.Entreg_Local,
                    compl=obj.Entreg_Compl,
                    referencia=obj.Entreg_Referencia,
                    condicobs=obj.Condic_Obs,
                    pccriou=obj.Pc_Criou

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

        public IEnumerable<Orcamentos> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orcamentos> GetAll(int empresa)
        {
            string query = $@" select Emp_Codigo,
                                      Orc_Codigo,
                                      Orc_Ano,
                                      Conta_Codigo,
                                      Condic_Codigo,
                                      Trans_Codigo,
                                      Orc_Data,
                                      Fun_Codigo,
                                      Cli_Codigo,
                                      Orc_Data_Confirmacao,
                                      Orc_Subtotal,
                                      Orc_Observacoes,
                                      Orc_Total,
                                      Orc_Desconto,
                                      Orc_Totitems,
                                      Orc_Qdeparcelas,
                                      Orc_Notafical,
                                      Orc_Imposto,
                                      Cfop,
                                      Cancelado,
                                      Formpgto_Codigo,
                                      Mov_Codigo,
                                      Preorc_Codigo,
                                      Orc_Dt_Cancela,
                                      Orc_Data_Emissao,
                                      Orc_Data_Saida,
                                      Orc_Vlriss,
                                      Orc_Vlrpis,
                                      Orc_Vlrcofins,
                                      Orc_VlrIrrf,
                                      Orc_Vlrinss,
                                      Orc_Vlrcsll,
                                      Entreg_Endereco,
                                      Entreg_Numero,
                                      Entreg_Bairro,
                                      Entreg_Cidade,
                                      Entreg_Uf,
                                      Entreg_Fone1,
                                      Entreg_Fone2,
                                      Entreg_Cep,
                                      Entreg_Contato,
                                      Entreg_Local,
                                      Entreg_Compl,
                                      Entreg_Referencia,
                                      Condic_Obs,
                                      Liberado,
                                      Dtentrega,
                                      Dtcancelado,
                                      Hrcancelado,
                                      Orc_Notafiscal,
                                      Orc_Nfserie,
                                      Nfse,
                                      File_Xml_Nfe,
                                      Dt_Envio_Xml,
                                      File_Xml_Cancelado,
                                      Dt_Cancelamento_Nfe,
                                      Hora_Abertura,
                                      Orc_Data_Hora,
                                      Orc_Fim_Hora,
                                      Seq,
                                      Perc_Comissao,
                                      Vlr_Comissao,
                                      Vlr_Acrescimo,
                                      Perc_Desconto,
                                      Mesa,
                                      Orc_Hrultimo_Atendimento,
                                      Numero_Nfce,
                                      Serie_Nfce,
                                      Orc_Notafiscal_Serie,
                                      Totaproxtributo,
                                      inscricaoestadual,
                                      emissorinscricaoestadual,
                                      Pc_Criou,
                                      Via,
                                      Pc_Encerrou,
                                      Nfe_Tp_Doc,
                                      Nfe_Doc 
                                from orcamentos
                                where emp_codigo= @empresa";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Orcamentos>(query, new
                {empresa = empresa}).ToList();
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

        public Orcamentos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Orcamentos GetById(int empresa, int orcamentoid, string ano)
        {
            string query = $@" select Emp_Codigo,
                                      Orc_Codigo,
                                      Orc_Ano,
                                      Conta_Codigo,
                                      Condic_Codigo,
                                      Trans_Codigo,
                                      Orc_Data,
                                      Fun_Codigo,
                                      Cli_Codigo,
                                      Orc_Data_Confirmacao,
                                      Orc_Subtotal,
                                      Orc_Observacoes,
                                      Orc_Total,
                                      Orc_Desconto,
                                      Orc_Totitems,
                                      Orc_Qdeparcelas,
                                      Orc_Notafical,
                                      Orc_Imposto,
                                      Cfop,
                                      Cancelado,
                                      Formpgto_Codigo,
                                      Mov_Codigo,
                                      Preorc_Codigo,
                                      Orc_Dt_Cancela,
                                      Orc_Data_Emissao,
                                      Orc_Data_Saida,
                                      Orc_Vlriss,
                                      Orc_Vlrpis,
                                      Orc_Vlrcofins,
                                      Orc_VlrIrrf,
                                      Orc_Vlrinss,
                                      Orc_Vlrcsll,
                                      Entreg_Endereco,
                                      Entreg_Numero,
                                      Entreg_Bairro,
                                      Entreg_Cidade,
                                      Entreg_Uf,
                                      Entreg_Fone1,
                                      Entreg_Fone2,
                                      Entreg_Cep,
                                      Entreg_Contato,
                                      Entreg_Local,
                                      Entreg_Compl,
                                      Entreg_Referencia,
                                      Condic_Obs,
                                      Liberado,
                                      Dtentrega,
                                      Dtcancelado,
                                      Hrcancelado,
                                      Orc_Notafiscal,
                                      Orc_Nfserie,
                                      Nfse,
                                      File_Xml_Nfe,
                                      Dt_Envio_Xml,
                                      File_Xml_Cancelado,
                                      Dt_Cancelamento_Nfe,
                                      Hora_Abertura,
                                      Orc_Data_Hora,
                                      Orc_Fim_Hora,
                                      Seq,
                                      Perc_Comissao,
                                      Vlr_Comissao,
                                      Vlr_Acrescimo,
                                      Perc_Desconto,
                                      Mesa,
                                      Orc_Hrultimo_Atendimento,
                                      Numero_Nfce,
                                      Serie_Nfce,
                                      Orc_Notafiscal_Serie,
                                      Totaproxtributo,
                                      inscricaoestadual,
                                      emissorinscricaoestadual,
                                      Pc_Criou,
                                      Via,
                                      Pc_Encerrou,
                                      Nfe_Tp_Doc,
                                      Nfe_Doc 
                                from orcamentos
                                where emp_codigo= @empresa and 
                                      orc_codigo= @codigo and 
                                         orc_ano= @ano";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Orcamentos>(query, new
                { empresa = empresa, codigo=orcamentoid, ano=ano }).FirstOrDefault();
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

        public void Remove(int empresa, int orcamentoid, string ano)
        {
            string query = $@"delete from orcamentos  
                              where                                       
                                Emp_Codigo = @empresa   and 
                                Orc_Codigo = @orccodigo and
                                orc_ano    = @orcano";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = empresa,
                    orccodigo = orcamentoid,
                    orcano = ano
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

        public void Update(Orcamentos obj)
        {
            string query = $@"update orcamentos set   
                                      Conta_Codigo=@contacodigo,
                                      Condic_Codigo=@condicaopgto,
                                      Trans_Codigo=@transportador,
                                      Fun_Codigo=@funcodigo,
                                      Cli_Codigo=@clicodigo,
                                      Orc_Subtotal=@subtotal,
                                      Orc_Observacoes=@observacoes,
                                      Orc_Total=@total,
                                      Orc_Desconto=@desconto,
                                      Orc_Totitems=@totalitens,
                                      Orc_Qdeparcelas=@qdeparcelas,
                                      Orc_Imposto=@valorimposto,
                                      Cfop=@cfop,
                                      Formpgto_Codigo=@formpgtoCodigo,
                                      Orc_Vlriss=@vlriss,
                                      Orc_Vlrpis=@vlrpis,
                                      Orc_Vlrcofins=@vlrcofins,
                                      Orc_VlrIrrf=@vlrirrf,
                                      Orc_Vlrinss=@vlrinss,
                                      Orc_Vlrcsll=@vlrcsll,
                                      Entreg_Endereco=@endereco,
                                      Entreg_Numero=@numero,
                                      Entreg_Bairro=@bairro,
                                      Entreg_Cidade=@cidade,
                                      Entreg_Uf=@uf,
                                      Entreg_Fone1=@fone1,
                                      Entreg_Fone2=@fone2,
                                      Entreg_Cep=@cep,
                                      Entreg_Contato=@contato,
                                      Entreg_Local=@local,
                                      Entreg_Compl=@compl,
                                      Entreg_Referencia=@referencia,
                                      Condic_Obs=@condicobs,
                                      inscricaoestadual=@inscricaoestadual,
                                      emissorinscricaoestadual=@emissorinscricaoestadual,
                                      Nfe_Tp_Doc=@nfetp,
                                      Nfe_Doc=@nfedoc 
                                where                                       
                                      Emp_Codigo=@empresa   and 
                                      Orc_Codigo=@orccodigo and
                                      orc_ano= @orcano";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = obj.Emp_Codigo,
                    orccodigo = obj.Orc_Codigo,
                    orcano = obj.Orc_Ano,
                    contacodigo = obj.Conta_Codigo,
                    condicaopgto = obj.Condic_Codigo,
                    transportador = obj.Trans_Codigo,
                    funcodigo = obj.Fun_Codigo,
                    clicodigo = obj.Cli_Codigo,
                    inscricaoestadual = obj.inscricaoestadual,
                    emissorinscricaoestadual = obj.emissorinscricaoestadual,
                    subtotal = obj.Orc_Subtotal,
                    observacoes = obj.Orc_Observacoes,
                    total = obj.Orc_Total,
                    desconto = obj.Orc_Desconto,
                    totalitens = obj.Orc_Totitems,
                    qdeparcelas = obj.Orc_Qdeparcelas,
                    valorimposto = obj.Orc_Imposto,
                    cfop = obj.Cfop,
                    formpgtoCodigo = obj.Formpgto_Codigo,
                    endereco = obj.Entreg_Endereco,
                    numero = obj.Entreg_Numero,
                    bairro = obj.Entreg_Bairro,
                    cidade = obj.Entreg_Cidade,
                    uf = obj.Entreg_Uf,
                    fone1 = obj.Entreg_Fone1,
                    fone2 = obj.Entreg_Fone2,
                    cep = obj.ENTREG_Cep,
                    contato = obj.Entreg_Contato,
                    local = obj.Entreg_Local,
                    compl = obj.Entreg_Compl,
                    referencia = obj.Entreg_Referencia,
                    condicobs = obj.Condic_Obs,
                    nfetp=obj.Nfe_Tp_Doc,
                    nfedoc=obj.Nfe_Doc

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
    }
}
