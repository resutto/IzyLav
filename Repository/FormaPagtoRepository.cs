using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;

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
        public void Add(FormaPagto objForma)
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
                IdLanc que1 = Datpai.GerarIdLanc(-1, connection, "select max(formpgto_codigo)+1 as IdLanc from forma_pagto");

                connection.Execute(query, new {
                      Codigo=que1.idLanc,
                      Descricao= objForma.Formpgto_Descricao,
                      Entrada= objForma.Formpgto_Entrada,
                      Qdeparc= objForma.Formpgto_Qdeparc,
                      Tipo=objForma.Formpgto_Tipo,
                      Hab=objForma.Formpgto_Hab
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

        public IEnumerable<FormaPagto> GetAll(string tipo)
        {
            string query = $@"select   
                              Formpgto_Codigo,
                              Formpgto_Descricao,
                              Formpgto_Entrada,
                              Formpgto_Qdeparc,
                              Formpgto_Tipo,
                              Formpgto_Hab
                            from forma_pagto where Formpgto_Tipo=@formatipo";

            var connection = new FbConnection(Conexao);

            try
            {
                return connection.Query<FormaPagto>(query, new { formatipo = tipo} ).ToList();
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

        public void Update(FormaPagto objForma)
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
                    Descricao = objForma.Formpgto_Descricao,
                    Entrada = objForma.Formpgto_Entrada,
                    Qdeparc = objForma.Formpgto_Qdeparc,
                    Tipo = objForma.Formpgto_Tipo,
                    Hab = objForma.Formpgto_Hab,
                    Codigo = objForma.Formpgto_Codigo
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
            throw new NotImplementedException();
        }
    }
}