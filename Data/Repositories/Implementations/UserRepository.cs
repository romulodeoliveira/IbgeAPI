using IbgeApi.Data.DTO.User;
using IbgeApi.Models;

namespace IbgeApi.Data.Repositories.Implementations;

public class UserRepository : IbgeApi.Data.Repositories.Interfaces.IUserRepository
{
    private readonly DataContext _dataContext;
    
    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public (bool Success, string Message, IbgeApi.Data.DTO.User.ListUser) GetUserById(Guid id)
    {
        try
        {
            var model = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            
            if (model == null)
            {
                return (
                    false,
                    "Usuário não encontrado.", 
                    new IbgeApi.Data.DTO.User.ListUser());
            }
            
            var response = new IbgeApi.Data.DTO.User.ListUser
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email
            };
            
            return (
                true,
                "",
                response);
        }
        catch (Exception error)
        {
            Console.WriteLine($"Erro interno do servidor: {error.Message}");
            return (false, $"Erro interno do servidor: {error.Message}", new ListUser());
        }
    }

    public List<IbgeApi.Data.DTO.User.ListUser> GetAllUsers()
    {
        var users = _dataContext.Users.ToList();
        
        var userDTOs = users.Select(user => new ListUser 
        {
            Id = user.Id,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = user.Email
        }).ToList();

        return userDTOs;
    }

    public (bool Success, string Message) RegisterUser(DTO.User.CreateUser request)
    {
        try
        {
            var emailInUse = _dataContext.Users.FirstOrDefault(User => User.Email == request.Email);
            if (emailInUse != null)
            {
                return (false, "E-mail em uso.");
            }

            var password = new IbgeApi.Authentication.Password();

            if (!password.CheckerStrongPassword(request.Password))
            {
                return (false, "Senha não aceita. Insira uma senha de 6 a 12 caracteres e que tenha pelo menos uma letra maiuscula, uma minuscula, um numero e um caractere especial.");
            }

            if (!IbgeApi.Authentication.Email.IsValidEmail(request.Email))
            {
                return (false, "Email inválido!");
            }
            
            password.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            var user = new User()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return (true, "Usuário cadastrado.");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Erro interno do servidor: {error.Message}");
            return (false, $"Erro interno do servidor: {error.Message}");
        }
    }

    public (bool Success, string Message) UpdateUser(DTO.User.CreateUser createUserDto)
    {
        throw new NotImplementedException();
    }

    public (bool Success, string Message) DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}