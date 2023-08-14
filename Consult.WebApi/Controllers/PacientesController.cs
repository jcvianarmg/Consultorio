using Consult.Core.Shared.ModelViews;
using Consult.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public PacientesController(IPacienteManager pacienteManager)
        {
            this.pacienteManager = pacienteManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await pacienteManager.GetPacientesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await pacienteManager.GetPacienteAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(NovoPaciente novoPaciente)
        {
            var pacienteInserido = await pacienteManager.InsertPacienteAsync(novoPaciente);
            return CreatedAtAction(nameof(Get), new { id = pacienteInserido.Id}, pacienteInserido);
        }

        [HttpPut]
        public async Task<ActionResult> Put(AlteraPaciente alteraPaciente)
        {
            var pacienteAtualizado = await pacienteManager.UpdatePacienteAsync(alteraPaciente);
            if (pacienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(pacienteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await pacienteManager.DeletePacienteAsync(id);
            return NoContent();
        }
    }
}
