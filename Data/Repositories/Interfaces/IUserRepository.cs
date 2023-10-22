namespace IbgeApi.Data.Repositories.Interfaces;

public interface IUserRepository
{
    (bool Success, string Message, IbgeApi.Models.User) GetUserById(Guid id);
    List<IbgeApi.Models.User> GetAllUsers();
    (bool Success, string Message) AddUser(IbgeApi.Data.DTO.User.Create createDto);
    (bool Success, string Message) UpdateUser(IbgeApi.Data.DTO.User.Create createDto);
    (bool Success, string Message) DeleteUser(Guid userId);
}