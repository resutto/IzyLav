using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace EgourmetAPI.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {

        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public FornecedorRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(Fornecedor obj)
        {
            string query = $@"insert into fornecedor(
                       FOR_CODIGO,
                       FOR_NOME_FANTASIA,
                       FOR_DATA_CADASTRO,
                       FOR_RAZAO_SOCIAL,
                       FOR_ENDERECO,
                       FOR_TELEFONE,
                       FOR_EMAIL,
                       FOR_HOME_PAGE,
                       FOR_BAIRRO,
                       FOR_CIDADE,
                       FOR_UF,
                       FOR_CEP,
                       FOR_CPFCNPJ,
                       FOR_INSCRICAO_ESTADUAL,
                       FOR_OBSERVACAO,
                       FOR_ANOTACAO,
                       FOR_COMPL,
                       FOR_NUMERO,
                       FOR_INSCRICAO_MUNICIPAL,
                       ATIVO) 
                       values(@codigo,@nome,null,@razao,@endereco,@telefone,
                              @email,@www,@bairro,@cidade,@uf,@cep,@cnpj,@ie,
                              @observacao,@anotacao,@compl,@numero,@im,'S')";
            
            var connection = new FbConnection(conexao);
            try
            {
                IdLanc que1 = Datpai.GerarIdLanc(-1, connection, "select max(for_codigo)+1 as IdLanc from fornecedor");
                connection.Execute(query,
                    new
                    {
                        codigo = que1.idLanc,
                        nome = obj.For_Nome_Fantasia,
                        razao = obj.For_Razao_Social,
                        endereco = obj.For_Endereco,
                        telefone = obj.For_Telefone,
                        email = obj.For_Email,
                        www = obj.For_Home_Page,
                        bairro = obj.For_Bairro,
                        cidade = obj.For_Cidade,
                        uf = obj.For_Uf,
                        cep = obj.For_Cep,
                        cnpj = obj.For_CpfCnpj,
                        ie = obj.For_Inscricao_Estadual,
                        observacao = obj.For_Observacao,
                        anotacao = obj.For_Anotacao,
                        compl = obj.For_Compl,
                        numero = obj.For_Numero,
                        im = obj.For_Inscricao_Municipal
                    });
            }
            catch (Exception e)
            {

                throw e;
            }
            finally {
                connection.Close();
            }
            
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            string query = $@"select    
                               FOR_CODIGO,
                               FOR_NOME_FANTASIA,
                               FOR_DATA_CADASTRO,
                               FOR_RAZAO_SOCIAL,
                               FOR_ENDERECO,
                               FOR_TELEFONE,
                               FOR_EMAIL,
                               FOR_HOME_PAGE,
                               FOR_BAIRRO,
                               FOR_CIDADE,
                               FOR_UF,
                               FOR_CEP,
                               FOR_CPFCNPJ,
                               FOR_INSCRICAO_ESTADUAL,
                               FOR_OBSERVACAO,
                               FOR_ANOTACAO,
                               FOR_COMPL,
                               FOR_NUMERO,
                               FOR_INSCRICAO_MUNICIPAL,
                               ATIVO from fornecedor ";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Fornecedor>(query).ToList();
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

        public Fornecedor GetById(int id)
        {
            string query = $@"select    
                               FOR_CODIGO,
                               FOR_NOME_FANTASIA,
                               FOR_DATA_CADASTRO,
                               FOR_RAZAO_SOCIAL,
                               FOR_ENDERECO,
                               FOR_TELEFONE,
                               FOR_EMAIL,
                               FOR_HOME_PAGE,
                               FOR_BAIRRO,
                               FOR_CIDADE,
                               FOR_UF,
                               FOR_CEP,
                               FOR_CPFCNPJ,
                               FOR_INSCRICAO_ESTADUAL,
                               FOR_OBSERVACAO,
                               FOR_ANOTACAO,
                               FOR_COMPL,
                               FOR_NUMERO,
                               FOR_INSCRICAO_MUNICIPAL,
                               ATIVO from fornecedor where for_codigo=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Fornecedor>(query, new {codigo=id}).FirstOrDefault();
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
            string query = $@"delete from fornecedor 
                       where
                        FOR_CODIGO=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query,
                    new
                    {
                        codigo = id});
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

        public void Update(Fornecedor obj)
        {
            string query = $@"update fornecedor set
                       FOR_NOME_FANTASIA=@nome,
                       FOR_RAZAO_SOCIAL=@razao,
                       FOR_ENDERECO=@endereco,
                       FOR_TELEFONE=@telefone,
                       FOR_EMAIL=@email,
                       FOR_HOME_PAGE=@www,
                       FOR_BAIRRO=@bairro,
                       FOR_CIDADE=@cidade,
                       FOR_UF=@uf,
                       FOR_CEP=@cep,
                       FOR_CPFCNPJ=@cnpj,
                       FOR_INSCRICAO_ESTADUAL=@ie,
                       FOR_OBSERVACAO=@observacao,
                       FOR_ANOTACAO=@anotacao,
                       FOR_COMPL=@compl,
                       FOR_NUMERO=@numero,
                       FOR_INSCRICAO_MUNICIPAL=@im,
                       ATIVO=@ativo
                       where
                        FOR_CODIGO=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query,
                    new
                    {
                        codigo = obj.For_Codigo,
                        nome = obj.For_Nome_Fantasia,
                        razao = obj.For_Razao_Social,
                        endereco = obj.For_Endereco,
                        telefone = obj.For_Telefone,
                        email = obj.For_Email,
                        www = obj.For_Home_Page,
                        bairro = obj.For_Bairro,
                        cidade = obj.For_Cidade,
                        uf = obj.For_Uf,
                        cep = obj.For_Cep,
                        cnpj = obj.For_CpfCnpj,
                        ie = obj.For_Inscricao_Estadual,
                        observacao = obj.For_Observacao,
                        anotacao = obj.For_Anotacao,
                        compl = obj.For_Compl,
                        numero = obj.For_Numero,
                        im = obj.For_Inscricao_Municipal
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
