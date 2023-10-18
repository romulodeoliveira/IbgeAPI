namespace IbgeApi.Data.Repositories.Interfaces;

public interface IIbgeRepository
{
    IbgeApi.Models.Ibge GetIbgeById(int id);
    List<IbgeApi.Models.User> GetAllIbge();
    (bool Success, string Message) AddIbge(IbgeApi.Data.DTO.Ibge ibgeDto);
    (bool Success, string Message) UpdateIbge(IbgeApi.Data.DTO.Ibge ibgeDto);
    (bool Success, string Message) DeleteIbge(Guid ibgeId);
}