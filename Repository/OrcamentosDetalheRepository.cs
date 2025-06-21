using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class OrcamentosDetalheRepository : IOrcamentosDetalheRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public OrcamentosDetalheRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(OrcamentosDetalhe obj)
        {
            string query = $@"insert into orcamentos_Detalhe (  
                                  Emp_Codigo,
                                  Orc_Codigo,
                                  Detorc_Codigo,
                                  Cli_Codigo,
                                  Orc_Ano,
                                  Unid_Codigo,
                                  Pro_Codigo,
                                  Detorc_Qtde,
                                  Detorc_Custotot,
                                  Detorc_Custo,
                                  Detorc_Observacao,
                                  Infadicional,
                                  Fun_Codigo,
                                  Data_Cadastro,
                                  Totaproxtributoitem,
                                  Dep_Codigo,
                                  Cst_Icms,
                                  Perc_Icms,
                                  Cst_Ipi,
                                  Perc_Ipi,
                                  Cst_Pis,
                                  Perc_Pis,
                                  Cst_Cofins,
                                  Perc_Cofins,
                                  Detorc_Desconto,
                                  Pc_Criou,
                                  Qdecasas,
                                  Idmotivodeson,
                                  Vicmsdeson)
                                values(
                                  @empresa,
                                  @orccodigo,
                                  @detorccodigo,
                                  @cliente,
                                  @ano,
                                  @unidade,
                                  @produto,
                                  @qtde,
                                  @custotot,
                                  @custo,
                                  @observacao,
                                  @infadicional,
                                  @funcionario,
                                  current_date,
                                  @Totaproxtributoitem,
                                  @deposito,
                                  @csticms,
                                  @percicms,
                                  @cstipi,
                                  @percipi,
                                  @cstpis,
                                  @percpis,
                                  @cstcofins,
                                  @perccofins,
                                  @detorcdesconto,
                                  @pccriou,
                                  @qdecasas,
                                  @idmotivodeson,
                                  @vicmsdeson
                                )";
            
            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa=obj.Emp_Codigo,
                    orccodigo=obj.Orc_Codigo,
                    detorccodigo=obj.Detorc_Codigo,
                    cliente=obj.Cli_Codigo,
                    ano    =obj.ORC_Ano,
                    unidade=obj.Unid_Codigo,
                    produto=obj.Pro_Codigo,
                    qtde=obj.Detorc_Qtde,
                    custotot=obj.Detorc_Custotot,
                    custo=obj.Detorc_Custo,
                    observacao=obj.Detorc_Observacao,
                    infadicional=obj.Infadicional,
                    funcionario=obj.Fun_Codigo,
                    totaproxtributoitem=obj.Totaproxtributoitem,
                    deposito = obj.Dep_Codigo,
                    csticms  = obj.Cst_Icms,
                    percicms = obj.Perc_Icms,
                    cstipi = obj.Cst_Ipi,
                    percipi = obj.Perc_Ipi,
                    cstpis = obj.Cst_Pis,
                    percpis = obj.Perc_Pis,
                    cstcofins = obj.Cst_Cofins,
                    perccofins=obj.Perc_Cofins,
                    detorcdesconto=obj.Detorc_Desconto,
                    pccriou=obj.Pc_Criou,
                    qdecasas=obj.Qdecasas,
                    idmotivodeson=obj.Idmotivodeson,
                    vicmsdeson=obj.Vicmsdeson
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

        public IEnumerable<OrcamentosDetalhe> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrcamentosDetalhe> GetAll(int empCodigo, string ano, int orcCodigo)
        {
            string query = $@" select 
                                  Emp_Codigo,
                                  Orc_Codigo,
                                  Detorc_Codigo,
                                  Cli_Codigo,
                                  Orc_Ano,
                                  Unid_Codigo,
                                  Pro_Codigo,
                                  Detorc_Qtde,
                                  Detorc_Custotot,
                                  Detorc_Custo,
                                  Detorc_Observacao,
                                  Infadicional,
                                  Fun_Codigo,
                                  Data_Cadastro,
                                  Totaproxtributoitem,
                                  Dep_Codigo,
                                  Cst_Icms,
                                  Perc_Icms,
                                  Cst_Ipi,
                                  Perc_Ipi,
                                  Cst_Pis,
                                  Perc_Pis,
                                  Cst_Cofins,
                                  Perc_Cofins,
                                  Detorc_Desconto,
                                  Pc_Criou,
                                  Qdecasas,
                                  Idmotivodeson,
                                  Vicmsdeson
                              from orcamentos_detalhe
                              where 
                                  emp_codigo=@empresa and orc_ano=@anoOrc and Orc_Codigo=@orcamento";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<OrcamentosDetalhe>(query, new
                {
                    empresa  = empCodigo,
                    anoOrc   = ano,
                    orcamento= orcCodigo
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

        public OrcamentosDetalhe GetById(int id)
        {
            throw new NotImplementedException();
        }
        
        public OrcamentosDetalhe GetById(int empresa, int orcamento, int detalhe , string ano)
        {
            string query = $@" select 
                                  Emp_Codigo,
                                  Orc_Codigo,
                                  Detorc_Codigo,
                                  Cli_Codigo,
                                  Orc_Ano,
                                  Unid_Codigo,
                                  Pro_Codigo,
                                  Detorc_Qtde,
                                  Detorc_Custotot,
                                  Detorc_Custo,
                                  Detorc_Observacao,
                                  Infadicional,
                                  Fun_Codigo,
                                  Data_Cadastro,
                                  Totaproxtributoitem,
                                  Dep_Codigo,
                                  Cst_Icms,
                                  Perc_Icms,
                                  Cst_Ipi,
                                  Perc_Ipi,
                                  Cst_Pis,
                                  Perc_Pis,
                                  Cst_Cofins,
                                  Perc_Cofins,
                                  Detorc_Desconto,
                                  Pc_Criou,
                                  Qdecasas,
                                  Idmotivodeson,
                                  Vicmsdeson
                              from orcamentos_detalhe
                              where 
                                  emp_codigo=@empresa and 
                                  orc_codigo=@orcamento and 
                                     orc_ano=@ano and 
                               detorc_codigo=@detalhe";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<OrcamentosDetalhe>(query, new
                {
                    empresa = empresa,
                    orcamento=orcamento,
                    ano=ano,
                    detalhe=detalhe
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
        public void Remove (int empresa, int orcamento, string ano, int detalhe)
        {
            string query = $@" delete from orcamentos_Detalhe
                                where
                                  Emp_Codigo=@empresa and 
                                  Orc_Codigo=@orccodigo and 
                                  Orc_Ano=@ano and
                                  Detorc_codigo=@detorccodigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = empresa,
                    orccodigo = orcamento,
                    detorccodigo = detalhe,
                    ano = ano

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

        public void Update(OrcamentosDetalhe obj)
        {
            string query = $@"update orcamentos_Detalhe  set
                                  Cli_Codigo=@cliente,
                                  Unid_Codigo=@unidade,
                                  Pro_Codigo=@produto,
                                  Dep_Codigo=@deposito,
                                  Fun_Codigo=@funcionario,
                                  Detorc_Qtde=@qtde,
                                  Detorc_Custo=@custo,
                                  Detorc_Custotot=@custotot,
                                  Detorc_Observacao=@observacao,
                                  Infadicional=@infadicional,
                                  Totaproxtributoitem=@totaproxtributoitem,
                                  Cst_Icms=@csticms,
                                  Perc_Icms=@percicms,
                                  Cst_Ipi=@cstipi,
                                  Perc_Ipi=@percipi,
                                  Cst_Pis=@cstpis,
                                  Perc_Pis=@percpis,
                                  Cst_Cofins=@cstcofins,
                                  Perc_Cofins=@perccofins,
                                  Detorc_Desconto=@detorcdesconto,
                                  Qdecasas=@qdecasas,
                                  Idmotivodeson=@idmotivodeson,
                                  Vicmsdeson=@vicmsdeson
                            where
                                  Emp_Codigo=@empresa and 
                                  Orc_Codigo=@orccodigo and 
                                  Orc_Ano=@ano and
                                  Det=orc_Codigo=@detorccodigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    cliente = obj.Cli_Codigo,
                    unidade = obj.Unid_Codigo,
                    produto = obj.Pro_Codigo,
                    deposito = obj.Dep_Codigo,
                    funcionario = obj.Fun_Codigo,

                    qtde = obj.Detorc_Qtde,
                    custotot = obj.Detorc_Custotot,
                    custo = obj.Detorc_Custo,
                    observacao = obj.Detorc_Observacao,
                    infadicional = obj.Infadicional,
                    totaproxtributoitem = obj.Totaproxtributoitem,
                    csticms = obj.Cst_Icms,
                    percicms = obj.Perc_Icms,
                    cstipi = obj.Cst_Ipi,
                    percipi = obj.Perc_Ipi,
                    cstpis = obj.Cst_Pis,
                    percpis = obj.Perc_Pis,
                    cstcofins = obj.Cst_Cofins,
                    perccofins = obj.Perc_Cofins,
                    detorcdesconto = obj.Detorc_Desconto,
                    qdecasas = obj.Qdecasas,
                    idmotivodeson = obj.Idmotivodeson,
                    vicmsdeson = obj.Vicmsdeson,
                    empresa = obj.Emp_Codigo,
                    orccodigo = obj.Orc_Codigo,
                    detorccodigo = obj.Detorc_Codigo,
                    ano = obj.ORC_Ano

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
