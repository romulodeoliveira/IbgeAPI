namespace IbgeApi.Data.DTO.User;

public class CreateUser
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}