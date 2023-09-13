using Consult.Core.Shared.ModelViews.Paciente;
using SerilogTimings;

namespace Consult.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly IPacienteManager pacienteManager;
    private readonly ILogger<PacientesController> logger;

    public PacientesController(IPacienteManager pacienteManager, ILogger<PacientesController> logger)
    {
        this.pacienteManager = pacienteManager;
        this.logger = logger;
    }

    /// <summary>
    /// Retorna todos pacientes cadastrados na base.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(PacienteView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var pacientes = await pacienteManager.GetPacientesAsync();
        if (pacientes.Any())
        {
            return Ok(pacientes);
        }
        return NotFound();
    }

    /// <summary>
    /// Retorna um paciente consultado pelo id.
    /// </summary>
    /// <param name="id" example="123">Id do paciente.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PacienteView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(int id)
    {
        var paciente = await pacienteManager.GetPacienteAsync(id);
        if (paciente.Id == 0)
        {
            return NotFound();
        }
        return Ok(paciente);
    }

    /// <summary>
    /// Insere um novo paciente
    /// </summary>
    /// <param name="novoPaciente"></param>
    [HttpPost]
    [ProducesResponseType(typeof(PacienteView), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(NovoPaciente novoPaciente)
    {
        logger.LogInformation("Objeto recebido {@novoPaciente}", novoPaciente);

        PacienteView pacienteInserido;
        using (Operation.Time("Tempo de adição de um novo paciente."))
        {
            logger.LogInformation("Foi requisitada a inserção de um novo paciente.");
            pacienteInserido = await pacienteManager.InsertPacienteAsync(novoPaciente);
        }
        return CreatedAtAction(nameof(Get), new { id = pacienteInserido.Id }, pacienteInserido);
    }

    /// <summary>
    /// Altera um paciente.
    /// </summary>
    /// <param name="alteraPaciente"></param>
    [HttpPut]
    [ProducesResponseType(typeof(PacienteView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(AlteraPaciente alteraPaciente)
    {
        var pacienteAtualizado = await pacienteManager.UpdatePacienteAsync(alteraPaciente);
        if (pacienteAtualizado == null)
        {
            return NotFound();
        }
        return Ok(pacienteAtualizado);
    }

    /// <summary>
    /// Exclui um paciente.
    /// </summary>
    /// <param name="id" example="123">Id do paciente</param>
    /// <remarks>Ao excluir um paciente o mesmo será removido permanentemente da base.</remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        var pacienteExcliudo = await pacienteManager.DeletePacienteAsync(id);
        if (pacienteExcliudo == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}