using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DataAccess.Concrete.Context;

public class WeatherDbContext : DbContext
{
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=WeatherDb;Trusted_Connection=True;");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Satellite> Satellites { get; set; }
}
