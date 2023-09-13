namespace Consult.Data.Repository;

public class EspecialidadeRepository : IEspecialidadeRepository
{
    private readonly ConsultContext context;

    public EspecialidadeRepository(ConsultContext context)
    {
        this.context = context;
    }

    public async Task<bool> ExisteAsync(int id)
    {
        return await context.Especialidades.AnyAsync(p => p.Id == id);
    }
}