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
        Task<Core.Domain.Paciente> GetPacienteAsync(int id);

        Task<IEnumerable<Core.Domain.Paciente>> GetPacientesAsync();
        Task<Core.Domain.Paciente> InsertPacienteAsync(Core.Domain.Paciente paciente);
        Task<Core.Domain.Paciente> UpdatePacienteAsync(Core.Domain.Paciente paciente);
        Task<Core.Domain.Paciente> UpdatePacienteAsync(Core.Shared.ModelViews.AlteraPaciente alteraPaciente);
    }
}
