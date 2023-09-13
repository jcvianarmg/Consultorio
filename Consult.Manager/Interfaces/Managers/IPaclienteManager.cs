using Consult.Core.Shared.ModelViews.Paciente;

namespace Consult.Manager.Interfaces.Managers;

public interface IPacienteManager
{
    Task<PacienteView> DeletePacienteAsync(int id);

    Task<PacienteView> GetPacienteAsync(int id);

    Task<IEnumerable<PacienteView>> GetPacientesAsync();

    Task<PacienteView> InsertPacienteAsync(NovoPaciente paciente);

    Task<PacienteView> UpdatePacienteAsync(AlteraPaciente paciente);
}