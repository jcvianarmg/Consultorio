using Consult.Core.Domain;
using Consult.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Consult.Manager.Interfaces
{
    public interface IPacienteManager
    {
        Task DeletePacienteAsync(int id);

        Task<Paciente> GetPacienteAsync(int id);
  
        Task<IEnumerable<Paciente>> GetPacientesAsync();

        Task<Paciente> InsertPacienteAsync(NovoPaciente paciente);

        Task<Paciente> UpdatePacienteAsync(AlteraPaciente alteraPaciente);
    }
}
