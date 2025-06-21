
using Dapper;
using Model;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using EgourmetAPI.Model;

namespace egourmetAPI
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }
        public EmpresaRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
            
        }

        public void Add(Empresa obj)
        {

            throw new NotImplementedException();
        }

        
        public IEnumerable<Empresa> GetAll()
        {
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    var sql = $@" select EMP_CODIGO, EMP_NOME_FANTASIA, EMP_RAZAO_SOCIAL, EMP_CGC, EMP_INSCRICAO_ESTADUAL, EMP_ENDERECO, " +
                              "          EMP_BAIRRO, EMP_CIDADE, EMP_UF, EMP_CEP, EMP_TELEFONE, EMP_EMAIL, EMP_NUMERO, EMP_COMPLEMENTO, " +
                              "          EMP_WWW, EMP_LOGOTIPO, EMP_INSCRICAO_MUNICIPAL, CFOP_CODIGO, CNAEFISCAL , REGIME     ," +
                              "          INSCRICAO_SUFRAMA from empresa ";

                    return connection.Query<Empresa>(sql).ToList();

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
        
        public Empresa GetById(int id)
        {
            string query = $@" select EMP_CODIGO, EMP_NOME_FANTASIA, EMP_RAZAO_SOCIAL, EMP_CGC, EMP_INSCRICAO_ESTADUAL, EMP_ENDERECO, " +
                          "          EMP_BAIRRO, EMP_CIDADE, EMP_UF, EMP_CEP, EMP_TELEFONE, EMP_EMAIL, EMP_NUMERO, EMP_COMPLEMENTO, " +
                          "          EMP_WWW, EMP_LOGOTIPO, EMP_INSCRICAO_MUNICIPAL, CFOP_CODIGO, CNAEFISCAL , REGIME     ," +
                          "          INSCRICAO_SUFRAMA from empresa ";
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    connection.Open();
                    return connection.Query<Empresa>(query).Where(x => x.Emp_Codigo == id).FirstOrDefault();
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

        public void Remove(int id)
        {
            string query = $@"delete from empresa where emp_codigo=@codigo";
            using (var connection = new FbConnection(conexao))
            {
                try
                {
                    connection.Open();
                    connection.Query(query, new { codigo = id });

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

        public void Update(Empresa empresa)
        {
            using var connection = new FbConnection(conexao);
            try {
                string strInsert = $@"update empresa set emp_nome_fantasia=@emp_nome_fantasia, "+
                    " EMP_RAZAO_SOCIAL=@EMP_RAZAO_SOCIAL, EMP_CGC =@EMP_CGC , EMP_INSCRICAO_ESTADUAL=@EMP_INSCRICAO_ESTADUAL, EMP_ENDERECO=@EMP_ENDERECO, " +
                          "          EMP_BAIRRO=@EMP_BAIRRO, EMP_CIDADE=@EMP_CIDADE, EMP_UF=@EMP_UF, EMP_CEP=@EMP_CEP, "+
                          "          EMP_TELEFONE=@EMP_TELEFONE, EMP_EMAIL=@EMP_EMAIL, EMP_NUMERO=@EMP_NUMERO, EMP_COMPLEMENTO=@EMP_COMPLEMENTO, " +
                          "          EMP_WWW=@EMP_WWW, EMP_LOGOTIPO=@EMP_LOGOTIPO, EMP_INSCRICAO_MUNICIPAL=@EMP_INSCRICAO_MUNICIPAL, "+
                          "          CFOP_CODIGO=@CFOP_CODIGO, CNAEFISCAL=@CNAEFISCAL , REGIME=@REGIME ," +
                          "          INSCRICAO_SUFRAMA=@INSCRICAO_SUFRAMA " +
                    " where emp_codigo=@emp_codigo";
                connection.Execute(strInsert, new
                {
                    emp_codigo = empresa.Emp_Codigo,
                    emp_nome_fantasia = empresa.Emp_Nome_Fantasia,
                    emp_razao_social = empresa.Emp_Razao_Social,
                    emp_cgc = empresa.Emp_Cgc,
                    emp_inscricao_estadual = empresa.Emp_inscricao_Estadual,
                    emp_endereco = empresa.Emp_Endereco,
                    emp_bairro = empresa.Emp_Bairro,
                    emp_cidade = empresa.Emp_Cidade,
                    emp_uf = empresa.Emp_Uf,
                    emp_cep = empresa.Emp_Cep,
                    emp_telefone = empresa.Emp_Telefone,
                    emp_email = empresa.Emp_Email,
                    emp_numero = empresa.Emp_numero,
                    emp_www = empresa.Emp_Www,
                    emp_complemento = empresa.Emp_Complemento,
                    emp_logotipo = empresa.Emp_Logotipo,
                    emp_inscricao_municipal = empresa.Emp_Inscricao_Municipal,
                    cfop_codigo = empresa.Cfop_Codigo,
                    cnaefiscal = empresa.Cnaefiscal,
                    regime = empresa.Regime,
                    inscricao_suframa = empresa.Inscricao_Suframa
                }); ;
            } catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            
        }

        public IEnumerable<Empresa> GetAllEmpresas()
        {
            var connection = new FbConnection(conexao);
            try {
                var sql = $@" select EMP_CODIGO, EMP_NOME_FANTASIA, EMP_RAZAO_SOCIAL, EMP_CGC, EMP_INSCRICAO_ESTADUAL, EMP_ENDERECO, " +
                          "          EMP_BAIRRO, EMP_CIDADE, EMP_UF, EMP_CEP, EMP_TELEFONE, EMP_EMAIL, EMP_NUMERO, EMP_COMPLEMENTO, "+
                          "          EMP_WWW, EMP_LOGOTIPO, EMP_INSCRICAO_MUNICIPAL, CFOP_CODIGO, CNAEFISCAL , REGIME     ,"+
                          "          INSCRICAO_SUFRAMA from empresa ";
                
                return connection.Query<Empresa>(sql).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public ResponseMessage Adicionar(Empresa empresa)
        {
            Response<Empresa> resposta = new Response<Empresa>();
            using (var connection = new FbConnection(conexao))
            {
                string queInsert = $@" insert into empresa(EMP_CODIGO, EMP_NOME_FANTASIA, EMP_RAZAO_SOCIAL, EMP_CGC, EMP_INSCRICAO_ESTADUAL, EMP_ENDERECO, " +
                              "          EMP_BAIRRO, EMP_CIDADE, EMP_UF, EMP_CEP, EMP_TELEFONE, EMP_EMAIL, EMP_NUMERO, EMP_COMPLEMENTO, " +
                              "          EMP_WWW, EMP_LOGOTIPO, EMP_INSCRICAO_MUNICIPAL, CFOP_CODIGO, CNAEFISCAL , REGIME     ," +
                              "          INSCRICAO_SUFRAMA) " +
                              "  values(@EMP_CODIGO, @EMP_NOME_FANTASIA, @EMP_RAZAO_SOCIAL, @EMP_CGC, @EMP_INSCRICAO_ESTADUAL, " +
                              "         @EMP_ENDERECO, @EMP_BAIRRO, @EMP_CIDADE, @EMP_UF, @EMP_CEP, @EMP_TELEFONE, @EMP_EMAIL, " +
                              "         @EMP_NUMERO, @EMP_COMPLEMENTO, @EMP_WWW, @EMP_LOGOTIPO, @EMP_INSCRICAO_MUNICIPAL, " +
                              "         @CFOP_CODIGO, @CNAEFISCAL, @REGIME, @INSCRICAO_SUFRAMA) ";

                try
                {
                    string queSequencial = $@"SELECT GEN_ID(NEW_EMPRESA, 1) as Gen_id from RDB$DATABASE";
                    IdInternal meuId = connection.Query<IdInternal>(queSequencial).FirstOrDefault();
                    empresa.Emp_Codigo = meuId.Gen_Id;
                    resposta.Data = empresa;
                    resposta.Status = 400;
                    connection.Execute(queInsert, new
                    {
                        emp_codigo = empresa.Emp_Codigo,
                        emp_nome_fantasia = empresa.Emp_Nome_Fantasia,
                        emp_razao_social = empresa.Emp_Razao_Social,
                        emp_cgc = empresa.Emp_Cgc,
                        emp_inscricao_estadual = empresa.Emp_inscricao_Estadual,
                        emp_endereco = empresa.Emp_Endereco,
                        emp_bairro = empresa.Emp_Bairro,
                        emp_cidade = empresa.Emp_Cidade,
                        emp_uf = empresa.Emp_Uf,
                        emp_cep = empresa.Emp_Cep,
                        emp_telefone = empresa.Emp_Telefone,
                        emp_email = empresa.Emp_Email,
                        emp_numero = empresa.Emp_numero,
                        emp_www = empresa.Emp_Www,
                        emp_complemento = empresa.Emp_Complemento,
                        emp_logotipo = empresa.Emp_Logotipo,
                        emp_inscricao_municipal = empresa.Emp_Inscricao_Municipal,
                        cfop_codigo = empresa.Cfop_Codigo,
                        cnaefiscal = empresa.Cnaefiscal,
                        regime = empresa.Regime,
                        inscricao_suframa = empresa.Inscricao_Suframa
                    });
                }
                catch (Exception e)
                {
                    resposta.Message = e.Message;
                    resposta.Status = 400;
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
                return resposta;
            }
        }
    }
}