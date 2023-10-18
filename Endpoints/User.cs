namespace IbgeApi.Endpoints;

public static class User
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/users", () => ("User API Endpoint"));
    }
}