using Autofac.Features.Metadata;
using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using System.Diagnostics;
using System.Drawing;

namespace EgourmetAPI.Repository
{

    public class CaixaLancRepository : ICaixaLancRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public CaixaLancRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(CaixaLanc obj)
        {
            string query = $@"insert into caixa_lanc(
                                      Emp_Codigo,
                                      Lanc_Codigo,
                                      Parcela,
                                      Conta_Codigo,
                                      Tipo,
                                      Condic_Codigo,
                                      Hora,
                                      Data,
                                      Documento,
                                      Historico,
                                      Usuario,
                                      Nro_Compra,
                                      Nro_Venda,
                                      Contrec_Codigo,
                                      Contpag_Codigo,
                                      Valor,
                                      Juros_Real,
                                      Multa,
                                      Desconto,
                                      Valor_total,
                                      Troco,
                                      Nf,
                                      Orc_Ano,
                                      Cont_Codigo,
                                      For_Codigo,
                                      Cli_Codigo,
                                      Dtsangria,
                                      Hrsangria,
                                      Dtsuprimento,
                                      Hrsuprimento,
                                      Cpgrup_Codigo,
                                      Cpsgrup_Codigo)
                                    values(
                                      @empresa,
                                      @lancamento,
                                      @parcela,
                                      @contacodigo,
                                      @tipo,
                                      @condiccodigo,
                                      @hora,
                                      @data,
                                      @documento,
                                      @historico,
                                      @Usuario,
                                      @nrocompra,
                                      @nrovenda,
                                      @recebimentocodigo,
                                      @pagamentocodigo,
                                      @valor,
                                      @Jurosreal,
                                      @multa,
                                      @desconto,
                                      @valortotal,
                                      @troco,
                                      @Nf,
                                      @ano,
                                      @contcodigo,
                                      @fornecedor,
                                      @cliente,
                                      @dtsangria,
                                      @hrsangria,
                                      @dtsuprimento,
                                      @hrsuprimento,
                                      @cpgrupcodigo,
                                      @cpsgrupcodigo)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa=obj.Emp_Codigo,
                    lancamento = obj.Lanc_Codigo,
                    parcela = obj.Parcela,
                    contacodigo = obj.Conta_Codigo,
                    tipo = obj.Tipo,
                    condiccodigo = obj.Condic_Codigo,
                    hora = obj.Hora,
                    data = obj.Data,
                    documento = obj.Documento,
                    historico = obj.Historico,
                    Usuario = obj.Usuario,
                    nrocompra = obj.Nro_Compra,
                    nrovenda = obj.Nro_Venda,
                    recebimentocodigo = obj.Contrec_Codigo,
                    pagamentocodigo = obj.Contpag_Codigo,
                    valor = obj.Valor,
                    Jurosreal = obj.Juros_Real,
                    multa = obj.Multa,
                    desconto = obj.Desconto,
                    valortotal = obj.Valor_total,
                    troco = obj.Troco,
                    Nf = obj.Nf,
                    ano = obj.Orc_Ano,
                    contcodigo = obj.Cont_Codigo,
                    fornecedor = obj.For_Codigo,
                    cliente = obj.Cli_Codigo,
                    dtsangria = obj.Dtsangria,
                    hrsangria = obj.Hrsangria,
                    dtsuprimento = obj.Dtsuprimento,
                    hrsuprimento = obj.Hrsuprimento,
                    cpgrupcodigo = obj.Cpgrup_Codigo,
                    cpsgrupcodigo = obj.Cpsgrup_Codigo
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

        public IEnumerable<CaixaLanc> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CaixaLanc> GetAll(int empresa)
        {
            string query = $@"    select 
                                      Emp_Codigo,
                                      Lanc_Codigo,
                                      Parcela,
                                      Conta_Codigo,
                                      Tipo,
                                      Condic_Codigo,
                                      Hora,
                                      Data,
                                      Documento,
                                      Historico,
                                      Usuario,
                                      Nro_Compra,
                                      Nro_Venda,
                                      Contrec_Codigo,
                                      Contpag_Codigo,
                                      Valor,
                                      Juros_Real,
                                      Multa,
                                      Desconto,
                                      Valor_total,
                                      Troco,
                                      Nf,
                                      Orc_Ano,
                                      Cont_Codigo,
                                      For_Codigo,
                                      Cli_Codigo,
                                      Dtsangria,
                                      Hrsangria,
                                      Dtsuprimento,
                                      Hrsuprimento,
                                      Cpgrup_Codigo,
                                      Cpsgrup_Codigo
                                from caixa_lanc
                                where emp_codigo=@empresa ";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<CaixaLanc>(query, new
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

        public CaixaLanc GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CaixaLanc GetById(int empresa, int lancamento)
        {
            string query = $@"    select 
                                      Emp_Codigo,
                                      Lanc_Codigo,
                                      Parcela,
                                      Conta_Codigo,
                                      Tipo,
                                      Condic_Codigo,
                                      Hora,
                                      Data,
                                      Documento,
                                      Historico,
                                      Usuario,
                                      Nro_Compra,
                                      Nro_Venda,
                                      Contrec_Codigo,
                                      Contpag_Codigo,
                                      Valor,
                                      Juros_Real,
                                      Multa,
                                      Desconto,
                                      Valor_total,
                                      Troco,
                                      Nf,
                                      Orc_Ano,
                                      Cont_Codigo,
                                      For_Codigo,
                                      Cli_Codigo,
                                      Dtsangria,
                                      Hrsangria,
                                      Dtsuprimento,
                                      Hrsuprimento,
                                      Cpgrup_Codigo,
                                      Cpsgrup_Codigo
                                from caixa_lanc
                                where emp_codigo=@empresa and lanc_codigo=@lancamento";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<CaixaLanc>(query, new
                {
                    empresa = empresa,
                    lancamento=lancamento
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
        public void Remove(int empresa,int lancamento)
        {
            string query = $@"delete from caixa_lanc 
                               where 
                                 Emp_Codigo=@empresa and
                                 Lanc_Codigo=@lancamento ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = empresa,
                    lancamento = lancamento
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
        public void Update(CaixaLanc obj)
        {
            string query = $@"update caixa_lanc set
                                      Conta_Codigo=@contacodigo,
                                      Tipo=@tipo,
                                      Condic_Codigo=@condiccodigo,
                                      Documento=@documento,
                                      Historico=@historico,
                                      Nro_Compra=@nrocompra,
                                      Nro_Venda=@nrovenda,
                                      Contrec_Codigo=@recebimentocodigo,
                                      Contpag_Codigo=@pagamentocodigo,
                                      Valor=@valor,
                                      Juros_Real=@Jurosreal,
                                      Multa=@multa,
                                      Desconto=@desconto,
                                      Valor_total=@valortotal,
                                      Troco=@troco,
                                      Nf=@Nf,
                                      Orc_Ano=@ano,
                                      Cont_Codigo=@contcodigo,
                                      For_Codigo=@fornecedor,
                                      Cli_Codigo=@cliente,
                                      Dtsangria=@dtsangria,
                                      Hrsangria=@hrsangria,
                                      Dtsuprimento=@dtsuprimento,
                                      Hrsuprimento=@hrsuprimento,
                                      Cpgrup_Codigo=@cpgrupcodigo,
                                      Cpsgrup_Codigo=@cpsgrupcodigo
                                    where 
                                      Emp_Codigo=@empresa and
                                      Lanc_Codigo=@lancamento ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    contacodigo = obj.Conta_Codigo,
                    tipo = obj.Tipo,
                    condiccodigo = obj.Condic_Codigo,
                    documento = obj.Documento,
                    historico = obj.Historico,
                    nrocompra = obj.Nro_Compra,
                    nrovenda = obj.Nro_Venda,
                    recebimentocodigo = obj.Contrec_Codigo,
                    pagamentocodigo = obj.Contpag_Codigo,
                    valor = obj.Valor,
                    Jurosreal = obj.Juros_Real,
                    multa = obj.Multa,
                    desconto = obj.Desconto,
                    valortotal = obj.Valor_total,
                    troco = obj.Troco,
                    Nf = obj.Nf,
                    ano = obj.Orc_Ano,
                    contcodigo = obj.Cont_Codigo,
                    fornecedor = obj.For_Codigo,
                    cliente = obj.Cli_Codigo,
                    dtsangria = obj.Dtsangria,
                    hrsangria = obj.Hrsangria,
                    dtsuprimento = obj.Dtsuprimento,
                    hrsuprimento = obj.Hrsuprimento,
                    cpgrupcodigo = obj.Cpgrup_Codigo,
                    cpsgrupcodigo = obj.Cpsgrup_Codigo,
                    empresa = obj.Emp_Codigo,
                    lancamento = obj.Lanc_Codigo
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
