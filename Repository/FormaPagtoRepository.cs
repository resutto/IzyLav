using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class FormaPagtoRepository : IFormaPagtoRepository
    {
        private IConfiguration _configuracoes;
        string Conexao { get { return _configuracoes.GetConnectionString("firedb"); } }
        
        public FormaPagtoRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }
        public void Add(FormaPagto obj)
        {
            string query = $@"insert into forma_pagto(Formpgto_Codigo,
                              Formpgto_Descricao,
                              Formpgto_Entrada,
                              Formpgto_Qdeparc,
                              Formpgto_Tipo,
                              Formpgto_Hab) 
                            values(
                              @Codigo,
                              @Descricao,
                              @Entrada,
                              @Qdeparc,
                              @Tipo,
                              @Hab)";

            var connection = new FbConnection(Conexao);

            try
            {
                connection.Execute(query, new {
                      Codigo=obj.Formpgto_Codigo,
                      Descricao=obj.Formpgto_Descricao,
                      Entrada=obj.Formpgto_Entrada,
                      Qdeparc=obj.Formpgto_Qdeparc,
                      Tipo=obj.Formpgto_Tipo,
                      Hab=obj.Formpgto_Hab
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

        public IEnumerable<FormaPagto> GetAll()
        {
            string query = $@"select   
                              Formpgto_Codigo,
                              Formpgto_Descricao,
                              Formpgto_Entrada,
                              Formpgto_Qdeparc,
                              Formpgto_Tipo,
                              Formpgto_Hab
                            from forma_pagto ";

            var connection = new FbConnection(Conexao);

            try
            {
                return connection.Query<FormaPagto>(query).ToList();
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

        public FormaPagto GetById(int id)
        {
            string query = $@"select   
                              Formpgto_Codigo,
                              Formpgto_Descricao,
                              Formpgto_Entrada,
                              Formpgto_Qdeparc,
                              Formpgto_Tipo,
                              Formpgto_Hab
                            from forma_pagto 
                            where Formpgto_Codigo=@codigo";

            var connection = new FbConnection(Conexao);

            try
            {
                return connection.Query<FormaPagto>(query, new { codigo = id }).FirstOrDefault();
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
            string query = $@"delete from forma_pagto
                            where
                            Formpgto_Codigo=@Codigo ";

            var connection = new FbConnection(Conexao);

            try
            {
                connection.Execute(query, new
                {
                    Codigo = id
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

        public void Update(FormaPagto obj)
        {
            string query = $@"update forma_pagto set
                              Formpgto_Descricao=@Descricao,
                              Formpgto_Entrada=@Entrada,
                              Formpgto_Qdeparc=@Qdeparc,
                              Formpgto_Tipo=@Tipo,
                              Formpgto_Hab=@Hab
                            where
                            Formpgto_Codigo=@Codigo ";

            var connection = new FbConnection(Conexao);

            try
            {
                connection.Execute(query, new
                {
                    Descricao = obj.Formpgto_Descricao,
                    Entrada = obj.Formpgto_Entrada,
                    Qdeparc = obj.Formpgto_Qdeparc,
                    Tipo = obj.Formpgto_Tipo,
                    Hab = obj.Formpgto_Hab,
                    Codigo = obj.Formpgto_Codigo
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