using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;

namespace EgourmetAPI.Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public FamiliaRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(Familia objFamilia)
        {
            string query = $@"  insert into familia(FAM_CODIGO,
                                  GRUP_CODIGO,
                                  FAM_DESCRICAO) 
                                  values(@codigoFamilia,@codigoGrupo,@descricao)";
            
            var connection = new FbConnection(conexao);
            
            try
            {
                IdLanc que1 = Datpai.GerarIdLanc(objFamilia.Grup_Codigo, connection, "select max(fam_codigo)+1 as idLanc from familia where grup_codigo=@empresa");
                connection.Execute(query, new { codigoFamilia= que1.idLanc, codigoGrupo= objFamilia.Grup_Codigo, descricao= objFamilia.Fam_Descricao });
            
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

        public IEnumerable<Familia> GetAll(int grupCodigo)
        {
            string query = $@"  select FAM_CODIGO,
                                  GRUP_CODIGO,
                                  FAM_DESCRICAO from familia where grup_codigo=@grupo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Familia>(query, new { grupo= grupCodigo }).ToList();
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


    public Familia GetByIdGrupoFamilia(int idFamilia, int idGrupo)
        {
            string query = $@"  select 
                                  FAM_CODIGO,
                                  GRUP_CODIGO,
                                  FAM_DESCRICAO
                                from  familia 
                                where 
                                        fam_codigo = @codigoFamilia and 
                                        grup_codigo= @codigoGrupo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Familia>(query, new { codigoFamilia = idFamilia, codigoGrupo=idGrupo }).FirstOrDefault();
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
        public Familia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }


        public void RemoveIdGrupoFamilia(int idFamilia, int idGrupo)
        {
            string query = $@"  select 
                                  FAM_CODIGO,
                                  GRUP_CODIGO,
                                  FAM_DESCRICAO,
                                  FAM_PROP_TECNICA 
                                from  familia 
                                where 
                                        fam_codigo = @codigoFamilia and 
                                        grup_codigo= @codigoGrupo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new { codigoFamilia = idFamilia, codigoGrupo = idGrupo });
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

        public void Update(Familia objFamilia)
        {
            string query = $@"  update familia set FAM_DESCRICAO=@descricao 
                                where
                                  GRUP_CODIGO=@codigoGrupo and 
                                  fam_codigo=@codigoFamilia ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new { descricao = objFamilia.Fam_Descricao , codigoFamilia = objFamilia.Fam_Codigo, codigoGrupo = objFamilia.Grup_Codigo });
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

        public IEnumerable<Familia> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
