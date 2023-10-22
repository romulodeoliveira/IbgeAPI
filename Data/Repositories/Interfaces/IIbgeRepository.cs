namespace IbgeApi.Data.Repositories.Interfaces;

public interface IIbgeRepository
{
    (bool Success, string Message, IbgeApi.Models.Ibge) GetIbgeById(int id);
    List<IbgeApi.Models.Ibge> GetAllIbge();
    (bool Success, string Message) AddIbge(IbgeApi.Data.DTO.IBGE.Create createDto);
    (bool Success, string Message) UpdateIbge(IbgeApi.Data.DTO.IBGE.Update createDto);
    (bool Success, string Message) DeleteIbge(int ibgeId);
}