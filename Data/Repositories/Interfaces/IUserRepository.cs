namespace IbgeApi.Data.Repositories.Interfaces;

public interface IUserRepository
{
    (bool Success, string Message, IbgeApi.Data.DTO.User.ListUser) GetUserById(Guid id);
    List<IbgeApi.Data.DTO.User.ListUser> GetAllUsers();
    (bool Success, string Message) RegisterUser(IbgeApi.Data.DTO.User.CreateUser createUserDto);
    (bool Success, string Message) UpdateUser(IbgeApi.Data.DTO.User.CreateUser createUserDto);
    (bool Success, string Message) DeleteUser(Guid userId);
}