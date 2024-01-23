using Microsoft.EntityFrameworkCore;
using CrudDeProduto.Models;
namespace CrudDeProduto.Data
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
