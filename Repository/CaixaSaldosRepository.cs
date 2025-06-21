using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using System.Security.Policy;

namespace EgourmetAPI.Repository
{
    public class CaixaSaldosRepository : ICaixaSaldos
    {
        private IConfiguration _configuracoes;
        string conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public CaixaSaldosRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }


        public void Add(CaixaSaldos obj)
        {
            string query = $@"insert into caixa_saldos(
                              Emp_Codigo,
                              Sald_Codigo,
                              Conta_Codigo,
                              Data,
                              Saldo_Anterior,
                              Saldo_Dia,
                              Saldo_Atual,
                              Obs,
                              Ultimo,
                              Sit,
                              Tipo,
                              Usuario,
                              Hora,
                              Pc_Abriucx
                              Emp_Codigo,
                              Sald_Codigo,
                              Conta_Codigo,
                              Data,
                              Saldo_Anterior,
                              Saldo_Dia,
                              Saldo_Atual,
                              Obs,
                              Ultimo,
                              Sit,
                              Tipo,
                              Usuario,
                              Hora,
                              Pc_Abriucx
                            ) values (
                              @empresa,
                              @id,
                              @contacodigo,
                              @data,
                              @saldoanterior,
                              @saldodia,
                              @saldoatual,
                              @obs,
                              @ultimo,  
                              @sit,
                              @tipo,
                              @usuario,
                              @hora,
                              @pcabriucx)";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = obj.Emp_Codigo,
                    id=obj.Sald_Codigo,
                    contacodigo=obj.Conta_Codigo,
                    data=obj.Data,
                    saldoanterior=obj.Saldo_Anterior,
                    saldodia=obj.Saldo_Dia,
                    saldoatual=obj.Saldo_Atual,
                    obs=obj.Obs,
                    ultimo=obj.Ultimo,
                    sit=obj.Sit,
                    tipo=obj.Tipo,
                    usuario=obj.Usuario,
                    hora=obj.Hora,
                    pcabriucx=obj.Pc_Abriucx
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

        public IEnumerable<CaixaSaldos> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<CaixaSaldos> GetAll(int empresa)
        {
            string query = $@"select 
                              Emp_Codigo,
                              Sald_Codigo,
                              Conta_Codigo,
                              Data,
                              Saldo_Anterior,
                              Saldo_Dia,
                              Saldo_Atual,
                              Obs,
                              Ultimo,
                              Sit,
                              Tipo,
                              Usuario,
                              Hora,
                              Pc_Abriucx
                              Emp_Codigo,
                              Sald_Codigo,
                              Conta_Codigo,
                              Data,
                              Saldo_Anterior,
                              Saldo_Dia,
                              Saldo_Atual,
                              Obs,
                              Ultimo,
                              Sit,
                              Tipo,
                              Usuario,
                              Hora,
                              Pc_Abriucx
                            from caixa_saldos where
                            emp_codigo=@empresa";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<CaixaSaldos>(query, new
                {
                    empresa = empresa
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

        public CaixaSaldos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(int empresa, int saldoid)
        {
            string query = $@" delete from caixa_saldos
                            where
                              emp_codigo=@empresa and
                              sald_codigo=@id";

            var connection = new FbConnection(conexao);

            try
            {
                connection.Execute(query, new
                {
                    empresa = empresa,
                    id = saldoid
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

        public void Update(CaixaSaldos obj)
        {
            throw new NotImplementedException();
        }
    }
}
