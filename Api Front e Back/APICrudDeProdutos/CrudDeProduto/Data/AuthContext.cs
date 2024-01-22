using Microsoft.EntityFrameworkCore;

namespace CrudDeProduto.Data
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<CrudDeProduto.Models.User> Users { get; set; }
    }
}
