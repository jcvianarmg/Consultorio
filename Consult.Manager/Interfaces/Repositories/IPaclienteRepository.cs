namespace Consult.Manager.Interfaces.Repositories;

public interface IPacienteRepository
{
    Task<Paciente> DeletePacienteAsync(int id);

    Task<Paciente> GetPacienteAsync(int id);

    Task<IEnumerable<Paciente>> GetPacientesAsync();

    Task<Paciente> InsertPacienteAsync(Paciente paciente);

    Task<Paciente> UpdatePacienteAsync(Paciente paciente);
}