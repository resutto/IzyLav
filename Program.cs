using System.Text;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenXmlPowerTools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at  https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc(name: "v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "IzyLavApi",
        Description = "Api Lavanderia"
    });

    options.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de Autorização JWT está usando o esquema Bearer \r\n\r\n Digite 'Bearer' antes de colocar o Token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        Array.Empty<string>()
        }
    });

});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();

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

builder.Services.AddScoped<ICondicPagtoRepository, CondicPagtoRepository>();
builder.Services.AddScoped<ICondicPagtoService, CondicPagtoService>();

builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();

builder.Services.AddScoped<ICfopRepository, CfopRepository>();
builder.Services.AddScoped<ICfopService, CfopService>();

builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<ICargoService, CargoService>();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<ISegGrupoService, SegGrupoService>();
builder.Services.AddScoped<ISegGrupoRepository, SegGrupoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
