using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;

namespace EgourmetAPI.Repository
{
    public class DepositoRepository : IDepositoRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public DepositoRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(Deposito obj)
        {
            string query = $@"insert into deposito(Dep_Codigo,Emp_Codigo,Dep_Descricao,Dep_Local) 
                                           values(@codigo,@empCodigo,@descricao,@local)";

            var connection = new FbConnection(conexao);

            try
            {
                IdLanc que1 = Datpai.GerarIdLanc(obj.Emp_Codigo, connection, "select max(dep_codigo)+1 from deposito where emp_Codigo=@empresa");
                connection.Execute(query, new
                {
                    codigo = que1.idLanc,
                    empCodigo = obj.Emp_Codigo,
                    descricao = obj.Dep_Descricao,
                    local = obj.Dep_Local
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

        public IEnumerable<Deposito> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Deposito> GetAll(int empresa)
        {
            string query = $@"select Dep_Codigo,Emp_Codigo,Dep_Descricao,Dep_Local from deposito 
                              where emp_codigo=@empCodigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Deposito>(query, new
                {
                    empCodigo = empresa
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

        public Deposito GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Deposito GetById(int codigo, int empresa)
        {
            string query = $@"select Dep_Codigo,Emp_Codigo,Dep_Descricao,Dep_Local from deposito 
                              where dep_codigo=@codigo and emp_codigo=@empCodigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Deposito>(query, new
                {   codigo = codigo,
                    empCodigo = empresa}).FirstOrDefault();
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
        public void Remove(int codigo,int empresa)
        {
            string query = $@"delete from deposito where Dep_Codigo=@codigo and Emp_Codigo=@empCodigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = codigo,
                    empCodigo = empresa
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


        public void Update(Deposito obj)
        {
            string query = $@"update deposito set Dep_Descricao=@descricao,Dep_Local=@local 
                              where Dep_Codigo=@codigo and Emp_Codigo=@empCodigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    descricao = obj.Dep_Descricao,
                    local = obj.Dep_Local,
                    codigo = obj.Dep_Codigo,
                    empCodigo = obj.Emp_Codigo
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
