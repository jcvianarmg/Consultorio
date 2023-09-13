namespace Consult.Data.Repository;

public class PacienteRepository : IPacienteRepository
{
    private readonly ConsultContext context;

    public PacienteRepository(ConsultContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Paciente>> GetPacientesAsync()
    {
        return await context.Pacientes
            .Include(p => p.Endereco)
            .Include(p => p.Telefones)
            .AsNoTracking().ToListAsync();
    }

    public async Task<Paciente> GetPacienteAsync(int id)
    {
        return await context.Pacientes
            .Include(p => p.Endereco)
            .Include(p => p.Telefones)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Paciente> InsertPacienteAsync(Paciente paciente)
    {
        await context.Pacientes.AddAsync(paciente);
        await context.SaveChangesAsync();
        return paciente;
    }

    public async Task<Paciente> UpdatePacienteAsync(Paciente paciente)
    {
        var pacienteConsultado = await context.Pacientes
                                             .Include(p => p.Endereco)
                                             .Include(p => p.Telefones)
                                             .FirstOrDefaultAsync(p => p.Id == paciente.Id);
        if (pacienteConsultado == null)
        {
            return null;
        }
        context.Entry(pacienteConsultado).CurrentValues.SetValues(paciente);
        pacienteConsultado.Endereco = paciente.Endereco;
        UpdatePacienteTelefones(paciente, pacienteConsultado);
        await context.SaveChangesAsync();
        return pacienteConsultado;
    }

    private static void UpdatePacienteTelefones(Paciente paciente, Paciente pacienteConsultado)
    {
        pacienteConsultado.Telefones.Clear();
        foreach (var telefone in paciente.Telefones)
        {
            pacienteConsultado.Telefones.Add(telefone);
        }
    }

    public async Task<Paciente> DeletePacienteAsync(int id)
    {
        var pacienteConsultado = await context.Pacientes.FindAsync(id);
        if (pacienteConsultado == null)
        {
            return null;
        }
        var pacienteRemovido = context.Pacientes.Remove(pacienteConsultado);
        await context.SaveChangesAsync();
        return pacienteRemovido.Entity;
    }
}