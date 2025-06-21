using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace EgourmetAPI.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }
        public FuncionarioRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(Funcionario obj)
        {
            string query = $@"insert into funcionario(  
              
              Emp_Codigo,Set_Codigo,Fun_Codigo,Cargo_Codigo,Fun_Nome,Fun_Rg,Fun_Cpf
  			  Fun_Carteira_Profissional,Fun_Habilitacao,Fun_Cep,Fun_Endereco,Fun_Bairro,Fun_Numero,
			  Fun_Uf,Fun_Cidade,Fun_Compl,Fun_Telefone,Fun_Data_Nascimento,Fun_Sexo,
			  Fun_Comissao,Fun_Observacoes,Fun_Imagem_Foto,Fun_Email,
			  Ativo,Eh_Vendedor,foto )
              
              values(  @empresa,@setor,@funcionario,@cargo,@nome,@rg,@cpf,@carteiraprofissional,@habilitacao,@cep,
                       @endereco,@bairro,@numero,@uf,@cidade,@compl,@telefone,@datanascimento,@sexo,@comissao,
                       @observacoes,@email,@ativo,@ehvendedor,@foto)";

            var connection = new FbConnection(conexao);
            try
            {

                IdLanc que1 = Datpai.GerarIdLanc(obj.Emp_Codigo, connection,
                                                 $@"select max(fun_codigo)+1 as idlanc from funcionario where emp_Codigo=@empresa");

                connection.Execute(query, new
                {
                      empresa   = obj.Emp_Codigo,
                      setor     = obj.Set_Codigo,
                    funcionario = que1.idLanc,
                    cargo = obj.Cargo_Codigo,
                    nome = obj.Fun_Nome,
                    rg = obj.Fun_Rg,
                    cpf = obj.Fun_Cpf,
                    carteiraprofissional = obj.Fun_Carteira_Profissional,
                    habilitacao = obj.Fun_Habilitacao,
                    cep = obj.Fun_Cep,
                    endereco = obj.Fun_Endereco,
                    bairro = obj.Fun_Bairro,
                    numero = obj.Fun_Numero,
                    uf = obj.Fun_Uf,
                    cidade = obj.Fun_Cidade,
                    compl = obj.Fun_Compl,
                    telefone = obj.Fun_Telefone,
                    datanascimento = obj.Fun_Data_Nascimento,
                    sexo = obj.Fun_Sexo,
                    comissao = obj.Fun_Comissao,
                    observacoes = obj.Fun_Observacoes,
                    email = obj.Fun_Email,
                    ativo = obj.Ativo,
                    ehvendedor = obj.Eh_Vendedor,
                    foto = obj.Fun_Foto
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

        public IEnumerable<Funcionario> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Funcionario> GetAll(int empresa)
        {
            string query = $@" select 
              Set_Codigo,
              Cargo_Codigo,
              Fun_Nome,
              Fun_Rg,
              Fun_Cpf,
  			  Fun_Carteira_Profissional,
              Fun_Habilitacao,
              Fun_Cep,
              Fun_Endereco,
              Fun_Bairro,
              Fun_Numero,
			  Fun_Uf,
              Fun_Cidade,
              Fun_Compl,
              Fun_Telefone,
              Fun_Data_Nascimento,
              Fun_Sexo,
			  Fun_Comissao,
              Fun_Observacoes,
              Fun_Imagem_Foto,
              Fun_Email,
			  Ativo,
              Eh_Vendedor 
              from funcionario
              where Emp_Codigo=@empresa ";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Funcionario>(query, new
                {
                    empresa = empresa,
                }).ToList();
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

        public Funcionario GetById(int funCodigo,int empresa)
        {
            string query = $@" select 
              Set_Codigo,
              Cargo_Codigo,
              Fun_Nome,
              Fun_Rg,
              Fun_Cpf,
  			  Fun_Carteira_Profissional,
              Fun_Habilitacao,
              Fun_Cep,
              Fun_Endereco,
              Fun_Bairro,
              Fun_Numero,
			  Fun_Uf,
              Fun_Cidade,
              Fun_Compl,
              Fun_Telefone,
              Fun_Data_Nascimento,
              Fun_Sexo,
			  Fun_Comissao,
              Fun_Observacoes,
              Fun_Imagem_Foto,
              Fun_Email,
			  Ativo,
              Eh_Vendedor 
              from funcionario
              where Emp_Codigo=@empresa and fun_codigo=@funcionario";
            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Funcionario>(query, new
                {
                    empresa = empresa,
                    funcionario=funCodigo
                }).FirstOrDefault();
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

        public void Remove(int funcionario , int empresa)
        {
            string query = $@"delete from funcionario 
              where Emp_Codigo=@empresa and Fun_Codigo=@funcionario ";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new
                {
                    empresa = empresa,
                    funcionario = funcionario
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

        public void Update(Funcionario obj)
        {
            string query = $@"update funcionario set  
              Set_Codigo=@setor,
              Cargo_Codigo=@cargo,
              Fun_Nome=@nome,
              Fun_Rg=@rg,
              Fun_Cpf=@cpf,
  			  Fun_Carteira_Profissional=@carteiraprofissional,
              Fun_Habilitacao=@habilitacao,
              Fun_Cep=@cep,
              Fun_Endereco=@endereco,
              Fun_Bairro=@bairro,
              Fun_Numero=@numero,
			  Fun_Uf=@uf,
              Fun_Cidade=@cidade,
              Fun_Compl=@compl,
              Fun_Telefone=@telefone,
              Fun_Data_Nascimento=@datanascimento,
              Fun_Sexo=@sexo,
			  Fun_Comissao=@comissao,
              Fun_Observacoes=@observacoes,
              Fun_Imagem_Foto=@foto,
              Fun_Email=@email,
			  Ativo=@ativo,
              Eh_Vendedor=@ehvendedor
              where Emp_Codigo=@empresa and Fun_Codigo=@funcionario ";

            var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new
                {
                    setor = obj.Set_Codigo,
                    cargo = obj.Cargo_Codigo,
                    nome = obj.Fun_Nome,
                    rg = obj.Fun_Rg,
                    cpf = obj.Fun_Cpf,
                    carteiraprofissional = obj.Fun_Carteira_Profissional,
                    habilitacao = obj.Fun_Habilitacao,
                    cep = obj.Fun_Cep,
                    endereco = obj.Fun_Endereco,
                    bairro = obj.Fun_Bairro,
                    numero = obj.Fun_Numero,
                    uf = obj.Fun_Uf,
                    cidade = obj.Fun_Cidade,
                    compl = obj.Fun_Compl,
                    telefone = obj.Fun_Telefone,
                    datanascimento = obj.Fun_Data_Nascimento,
                    sexo = obj.Fun_Sexo,
                    comissao = obj.Fun_Comissao,
                    observacoes = obj.Fun_Observacoes,
                    email = obj.Fun_Email,
                    ativo = obj.Ativo,
                    ehvendedor = obj.Eh_Vendedor,
                    foto = obj.Fun_Foto,
                    empresa = obj.Emp_Codigo,
                    funcionario = obj.Fun_Codigo
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

        public Funcionario GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
