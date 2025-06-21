using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.SignalR;

namespace EgourmetAPI.Repository
{
    public class CondicPagtoRepository : ICondicPagtoRepository
    {

        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public CondicPagtoRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public void Add(CondicPagto obj)
        {
            string query = $@"insert into condic_pagto(
                              Condic_Codigo,
                              Condic_Descricao,
                              Condic_Avista,
                              Port_Codigo,
                              Condic_Tipo,
                              Condic_Hab,
                              Perfil,
                              Idformapagsefaz)
                            values(
                              @Codigo,
                              @Descricao,
                              @Condic_Avista,
                              1,
                              @Tipo,
                              @Hab,
                              @Perfil,
                              @Formapagsefaz)";
            
            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    Codigo=obj.Condic_Codigo,
                    Descricao = obj.Condic_Descricao,
                    Condic_Avista=obj.Condic_Avista,
                    Tipo=obj.Condic_Tipo,
                    Hab=obj.Condic_Hab,
                    Perfil=obj.Perfil,
                    Formapagsefaz=obj.Idformapagsefaz
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

        public IEnumerable<CondicPagto> GetAll()
        {
            string query = $@" select   
                                  Condic_Codigo
                                  Condic_Descricao
                                  Condic_Avista
                                  Port_Codigo
                                  Condic_Tipo
                                  Condic_Hab,
                                  Perfil
                                  Idformapagsefaz 
                                from condic_pagto ";
            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<CondicPagto>(query).ToList();
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

        public CondicPagto GetById(int id)
        {
            string query = $@" select   
                                  Condic_Codigo
                                  Condic_Descricao
                                  Condic_Avista
                                  Port_Codigo
                                  Condic_Tipo
                                  Condic_Hab,
                                  Perfil
                                  Idformapagsefaz 
                                from condic_pagto where condic_codigo=@codigo";
            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<CondicPagto>(query, new { codigo = id }).FirstOrDefault();
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
            string query = $@" delete from condic_pagto
                            where
                              Condic_Codigo=@Codigo";

            var connection = new FbConnection(conexao);

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

        public void Update(CondicPagto obj)
        {
            string query = $@"update condic_pagto set 
                              Condic_Descricao=@Descricao,
                              Condic_Avista=@Condic_Avista,
                              Condic_Tipo=@Tipo,
                              Condic_Hab=@Hab,
                              Perfil=@Perfil,
                              Idformapagsefaz=@Formapagsefaz
                            where
                              Condic_Codigo=@Codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    Descricao = obj.Condic_Descricao,
                    Condic_Avista = obj.Condic_Avista,
                    Tipo = obj.Condic_Tipo,
                    Hab = obj.Condic_Hab,
                    Perfil = obj.Perfil,
                    Formapagsefaz = obj.Idformapagsefaz,
                    Codigo = obj.Condic_Codigo
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