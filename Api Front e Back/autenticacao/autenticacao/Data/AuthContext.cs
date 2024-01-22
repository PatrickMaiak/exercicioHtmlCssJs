using Microsoft.EntityFrameworkCore;

namespace autenticacao.Data
{
    public class AuthContext : DbContext
    {

        public AuthContext(DbContextOptions options):base(options) 
        {
        }
        
         public DbSet<autenticacao.Models.User> User { get; set; }
    }
}
