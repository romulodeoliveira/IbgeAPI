using IbgeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IbgeApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Ibge> Ibges { get; set; }
    public DbSet<User> Users { get; set; }
}
