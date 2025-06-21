using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class ContasPagarRepository : IContasPagarRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public ContasPagarRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public void Add(ContasPagar obj)
        {
            string query = $@"insert into contas_pagar(
                                                      Contpag_Codigo,
                                                      Emp_Codigo,
                                                      Contpag_Parcela,
                                                      For_Codigo,
                                                      Cpsgrup_Codigo,
                                                      Cpgrup_Codigo,
                                                      Contpag_Conta,
                                                      Condic_Codigo,
                                                      Contpag_Documento,
                                                      Contpag_Descricao,
                                                      Contpag_Data_Conta,
                                                      Contpag_Data_Vencimento,
                                                      Contpag_Valor,
                                                      Contpag_Desconto,
                                                      Contpag_Juros,
                                                      Contpag_Multa,
                                                      Contpag_Total,
                                                      Contpag_Observacoes,
                                                      Contpag_Cancelado,
                                                      Contpag_Numparcelas,
                                                      Ped_Codigo,
                                                      Contpag_Quitacao,
                                                      Contpag_Vlrpago,
                                                      Contpag_Nf,
                                                      Contpag_Troco,
                                                      Snrocheque,
                                                      Despfixa,
                                                      despesa_fixa,
                                                      cheque,
                                                      PodePagar_Usuario,
                                                      Tem_Boleto,
                                                      Tem_Nota,
                                                      Preped_Codigo,
                                                      Cartorio,
                                                      Valor,
                                                      Entrada,
                                                      Vencto,
                                                      Protocolo)
                                                    values(
                                                      @contpagcodigo,
                                                      @empresa,
                                                      @parcela,
                                                      @fornecedor,
                                                      @cpsgrupcodigo,
                                                      @cpgrupCodigo,
                                                      @conta,
                                                      @condicaopgto,
                                                      @documento,
                                                      @descricao,
                                                      @dataconta,
                                                      @datavencimento,
                                                      @valor,
                                                      @desconto,
                                                      @juros,
                                                      @multa,
                                                      @total,
                                                      @observacoes,
                                                      @cancelado,
                                                      @parcelas,
                                                      @pedcodigo,
                                                      @quitacao,
                                                      @vlrpago,
                                                      @nf,
                                                      @troco,
                                                      @snrocheque,
                                                      @despfixa,
                                                      @despesafixa,
                                                      @cheque,
                                                      @podepagarusuario,
                                                      @temboleto,
                                                      @temnota,
                                                      @prepedcodigo,
                                                      @cartorio,
                                                      @valorcartorio,
                                                      @entrada,
                                                      @vencto,
                                                      @protocolo)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    contpagcodigo=obj.Contpag_Codigo,
                    empresa=obj.Emp_Codigo,
                    parcela=obj.Contpag_Parcela,
                    fornecedor = obj.For_Codigo,
                    cpsgrupcodigo = obj.Cpsgrup_Codigo,
                    cpgrupCodigo = obj.Cpgrup_Codigo,
                    conta = obj.Contpag_Conta,
                    condicaopgto = obj.Condic_Codigo,
                    documento = obj.Contpag_Documento,
                    descricao = obj.Contpag_Descricao,
                    dataconta = obj.Contpag_Data_Conta,
                    datavencimento = obj.Contpag_Data_Vencimento,
                    valor = obj.Contpag_Valor,
                    desconto = obj.Contpag_Desconto,
                    juros = obj.Contpag_Juros,
                    multa = obj.Contpag_Multa,
                    total = obj.Contpag_Total,
                    observacoes = obj.Contpag_Observacoes,
                    cancelado = obj.Contpag_Cancelado,
                    parcelas = obj.Contpag_Numparcelas,
                    pedcodigo = obj.Ped_Codigo,
                    quitacao = obj.Contpag_Quitacao,
                    vlrpago = obj.Contpag_Vlrpago,
                    nf = obj.Contpag_Nf,
                    troco = obj.Contpag_Troco,
                    snrocheque = obj.Snrocheque,
                    despfixa = obj.Despfixa,
                    despesafixa = obj.despesa_fixa,
                    cheque = obj.cheque,
                    podepagarusuario = obj.PodePagar_Usuario,
                    temboleto = obj.Tem_Boleto,
                    temnota = obj.Tem_Nota,
                    prepedcodigo = obj.Preped_Codigo,
                    cartorio = obj.Cartorio,
                    valorcartorio=obj.Valor,
                    entrada=obj.Entrada,
                    vencto = obj.Vencto,
                    protocolo = obj.Protocolo
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

        public IEnumerable<ContasPagar> GetAll(int empresa)
        {
            string query = $@" select                 Contpag_Codigo,
                                                      Emp_Codigo,
                                                      Contpag_Parcela,
                                                      For_Codigo,
                                                      Cpsgrup_Codigo,
                                                      Cpgrup_Codigo,
                                                      Contpag_Conta,
                                                      Condic_Codigo,
                                                      Contpag_Documento,
                                                      Contpag_Descricao,
                                                      Contpag_Data_Conta,
                                                      Contpag_Data_Vencimento,
                                                      Contpag_Valor,
                                                      Contpag_Desconto,
                                                      Contpag_Juros,
                                                      Contpag_Multa,
                                                      Contpag_Total,
                                                      Contpag_Observacoes,
                                                      Contpag_Cancelado,
                                                      Contpag_Numparcelas,
                                                      Ped_Codigo,
                                                      Contpag_Quitacao,
                                                      Contpag_Vlrpago,
                                                      Contpag_Nf,
                                                      Contpag_Troco,
                                                      Snrocheque,
                                                      Despfixa,
                                                      despesa_fixa,
                                                      cheque,
                                                      PodePagar_Usuario,
                                                      Tem_Boleto,
                                                      Tem_Nota,
                                                      Preped_Codigo,
                                                      Cartorio,
                                                      Valor,
                                                      Entrada,
                                                      Vencto,
                                                      Protocolo
                                        from contas_pagar
                                        where emp_codigo=@empresa";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<ContasPagar>(query, new
                {
                    empresa = empresa
                }).ToList();
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

        public ContasPagar GetById(int empresa, int contpagcodigo)
        {
            string query = $@" select                 Contpag_Codigo,
                                                      Emp_Codigo,
                                                      Contpag_Parcela,
                                                      For_Codigo,
                                                      Cpsgrup_Codigo,
                                                      Cpgrup_Codigo,
                                                      Contpag_Conta,
                                                      Condic_Codigo,
                                                      Contpag_Documento,
                                                      Contpag_Descricao,
                                                      Contpag_Data_Conta,
                                                      Contpag_Data_Vencimento,
                                                      Contpag_Valor,
                                                      Contpag_Desconto,
                                                      Contpag_Juros,
                                                      Contpag_Multa,
                                                      Contpag_Total,
                                                      Contpag_Observacoes,
                                                      Contpag_Cancelado,
                                                      Contpag_Numparcelas,
                                                      Ped_Codigo,
                                                      Contpag_Quitacao,
                                                      Contpag_Vlrpago,
                                                      Contpag_Nf,
                                                      Contpag_Troco,
                                                      Snrocheque,
                                                      Despfixa,
                                                      despesa_fixa,
                                                      cheque,
                                                      PodePagar_Usuario,
                                                      Tem_Boleto,
                                                      Tem_Nota,
                                                      Preped_Codigo,
                                                      Cartorio,
                                                      Valor,
                                                      Entrada,
                                                      Vencto,
                                                      Protocolo
                                        from contas_pagar
                                        where emp_codigo=@empresa and contpag_codigo=@contpagcodigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<ContasPagar>(query, new
                {
                    empresa = empresa,
                    contpagcodigo=contpagcodigo,
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

        public void Remove(int empresa, int contpagcodigo)
        {
            string query = $@"delete from contas_pagar 
                               where Contpag_Codigo = @contpagcodigo and
                                     Emp_Codigo     = @empresa";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    contpagcodigo = contpagcodigo,
                    empresa = empresa
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

        public void Update(ContasPagar obj)
        {
            string query = $@"update contas_pagar set
                                                      For_Codigo=@fornecedor ,
                                                      Cpsgrup_Codigo=@cpsgrupcodigo,
                                                      Cpgrup_Codigo=@cpgrupCodigo,
                                                      Contpag_Conta=@conta,
                                                      Condic_Codigo=@condicaopgto,
                                                      Contpag_Documento=@documento,
                                                      Contpag_Descricao=@descricao,
                                                      Contpag_Data_Conta=@dataconta,
                                                      Contpag_Data_Vencimento=@datavencimento,
                                                      Contpag_Valor=@valor,
                                                      Contpag_Desconto=@desconto,
                                                      Contpag_Juros=@juros,
                                                      Contpag_Multa=@multa,
                                                      Contpag_Total=@total,
                                                      Contpag_Observacoes=@observacoes,
                                                      Contpag_Cancelado=@cancelado,
                                                      Contpag_Numparcelas=@parcelas,
                                                      Ped_Codigo=@pedcodigo,
                                                      Contpag_Quitacao=@quitacao,
                                                      Contpag_Vlrpago=@vlrpago,
                                                      Contpag_Nf=@nf,
                                                      Contpag_Troco=@troco,
                                                      Snrocheque=@snrocheque,
                                                      Despfixa=@despfixa,
                                                      despesa_fixa=@despesafixa,
                                                      cheque=@cheque,
                                                      PodePagar_Usuario=@podepagarusuario,
                                                      Tem_Boleto=@temboleto,
                                                      Tem_Nota=@temnota,
                                                      Preped_Codigo=@prepedcodigo,
                                                      Cartorio=@cartorio,
                                                      Valor=@valorcartorio,
                                                      Entrada=@entrada,
                                                      Vencto=@vencto,
                                                      Protocolo=@protocolo                                                       
                                                where 
                                                      Contpag_Codigo=@contpagcodigo and
                                                      Emp_Codigo=@empresa";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    fornecedor = obj.For_Codigo,
                    cpsgrupcodigo = obj.Cpsgrup_Codigo,
                    cpgrupCodigo = obj.Cpgrup_Codigo,
                    conta = obj.Contpag_Conta,
                    condicaopgto = obj.Condic_Codigo,
                    documento = obj.Contpag_Documento,
                    descricao = obj.Contpag_Descricao,
                    dataconta = obj.Contpag_Data_Conta,
                    datavencimento = obj.Contpag_Data_Vencimento,
                    valor = obj.Contpag_Valor,
                    desconto = obj.Contpag_Desconto,
                    juros = obj.Contpag_Juros,
                    multa = obj.Contpag_Multa,
                    total = obj.Contpag_Total,
                    observacoes = obj.Contpag_Observacoes,
                    cancelado = obj.Contpag_Cancelado,
                    parcelas = obj.Contpag_Numparcelas,
                    pedcodigo = obj.Ped_Codigo,
                    quitacao = obj.Contpag_Quitacao,
                    vlrpago = obj.Contpag_Vlrpago,
                    nf = obj.Contpag_Nf,
                    troco = obj.Contpag_Troco,
                    snrocheque = obj.Snrocheque,
                    despfixa = obj.Despfixa,
                    despesafixa = obj.despesa_fixa,
                    cheque = obj.cheque,
                    podepagarusuario = obj.PodePagar_Usuario,
                    temboleto = obj.Tem_Boleto,
                    temnota = obj.Tem_Nota,
                    prepedcodigo = obj.Preped_Codigo,
                    cartorio = obj.Cartorio,
                    valorcartorio = obj.Valor,
                    entrada = obj.Entrada,
                    vencto = obj.Vencto,
                    protocolo = obj.Protocolo,
                    contpagcodigo = obj.Contpag_Codigo,
                    empresa = obj.Emp_Codigo
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

        public IEnumerable<ContasPagar> GetAll()
        {
            throw new NotImplementedException();
        }

        public ContasPagar GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
