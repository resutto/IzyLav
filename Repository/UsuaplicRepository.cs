using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class UsuaplicRepository : IUsuaplicRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public UsuaplicRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public void Add(Usuaplic obj)
        {
            string query = $@"insert into USUAPLIC(Grup_Codigo,Apli_Codigo)
                                        values(@grupocodigo,@aplicodigo)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                   grupocodigo=obj.Grup_Codigo,
                   aplicodigo=obj.Apli_Codigo
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

        public IEnumerable<Usuaplic> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuaplic GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(int empresa, string aplicacao)
        {
            string query = $@"delete from USUAPLIC where Grup_Codigo=@grupocodigo and Apli_Codigo=@aplicodigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    grupocodigo = empresa,
                    aplicodigo = aplicacao
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

        public void Update(Usuaplic obj)
        {
            throw new NotImplementedException();
        }
    }
}
