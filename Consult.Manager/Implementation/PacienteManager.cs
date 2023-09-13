using Consult.Core.Shared.ModelViews.Paciente;

namespace Consult.Manager.Implementation;

public class PacienteManager : IPacienteManager
{
    private readonly IPacienteRepository pacienteRepository;
    private readonly IMapper mapper;
    private readonly ILogger<PacienteManager> logger;

    public PacienteManager(IPacienteRepository pacienteRepository, IMapper mapper, ILogger<PacienteManager> logger)
    {
        this.pacienteRepository = pacienteRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<IEnumerable<PacienteView>> GetPacientesAsync()
    {
        var pacientes = await pacienteRepository.GetPacientesAsync();
        return mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteView>>(pacientes);
    }

    public async Task<PacienteView> GetPacienteAsync(int id)
    {
        var paciente = await pacienteRepository.GetPacienteAsync(id);
        return mapper.Map<PacienteView>(paciente);
    }

    public async Task<PacienteView> DeletePacienteAsync(int id)
    {
        var paciente = await pacienteRepository.DeletePacienteAsync(id);
        return mapper.Map<PacienteView>(paciente);
    }

    public async Task<PacienteView> InsertPacienteAsync(NovoPaciente novoPaciente)
    {
        logger.LogInformation("Chamada de negócio para inserir um paciente.");
        var paciente = mapper.Map<Paciente>(novoPaciente);
        paciente = await pacienteRepository.InsertPacienteAsync(paciente);
        return mapper.Map<PacienteView>(paciente);
    }

    public async Task<PacienteView> UpdatePacienteAsync(AlteraPaciente alteraPaciente)
    {
        var paciente = mapper.Map<Paciente>(alteraPaciente);
        paciente = await pacienteRepository.UpdatePacienteAsync(paciente);
        return mapper.Map<PacienteView>(paciente);
    }
}