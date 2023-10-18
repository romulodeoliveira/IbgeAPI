namespace IbgeApi.Models;

public class User
{
    public Guid Id { get; set; } = new Guid();
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}

