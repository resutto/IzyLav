using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace EgourmetAPI.Repository
{
    public class TransportadorRepository : ITransportadorRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public TransportadorRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(Transportador obj)
        {
            string query = $@"insert into transportador(
                                  Trans_Codigo,
                                  Trans_Nome_Fantasia,
                                  Trans_Data_Cadastro,
                                  Trans_Razao_Social,
                                  Trans_Telefone,
                                  Trans_Email,
                                  Trans_Home_Page,
                                  Trans_Cep,
                                  Trans_Endereco,
                                  Trans_Bairro,
                                  Trans_Cidade,
                                  Trans_Uf,
                                  Trans_Compl,
                                  Trans_Numero,
                                  Trans_Cpfcnpj,
                                  Trans_Inscricao_Estadual,
                                  Trans_Inscricao_Municipal,
                                  Trans_Isuframa,
                                  Trans_Observacao,
                                  Trans_Anotacao) 
                                values(
                                  @codigo,
                                  @nome,
                                  current_date,
                                  @razao,
                                  @telefone,
                                  @email,
                                  @homepage,
                                  @cep,
                                  @endereco,
                                  @bairro,
                                  @cidade,
                                  @uf,
                                  @compl,
                                  @numero,
                                  @cpfcnpj,
                                  @ie,
                                  @im,
                                  @isuf,
                                  @observacao,
                                  @anotacao)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo=obj.Trans_Codigo,
                    nome = obj.Trans_Nome_Fantasia,
                    razao = obj.Trans_Razao_Social,
                    telefone = obj.Trans_Telefone,
                    email = obj.Trans_Email,
                    homepage = obj.Trans_Home_Page,
                    cep = obj.Trans_Cep,
                    endereco = obj.Trans_Endereco,
                    bairro = obj.Trans_Bairro,
                    cidade = obj.Trans_Cidade,
                    uf = obj.Trans_Uf,
                    compl=obj.Trans_Compl,
                    numero = obj.Trans_Numero,
                    cpfcnpj = obj.Trans_Cpfcnpj,
                    ie = obj.Trans_Inscricao_Estadual,
                    im = obj.Trans_Inscricao_Municipal,
                    isuf = obj.Trans_Isuframa,
                    observacao = obj.Trans_Observacao,
                    anotacao = obj.Trans_Anotacao
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

        public IEnumerable<Transportador> GetAll()
        {
            string query = $@" select
                                  Trans_Codigo,
                                  Trans_Nome_Fantasia,
                                  Trans_Data_Cadastro,
                                  Trans_Razao_Social,
                                  Trans_Telefone,
                                  Trans_Email,
                                  Trans_Home_Page,
                                  Trans_Cep,
                                  Trans_Endereco,
                                  Trans_Bairro,
                                  Trans_Cidade,
                                  Trans_Uf,
                                  Trans_Compl,
                                  Trans_Numero,
                                  Trans_Cpfcnpj,
                                  Trans_Inscricao_Estadual,
                                  Trans_Inscricao_Municipal,
                                  Trans_Isuframa,
                                  Trans_Observacao,
                                  Trans_Anotacao 
                            from  transportador ";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Transportador>(query).ToList();
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

        public Transportador GetById(int id)
        {
            string query = $@" select
                                  Trans_Codigo,
                                  Trans_Nome_Fantasia,
                                  Trans_Data_Cadastro,
                                  Trans_Razao_Social,
                                  Trans_Telefone,
                                  Trans_Email,
                                  Trans_Home_Page,
                                  Trans_Cep,
                                  Trans_Endereco,
                                  Trans_Bairro,
                                  Trans_Cidade,
                                  Trans_Uf,
                                  Trans_Compl,
                                  Trans_Numero,
                                  Trans_Cpfcnpj,
                                  Trans_Inscricao_Estadual,
                                  Trans_Inscricao_Municipal,
                                  Trans_Isuframa,
                                  Trans_Observacao,
                                  Trans_Anotacao 
                            from  transportador where trans_codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Transportador>(query, new {codigo=id}).FirstOrDefault();
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
            string query = $@" delete from transportador 
                            where Trans_Codigo=@codigo ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = id
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

        public void Update(Transportador obj)
        {
            string query = $@"update transportador set
                                  Trans_Nome_Fantasia=@nome,
                                  Trans_Razao_Social=@razao,
                                  Trans_Telefone=@telefone,
                                  Trans_Email=@email,
                                  Trans_Home_Page=@homepage,
                                  Trans_Cep=@cep,
                                  Trans_Endereco=@endereco,
                                  Trans_Bairro=@bairro,
                                  Trans_Cidade=@cidade,
                                  Trans_Uf=@uf,
                                  Trans_Compl=@compl,
                                  Trans_Numero=@numero,
                                  Trans_Cpfcnpj=@cpfcnpj,
                                  Trans_Inscricao_Estadual=@ie,
                                  Trans_Inscricao_Municipal=@im,
                                  Trans_Isuframa=@isuf,
                                  Trans_Observacao=@observacao,
                                  Trans_Anotacao=@anotacao
                            where Trans_Codigo=@codigo ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    nome = obj.Trans_Nome_Fantasia,
                    razao = obj.Trans_Razao_Social,
                    telefone = obj.Trans_Telefone,
                    email = obj.Trans_Email,
                    homepage = obj.Trans_Home_Page,
                    cep = obj.Trans_Cep,
                    endereco = obj.Trans_Endereco,
                    bairro = obj.Trans_Bairro,
                    cidade = obj.Trans_Cidade,
                    uf = obj.Trans_Uf,
                    compl = obj.Trans_Compl,
                    numero = obj.Trans_Numero,
                    cpfcnpj = obj.Trans_Cpfcnpj,
                    ie = obj.Trans_Inscricao_Estadual,
                    im = obj.Trans_Inscricao_Municipal,
                    isuf = obj.Trans_Isuframa,
                    observacao = obj.Trans_Observacao,
                    anotacao = obj.Trans_Anotacao,
                    codigo = obj.Trans_Codigo
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
