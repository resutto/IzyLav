using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;

namespace EgourmetAPI.Repository
{
    public class ContasRepository : IContasRepository
    {
        private IConfiguration _configuration;
        string conexao { get { return _configuration.GetConnectionString("firedb"); } }
        public ContasRepository(IConfiguration configuracao)
        {
            _configuration = configuracao;
        }
        public void Add(Contas obj)
        {
            string query = $@"insert into contas(Conta_Codigo,Conta_Descricao,Conta_Tipo,Caixa_Rapido,Caixa_Full,Imagem,Hab,Imgshort)
                              values(@conta,@descricao,@tipo,@rapido,@full,@imagem,@hab,@imgshort)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    conta=obj.Conta_Codigo,
                    descricao=obj.Conta_Descricao,
                    tipo=obj.Conta_Tipo,
                    rapido=obj.Caixa_Rapido,
                    full=obj.Caixa_Full,
                    imagem=obj.Imagem,
                    hab=obj.Hab,
                    imgshort=obj.Imgshort
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

        public IEnumerable<Contas> GetAll()
        {
            string query = $@"select Conta_Codigo,Conta_Descricao,Conta_Tipo,Caixa_Rapido,
                                     Caixa_Full,Imagem,Hab,Imgshort from contas";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Contas>(query).ToList();
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

        public Contas GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Contas GetById(string id)
        {
            string query = $@"select Conta_Codigo,Conta_Descricao,Conta_Tipo,Caixa_Rapido,
                                     Caixa_Full,Imagem,Hab,Imgshort from contas
                              where conta_codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Contas>(query, new { codigo=id}).FirstOrDefault();
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
            throw new NotImplementedException();
        }
        public void Remove(string id)
        {
            string query = $@"delete from contas where Conta_Codigo=@conta";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    conta = id
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


        public void Update(Contas obj)
        {
            string query = $@"update contas set   Conta_Descricao=@descricao,
                                                  Conta_Tipo=@tipo,
                                                  Caixa_Rapido=@rapido,
  		                                          Caixa_Full=@full,
                                                  Imagem=@imagem,
                                                  Hab=@hab,
                                                  Imgshort=@imgshort
                              where Conta_Codigo=@conta";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    descricao = obj.Conta_Descricao,
                    tipo = obj.Conta_Tipo,
                    rapido = obj.Caixa_Rapido,
                    full = obj.Caixa_Full,
                    imagem = obj.Imagem,
                    hab = obj.Hab,
                    imgshort = obj.Imgshort,
                    conta = obj.Conta_Codigo
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
