using Consult.FakeData.PacienteData;
using Consult.FakeData.TelefoneData;

namespace Consult.Respository.Tests.Repository;

public class PacienteRepositoryTest : IDisposable
{
    private readonly IPacienteRepository repository;
    private readonly ConsultContext context;
    private readonly Paciente paciente;
    private readonly PacienteFaker pacienteFaker;

    public PacienteRepositoryTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ConsultContext>();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        context = new ConsultContext(optionsBuilder.Options);
        repository = new PacienteRepository(context);

        pacienteFaker = new PacienteFaker();
        paciente = pacienteFaker.Generate();
    }

    private async Task<List<Paciente>> InsereRegistros()
    {
        var pacientes = pacienteFaker.Generate(100);
        foreach (var cli in pacientes)
        {
            cli.Id = 0;
            await context.Pacientes.AddAsync(cli);
        }
        await context.SaveChangesAsync();
        return pacientes;
    }

    [Fact]
    public async Task GetPacientesAsync_ComRetorno()
    {
        var registros = await InsereRegistros();
        var retorno = await repository.GetPacientesAsync();

        retorno.Should().HaveCount(registros.Count);
        retorno.First().Endereco.Should().NotBeNull();
        retorno.First().Telefones.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPacientesAsync_Vazio()
    {
        var retorno = await repository.GetPacientesAsync();
        retorno.Should().HaveCount(0);
    }

    [Fact]
    public async Task GetPacienteAsync_Encontrado()
    {
        var registros = await InsereRegistros();
        var retorno = await repository.GetPacienteAsync(registros.First().Id);
        retorno.Should().BeEquivalentTo(registros.First());
    }

    [Fact]
    public async Task GetPacienteAsync_NaoEncontrado()
    {
        var retorno = await repository.GetPacienteAsync(1);
        retorno.Should().BeNull();
    }

    [Fact]
    public async Task InsertPacienteAsync_Sucesso()
    {
        var retorno = await repository.InsertPacienteAsync(paciente);
        retorno.Should().BeEquivalentTo(paciente);
    }

    [Fact]
    public async Task UpdatePacienteAsync_Sucesso()
    {
        var registros = await InsereRegistros();
        var pacienteAlterado = pacienteFaker.Generate();
        pacienteAlterado.Id = registros.First().Id;
        var retorno = await repository.UpdatePacienteAsync(pacienteAlterado);
        retorno.Should().BeEquivalentTo(pacienteAlterado);
    }

    [Fact]
    public async Task UpdatePacienteAsync_AdicionaTelefone()
    {
        var registros = await InsereRegistros();
        var pacienteAlterado = registros.First();
        pacienteAlterado.Telefones.Add(new TelefoneFaker(pacienteAlterado.Id).Generate());
        var retorno = await repository.UpdatePacienteAsync(pacienteAlterado);
        retorno.Should().BeEquivalentTo(pacienteAlterado);
    }

    [Fact]
    public async Task UpdatePacienteAsync_RemoveTelefone()
    {
        var registros = await InsereRegistros();
        var pacienteAlterado = registros.First();
        pacienteAlterado.Telefones.Remove(pacienteAlterado.Telefones.First());
        var retorno = await repository.UpdatePacienteAsync(pacienteAlterado);
        retorno.Should().BeEquivalentTo(pacienteAlterado);
    }

    [Fact]
    public async Task UpdatePacienteAsync_RemoveTodosTelefones()
    {
        var registros = await InsereRegistros();
        var pacienteAlterado = registros.First();
        pacienteAlterado.Telefones.Clear();
        var retorno = await repository.UpdatePacienteAsync(pacienteAlterado);
        retorno.Should().BeEquivalentTo(pacienteAlterado);
    }

    [Fact]
    public async Task UpdatePacienteAsync_NaoEncontrado()
    {
        var retorno = await repository.UpdatePacienteAsync(paciente);
        retorno.Should().BeNull();
    }

    [Fact]
    public async Task DeletePacienteAsync_Sucesso()
    {
        var registros = await InsereRegistros();
        var retorno = await repository.DeletePacienteAsync(registros.First().Id);
        retorno.Should().BeEquivalentTo(registros.First());
    }

    [Fact]
    public async Task DeletePacienteAsync_NaoEncontrado()
    {
        var retorno = await repository.DeletePacienteAsync(1);
        retorno.Should().BeNull();
    }

    public void Dispose()
    {
        context.Database.EnsureDeleted();
    }
}