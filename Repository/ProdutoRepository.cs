using Dapper;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.common;
using Model;

namespace EgourmetAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private IConfiguration _configuracoes;
        string conexao  { get {  return _configuracoes.GetConnectionString("firedb"); } }
        
        public ProdutoRepository(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }

        public void Add(Produto obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll(int empCodigo)
        {
            string query = $@" select  
                        Pro_Codigo,
                        emp_codigo, 
                        for_codigo,  
                        unid_codigo,  
                        grup_codigo,  
                        fam_codigo,  
                        pro_data_cadastro,
                        fab_codigo,
                        pro_custo,
                        pro_preco_venda,
                        pro_ultima_compra, 
                        pro_ultima_venda,
                        pro_estoque_minimo,
                        pro_estoque_atual,
                        pro_estoque_previsto,  
                        pro_imagem1,
                        pro_localizacao,
                        pro_observacao,
                        pro_barra,
                        pro_baixa_automatica,
                        pro_modelo,
                        pro_peso_unitario,
                        pro_altura,
                        pro_largura,
                        pro_icms,
                        pro_sit,
                        cli_codigo,
                        prod_comissao,
                        conta_codigo,
                        pro_tipo,
                        codfornec,
                        pro_indice,
                        desabilitado,
                        pro_perc,
                        mostrar_materia,
                        pro_marca,
                        pro_referencia,
                        pro_descricao,
                        descricaob,
                        descrfiscal,
                        ncm,
                        unid_codigovenda,  
                        cod_impressora,
                        pro_custo_medio,
                        cfop_out,  
                        cst_out,  
                        regime,
                        origem_nfe,
                        taxaservico, 
                        pro_cst_ipi,
                        pro_perc_ipi,  
                        pro_cst_pis,
                        pro_perc_pis,
                        pro_cst_cofins,
                        pro_perc_cofins,
                        itemservico,
                        pro_dtvalidade,
                        dtalter,  
                        dtsinc from produto where emp_codigo=@empresa";

            var connection = new FbConnection(conexao);

            try
            {
               return connection.Query<Produto>(query, new {empresa=empCodigo}).ToList();

            } catch (Exception ex) {

                throw ex;
            }
            finally
            {
                connection.Close();
            }


        }

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Produto GetByProCodigoeEmpresa(string produto, int empresa)
        {
            string query = $@" 
                        select  
                        Pro_Codigo,
                        emp_codigo, 
                        for_codigo,  
                        unid_codigo,  
                        grup_codigo,  
                        fam_codigo,  
                        pro_data_cadastro,
                        fab_codigo,
                        pro_custo,
                        pro_preco_venda,
                        pro_ultima_compra, 
                        pro_ultima_venda,
                        pro_estoque_minimo,
                        pro_estoque_atual,
                        pro_estoque_previsto,  
                        pro_imagem1,
                        pro_localizacao,
                        pro_observacao,
                        pro_barra,
                        pro_baixa_automatica,
                        pro_modelo,
                        pro_peso_unitario,
                        pro_altura,
                        pro_largura,
                        pro_icms,
                        pro_sit,
                        cli_codigo,
                        prod_comissao,
                        conta_codigo,
                        pro_tipo,
                        codfornec,
                        pro_indice,
                        desabilitado,
                        pro_perc,
                        mostrar_materia,
                        pro_marca,
                        pro_referencia,
                        pro_descricao,
                        descricaob,
                        descrfiscal,
                        ncm,
                        unid_codigovenda,  
                        cod_impressora,
                        pro_custo_medio,
                        cfop_out,  
                        cst_out,  
                        regime,
                        origem_nfe,
                        taxaservico, 
                        pro_cst_ipi,
                        pro_perc_ipi,  
                        pro_cst_pis,
                        pro_perc_pis,
                        pro_cst_cofins,
                        pro_perc_cofins,
                        itemservico,
                        pro_dtvalidade,
                        dtalter,  
                        dtsinc from produto where emp_codigo=@empresa and pro_codigo=@produto";

            var connection = new FbConnection(conexao);
            try
            {
                return connection.Query<Produto>(query, new {empresa=empresa,produto=produto}).FirstOrDefault();
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

        public void RemoveProduto(string produto, int empresa)
        {
            string query = $@"delete from produto where emp_codigo=@empresa and pro_codigo=@pro_codigo";
            using var connection = new FbConnection(conexao);
            try
            {
                connection.Execute(query, new { empresa = empresa, pro_codigo = produto });
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

        public void Update(Produto produto)
        {
            string query = $@" 
                        update produto set  
                        for_codigo=@for_codigo,  
                        unid_codigo=@unid_codigo,  
                        grup_codigo=@grup_codigo,  
                        fam_codigo=@fam_codigo,  
                        fab_codigo=@fab_codigo,
                        pro_custo=@pro_custo,
                        pro_preco_venda=@pro_preco_venda,
                        pro_estoque_minimo=@pro_estoque_minimo,
                        pro_imagem1=@pro_imagem1,
                        pro_localizacao=@pro_localizacao,
                        pro_observacao=@pro_observacao,
                        pro_barra=@pro_barra,
                        pro_baixa_automatica=@pro_baixa_automatica,
                        pro_peso_unitario=@pro_peso_unitario,
                        pro_altura=@pro_altura,
                        pro_largura=@pro_largura,
                        pro_icms=@pro_icms,
                        pro_sit=@pro_sit,
                        cli_codigo=@cli_codigo,
                        conta_codigo=@conta_codigo,
                        pro_tipo=@pro_tipo,
                        codfornec=@codfornec,
                        pro_indice=@pro_indice,
                        desabilitado=@desabilitado,
                        pro_perc=@pro_perc,
                        mostrar_materia=@mostrar_materia,
                        pro_marca=@pro_marca,
                        pro_referencia=@pro_referencia,
                        pro_descricao=@pro_descricao,
                        descricaob=@descricaob,
                        descrfiscal=@descrfiscal,
                        ncm=@ncm,
                        pro_custo_medio=@pro_custo_medio,
                        cfop_out=@cfop_out,  
                        cst_out=@cst_out,  
                        regime=@regime,
                        origem_nfe=@origem_nfe,
                        pro_cst_ipi=@pro_cst_ipi,
                        pro_perc_ipi=@pro_perc_ipi,  
                        pro_cst_pis=@pro_cst_pis,
                        pro_perc_pis=@pro_perc_pis,
                        pro_cst_cofins=@pro_cst_cofins,
                        pro_perc_cofins=@pro_perc_cofins,
                        itemservico=@itemservico
                    where
                        Pro_Codigo=@Pro_Codigo and 
                        emp_codigo=@emp_codigo ";
            
            var connection = new FbConnection(conexao);
            try {

                connection.Execute(query, new {
                    for_codigo = produto.For_Codigo,
                    unid_codigo = produto.Unid_Codigo,
                    grup_codigo = produto.Grup_Codigo,
                    fam_codigo = produto.Fam_Codigo,
                    fab_codigo = produto.Fab_Codigo,
                    pro_custo = produto.Pro_Custo,
                    pro_preco_venda = produto.Pro_Preco_Venda,
                    pro_estoque_minimo = produto.Pro_Estoque_Minimo,
                    pro_imagem1 = produto.Pro_Imagem1,
                    pro_localizacao = produto.Pro_Localizacao,
                    pro_observacao = produto.Pro_Observacao,
                    pro_barra = produto.Pro_Barra,
                    pro_baixa_automatica = produto.Pro_Baixa_Automatica,
                    pro_peso_unitario = produto.Pro_Peso_Unitario,
                    pro_altura = produto.Pro_Altura,
                    pro_largura = produto.Pro_Largura,
                    pro_icms = produto.Pro_Icms,
                    pro_sit = produto.Pro_Sit,
                    cli_codigo = produto.Pro_Codigo,
                    conta_codigo = produto.Conta_Codigo,
                    pro_tipo = produto.Pro_Tipo,
                    codfornec = produto.Codfornec,
                    pro_indice = produto.Pro_Indice,
                    desabilitado = produto.Desabilitado,
                    pro_perc = produto.Pro_Perc,
                    mostrar_materia = produto.Mostrar_Materia,
                    pro_marca = produto.Pro_Marca,
                    pro_referencia = produto.Pro_Referencia,
                    pro_descricao = produto.Pro_Descricao,
                    descricaob = produto.Descricaob,
                    descrfiscal = produto.Descrfiscal,
                    ncm = produto.Ncm,
                    pro_custo_medio = produto.Pro_Custo_Medio,
                    cfop_out = produto.Cfop_Out,
                    cst_out = produto.Cst_Out,
                    regime = produto.Regime,
                    origem_nfe = produto.Origem_Nfe,
                    pro_cst_ipi = produto.Pro_Cst_Ipi,
                    pro_perc_ipi = produto.Pro_Perc_Ipi,
                    pro_cst_pis = produto.Pro_Cst_Pis,
                    pro_perc_pis = produto.Pro_Perc_Pis,
                    pro_cst_cofins = produto.Pro_Cst_Cofins,
                    pro_perc_cofins = produto.Pro_Perc_Cofins,
                    itemservico = produto.Itemservico,
                    Pro_Codigo = produto.Pro_Codigo,
                    emp_codigo = produto.Emp_Codigo
                });

            } catch( Exception ex)
            {
                throw ex;
            } finally { connection.Close(); }
            


        }

        public ResponseMessage Adicionar(Produto produto)
        {
            string query = $@" 
                        insert into produto(  
                        Pro_Codigo,
                        emp_codigo, 
                        for_codigo,  
                        unid_codigo,  
                        grup_codigo,  
                        fam_codigo,  
                        pro_data_cadastro,
                        fab_codigo,
                        pro_custo,
                        pro_preco_venda,
                        pro_ultima_compra, 
                        pro_ultima_venda,
                        pro_estoque_minimo,
                        pro_estoque_atual,
                        pro_estoque_previsto,  
                        pro_imagem1,
                        pro_localizacao,
                        pro_observacao,
                        pro_barra,
                        pro_baixa_automatica,
                        pro_modelo,
                        pro_peso_unitario,
                        pro_altura,
                        pro_largura,
                        pro_icms,
                        pro_sit,
                        cli_codigo,
                        conta_codigo,
                        pro_tipo,
                        codfornec,
                        pro_indice,
                        desabilitado,
                        pro_perc,
                        mostrar_materia,
                        pro_marca,
                        pro_referencia,
                        pro_descricao,
                        descricaob,
                        descrfiscal,
                        ncm,
                        unid_codigovenda,  
                        cod_impressora,
                        pro_custo_medio,
                        cfop_out,  
                        cst_out,  
                        regime,
                        origem_nfe,
                        pro_cst_ipi,
                        pro_perc_ipi,  
                        pro_cst_pis,
                        pro_perc_pis,
                        pro_cst_cofins,
                        pro_perc_cofins,
                        itemservico) 
                        
                    values(
                    
                        @Pro_Codigo,
                        @emp_codigo, 
                        @for_codigo,  
                        @unid_codigo,  
                        @grup_codigo,  
                        @fam_codigo,  
                        (select timestamp 'NOW' from rdb$database),
                        @fab_codigo,
                        @pro_custo,
                        @pro_preco_venda,
                        @pro_ultima_compra, 
                        @pro_ultima_venda,
                        @pro_estoque_minimo,
                        @pro_estoque_atual,
                        @pro_estoque_previsto,  
                        @pro_imagem1,
                        @pro_localizacao,
                        @pro_observacao,
                        @pro_barra,
                        @pro_baixa_automatica,
                        @pro_modelo,
                        @pro_peso_unitario,
                        @pro_altura,
                        @pro_largura,
                        @pro_icms,
                        @pro_sit,
                        @cli_codigo,
                        @conta_codigo,
                        @pro_tipo,
                        @codfornec,
                        @pro_indice,
                        @desabilitado,
                        @pro_perc,
                        @mostrar_materia,
                        @pro_marca,
                        @pro_referencia,
                        @pro_descricao,
                        @descricaob,
                        @descrfiscal,
                        @ncm,
                        @unid_codigovenda,  
                        @cod_impressora,
                        @pro_custo_medio,
                        @cfop_out,  
                        @cst_out,  
                        @regime,
                        @origem_nfe,
                        @pro_cst_ipi,
                        @pro_perc_ipi,  
                        @pro_cst_pis,
                        @pro_perc_pis,
                        @pro_cst_cofins,
                        @pro_perc_cofins,
                        @itemservico) ";

            Response<Produto> resposta = new Response<Produto>(); 

            var connection = new FbConnection(conexao);
            try
            {
                IdLanc que1 = Datpai.GerarIdLanc(produto.Emp_Codigo, connection, 
                                                 "select (cast(pro_codigo as integer)+1) as IdLanc from produto where emp_codigo=@empresa");
                
                resposta.Data = produto;
                resposta.Status = 400;

                connection.Execute(query, new { 
                    Pro_Codigo=que1.idLanc,
                    emp_codigo=produto.Emp_Codigo,
                    for_codigo=produto.For_Codigo,
                    unid_codigo=produto.Unid_Codigo,
                    grup_codigo = produto.Grup_Codigo,
                    fam_codigo = produto.Fam_Codigo,
                    fab_codigo = produto.Fab_Codigo,
                    pro_custo = produto.Pro_Custo,
                    pro_preco_venda = produto.Pro_Preco_Venda,
                    pro_ultima_compra = produto.Pro_Ultima_Compra,
                    pro_ultima_venda = produto.Pro_Ultima_Venda,
                    pro_estoque_minimo = produto.Pro_Estoque_Minimo,
                    pro_estoque_atual = produto.Pro_Estoque_Atual,
                    pro_estoque_previsto = produto.Pro_Estoque_Previsto,
                    pro_imagem1 = produto.Pro_Imagem1,
                    pro_localizacao = produto.Pro_Localizacao,
                    pro_observacao = produto.Pro_Observacao,
                    pro_barra = produto.Pro_Barra,
                    pro_baixa_automatica = produto.Pro_Baixa_Automatica,
                    pro_modelo = produto.Pro_Modelo,
                    pro_peso_unitario = produto.Pro_Peso_Unitario,
                    pro_altura = produto.Pro_Altura,
                    pro_largura = produto.Pro_Largura,
                    pro_icms = produto.Pro_Icms,
                    pro_sit = produto.Pro_Sit,
                    cli_codigo = produto.Pro_Codigo,
                    conta_codigo = produto.Conta_Codigo,
                    pro_tipo = produto.Pro_Tipo,
                    codfornec = produto.Codfornec,
                    pro_indice = produto.Pro_Indice,
                    desabilitado = produto.Desabilitado,
                    pro_perc = produto.Pro_Perc,
                    mostrar_materia = produto.Mostrar_Materia,
                    pro_marca = produto.Pro_Marca,
                    pro_referencia = produto.Pro_Referencia,
                    pro_descricao = produto.Pro_Descricao,
                    descricaob = produto.Descricaob,
                    descrfiscal = produto.Descrfiscal,
                    ncm = produto.Ncm,
                    unid_codigovenda = produto.Unid_Codigovenda,
                    cod_impressora = produto.Cod_Impressora,
                    pro_custo_medio = produto.Pro_Custo_Medio,
                    cfop_out = produto.Cfop_Out,
                    cst_out = produto.Cst_Out,
                    regime = produto.Regime,
                    origem_nfe = produto.Origem_Nfe,
                    pro_cst_ipi = produto.Pro_Cst_Ipi,
                    pro_perc_ipi = produto.Pro_Perc_Ipi,
                    pro_cst_pis = produto.Pro_Cst_Pis,
                    pro_perc_pis = produto.Pro_Perc_Pis,
                    pro_cst_cofins = produto.Pro_Cst_Cofins,
                    pro_perc_cofins = produto.Pro_Perc_Cofins,
                    itemservico = produto.Itemservico
                });

            } 
            catch (Exception ex) {
                resposta.Message = ex.Message;
                resposta.Status = 400;
            }
            finally { 
                connection.Close();
            }
            return resposta;
        }

        ResponseMessage IProdutoRepository.Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAllClientesPorEmpresa(int empCodigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetPorGrupo(int empCodigo, int grupoCodigo)
        {
            string query = $@" select  
                        Pro_Codigo,
                        emp_codigo, 
                        for_codigo,  
                        unid_codigo,  
                        grup_codigo,  
                        CAST(pro_preco_venda AS DOUBLE PRECISION) as pro_preco_venda,
                        pro_imagem1,
                        pro_barra,
                        pro_descricao from produto where emp_codigo=@empresa and grup_codigo=@grupo";

            var connection = new FbConnection(conexao);

            try
            {
                return connection.Query<Produto>(query, new { empresa = empCodigo, grupo=grupoCodigo }).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }


        }

    }
}
