using Consult.Core.Domain;
using Consult.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consult.Manager.Interfaces
{
    public interface IPacienteRepository
    {
        Task DeletePacienteAsync(int id);
        Task<Paciente> GetPacienteAsync(int id);

        Task<IEnumerable<Core.Domain.Paciente>> GetPacientesAsync();
        Task<Paciente> InsertPacienteAsync(Core.Domain.Paciente paciente);
        Task<Paciente> UpdatePacienteAsync(Core.Domain.Paciente paciente);
        Task<Paciente> UpdatePacienteAsync(Core.Shared.ModelViews.AlteraPaciente alteraPaciente);
    }
}
