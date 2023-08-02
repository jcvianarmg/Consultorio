using Cons.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cons.Data.Context
{
    public class ConsContext : DbContext
    {
       public DbSet<Paciente> Pacientes { get; set;  }

        public ConsContext(DbContextOptions options) : base(options) 
        { 
        
        }
            

    }
}
