namespace IbgeApi.Data.DTO.User;

public class ListUser
{
    public Guid Id { get; set; } = new Guid();
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string Email { get; set; }
}