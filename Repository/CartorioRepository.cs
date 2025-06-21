using Dapper;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using System.Runtime.ConstrainedExecution;

namespace EgourmetAPI.Repository
{
    public class CartorioRepository : ICartorioRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public CartorioRepository(IConfiguration configuracao)
        {
            _configuracoes= configuracao;
        }   
        public void Add(Cartorio obj)
        {
            string query = $@"  insert into cartorios(Cart_Codigo,Cart_Nome_Fantasia,Cart_Razao_Social,Cart_cgc,
                                Cart_Inscricao_Estadual,Cart_Inscricao_Municipal,Cart_Cep,Cart_Endereco,Cart_Numero,
                                Cart_Bairro,Cart_Complemento,Cart_Uf,Cart_Cidade,Cart_Telefone,Cart_Homepage,
                                Cart_Email,Cart_Responsavel)
                                values(
                                  @codigo,@nome,@razao,@cnpj,
                                  @ie,@im,@cep,@endereco,@numero,
                                  @bairro,@complemento,@Uf,@cidade,@telefone,@homepage,
                                  @email,@responsavel)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo=obj.Cart_Codigo,
                    nome = obj.Cart_Nome_Fantasia,
                    razao = obj.Cart_Razao_Social,
                    cnpj = obj.Cart_Cnpj,
                    ie = obj.Cart_Inscricao_Estadual,
                    im = obj.Cart_Inscricao_Municipal,
                    cep = obj.Cart_Cep,
                    endereco = obj.Cart_Endereco,
                    numero = obj.Cart_Numero,
                    bairro = obj.Cart_Bairro,
                    complemento = obj.Cart_Complemento,
                    Uf = obj.Cart_Uf,
                    cidade = obj.Cart_Cidade,
                    telefone = obj.Cart_Telefone,
                    homepage = obj.Cart_Homepage,
                    email = obj.Cart_Email,
                    responsavel = obj.Cart_Responsavel
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

        public IEnumerable<Cartorio> GetAll()
        {
            string query = $@" select Cart_Codigo,Cart_Nome_Fantasia,Cart_Razao_Social,Cart_cgc,
                                      Cart_Inscricao_Estadual,Cart_Inscricao_Municipal,Cart_Cep,Cart_Endereco,Cart_Numero,
                                      Cart_Bairro,Cart_Complemento,Cart_Uf,Cart_Cidade,Cart_Telefone,Cart_Homepage,
                                      Cart_Email,Cart_Responsavel ";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cartorio>(query).ToList();
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

        public Cartorio GetById(int id)
        {
            string query = $@" select Cart_Codigo,Cart_Nome_Fantasia,Cart_Razao_Social,Cart_cgc,
                                      Cart_Inscricao_Estadual,Cart_Inscricao_Municipal,Cart_Cep,Cart_Endereco,Cart_Numero,
                                      Cart_Bairro,Cart_Complemento,Cart_Uf,Cart_Cidade,Cart_Telefone,Cart_Homepage,
                                      Cart_Email,Cart_Responsavel where cart_codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Cartorio>(query,new {codigo=id}).FirstOrDefault();
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
            string query = $@"delete from cartorios where Cart_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    codigo = id
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

        public void Update(Cartorio obj)
        {
            string query = $@" update cartorios set 
                                  Cart_Nome_Fantasia=@nome,
                                  Cart_Razao_Social=@razao,
                                  Cart_Inscricao_Estadual=@ie,
                                  Cart_Inscricao_Municipal=@im,
                                  Cart_Cep=@cep,
                                  Cart_Endereco=@endereco,
                                  Cart_Numero=@numero,
                                  Cart_Bairro=@bairro,
                                  Cart_Complemento=@complemento,
                                  Cart_Uf=@uf,
                                  Cart_Cidade=@cidade,
                                  Cart_Telefone=@telefone,
                                  Cart_Homepage=@homepage,
                                  Cart_Email=@razao,
                                  Cart_Responsavel=@responsavel
                                where Cart_Codigo=@codigo";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    nome = obj.Cart_Nome_Fantasia,
                    razao = obj.Cart_Razao_Social,
                    ie = obj.Cart_Inscricao_Estadual,
                    im = obj.Cart_Inscricao_Municipal,
                    cep = obj.Cart_Cep,
                    endereco = obj.Cart_Endereco,
                    numero = obj.Cart_Numero,
                    bairro = obj.Cart_Bairro,
                    complemento = obj.Cart_Complemento,
                    Uf = obj.Cart_Uf,
                    cidade = obj.Cart_Cidade,
                    telefone = obj.Cart_Telefone,
                    homepage = obj.Cart_Homepage,
                    email = obj.Cart_Email,
                    responsavel = obj.Cart_Responsavel,
                    codigo = obj.Cart_Codigo
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
