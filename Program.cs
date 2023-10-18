using IbgeApi.Data;
using IbgeApi.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // documentação do swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "IBGE API",
        Description = "Projeto destinado a portfólio. Desenvolvido durante um desafio do Balta. :)",
        Contact = new OpenApiContact
        {
            Name = "Romulo de Oliveira",
            Email = "dev@romulodeoliveira.net",
            Url = new Uri("https://romulodeoliveira.net/"),
        },
        License = new OpenApiLicense
        {
            Name = "Licença",
            Url = new Uri("https://github.com/romulodeoliveira/"),
        }
    });
    
    // oauth2
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

string dbConfig = "Data Source=NomeDoBancoDeDados.db;";
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(dbConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    User.MapEndpoints(endpoints);
    Ibge.MapEndpoints(endpoints);
});

app.Run();
