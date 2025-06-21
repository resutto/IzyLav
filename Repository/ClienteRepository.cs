using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;
using Microsoft.AspNetCore.Routing.Tree;
using System.Globalization;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace EgourmetAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {


        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public ClienteRepository (IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }


        public void Add(Cliente obj)
        {
                        string query = $@"insert into cliente(
                               EMP_CODIGO, 
                               CLI_CODIGO, 
                               CLI_NOME, 
                               CLI_RAZAO_SOCIAL, 
                               CLI_SEXO,
                               CLI_DATA_CADASTRO,
                               CLI_CPFCNPJ,
                               CLI_INSCRICAO_ESTADUAL,
                               CLI_INSCRICAO_MUNICIPAL,
                               CLI_INSCRICAO_SUFRAMA,
                               CLI_ENDERECO,
                               CLI_NUMERO,
                               CLI_BAIRRO,
                               CLI_CIDADE,
                               CLI_CEP,
                               CLI_UF,
                               CLI_COMPL
                               CLI_REFERENCIA,
                               CLI_TELEFONE,
                               CLI_TELEFONE2,
                               CLI_TELEFONE3,
                               CLI_OBSERVACOES,
                               CLI_ANOTACOES,
                               CLI_TIPOPESSOA,
                               CLI_EMAIL,
                               CLI_HOME_PAGE,
                               CLI_RESPONSAVEL,
                               FANTASIASEM,
                               RAZSOCSEM,
                               CLI_EMAIL_XML,
                               INDICADORIEDESTINATARIO,
                               DESABILITADO
                               )
                            values(@empresa,@codigo,@nome,@razao,@sexo,(select date 'NOW' from rdb$database),@CpfCnpj,
                                    @ie,@im,@isuf,@endereco,@numero,@bairro,@cidade,@cep,@uf,@compl,@referencia,
                                    @telefone,@telefone2,@telefone3,@obs,@anot,@tipopessoa,@email,@www,
                                    @responsavel,@fantasiasem,@razsocsem,@emailXml,@indicador,@desabilitado)";
            
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                IdLanc que1 = Datpai.GerarIdLanc(obj.Emp_Codigo, connection, 
                                                 $@"select max(cli_codigo)+1 as idlanc from cliente where emp_Codigo=@empresa");

                connection.Execute(query, new {
                    empresa= obj.Emp_Codigo,
                    codigo = que1.idLanc ,
                    nome = obj.Cli_Nome,
                    razao = obj.Cli_Razao_Social,
                    sexo = obj.Cli_Sexo,
                    CpfCnpj = obj.Cli_CpfCnpj,
                    ie = obj.Cli_Inscricao_Estadual,
                    im = obj.Cli_Inscricao_Municipal,
                    isuf = obj.Cli_Inscricao_Suframa,
                    endereco = obj.Cli_Endereco,
                    numero = obj.Cli_Numero,
                    bairro = obj.Cli_Bairro,
                    cidade = obj.Cli_Cidade,
                    cep = obj.Cli_Cep,
                    uf = obj.Cli_Uf,
                    compl = obj.Cli_Compl,
                    referencia = obj.Cli_Referencia,
                    telefone = obj.Cli_Telefone,
                    telefone2 = obj.Cli_Telefone2,
                    telefone3 = obj.Cli_Telefone3,
                    obs = obj.Cli_Observacoes,
                    anot = obj.Cli_Anotacoes,
                    tipopessoa = obj.Cli_Tipopessoa,
                    email = obj.Cli_Email,
                    www = obj.Cli_Home_Page,
                    responsavel = obj.Cli_responsavel,
                    fantasiasem = Datpai.RemoveAccents(obj.Fantasiasem),
                    razsocsem = Datpai.RemoveAccents(obj.Razsocsem),
                    emailXml = obj.Cli_Email_Xml,
                    indicador = obj.IndicadorIEDestinatario,
                    desabilitado = obj.Desabilitado
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

        public IEnumerable<Cliente> GetAllClientesPorEmpresa(int empCodigo)
        {
            string query = $@"select                                
                               EMP_CODIGO, 
                               CLI_CODIGO, 
                               CLI_NOME, 
                               CLI_RAZAO_SOCIAL, 
                               CLI_SEXO,
                               CLI_DATA_NASCIMENTO,
                               CLI_DATA_CADASTRO,
                               CLI_CPFCNPJ,
                               CLI_INSCRICAO_ESTADUAL,
                               CLI_INSCRICAO_MUNICIPAL,
                               CLI_INSCRICAO_SUFRAMA,
                               CLI_ENDERECO,
                               CLI_NUMERO,
                               CLI_BAIRRO,
                               CLI_CIDADE,
                               CLI_CEP,
                               CLI_UF,
                               CLI_COMPL
                               CLI_REFERENCIA,
                               CLI_TELEFONE,
                               CLI_TELEFONE2,
                               CLI_TELEFONE3,
                               CLI_OBSERVACOES,
                               CLI_ANOTACOES,
                               CLI_TIPOPESSOA,
                               CLI_EMAIL,
                               CLI_HOME_PAGE,
                               CLI_RESPONSAVEL,
                               FANTASIASEM,
                               RAZSOCSEM,
                               CLI_EMAIL_XML,
                               INDICADORIEDESTINATARIO,
                               DESABILITADO from cliente where emp_codigo=@empresa";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Cliente>(query, new { empresa = empCodigo }).ToList();
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
        public IEnumerable<Cliente> GetAll()
        {
         throw new NotImplementedException();
        }

        public Cliente GetByIdeEmpresa(int id , int empCodigo)
        {
            string query = $@"select                                
                               EMP_CODIGO, 
                               CLI_CODIGO, 
                               CLI_NOME, 
                               CLI_RAZAO_SOCIAL, 
                               CLI_SEXO,
                               CLI_DATA_NASCIMENTO,
                               CLI_DATA_CADASTRO,
                               CLI_CPFCNPJ,
                               CLI_INSCRICAO_ESTADUAL,
                               CLI_INSCRICAO_MUNICIPAL,
                               CLI_INSCRICAO_SUFRAMA,
                               CLI_ENDERECO,
                               CLI_NUMERO,
                               CLI_BAIRRO,
                               CLI_CIDADE,
                               CLI_CEP,
                               CLI_UF,
                               CLI_COMPL
                               CLI_REFERENCIA,
                               CLI_TELEFONE,
                               CLI_TELEFONE2,
                               CLI_TELEFONE3,
                               CLI_OBSERVACOES,
                               CLI_ANOTACOES,
                               CLI_TIPOPESSOA,
                               CLI_EMAIL,
                               CLI_HOME_PAGE,
                               CLI_RESPONSAVEL,
                               FANTASIASEM,
                               RAZSOCSEM,
                               CLI_EMAIL_XML,
                               INDICADORIEDESTINATARIO,
                               DESABILITADO from cliente where emp_codigo=@empresa and cli_codigo=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Cliente>(query, new { codigo = id, empresa = empCodigo }).FirstOrDefault();
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
        
        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePorEmpresa(int id, int empCodigo)
        {
            string query = $@"delete from cliente where emp_codigo=@empresa and cli_codigo=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { codigo = id, empresa = empCodigo });
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
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente obj)
        {
            string query = $@" update cliente set
                               CLI_NOME=@nome, 
                               CLI_RAZAO_SOCIAL=@razao, 
                               CLI_SEXO=@sexo,
                               CLI_CPFCNPJ=@CpfCnpj,
                               CLI_INSCRICAO_ESTADUAL=@ie,
                               CLI_INSCRICAO_MUNICIPAL=@im,
                               CLI_INSCRICAO_SUFRAMA=@isuf,
                               CLI_ENDERECO=@endereco,
                               CLI_NUMERO=@numero,
                               CLI_BAIRRO=@bairro,
                               CLI_CIDADE=@cidade,
                               CLI_CEP=@cep,
                               CLI_UF=@uf,
                               CLI_COMPL=@compl
                               CLI_REFERENCIA=@referencia,
                               CLI_TELEFONE=@telefone,
                               CLI_TELEFONE2=@telefone2,
                               CLI_TELEFONE3=@telefone3,
                               CLI_OBSERVACOES=@obs,
                               CLI_ANOTACOES=@anot,
                               CLI_TIPOPESSOA=@tipopessoa,
                               CLI_EMAIL=@email,
                               CLI_HOME_PAGE=@www,
                               CLI_RESPONSAVEL=@responsavel,
                               FANTASIASEM=@fantasiasem,
                               RAZSOCSEM=@razsocsem,
                               CLI_EMAIL_XML=@emailXml,
                               INDICADORIEDESTINATARIO=@indicador,
                               DESABILITADO=@desabilitado
                            where
                               EMP_CODIGO=@empresa 
                               and CLI_CODIGO=@codigo ";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new
                {
                    nome = obj.Cli_Nome,
                    razao = obj.Cli_Razao_Social,
                    sexo = obj.Cli_Sexo,
                    CpfCnpj = obj.Cli_CpfCnpj,
                    ie = obj.Cli_Inscricao_Estadual,
                    im = obj.Cli_Inscricao_Municipal,
                    isuf = obj.Cli_Inscricao_Suframa,
                    endereco = obj.Cli_Endereco,
                    numero = obj.Cli_Numero,
                    bairro = obj.Cli_Bairro,
                    cidade = obj.Cli_Cidade,
                    cep = obj.Cli_Cep,
                    uf = obj.Cli_Uf,
                    compl = obj.Cli_Compl,
                    referencia = obj.Cli_Referencia,
                    telefone = obj.Cli_Telefone,
                    telefone2 = obj.Cli_Telefone2,
                    telefone3 = obj.Cli_Telefone3,
                    obs = obj.Cli_Observacoes,
                    anot = obj.Cli_Anotacoes,
                    tipopessoa = obj.Cli_Tipopessoa,
                    email = obj.Cli_Email,
                    www = obj.Cli_Home_Page,
                    responsavel = obj.Cli_responsavel,
                    fantasiasem = Datpai.RemoveAccents(obj.Fantasiasem),
                    razsocsem = Datpai.RemoveAccents(obj.Razsocsem),
                    emailXml = obj.Cli_Email_Xml,
                    indicador = obj.IndicadorIEDestinatario,
                    desabilitado = obj.Desabilitado,
                    empresa = obj.Emp_Codigo,
                    codigo = obj.Cli_Codigo
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
}
