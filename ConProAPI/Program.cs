using ControladorProjetos.CamadaNegocio.Negocios;
using ControladorProjetos.CamadaRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

string cadeiaConexao = builder.Configuration.GetConnectionString( "ConProDb" );

builder.Services.AddDbContext<ConProContexto>( opcoes => opcoes.UseSqlServer( cadeiaConexao ) );
builder.Services.AddSingleton<ApontamentoNegocio>();
builder.Services.AddControllers().AddJsonOptions( opcao => opcao.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles );
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();