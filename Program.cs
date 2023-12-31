using System.Text.Json;
using IbgeApi.Data;
using IbgeApi.Data.Repositories.Implementations;
using IbgeApi.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Routing;

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

builder.Services.AddScoped<IIbgeRepository, IbgeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

string dbConfig = "Data Source=data.db;";
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(dbConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

#region IBGE
app.MapGet("/api/ibge", () => "IBGE");

app.MapGet("/api/ibge/id/{id}", (int id, IIbgeRepository ibgeRepository) =>
{
    try
    {
        var response = ibgeRepository.GetIbgeById(id);

        if (!response.Success)
        {
            return Results.NotFound(response.Message);
        }

        return Results.Ok(response.Item3);
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});

app.MapGet("/api/ibge/list-ibge", (IIbgeRepository ibgeRepository) =>
{
    try
    {
        var response = ibgeRepository.GetAllIbge();
        return Results.Ok(response);
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});

app.MapPost("/api/ibge/add-ibge", (IbgeApi.Data.DTO.IBGE.CreateIbge request, IIbgeRepository ibgeRepository) =>
{
    try
    {
        var response = ibgeRepository.AddIbge(request);
        if (response.Success)
        {
            return Results.Ok(response.Message);
        }
        else
        {
            return Results.BadRequest(response.Message);
        }
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});

app.MapPut("/api/ibge/update-ibge", (IbgeApi.Data.DTO.IBGE.Update request, IIbgeRepository ibgeRepository) =>
{
    try
    {
        var response = ibgeRepository.UpdateIbge(request);
        if (response.Success)
        {
            return Results.Ok(response.Message);
        }
        else
        {
            return Results.BadRequest(response.Message);
        }
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});

app.MapDelete("/api/ibge/delete-ibge/id/{ibgeId}", (int ibgeId, IIbgeRepository ibgeRepository) =>
{
    try
    {
        var response = ibgeRepository.DeleteIbge(ibgeId);
        if (response.Success)
        {
            return Results.Ok(response.Message);
        }
        else
        {
            return Results.BadRequest(response.Message);
        }
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});
#endregion

#region User
app.MapGet("/api/user/id/{userId}", (Guid userId, IUserRepository userRepository) =>
{
    try
    {
        var response = userRepository.GetUserById(userId);

        if (!response.Success)
        {
            return Results.NotFound(response.Message);
        }

        return Results.Ok(response.Item3);
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});

app.MapGet("/api/user/list-users", (IUserRepository userRepository) =>
{
    try
    {
        var response = userRepository.GetAllUsers();
        return Results.Ok(response);
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});

app.MapPost("/api/user/register", (IbgeApi.Data.DTO.User.CreateUser request, IUserRepository userRepository) =>
{
    try
    {
        var response = userRepository.RegisterUser(request);
        if (response.Success)
        {
            return Results.Ok(response.Message);
        }
        else
        {
            return Results.BadRequest(response.Message);
        }
    }
    catch (Exception error)
    {
        Console.WriteLine($"Erro interno do servidor: {error.Message}");
        return Results.StatusCode(500);
    }
});

/*
app.MapPost("/api/user/login", () => "Olá, Mundo");

app.MapPut("/api/user/update", () => "Olá, Mundo");

app.MapDelete("/api/user/delete", () => "Olá, Mundo");
*/
#endregion

app.Run();
