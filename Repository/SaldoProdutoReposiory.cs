using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class SaldoProdutoReposiory : ISaldoProdutoRepository
    {
        private IConfiguration _configuracao;
        string conexao { get { return _configuracao.GetConnectionString("firedb"); } }

        public SaldoProdutoReposiory(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public void Add(SaldoProduto obj)
        {
            string query = $@"insert into saldo_produto(Emp_Codigo,Pro_Codigo,Dep_Codigo,Saldo_Anterior,Saldo_Atual,Pro_Custo_Medio)
                                                 values(@empresa,@produto,@deposito,0,0,0)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = obj.Emp_Codigo,
                    produto = obj.Pro_Codigo,
                    deposito = obj.Dep_Codigo
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

        public IEnumerable<SaldoProduto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaldoProduto> GetAll(int empresa, string produto)
        {
            string query = $@"select Emp_Codigo,Pro_Codigo,Dep_Codigo,Saldo_Anterior,Saldo_Atual,Pro_Custo_Medio
                              from saldo_produto
                              where emp_codigo=@empresa and pro_codigo=@produto";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<SaldoProduto>(query, new
                {
                    empresa = empresa,
                    produto = produto,
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

        public SaldoProduto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public SaldoProduto GetById(int empresa, int deposito, string produto)
        {
            string query = $@"select Emp_Codigo,Pro_Codigo,Dep_Codigo,Saldo_Anterior,Saldo_Atual,Pro_Custo_Medio
                              from saldo_produto
                              where emp_codigo=@empresa and pro_codigo=@produto and dep_codigo=@deposito";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<SaldoProduto>(query, new
                {
                    empresa = empresa,
                    produto = produto,
                    deposito=deposito
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

        public void Update(SaldoProduto obj)
        {
            string query = $@"update saldo_produto set 
                                        Saldo_Anterior=@saldoAnterior ,
                                        Saldo_Atual=@saldoAtual
                              where
                                        Emp_Codigo=@empresa and 
                                        Pro_Codigo=@produto and
                                        Dep_Codigo=@deposito";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    saldoAnterior=obj.Saldo_Anterior,
                    saldoAtual=obj.Saldo_Atual,
                    empresa = obj.Emp_Codigo,
                    produto = obj.Pro_Codigo,
                    deposito = obj.Dep_Codigo
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
