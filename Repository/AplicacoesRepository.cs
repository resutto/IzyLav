using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class AplicacoesRepository : IAplicacoesRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public AplicacoesRepository(IConfiguration configuracao)
        {
            _configuracoes = configuracao;
        }

        public void Add(Aplicacoes obj)
        {
            string query = $@"insert into aplicacoes(
                                              Apli_Codigo,
                                              Apli_Descricao,
                                              Apli_Tipo,
                                              Apli_Img,
                                              Apli_Mostrar_Menu,
                                              Apli_Desc_Curta,
                                              Modulo)
                                            values(
                                              @codigo,
                                              @descricao,
                                              @tipo,
                                              @img,
                                              @menu,
                                              @menucurto,
                                              @modulo
                                            )";
            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new {
                    codigo=obj.Apli_Codigo,
                    descricao=obj.Apli_Descricao,
                    tipo=obj.Apli_Tipo,
                    img=obj.Apli_Img,
                    menu=obj.Apli_Mostrar_Menu,
                    menucurto=obj.Apli_Desc_Curta,
                    modulo=obj.Modulo
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }

        }

        public IEnumerable<Aplicacoes> GetAll()
        {
            string query = $@" select 
                                 Apli_Codigo,
                                 Apli_Descricao,
                                 Apli_Tipo,
                                 Apli_Img,
                                 Apli_Mostrar_Menu,
                                 Apli_Desc_Curta,
                                 Modulo 
                               from aplicacoes";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Aplicacoes>(query).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }

        }

        public Aplicacoes GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Aplicacoes GetById(string id)
        {
            string query = $@" select 
                                 Apli_Codigo,
                                 Apli_Descricao,
                                 Apli_Tipo,
                                 Apli_Img,
                                 Apli_Mostrar_Menu,
                                 Apli_Desc_Curta,
                                 Modulo 
                               from aplicacoes where apli_codigo=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Aplicacoes>(query,new { codigo = id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }

        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string codigo)
        {
            string query = $@"delete from aplicacoes 
                             where Apli_Codigo=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new
                {
                    codigo = codigo
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
        }

        public void Update(Aplicacoes obj)
        {
            string query = $@"update aplicacoes set
                                              Apli_Descricao=@descricao,
                                              Apli_Tipo=@tipo,
                                              Apli_Img=@img,
                                              Apli_Mostrar_Menu=@menu,
                                              Apli_Desc_Curta=@menucurto,
                                              Modulo=@modulo 
                             where Apli_Codigo=@codigo";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new
                {
                    codigo = obj.Apli_Codigo,
                    descricao = obj.Apli_Descricao,
                    tipo = obj.Apli_Tipo,
                    img = obj.Apli_Img,
                    menu = obj.Apli_Mostrar_Menu,
                    menucurto = obj.Apli_Desc_Curta,
                    modulo = obj.Modulo
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
