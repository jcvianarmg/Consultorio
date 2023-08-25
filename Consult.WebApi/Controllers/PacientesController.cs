using Consult.Core.Domain;
using Consult.Core.Shared.ModelViews;
using Consult.Manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Consult.WebApi.Controllers
{
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
        /// Retorna todos os Pacientes cadastrados na base de Dados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Paciente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await pacienteManager.GetPacientesAsync());
        }

        /// <summary>
        /// Retorna da base um Paciente pelo id 
        /// </summary>
        /// <param name="id" example="12">Id do Paciente</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Paciente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await pacienteManager.GetPacienteAsync(id));
        }

        /// <summary>
        /// Insere um novo Paciente.
        /// </summary>
        /// <param name="novoPaciente"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Paciente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(NovoPaciente novoPaciente)
        {
            logger.LogInformation("Objeto recebido {@novoPaciente}", novoPaciente);
            var pacienteInserido = await pacienteManager.InsertPacienteAsync(novoPaciente);
            return CreatedAtAction(nameof(Get), new { id = pacienteInserido.Id}, pacienteInserido);
        }

        /// <summary>
        /// Altera um Paciente.
        /// </summary>
        /// <param name="alteraPaciente"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Paciente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(AlteraPaciente alteraPaciente)
        {
            var pacienteAtualizado = await pacienteManager.UpdatePacienteAsync(alteraPaciente);
            if (pacienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(pacienteAtualizado);
        }

        /// <summary>
        /// Exclui um Paciente.
        /// </summary>
        /// <param name="id" example="12">Id do Paciente</param>
        /// <remarks>Ao remover um Paciente ele será excluido permanentemente da base de Dados.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            await pacienteManager.DeletePacienteAsync(id);
            return NoContent();
        }
    }
}
