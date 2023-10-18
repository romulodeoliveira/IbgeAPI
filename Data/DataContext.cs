using IbgeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IbgeApi.Data;

class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Ibge> Users { get; set; }
    public DbSet<User> Posts { get; set; }
}
