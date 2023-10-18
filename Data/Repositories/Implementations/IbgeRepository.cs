using IbgeApi.Models;

namespace IbgeApi.Data.Repositories.Implementations;

public class IbgeRepository : IbgeApi.Data.Repositories.Interfaces.IIbgeRepository
{
    public Ibge GetIbgeById(int id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAllIbge()
    {
        throw new NotImplementedException();
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