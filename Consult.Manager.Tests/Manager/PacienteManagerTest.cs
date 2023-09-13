using Consult.Core.Shared.ModelViews.Paciente;
using Consult.FakeData.PacienteData;

namespace Consult.Manager.Tests.Manager;

public class PacienteManagerTest
{
    private readonly IPacienteRepository repository;
    private readonly ILogger<PacienteManager> logger;
    private readonly IMapper mapper;
    private readonly IPacienteManager manager;
    private readonly Paciente Paciente;
    private readonly NovoPaciente NovoPaciente;
    private readonly AlteraPaciente AlteraPaciente;
    private readonly PacienteFaker PacienteFaker;
    private readonly NovoPacienteFaker NovoPacienteFaker;
    private readonly AlteraPacienteFaker AlteraPacienteFaker;

    public PacienteManagerTest()
    {
        repository = Substitute.For<IPacienteRepository>();
        logger = Substitute.For<ILogger<PacienteManager>>();
        mapper = new MapperConfiguration(p => p.AddProfile<NovoPacienteMappingProfile>()).CreateMapper();
        manager = new PacienteManager(repository, mapper, logger);
        PacienteFaker = new PacienteFaker();
        NovoPacienteFaker = new NovoPacienteFaker();
        AlteraPacienteFaker = new AlteraPacienteFaker();

        Paciente = PacienteFaker.Generate();
        NovoPaciente = NovoPacienteFaker.Generate();
        AlteraPaciente = AlteraPacienteFaker.Generate();
    }

    [Fact]
    public async Task GetPacientesAsync_Sucesso()
    {
        var listaPacientes = PacienteFaker.Generate(10);
        repository.GetPacientesAsync().Returns(listaPacientes);
        var controle = mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteView>>(listaPacientes);
        var retorno = await manager.GetPacientesAsync();

        await repository.Received().GetPacientesAsync();
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task GetPacientesAsync_Vazio()
    {
        repository.GetPacientesAsync().Returns(new List<Paciente>());

        var retorno = await manager.GetPacientesAsync();

        await repository.Received().GetPacientesAsync();
        retorno.Should().BeEquivalentTo(new List<Paciente>());
    }

    [Fact]
    public async Task GetPacienteAsync_Sucesso()
    {
        repository.GetPacienteAsync(Arg.Any<int>()).Returns(Paciente);
        var controle = mapper.Map<PacienteView>(Paciente);
        var retorno = await manager.GetPacienteAsync(Paciente.Id);

        await repository.Received().GetPacienteAsync(Arg.Any<int>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task GetPacienteAsync_NaoEncontrado()
    {
        repository.GetPacienteAsync(Arg.Any<int>()).Returns(new Paciente());
        var controle = mapper.Map<PacienteView>(new Paciente());
        var retorno = await manager.GetPacienteAsync(1);

        await repository.Received().GetPacienteAsync(Arg.Any<int>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task InsertPacienteAsync_Sucesso()
    {
        repository.InsertPacienteAsync(Arg.Any<Paciente>()).Returns(Paciente);
        var controle = mapper.Map<PacienteView>(Paciente);
        var retorno = await manager.InsertPacienteAsync(NovoPaciente);

        await repository.Received().InsertPacienteAsync(Arg.Any<Paciente>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task UpdatePacienteAsync_Sucesso()
    {
        repository.UpdatePacienteAsync(Arg.Any<Paciente>()).Returns(Paciente);
        var controle = mapper.Map<PacienteView>(Paciente);
        var retorno = await manager.UpdatePacienteAsync(AlteraPaciente);

        await repository.Received().UpdatePacienteAsync(Arg.Any<Paciente>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task UpdatePacienteAsync_NaoEncontrado()
    {
        repository.UpdatePacienteAsync(Arg.Any<Paciente>()).ReturnsNull();

        var retorno = await manager.UpdatePacienteAsync(AlteraPaciente);

        await repository.Received().UpdatePacienteAsync(Arg.Any<Paciente>());
        retorno.Should().BeNull();
    }

    [Fact]
    public async Task DeletePacienteAsync_Sucesso()
    {
        repository.DeletePacienteAsync(Arg.Any<int>()).Returns(Paciente);
        var controle = mapper.Map<PacienteView>(Paciente);
        var retorno = await manager.DeletePacienteAsync(Paciente.Id);

        await repository.Received().DeletePacienteAsync(Arg.Any<int>());
        retorno.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task DeletePacienteAsync_NaoEncontrado()
    {
        repository.DeletePacienteAsync(Arg.Any<int>()).ReturnsNull();

        var retorno = await manager.DeletePacienteAsync(1);

        await repository.Received().DeletePacienteAsync(Arg.Any<int>());
        retorno.Should().BeNull();
    }
}