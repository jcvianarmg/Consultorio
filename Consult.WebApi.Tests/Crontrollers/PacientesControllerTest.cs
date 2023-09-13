using Consult.Core.Shared.ModelViews.Paciente;
using Consult.FakeData.PacienteData;

namespace Consult.WebApi.Tests.Crontrollers;

public class PacientesControllerTest
{
    private readonly IPacienteManager manager;
    private readonly ILogger<PacientesController> logger;
    private readonly PacientesController controller;
    private readonly PacienteView pacienteView;
    private readonly List<PacienteView> listaPacienteView;
    private readonly NovoPaciente novoPaciente;

    public PacientesControllerTest()
    {
        manager = Substitute.For<IPacienteManager>();
        logger = Substitute.For<ILogger<PacientesController>>();
        controller = new PacientesController(manager, logger);

        pacienteView = new PacienteViewFaker().Generate();
        listaPacienteView = new PacienteViewFaker().Generate(10);
        novoPaciente = new NovoPacienteFaker().Generate();
    }

    [Fact]
    public async Task Get_Ok()
    {
        var controle = new List<PacienteView>();
        listaPacienteView.ForEach(p => controle.Add(p.CloneTipado()));
        manager.GetPacientesAsync().Returns(listaPacienteView);

        var resultado = (ObjectResult)await controller.Get();

        await manager.Received().GetPacientesAsync();
        resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        resultado.Value.Should().BeEquivalentTo(controle);
    }

    [Fact]
    public async Task Get_NotFound()
    {
        manager.GetPacientesAsync().Returns(new List<PacienteView>());

        var resultado = (StatusCodeResult)await controller.Get();

        await manager.Received().GetPacientesAsync();
        resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task GetById_Ok()
    {
        manager.GetPacienteAsync(Arg.Any<int>()).Returns(pacienteView.CloneTipado());

        var resultado = (ObjectResult)await controller.Get(pacienteView.Id);

        await manager.Received().GetPacienteAsync(Arg.Any<int>());
        resultado.Value.Should().BeEquivalentTo(pacienteView);
        resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetById_NotFound()
    {
        manager.GetPacienteAsync(Arg.Any<int>()).Returns(new PacienteView());

        var resultado = (StatusCodeResult)await controller.Get(1);

        await manager.Received().GetPacienteAsync(Arg.Any<int>());
        resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Post_Created()
    {
        manager.InsertPacienteAsync(Arg.Any<NovoPaciente>()).Returns(pacienteView.CloneTipado());

        var resultado = (ObjectResult)await controller.Post(novoPaciente);

        await manager.Received().InsertPacienteAsync(Arg.Any<NovoPaciente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
        resultado.Value.Should().BeEquivalentTo(pacienteView);
    }

    [Fact]
    public async Task Put_Ok()
    {
        manager.UpdatePacienteAsync(Arg.Any<AlteraPaciente>()).Returns(pacienteView.CloneTipado());

        var resultado = (ObjectResult)await controller.Put(new AlteraPaciente());

        await manager.Received().UpdatePacienteAsync(Arg.Any<AlteraPaciente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        resultado.Value.Should().BeEquivalentTo(pacienteView);
    }

    [Fact]
    public async Task Put_NotFound()
    {
        manager.UpdatePacienteAsync(Arg.Any<AlteraPaciente>()).ReturnsNull();

        var resultado = (StatusCodeResult)await controller.Put(new AlteraPaciente());

        await manager.Received().UpdatePacienteAsync(Arg.Any<AlteraPaciente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Delete_NoContent()
    {
        manager.UpdatePacienteAsync(Arg.Any<AlteraPaciente>()).Returns(pacienteView);

        var resultado = (StatusCodeResult)await controller.Delete(1);

        await manager.Received().UpdatePacienteAsync(Arg.Any<AlteraPaciente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task NotFound_NotFound()
    {
        manager.UpdatePacienteAsync(Arg.Any<AlteraPaciente>()).ReturnsNull();

        var resultado = (StatusCodeResult)await controller.Delete(1);

        await manager.Received().UpdatePacienteAsync(Arg.Any<AlteraPaciente>());
        resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}