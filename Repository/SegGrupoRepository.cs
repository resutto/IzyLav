using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Helpers;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;
using System.Collections.Generic;

namespace EgourmetAPI.Repository
{
    public class SegGrupoRepository : ISegGrupoRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public SegGrupoRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(SegGrupo obj)
        {
            string query = $@"insert into seg_grupo(Grup_Codigo, Grupo_Descricao) values(@codigo, @descricao)";
            var connection = new FbConnection(conexao);
            try
            {   
                connection.Open();
                IdLanc que1 = Datpai.GerarIdLanc(-1, connection, "select max(cast(grup_codigo as integer))+1 as IdLanc from seg_grupo");
                connection.Execute(query, new
                {
                    codigo = que1.idLanc,
                    descricao = obj.Grupo_Descricao
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }

        }

        public IEnumerable<SegGrupo> GetAll()
        {
            string query = $@"select Grup_Codigo, Grupo_Descricao from seg_grupo";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<SegGrupo>(query).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }

        public SegGrupo GetById(int id)
        {
            string query = $@"select Grup_Codigo, Grupo_Descricao from seg_grupo where grup_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<SegGrupo>(query, new { codigo = id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }

        public void Remove(int id)
        {
            string query = $@"delete from seg_grupo where  Grup_Codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new
                {
                    codigo = id
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }

        public void Update(SegGrupo obj)
        {
            string query = $@"update  seg_grupo set Grupo_Descricao=@descricao where grup_codigo=@codigo";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Grup_Codigo,
                    descricao = obj.Grupo_Descricao
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }
    }
}
