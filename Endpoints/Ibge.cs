namespace IbgeApi.Endpoints;

public static class Ibge
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/ibge", () => ("IBGE API Endpoint"));
    }
}