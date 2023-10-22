using IbgeApi.Models;

namespace IbgeApi.Data.Repositories.Implementations;

public class UserRepository : IbgeApi.Data.Repositories.Interfaces.IUserRepository
{
    private readonly DataContext _dataContext;
    
    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public (bool Success, string Message, IbgeApi.Models.User) GetUserById(Guid id)
    {
        try
        {
            var response = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            
            if (response == null)
            {
                return (
                    false,
                    "Usuário não encontrado.", 
                    new Models.User());
            }
            
            return (
                true, 
                "",
                new Models.User()
                {
                    Id = response.Id,
                    Firstname = response.Firstname,
                    Lastname = response.Lastname,
                    Email = response.Email
                });
        }
        catch (Exception error)
        {
            Console.WriteLine($"Erro interno do servidor: {error.Message}");
            return (false, $"Erro interno do servidor: {error.Message}", new Models.User());
        }
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