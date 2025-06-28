using egourmetAPI;
using egourmetAPI.Repository;
using egourmetAPI.Repository.Interface;
using egourmetAPI.Service;
using egourmetAPI.Service.Interface;
using EgourmetAPI.Repository;
using EgourmetAPI.Repository.Interface;
using IzyLav.Repository;
using IzyLav.Repository.Interface;
using IzyLav.Services;
using IzyLav.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at  https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmpresaRepository,EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService,EmpresaService>();

builder.Services.AddScoped<IMaquinaTipoRepository, MaquinaTipoRepository>();
builder.Services.AddScoped<IMaquinaTipoService, MaquinaTipoService>();

builder.Services.AddScoped<ICreditosRepository, CreditosRepository>();
builder.Services.AddScoped<ICreditosService, CreditosService>();

builder.Services.AddScoped<IMaquinasRepository, MaquinasRepository>();
builder.Services.AddScoped<IMaquinasService, MaquinasService>();

builder.Services.AddScoped<IMaquinasEtapas, MaquinasEtapasRepository>();
builder.Services.AddScoped<IMaquinasEtapasService, MaquinasEtapasServices>();

builder.Services.AddScoped<IMaquinasExecucaoRepository, MaquinasExecucaoRepository>();
builder.Services.AddScoped<IMaquinasExecucaoService, MaquinasExecucaoService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

builder.Services.AddScoped<IOrcamentosRepository, OrcamentosRepository>();
builder.Services.AddScoped<IOrcamentosService, OrcamentosService>();

builder.Services.AddScoped<IOrcamentosDetalheRepository, OrcamentosDetalheRepository>();
builder.Services.AddScoped<IOrcamentosDetalheService, OrcamentosDetalheService>();

builder.Services.AddScoped<IUfRepository, UfRepository>();
builder.Services.AddScoped<IUfService, UfService>();

builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<IUnidadeService, UnidadeService>();

builder.Services.AddScoped<IAplicacoesRepository, AplicacoesRepository>();
builder.Services.AddScoped<IAplicacoesService, AplicacoesService>();

builder.Services.AddScoped<IUsuarioFuncionarioRepository, UsuarioFuncionarioRepository>();
builder.Services.AddScoped<IUsuarioFuncionarioService, UsuarioFuncionarioService>();

builder.Services.AddScoped<IUsuarioAplicRepository, UsuarioAplicRepository>();
builder.Services.AddScoped<IUsuarioAplicService, UsuarioAplicService>();

builder.Services.AddScoped<ISetorRepository, SetorRepository>();
builder.Services.AddScoped<ISetorService, SetorService>();

builder.Services.AddScoped<ISaldoProdutoRepository, SaldoProdutoRepository>();
builder.Services.AddScoped<ISaldoProdutoService, SaldoProdutoService>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
builder.Services.AddScoped<IGrupoService, GrupoService>();

builder.Services.AddScoped<IFamiliaRepository, FamiliaRepository>();
builder.Services.AddScoped<IFamiliaService, FamiliaService>();

builder.Services.AddScoped<IFormaPagtoRepository, FormaPagtoRepository>();
builder.Services.AddScoped<IFormaPagtoService, FormaPagtoService>();

builder.Services.AddScoped<IFormaQdeDiasRepository, FormaQdeDiasRepository>();
builder.Services.AddScoped<IFormaQdeDiasService, FormaQdeDiasService>();

builder.Services.AddScoped<IDepositoRepository, DepositoRepository>();
builder.Services.AddScoped<IDepositoService, DepositoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
