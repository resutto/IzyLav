using Dapper;
using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace egourmetAPI.Repository
{
    public class MaquinasEtapasRepository : IMaquinasEtapas
    {
        private IConfiguration _configuration;
        string conexao { get { return _configuration.GetConnectionString("firedb"); } }
        public MaquinasEtapasRepository(IConfiguration config){
            _configuration = config;
        }
        public void Add(MaquinasEtapas objMaquinasEtapas)
        {
            string query = $@"insert into MAQUINAS_ETAPAS(IDETAPA,DESCRICAO,DURACAOETAPAMINUTOS,DURACAOETAPASEGUNDOS) 
                                                   values(@id,@descricao,@ducacaom,@duracaos)";
            var connection = new FbConnection(conexao);

            try
            {
                connection.Open();
                connection.Execute(query, new { 
                           id= objMaquinasEtapas.idEtapa, 
                    descricao= objMaquinasEtapas.descricao, 
                     ducacaom= objMaquinasEtapas.duracaoEtapaMinutos, 
                     duracaos= objMaquinasEtapas.duracaoEtapaSegudos });
            }
            catch (Exception ex) {
                throw ex;
            }
            finally { 
                connection.Close();
            }

        }

        public IEnumerable<MaquinasEtapas> GetAll()
        {
            string query = $@" select IDETAPA,DESCRICAO,DURACAOETAPAMINUTOS ,DURACAOETAPASEGUNDOS from MAQUINAS_ETAPAS";
            var connection = new FbConnection(conexao);

            try
            {
                connection.Open();
                return connection.Query<MaquinasEtapas>(query).ToList();
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

        public MaquinasEtapas GetById(int id)
        {
            string query = $@" select IDETAPA,DESCRICAO,DURACAOETAPAMINUTOS ,DURACAOETAPASEGUNDOS from MAQUINAS_ETAPAS where IDETAPA=idetapa";
            var connection = new FbConnection(conexao);

            try
            {
                connection.Open();
                return connection.Query<MaquinasEtapas>(query, new { idetapa = id }).FirstOrDefault();
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
            string query = $@" delete from MAQUINAS_ETAPAS where IDETAPA=@idetapa";
            var connection = new FbConnection(conexao);

            try
            {
                connection.Open();
                connection.Execute(query, new
                {
                    idetapa = id
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

        public void Update(MaquinasEtapas objMaquinasEtapas)
        {
            string query = $@" update MAQUINAS_ETAPAS set   DESCRICAO=@descricao,
                                                            DURACAOETAPAMINUTOS=@ducacaom,
                                                            DURACAOETAPASEGUNDOS=@duracaos 
                                                            where IDETAPA=@id";
            var connection = new FbConnection(conexao);

            try
            {
                connection.Open();
                connection.Execute(query, new
                {
                    id = objMaquinasEtapas.idEtapa,
                    descricao = objMaquinasEtapas.descricao,
                    ducacaom = objMaquinasEtapas.duracaoEtapaMinutos,
                    duracaos = objMaquinasEtapas.duracaoEtapaSegudos
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
