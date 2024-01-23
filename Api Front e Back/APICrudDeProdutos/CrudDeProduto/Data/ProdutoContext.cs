using System.Collections.Generic;
using CrudDeProduto.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDeProduto.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
        : base(options)
        {
        }

        public DbSet<TodoProduto> TodoProduto { get; set; } = null!;
        public DbSet<Categoria> Categoria { get; set; } = null!;
        public DbSet<CrudDeProduto.Models.User> User { get; set; } = default!;
    }
}
