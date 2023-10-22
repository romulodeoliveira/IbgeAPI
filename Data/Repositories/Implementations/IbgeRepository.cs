using IbgeApi.Models;

namespace IbgeApi.Data.Repositories.Implementations;

public class IbgeRepository : IbgeApi.Data.Repositories.Interfaces.IIbgeRepository
{
    private readonly DataContext _dataContext;

    public IbgeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public (bool Success, string Message, Models.Ibge) GetIbgeById(int id)
    {
        try
        {
            var response = _dataContext.Ibges.FirstOrDefault(x => x.Id == id);

            if (response == null)
            {
                return (
                    false,
                    "Dados IBGE não encontrados.", 
                    new Models.Ibge());
            }

            return (
                true, 
                "",
                new Models.Ibge()
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
                new Models.Ibge());
        }
    }

    public List<Models.Ibge> GetAllIbge()
    {
        return _dataContext.Ibges.ToList();
    }

    public (bool Success, string Message) AddIbge(DTO.Ibge request)
    {
        try
        {
            var model = new Models.Ibge();
            
            if (!string.IsNullOrEmpty(request.State))
            {
                model.State = request.State;
            }
            else
            {
                return (false, "Estado não pode estar em branco");
            }
            
            if (!string.IsNullOrEmpty(request.City))
            {
                model.City = request.City;
            }
            else
            {
                return (false, "Cidade não pode estar em branco");
            }

            _dataContext.Ibges.Add(model);
            _dataContext.SaveChanges();

            return (true, "Dados cadastrados.");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Erro interno do servidor: {error.Message}");
            return (false, $"Erro interno do servidor: {error.Message}");
        }
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