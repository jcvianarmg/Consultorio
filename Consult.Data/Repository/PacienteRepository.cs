using Consult.Core.Domain;
using Consult.Core.Shared.ModelViews;
using Consult.Data.Context;
using Consult.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consult.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ConsultContext context;

        public CancellationToken Id { get; private set; }

        public PacienteRepository(ConsultContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Core.Domain.Paciente>> GetPacientesAsync()
        {
            return await context.Pacientes.AsNoTracking().ToListAsync();
        }

        public async Task<Core.Domain.Paciente> GetPacienteAsync(int id)
        {
            return await context.Pacientes.FindAsync(id);
        }

        public async Task<Core.Domain.Paciente> InsertPacienteAsync(Core.Domain.Paciente paciente)
        {
            await context.Pacientes.AddAsync(paciente);
            await context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Core.Domain.Paciente> UpdatePacienteAsync(Core.Domain.Paciente paciente)
        {
            var buscaPaciente = await context.Pacientes.FindAsync(paciente.Id);
            if (buscaPaciente == null)
            {
                return null;
            }
            context.Entry(buscaPaciente).CurrentValues.SetValues(paciente);
            await context.SaveChangesAsync();
            return buscaPaciente;
        }

        public async Task DeletePacienteAsync(int id)
        {
            var consultaPaciente = await context.Pacientes.FindAsync(id);
            context.Pacientes.Remove(consultaPaciente);
            await context.SaveChangesAsync();
        }

        public Task<Core.Domain.Paciente> UpdatePacienteAsync(Core.Shared.ModelViews.AlteraPaciente alteraPaciente)
        {
            throw new System.NotImplementedException();
        }
    }
}
