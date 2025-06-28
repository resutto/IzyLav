using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;

namespace EgourmetAPI.Repository
{
    public class FormaQdeDiasRepository : IFormaQdeDiasRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public FormaQdeDiasRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public IEnumerable<FormaQdeDias> GetAll(int forma)
        {
            string query = $@"select Codigo,Formpgto_Codigo,Qdedias from forma_qdedias
                               where Formpgto_Codigo=@forma";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<FormaQdeDias>(query, new
                {
                    forma = forma
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

        public FormaQdeDias GetById(int id, int forma)
        {
            string query = $@"select Codigo,Formpgto_Codigo,Qdedias from forma_qdedias
                               where Formpgto_Codigo=@forma and Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<FormaQdeDias>(query, new { forma = forma,codigo=id}).FirstOrDefault();
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

        public void Add(FormaQdeDias obj)
        {
            string query = $@"insert into forma_qdedias(Codigo,obj.Formpgto_Codigo,Qdedias)
                                                 values(@id,@forma,@dias)";

            var connection = new FbConnection(conexao);

            try
            {
                IdLanc que1 = Datpai.GerarIdLanc(-1, connection, "select max(codigo)+1 from FORMA_QDEDIAS where Formpgto_Codigo=@empresa");
                connection.Execute(query, new
                {
                    id = que1.idLanc,
                    forma=obj.Formpgto_Codigo,
                    dias=obj.Qdedias
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

        public void Update(FormaQdeDias obj)
        {
            string query = $@"update forma_qdedias set Qdedias=@dias where Codigo=@id and Formpgto_Codigo=@forma";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    id = obj.Codigo,
                    forma = obj.Formpgto_Codigo,
                    dias = obj.Qdedias
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

        public void Remove(int id, int forma)
        {
            string query = $@"delete from forma_qdedias where Codigo=@id and Formpgto_Codigo=@forma";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    id = id,
                    forma = forma
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

        public IEnumerable<FormaQdeDias> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public FormaQdeDias GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
