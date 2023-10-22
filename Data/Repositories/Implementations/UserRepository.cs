using IbgeApi.Models;

namespace IbgeApi.Data.Repositories.Implementations;

public class UserRepository : IbgeApi.Data.Repositories.Interfaces.IUserRepository
{
    public User GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public (bool Success, string Message) AddUser(DTO.User.Create createDto)
    {
        throw new NotImplementedException();
    }

    public (bool Success, string Message) UpdateUser(DTO.User.Create createDto)
    {
        throw new NotImplementedException();
    }

    public (bool Success, string Message) DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}