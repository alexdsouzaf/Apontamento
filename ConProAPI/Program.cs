using CamadaNegocio.Negocios;
using CamadaRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

// Add services to the container.

string cadeiaConexao = builder.Configuration.GetConnectionString( "ConProDb" );

builder.Services.AddDbContext<ConProContexto>( opcoes => opcoes.UseSqlServer( cadeiaConexao ) );
builder.Services.AddScoped<ImplementacaoNegocio>();
builder.Services.AddScoped<ApontamentoNegocio>();
builder.Services.AddControllers().AddJsonOptions( opcao => opcao.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles );
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI( item =>
    {
        item.SwaggerEndpoint( "/swagger/v1/swagger.json", "ConProAPI" );
        item.InjectStylesheet( "/swagger/custom.css" );
    } );

    app.UseHsts();
}

app.UseDeveloperExceptionPage( new DeveloperExceptionPageOptions() );
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();