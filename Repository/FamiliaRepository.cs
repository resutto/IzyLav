using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

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
        public void Add(Familia obj)
        {
            string query = $@"  insert into familia(FAM_CODIGO,
                                  GRUP_CODIGO,
                                  FAM_DESCRICAO,
                                  FAM_PROP_TECNICA) 
                                  values(@codigoFamilia,@codigoGrupo,@descricao,@tecnica)";
            
            var connection = new FbConnection(conexao);
            
            try
            {
                connection.Execute(query, new { codigoFamilia= obj.Fam_Codigo, codigoGrupo=obj.Grup_Codigo, tecnica=obj.Fam_Descricao });
            }catch(Exception e)
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
            string query = $@"  select FAM_CODIGO,
                                  GRUP_CODIGO,
                                  FAM_DESCRICAO,
                                  FAM_PROP_TECNICA from familia";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Familia>(query).ToList();
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
                                  FAM_DESCRICAO,
                                  FAM_PROP_TECNICA 
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

        public void Update(Familia obj)
        {
            string query = $@"  update familia set FAM_DESCRICAO=@descricao , FAM_PROP_TECNICA=@proposta
                                where
                                  GRUP_CODIGO=@codigoGrupo and 
                                  fam_codigo=@codigoFamilia ";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new { codigoFamilia = obj.Fam_Codigo, codigoGrupo = obj.Grup_Codigo, tecnica = obj.Fam_Descricao });
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
