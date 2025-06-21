using Dapper;
using egourmetAPI.Model;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.Model;
using IzyLav.Repository.Interface;

namespace IzyLav.Repository
{
    public class MaquinaTipoRepository : IMaquinaTipoRepository
    {
        public readonly IConfiguration _config;
        string conexao { get { return _config.GetConnectionString("firedb"); } }
        
        public MaquinaTipoRepository(IConfiguration config)
        {
            _config = config;
        }

        public IdLanc GerarIdLanc()
        {
            string query = $@"select max(idtipo)+1 as idlanc from MAQUINAS_TIPO";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Open();
                IdLanc id;
                id = connection.Query<IdLanc>(query).FirstOrDefault();
                if (id.idLanc == 0)
                {
                    id.idLanc = 1;
                }
                return id;
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

        public void Add(MaquinaTipo objTipo)
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = @$"insert into MAQUINAS_TIPO(idtipo,descricao) values(@id,@descricao)";
                try
                {
                    connection.Open();
                    IdLanc que1 = GerarIdLanc();
                    connection.Execute(query, new { id = que1.idLanc, descricao = objTipo.Descricao });
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

        public IEnumerable<MaquinaTipo> GetAll()
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = @$"select idtipo,descricao from MAQUINAS_TIPO ";
                try
                {
                    connection.Open();
                    return connection.Query<MaquinaTipo>(query).ToList();
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

        public MaquinaTipo GetById(int id)
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = @$"select idtipo,descricao from MAQUINAS_TIPO where idtipo=@id1";
                try
                {
                    connection.Open();
                    return connection.Query<MaquinaTipo>(query, new { id1 = id }).FirstOrDefault();
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

        public void Remove(int id)
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = @$"delete from MAQUINAS_TIPO where idtipo=@id1";
                try
                {
                    connection.Open();
                    connection.Execute(query, new { id1 = id});
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

        public void Update(MaquinaTipo objTipo)
        {
            using (var connection = new FbConnection(conexao))
            {
                string query = @$"update MAQUINAS_TIPO set descricao=@descricao where idtipo=@id";
                try
                {
                    connection.Open();
                    connection.Execute(query, new { id = objTipo.IdTipo, descricao = objTipo.Descricao });
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
}
