using IbgeApi.Models;

namespace IbgeApi.Data.Repositories.Implementations;

public class IbgeRepository : IbgeApi.Data.Repositories.Interfaces.IIbgeRepository
{
    private readonly DataContext _dataContext;

    public IbgeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public (bool Success, string Message, Ibge) GetIbgeById(int id)
    {
        try
        {
            var response = _dataContext.Ibges.FirstOrDefault(x => x.Id == id);

            if (response == null)
            {
                return (
                    false,
                    "Dados IBGE não encontrados.", 
                    new Ibge());
            }

            return (
                true, 
                "",
                new Ibge()
                {
                    Id = response.Id,
                    City = response.City,
                    State = response.State
                });
        }
        catch (Exception error)
        {
            Console.WriteLine($"Erro interno do servidor: {error.Message}");
            return (
                false, 
                $"Erro interno do servidor: {error.Message}",
                new Ibge());
        }
    }

    public List<Ibge> GetAllIbge()
    {
        return _dataContext.Ibges.ToList();
    }

    public (bool Success, string Message) AddIbge(DTO.Ibge ibgeDto)
    {
        throw new NotImplementedException();
    }

    public (bool Success, string Message) UpdateIbge(DTO.Ibge ibgeDto)
    {
        throw new NotImplementedException();
    }

    public (bool Success, string Message) DeleteIbge(Guid ibgeId)
    {
        throw new NotImplementedException();
    }
}