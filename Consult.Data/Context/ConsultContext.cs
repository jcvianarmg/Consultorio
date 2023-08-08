using Consult.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consult.Data.Context
{
    public class ConsultContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        
        public ConsultContext(DbContextOptions options) : base(options) 
        { 
        }       
    }
}
