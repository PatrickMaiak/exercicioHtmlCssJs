using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ORM.Models;

namespace ORM.Data
{
    public class ORMContext : DbContext
    {
        public ORMContext (DbContextOptions<ORMContext> options)
            : base(options)
        {
        }

        public DbSet<ORM.Models.Contato> Contato { get; set; } = default!;

        public DbSet<ORM.Models.Local>? Local { get; set; }

        public DbSet<ORM.Models.Compromisso>? Compromisso { get; set; }
    }
}
